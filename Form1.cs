using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Cloo;
using OpenTK.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace SimpleSTL
{
    public partial class Form1 : Form {
        private Shader basic, shadeShader, aoTestShader, aoComputeShader, squareComputeShader, contrastCompute;
        private Mesh MainMesh_ = new Mesh();
        private IFormatProvider ifp = new CultureInfo("en-US");

        public Form1()
        {
            InitializeComponent();
        }

        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, -1, 1, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        private void Form1_Resize(object sender, EventArgs e) {
            if (logVisible) {
                textBox1.Width = glControl1.Width/2;
                textBox1.Left = glControl1.Left + textBox1.Width;
                if (!textBox1.Visible) {
                    textBox1.Show();
                }
            }
            else {
                if (textBox1.Visible) {
                    textBox1.Hide();
                }
            }
            SetupViewport();
           glControl1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
        }

        private int lastW;
        private int FarOffset = 10;
        private Matrix4 rotator = Matrix4.Identity;
        void glControl1_MouseWheel(object sender, MouseEventArgs e) {
            if (lastW > 0) {
                FarOffset -= (int)farestPoint / 4 + 1;
            }
            if (lastW < 0)
            {
                FarOffset += (int)farestPoint / 4 + 1;
                if (Keyboard.GetState()[Key.ShiftLeft]) {
                    FarOffset += 9;
                }
            }
            
            lastW = e.Delta;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
            var fi = new FileInfo(openFileDialog1.FileName);
            if (fi.Extension.ToLower() == ".obj") {
                MainMesh_.loadOBJ(fi.FullName);
                
                Text = "SimpleSTL - " + fi.Name;
                
            }
            if (fi.Extension.ToLower() == ".stl")
            {
                MainMesh_.loadSTL(fi.FullName);
                Text = "SimpleSTL - " + fi.Name;
                
            }
            MainMesh_.RecalcNormals();
            AutoZoom();
            MainMesh_.ResetAO();
        }

        private void AutoZoom() {
            farestPoint = MainMesh_.FarestPoint();
            FarOffset = (int) (farestPoint*10.0f + 1);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e) {
            MainMesh_.UnIndex();
            MainMesh_.RecalcNormals();
            MainMesh_.saveSTL(saveFileDialog1.FileName);
        }

        private float farestPoint;
        private void UpdateTooltip() {
            toolStripStatusLabel1.Text = string.Format("Model: v = {0} i = {1} CameraOffset: {2} FarestPoint: {3}", MainMesh_.Verteces.Count, MainMesh_.Indeces.Count, FarOffset, farestPoint);
        }

        int BUFFER_TYPE_VERTEX = 0;
        int BUFFER_TYPE_TEXTCOORD = 3;
        int BUFFER_TYPE_NORMALE = 1;
        int BUFFER_TYPE_AO = 2;
        int BUFFER_TYPE_SQUARE = 4;
        private Matrix4 viewModel, mult;
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTooltip();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(204 / 255.0F, 1.0f, 1.0f, 1.0f);

            Matrix4 model = rotator;
            viewModel = model * Matrix4.LookAt(FarOffset / 10.0f, FarOffset / 10.0f, FarOffset / 10.0f, 0, 0, 0, 0, 1, 0);
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)(Math.PI / 2.0), glControl1.Width/(float)glControl1.Height, 0.01f, 1000.0f);
            mult = viewModel * projection;

            basic.Use();

            //model *= Matrix4.CreateTranslation(FarOffset/10.0f, FarOffset/10.0f, FarOffset/10.0f);

            GL.UniformMatrix4(basic.shaderMVLocation_, false, ref viewModel);
            GL.UniformMatrix4(basic.shaderPLocation_, false, ref projection);
            if (wire)
            {
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GL.CullFace(CullFaceMode.FrontAndBack);
            }
            else
            {
                GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
                GL.CullFace(CullFaceMode.Back);
            }

            GL.Enable(EnableCap.DepthTest);
            

            MainMesh_.Bind(basic);
            if (MainMesh_.Indeces.Count == 0)
            {
            //    return;
            }

            basic.Use();
            MainMesh_.Render();
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.Disable(EnableCap.DepthTest);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref mult);
            GL.UseProgram(0);
            GL.Begin(PrimitiveType.Lines);
            GL.Color4(Color.Blue);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, FarOffset / 20.0f);
            GL.Color4(Color.GreenYellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, FarOffset / 20.0f, 0);
            GL.Color4(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(FarOffset / 20.0f, 0, 0);
            GL.End();

            GL.Flush();
            glControl1.SwapBuffers();

            if ((int)(OcclusionMap.AorResultTotal * 0.99f) < OcclusionMap.AorResult) {
                toolStripProgressBar1.Value = 0;
            }
            else {
                toolStripProgressBar1.Maximum = OcclusionMap.AorResultTotal;
                toolStripProgressBar1.Value = OcclusionMap.AorResult;
            }

            if (Log.updated && textBox1.Visible) {
                Log.updated = false;
                textBox1.Text = Log.Get();
            }
        }

        private bool down;
        private float rotY, rotZ;
        private Point preloc;
        private void glControl1_MouseDown(object sender, MouseEventArgs e) {
            down = true;
        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e) {
            down = false;
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (down) {
                var right_v = rotator.Row0.Xyz;
                var up_v = rotator.Row1.Xyz;
                var back_v = rotator.Row2.Xyz;

                rotY += (e.Location.X - preloc.X) / (float)glControl1.Width * 5;
                rotZ -= (e.Location.Y - preloc.Y) / (float)glControl1.Height * 5;

                var v = new Vector3(0.5f, 0, -0.5f);
                v.Normalize();
                rotator = rotator * Matrix4.CreateFromAxisAngle(new Vector3(0, 1, 0), (e.Location.X - preloc.X) / (float)glControl1.Width * 5) * Matrix4.CreateFromAxisAngle(v, (e.Location.Y - preloc.Y) / (float)glControl1.Height * 5);
            }
            preloc = e.Location;
        }

        private void генерацияToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void икосаэдрToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_ = Icosaohedron.GetMesh();
            MainMesh_.RecalcNormals();
            AutoZoom();
            MainMesh_.ResetAO();
        }

        private void кубToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMesh_ = Cube.GetMesh();
            MainMesh_.RecalcNormals();
            AutoZoom();
            MainMesh_.ResetAO();
        }

        private void видToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private bool wire;
        private void режимОтображенияПолигоновToolStripMenuItem_Click(object sender, EventArgs e) {
            wire = !wire;
        }

        private void тесселяцияToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_ = MeshTools.Tesselate(1, MainMesh_);
            MainMesh_.RecalcNormals();
            MainMesh_.ResetAO();
        }

        private void нормализацияToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_ = MeshTools.Normalize(MainMesh_);
            MainMesh_.RecalcNormals();
            AutoZoom();
            MainMesh_.ResetAO();
        }

        private void пересчитатьНормалиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMesh_.RecalcNormals();
        }

        private void перевернутьНормалиToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_.FlipNormals();
        }

        private void удратьИндексациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMesh_.UnIndex();
            MainMesh_.RecalcNormals();
        }

        private IAsyncResult arRoberts;
        private Func<Mesh, Mesh> Rdelegate;
        private void удалениеНевидимыхГранейToolStripMenuItem_Click(object sender, EventArgs e) {
            if (arRoberts == null || arRoberts.IsCompleted) {
                Rdelegate = MeshTools.RobertsSimplify;
                arRoberts = Rdelegate.BeginInvoke(MainMesh_, null, null);
            }
            
        }

        private void сеткаToolStripMenuItem_Click(object sender, EventArgs e) {
            wire = true;
        }

        private void заливкаToolStripMenuItem_Click(object sender, EventArgs e) {
            wire = false;
        }

        private void смешанныйToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_.AoTest = false;
            basic = shadeShader;
        }

        private IAsyncResult aor;
        private void пересчетAOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aor == null || aor.IsCompleted) {
                Action<Mesh> aorD = OcclusionMap.AmbientOcclusionRecalc;
                aor = aorD.BeginInvoke(MainMesh_, null, null);
            }
        }

        private void сбросAOToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_.ResetAO();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void тестAOToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_.AoTest = true;
            basic = aoTestShader;
        }

        Mesh backup = new Mesh();
        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            backup = new Mesh(MainMesh_);
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMesh_ = new Mesh(backup);
        }

        private void удалениеВнутреннихПолигоновToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_ = MeshTools.RemoveInternal(MainMesh_);
        }

        private bool logVisible = false;
        private int glTotalW;
        private void логРендераToolStripMenuItem_Click(object sender, EventArgs e) {
            logVisible = !logVisible;
            Form1_Resize(null,null);
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            shadeShader = new Shader();
            shadeShader.loadShaderFromSource(ShaderType.FragmentShader, "basic.glsl");
            shadeShader.loadShaderFromSource(ShaderType.VertexShader, "basic.glsl");
            shadeShader.Link();
            shadeShader.Use();
            shadeShader.LocateStd();

            aoTestShader = new Shader();
            aoTestShader.loadShaderFromSource(ShaderType.FragmentShader, "AoTest.glsl");
            aoTestShader.loadShaderFromSource(ShaderType.VertexShader, "AoTest.glsl");
            aoTestShader.Link();
            aoTestShader.Use();
            aoTestShader.LocateStd();

            aoComputeShader = new Shader();
            aoComputeShader.loadShaderFromSource(ShaderType.ComputeShader, "AOCompute.glsl");
            aoComputeShader.Link();

            squareComputeShader = new Shader();
            squareComputeShader.loadShaderFromSource(ShaderType.ComputeShader, "SquareCompute.glsl");
            squareComputeShader.Link();

            contrastCompute = new Shader();
            contrastCompute.loadShaderFromSource(ShaderType.ComputeShader, "contrastCompute.glsl");
            contrastCompute.Link();

            basic = shadeShader;

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.ActiveTexture(TextureUnit.Texture1);
            GL.BindTexture(TextureTarget.Texture2D, 1);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.NormalArray);

            glControl1.SwapBuffers();
            glControl1.MouseWheel += glControl1_MouseWheel;
            glControl1.MouseDown += glControl1_MouseDown;
            glControl1.MouseMove += glControl1_MouseMove;
            glControl1.MouseUp += glControl1_MouseUp;
            timer1.Enabled = true;
        }

        private void умнаяТесселяцияToolStripMenuItem_Click(object sender, EventArgs e) {
            MainMesh_ = MeshTools.SmartTesselate(MainMesh_);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void пересчетАОНаGPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMesh_.UnIndex();
            MainMesh_.Bind(basic);

            GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, 0, MainMesh_.m_vbo[0]);

            squareComputeShader.Use();
            GL.DispatchCompute(MainMesh_.Verteces.Count / 3, 1, 1);

            aoComputeShader.Use();
            GL.DispatchCompute(MainMesh_.Verteces.Count / 3, MainMesh_.Verteces.Count / 3, 1);

            contrastCompute.Use();
            GL.DispatchCompute(MainMesh_.Verteces.Count / 3, 1, 1);

            GL.BindBufferBase(BufferRangeTarget.ShaderStorageBuffer, 0, 0);
            var eSize = VertexPositionNormalTexture.Size;
            var a = new float[MainMesh_.Verteces.Count * (eSize / sizeof(float))];
            GL.BindBuffer(BufferTarget.ShaderStorageBuffer, MainMesh_.m_vbo[0]);
            GL.GetBufferSubData(BufferTarget.ShaderStorageBuffer, IntPtr.Zero, (IntPtr)(MainMesh_.Verteces.Count * eSize), a);

            for (int i = 0; i < MainMesh_.Verteces.Count; i++) {
                var tt = MainMesh_.Verteces[i];
                tt.Square = a[i*12 + 9];
                tt.Ao = a[i * 12 + 8];
                MainMesh_.Verteces[i] = tt;
            }
        }

        private void пересчетAOOpenCLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMesh_.UnIndex();

            ComputeContextPropertyList Properties = new ComputeContextPropertyList(ComputePlatform.Platforms[1]);
            ComputeContext Context = new ComputeContext(ComputeDeviceTypes.All, Properties, null, IntPtr.Zero);

            string vecSum = @"
                            __kernel void floatSquareDivPi(__global float * vx, __global float * vy, __global float * vz,
                                       __global float * nx, __global float * ny, __global float * nz,
                                       __global float * a, __global float * s)
                            { 
                                int i = get_global_id(0)*3;
	                            float3 vec1 = (float3)(vx[i], vy[i], vz[i]); 
                                float3 vec2 = (float3)(vx[i+1], vy[i+1], vz[i+1]); 
                                float3 vec3 = (float3)(vx[i+2], vy[i+2], vz[i+2]); 

                                float A = distance(vec1, vec2);
                                float B = distance(vec2, vec3);
                                float C = distance(vec1, vec3); // try fast ones

                                float S = (A + B + C) / 2.0f;
                                float sq = sqrt(S * (S - A) * (S - B) * (S - C)) / 3.1415926535897932384626433832795f;
                                s[i] = s[i+1] = s[i+2] = sq;
                            }
                            ";
            List<ComputeDevice> Devs = new List<ComputeDevice>();
            Devs.Add(ComputePlatform.Platforms[1].Devices[0]);
            ComputeProgram prog = null;
            try {

                prog = new ComputeProgram(Context, vecSum);
                prog.Build(Devs, "", null, IntPtr.Zero);
            }

            catch(Exception ex) {

                throw ex;
            }

            ComputeKernel kernelSquare = prog.CreateKernel("floatSquareDivPi");

            float[] v1 = new float[MainMesh_.Verteces.Count], v2 = new float[MainMesh_.Verteces.Count];
            float[] v3 = new float[MainMesh_.Verteces.Count], v4 = new float[MainMesh_.Verteces.Count];
            float[] v5 = new float[MainMesh_.Verteces.Count], v6 = new float[MainMesh_.Verteces.Count];
            float[] v7 = new float[MainMesh_.Verteces.Count], v8 = new float[MainMesh_.Verteces.Count];
            for (int i = 0; i < MainMesh_.Verteces.Count; i++)
            {
                v1[i] = MainMesh_.Verteces[i].Position.X;
                v2[i] = MainMesh_.Verteces[i].Position.Y;
                v3[i] = MainMesh_.Verteces[i].Position.Z;
                v4[i] = MainMesh_.Verteces[i].Normal.X;
                v5[i] = MainMesh_.Verteces[i].Normal.Y;
                v6[i] = MainMesh_.Verteces[i].Normal.Z;
                v7[i] = 1.0f;
                v8[i] = 0.0f;
            }

            var bufV1 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v1);
            var bufV2 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v2);
            var bufV3 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v3);
            var bufV4 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v4);
            var bufV5 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v5);
            var bufV6 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v6);
            var bufV7 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v7);
            var bufV8 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v8);

            kernelSquare.SetMemoryArgument(0, bufV1);
            kernelSquare.SetMemoryArgument(1, bufV2);
            kernelSquare.SetMemoryArgument(2, bufV3);
            kernelSquare.SetMemoryArgument(3, bufV4);
            kernelSquare.SetMemoryArgument(4, bufV5);
            kernelSquare.SetMemoryArgument(5, bufV6);
            kernelSquare.SetMemoryArgument(6, bufV7);
            kernelSquare.SetMemoryArgument(7, bufV8);
            ComputeCommandQueue Queue = new ComputeCommandQueue(Context, Cloo.ComputePlatform.Platforms[1].Devices[0], Cloo.ComputeCommandQueueFlags.None);
            Queue.Execute(kernelSquare, null, new long[] { v1.Length/3 }, null, null);
            float[] arr8Back = new float[MainMesh_.Verteces.Count];
            float[] arr7Back = new float[MainMesh_.Verteces.Count];
            GCHandle arr8Handle = GCHandle.Alloc(arr8Back, GCHandleType.Pinned);
            GCHandle arr7Handle = GCHandle.Alloc(arr7Back, GCHandleType.Pinned);
            Queue.Read(bufV8, true, 0, MainMesh_.Verteces.Count, arr8Handle.AddrOfPinnedObject(), null);
            Queue.Read(bufV7, true, 0, MainMesh_.Verteces.Count, arr7Handle.AddrOfPinnedObject(), null);

            for (int i = 0; i < MainMesh_.Verteces.Count; i++)
            {
                var tt = MainMesh_.Verteces[i];
                tt.Square = arr8Back[i];
                tt.Ao = arr7Back[i];
                MainMesh_.Verteces[i] = tt;
            }

            
            if (ar == null || ar.IsCompleted) {
                Action act = ComputeNext;
               ar = act.BeginInvoke(null, null);
            }
        }
        IAsyncResult ar;

        private void ComputeNext() {
            ComputeContextPropertyList Properties = new ComputeContextPropertyList(ComputePlatform.Platforms[1]);
            ComputeContext Context = new ComputeContext(ComputeDeviceTypes.All, Properties, null, IntPtr.Zero);

            string vecSum = @"
                            float ElementShadow(float3 v, float rSquared, float3 receiverNormal, float3 emitterNormal, float emitterArea) {
                                return (1.0f - 1.0f / sqrt(emitterArea/rSquared + 1.0f)) *
                                clamp(dot(emitterNormal, v), 0.0f, 1.0f) *
                                clamp(4.0f * dot(receiverNormal, v), 0.0f, 1.0f);
                            }
                            __kernel void floatAO(__global float * vx, __global float * vy, __global float * vz,
                                       __global float * nx, __global float * ny, __global float * nz,
                                       __global float * a, __global float * s, int from)
                            { 
                                int i = from + get_global_id(0)*3;
                                float res = 0.0f;
                                for(int j = 0; j<140000;j+=3){
                                    float3 v = (float3)(vx[j], vy[j], vz[j]) - (float3)(vx[i], vy[i], vz[i]);
                                    float d2 = dot(v, v) + 1e-16;
                                    
                                    v *= 1.0f / sqrt(d2);
	                                float value = ElementShadow(v, d2, (float3)(nx[i], ny[i], nz[i]), (float3)(nx[j], ny[j], nz[j]), s[j]);
                                    if(value == NAN) {
                                        value = 1;
                                    }
                                    res += value;
                                }
                            
                            a[i] = a[i+1] = a[i+2] = 1.0f - res;
}
                               
          ";
            List<ComputeDevice> Devs = new List<ComputeDevice>();
            Devs.Add(ComputePlatform.Platforms[1].Devices[0]);
            ComputeProgram prog = null;
            try
            {

                prog = new ComputeProgram(Context, vecSum);
                prog.Build(Devs, "", null, IntPtr.Zero);
            }

            catch (Exception ex)
            {

                throw ex;
            }

            ComputeKernel kernelSquare = prog.CreateKernel("floatAO");

            float[] v1 = new float[MainMesh_.Verteces.Count], v2 = new float[MainMesh_.Verteces.Count];
            float[] v3 = new float[MainMesh_.Verteces.Count], v4 = new float[MainMesh_.Verteces.Count];
            float[] v5 = new float[MainMesh_.Verteces.Count], v6 = new float[MainMesh_.Verteces.Count];
            float[] v7 = new float[MainMesh_.Verteces.Count], v8 = new float[MainMesh_.Verteces.Count];
            for (int i = 0; i < MainMesh_.Verteces.Count; i++)
            {
                v1[i] = MainMesh_.Verteces[i].Position.X;
                v2[i] = MainMesh_.Verteces[i].Position.Y;
                v3[i] = MainMesh_.Verteces[i].Position.Z;
                v4[i] = MainMesh_.Verteces[i].Normal.X;
                v5[i] = MainMesh_.Verteces[i].Normal.Y;
                v6[i] = MainMesh_.Verteces[i].Normal.Z;
                v7[i] = 1.0f;
                v8[i] = MainMesh_.Verteces[i].Square;
            }

            var bufV1 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v1);
            var bufV2 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v2);
            var bufV3 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v3);
            var bufV4 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v4);
            var bufV5 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v5);
            var bufV6 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v6);
            var bufV7 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v7);
            var bufV8 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v8);

            kernelSquare.SetMemoryArgument(0, bufV1);
            kernelSquare.SetMemoryArgument(1, bufV2);
            kernelSquare.SetMemoryArgument(2, bufV3);
            kernelSquare.SetMemoryArgument(3, bufV4);
            kernelSquare.SetMemoryArgument(4, bufV5);
            kernelSquare.SetMemoryArgument(5, bufV6);
            kernelSquare.SetMemoryArgument(6, bufV7);
            kernelSquare.SetMemoryArgument(7, bufV8);

           // var parts = ((long)v1.Length)*(v1.Length);
           // var diver = parts/10000000000.0f;
            var diverI =1;

            for (int j = 0; j < diverI; j++) {
//                 var min = j*10000000000;
//                 if (min >= MainMesh_.Verteces.Count) {
//                     min = MainMesh_.Verteces.Count;
//                 }
//                 var max = (j+1) * 10000000000;
//                 if (max >= MainMesh_.Verteces.Count)
//                 {
//                     max = MainMesh_.Verteces.Count;
//                 }

                kernelSquare.SetValueArgument(8, 0);
                ComputeCommandQueue Queue = new ComputeCommandQueue(Context, Cloo.ComputePlatform.Platforms[1].Devices[0], Cloo.ComputeCommandQueueFlags.None);
                Queue.Execute(kernelSquare, null, new long[] { MainMesh_.Verteces.Count / 3 }, null, null);
                float[] arr8Back = new float[MainMesh_.Verteces.Count];
                float[] arr7Back = new float[MainMesh_.Verteces.Count];
                GCHandle arr8Handle = GCHandle.Alloc(arr8Back, GCHandleType.Pinned);
                GCHandle arr7Handle = GCHandle.Alloc(arr7Back, GCHandleType.Pinned);
                Queue.Read(bufV8, true, 0, MainMesh_.Verteces.Count, arr8Handle.AddrOfPinnedObject(), null);
                Queue.Read(bufV7, true, 0, MainMesh_.Verteces.Count, arr7Handle.AddrOfPinnedObject(), null);

                for (int i = 0; i < MainMesh_.Verteces.Count; i++)
                {
                    var tt = MainMesh_.Verteces[i];
                    tt.Square = arr8Back[i];
                    tt.Ao = arr7Back[i];
                    MainMesh_.Verteces[i] = tt;
                }
            }


        }

        /*
         * 
         *             ComputeContextPropertyList Properties = new ComputeContextPropertyList(ComputePlatform.Platforms[1]);
            ComputeContext Context = new ComputeContext(ComputeDeviceTypes.All, Properties, null, IntPtr.Zero);

            //Текст програмы, исполняющейся на устройстве (GPU или CPU). Именно эта программа будет выполнять паралельные
            //вычисления и будет складывать вектора. Программа написанна на языке, основанном на C99 специально под OpenCL.
            string vecSum = @"
        __kernel voiprogSquare floatVectorSum(__global float * v1,
        __global float * v2)
        {
         int i = get_global_id(0);
         v1[i] = v1[i] + v2[i];
        }

        ";
            //Список устройств, для которых мы будем компилироprogSquareанную в vecSum программу
            List<ComputeDevice> Devs = new List<ComputeDevice>();
            Devs.Add(ComputePlatform.Platforms[1].Devices[0]);
           // Devs.Add(ComputePlatform.Platforms[1].Devices[1]);
           // Devs.Add(ComputePlatform.Platforms[1].Devices[2]);
            //Компиляция программы из vecSum
            ComputeProgram prog = null;
            try
            {

                prog = new ComputeProgram(Context, vecSum); prog.Build(Devs, "", null, IntPtr.Zero);
            }

            catch

            { }

            //Инициализация новой программы
            ComputeKernel kernelVecSum = prog.CreateKernel("floatVectorSum");

            //Инициализация и присвоение векторов, которые мы будем складывать.
            float[] v1 = new float[100], v2 = new float[100];
            for (int i = 0; i < v1.Length; i++)
            {
                v1[i] = i;
                v2[i] = 2 * i;
            }
            //Загрузка данных в указатели для дальнейшего использования.
            ComputeBuffer<float> bufV1 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v1);
            ComputeBuffer<float> bufV2 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v2);
            //Объявляем какие данные будут использоваться в программе vecSum
            kernelVecSum.SetMemoryArgument(0, bufV1);
            kernelVecSum.SetMemoryArgument(1, bufV2);
            //Создание програмной очереди. Не забудте указать устройство, на котором будет исполняться программа!
            ComputeCommandQueue Queue = new ComputeCommandQueue(Context, Cloo.ComputePlatform.Platforms[1].Devices[0], Cloo.ComputeCommandQueueFlags.None);
            //Старт. Execute запускает программу-ядро vecSum указанное колличество раз (v1.Length)
            Queue.Execute(kernelVecSum, null, new long[] { v1.Length }, null, null);
            //Считывание данных из памяти устройства.
            float[] arrC = new float[100];
            GCHandle arrCHandle = GCHandle.Alloc(arrC, GCHandleType.Pinned);
            Queue.Read<float>(bufV1, true, 0, 100, arrCHandle.AddrOfPinnedObject(), null);
         * 
         */
    }
}
