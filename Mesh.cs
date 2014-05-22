using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace SimpleSTL {
    public class Mesh
    {
        public List<VertexPositionNormalTexture> Verteces;
        public List<uint> Indeces;
        //JargShader* Shader;
        //Texture* Texture;
        Matrix4 World;
        int m_vao;
        int[] m_vbo;
        private IFormatProvider ifp = new CultureInfo("en-US");

        public Mesh() {
            Verteces = new List<VertexPositionNormalTexture>();
            Indeces = new List<uint>();
        }

        ~Mesh() {
           
        }

        int BUFFER_TYPE_VERTEX = 0;
        int BUFFER_TYPE_TEXTCOORD = 2;
        int BUFFER_TYPE_NORMALE = 1;

        public Mesh(Mesh mesh) {
            Verteces = mesh.Verteces;
            Indeces = mesh.Indeces;
            World = mesh.World;
        }

        public void Bind()
        {
            if (Indeces.Count == 0) {
                return;
            }
            if (m_vbo != null)
            {
                GL.BindVertexArray(0);
                GL.DisableVertexAttribArray(BUFFER_TYPE_VERTEX);
                GL.DisableVertexAttribArray(BUFFER_TYPE_TEXTCOORD);
                GL.DisableVertexAttribArray(BUFFER_TYPE_NORMALE);

                GL.DeleteBuffers(2, m_vbo);
                GL.DeleteVertexArrays(1, ref m_vao);
                m_vao = 0;
            }

            if (m_vao == 0)
            {
                GL.GenVertexArrays(1, out m_vao);
                GL.BindVertexArray(m_vao);
                m_vbo = new int[2];
                GL.GenBuffers(2, m_vbo);
            }
            else
            {
                GL.BindVertexArray(m_vao);
            }

            int stride = VertexPositionNormalTexture.Size;
            int offset = 0;
            GL.BindBuffer(BufferTarget.ArrayBuffer, m_vbo[0]);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(VertexPositionNormalTexture.Size * Verteces.Count), Verteces.ToArray(), BufferUsageHint.StreamDraw);
            GL.EnableVertexAttribArray(BUFFER_TYPE_VERTEX);
            GL.BindAttribLocation(4, 1, "vertex_position");  
            GL.VertexAttribPointer(BUFFER_TYPE_VERTEX, 3, VertexAttribPointerType.Float, false, stride, (offset)); offset += Vector3.SizeInBytes;
            GL.EnableVertexAttribArray(BUFFER_TYPE_TEXTCOORD);
            GL.VertexAttribPointer(BUFFER_TYPE_TEXTCOORD, 2, VertexAttribPointerType.Float, false, stride, (offset)); offset += Vector2.SizeInBytes;
            GL.EnableVertexAttribArray(BUFFER_TYPE_NORMALE);
            GL.BindAttribLocation(4, 1, "vertex_normal");  
            GL.VertexAttribPointer(BUFFER_TYPE_NORMALE, 3, VertexAttribPointerType.Float, false, stride, (offset));
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, m_vbo[1]);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(sizeof(int) * Indeces.Count), Indeces.ToArray(), BufferUsageHint.StreamDraw);
        }

        public void Render()
        {
            if (Verteces.Count == 0)
            {
                return;
            }
            GL.BindVertexArray(m_vao);
            GL.DrawElements(PrimitiveType.Triangles, Indeces.Count, DrawElementsType.UnsignedInt, IntPtr.Zero); 
            //for (int i = 0; i < Verteces.Count -2; i+= 3) {
            //    GL.Begin(PrimitiveType.Triangles);
            //    GL.Color4(new Color4(Verteces[i].Normal.X, Verteces[i].Normal.X, Verteces[i].Normal.X, 1));
            //    GL.Normal3(Verteces[i].Normal);
            //    GL.Vertex3(Verteces[i].Position);
            //    GL.Vertex3(Verteces[i+1].Position);
            //    GL.Vertex3(Verteces[i+2].Position);
            //     GL.End();
            //}
           
        }

        public void Combine(Mesh com)
        {
            int lastIndex = Verteces.Count;

            int t = Verteces.Count;
            Verteces.Capacity = (Verteces.Count + com.Verteces.Count);
            for (int i = 0; i < com.Verteces.Count; i++)
            {
                Verteces[t] = com.Verteces[i];
                t++;
            }

            t = Indeces.Count;
            Indeces.Capacity = (Indeces.Count + com.Indeces.Count);
            for (int i = 0; i < com.Indeces.Count; i++)
            {
                Indeces[t] = (uint) (com.Indeces[i] + lastIndex);
                t++;
            }
        }

        public bool loadOBJ(string path)
        {
            List<uint> vertexIndices = new List<uint>(), uvIndices = new List<uint>(), normalIndices = new List<uint>();
            var temp_vertices = new List<Vector3>();
            var temp_uvs = new List<Vector2>();
            var temp_normals = new List<Vector3>();

            StreamReader file = File.OpenText(path);

            while (true)
            {
                string lineHeader = file.ReadLine();
                if (file.EndOfStream || lineHeader == null)
                    break;

                if (lineHeader.IndexOf("v ", StringComparison.Ordinal) == 0)
                {
                    Vector3 vertex;
                    var parts = lineHeader.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    vertex.X = Convert.ToSingle(parts[1], ifp);
                    vertex.Y = Convert.ToSingle(parts[2], ifp);
                    vertex.Z = Convert.ToSingle(parts[3], ifp);
                    temp_vertices.Add(vertex);
                }
                else if (lineHeader.IndexOf("vt ", StringComparison.Ordinal) == 0)
                {
                    Vector2 uv;
                    var parts = lineHeader.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    uv.X = Convert.ToSingle(parts[1], ifp);
                    uv.Y = Convert.ToSingle(parts[2], ifp);
                    temp_uvs.Add(uv);
                }
                else if (lineHeader.IndexOf("vn ", StringComparison.Ordinal) == 0)
                {
                    Vector3 normal;
                    var parts = lineHeader.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    normal.X = Convert.ToSingle(parts[1], ifp);
                    normal.Y = Convert.ToSingle(parts[2], ifp);
                    normal.Z = Convert.ToSingle(parts[3], ifp);
                    temp_normals.Add(normal);
                }
                else if (lineHeader.IndexOf("f ", StringComparison.Ordinal) == 0) 
                {
                    var parts = lineHeader.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int i = 0;

                    //triangle
                    if (parts.Count() == 4)
                    { 
                        foreach (var part in parts.Skip(1)) {
                            var subparts = part.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
                            if (subparts.Count() == 3) {
                                // v/vt/vn
                                vertexIndices.Add(Convert.ToUInt32(subparts[0], ifp));
                                uvIndices.Add(Convert.ToUInt32(subparts[1], ifp));
                                normalIndices.Add(Convert.ToUInt32(subparts[2], ifp));
                            }

                            if (subparts.Count() == 2) {
                                if (part.Contains(@"//")) {
                                    vertexIndices.Add(Convert.ToUInt32(subparts[0], ifp));
                                    normalIndices.Add(Convert.ToUInt32(subparts[1], ifp));
                                }
                                else {
                                    vertexIndices.Add(Convert.ToUInt32(subparts[0], ifp));
                                    uvIndices.Add(Convert.ToUInt32(subparts[1], ifp));
                                }
                            }

                            if (subparts.Count() == 1) {
                                // v
                                vertexIndices.Add(Convert.ToUInt32(subparts[0], ifp));
                            }
                        }
                    }
                    //quad
                    if (parts.Count() == 5)
                    {
                        //foreach (var part in parts.Skip(1))
                        //{
                        //    var subparts = part.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                        //    if (subparts.Count() == 3)
                        //    {
                        //        // v/vt/vn
                        //        vertexIndices.Add(Convert.ToUInt32(subparts[0], ifp));
                        //        uvIndices.Add(Convert.ToUInt32(subparts[1], ifp));
                        //        normalIndices.Add(Convert.ToUInt32(subparts[2], ifp));
                        //    }

                        //    if (subparts.Count() == 1)
                        //    {
                        //        // v
                        //        vertexIndices.Add(Convert.ToUInt32(subparts[0], ifp));
                        //    }
                        //}
                    }
                }
            }
            file.Close();

            Verteces.Clear();
            for (int i = 0; i < vertexIndices.Count; i++)
            {
                if (normalIndices.Count != 0 && uvIndices.Count != 0) {
                    Verteces.Add(new VertexPositionNormalTexture(temp_vertices[(int) (vertexIndices[i] - 1)],
                                                                 temp_normals[(int) (normalIndices[i] - 1)],
                                                                 temp_uvs[(int) (uvIndices[i] - 1)]));
                }

                if (normalIndices.Count == 0 && uvIndices.Count != 0)
                {
                    Verteces.Add(new VertexPositionNormalTexture(temp_vertices[(int)(vertexIndices[i] - 1)],
                                                                 new Vector3(), 
                                                                 temp_uvs[(int)(uvIndices[i] - 1)]));
                }
                if (normalIndices.Count == 0 && uvIndices.Count == 0)
                {
                    Verteces.Add(new VertexPositionNormalTexture(temp_vertices[(int)(vertexIndices[i] - 1)],
                                                                 new Vector3(), 
                                                                 new Vector2()));
                }
                if (normalIndices.Count != 0 && uvIndices.Count == 0)
                {
                    Verteces.Add(new VertexPositionNormalTexture(temp_vertices[(int)(vertexIndices[i] - 1)],
                                                                 temp_normals[(int)(normalIndices[i] - 1)],
                                                                 new Vector2()));
                }
            }

            Indeces.Clear();
            for (int i = 0; i < vertexIndices.Count; i++)
            {
                Indeces.Add((uint)i);
            }
            return true;
        }

        public void RecalcNormals()
        {
            for (int i = 0; i < Verteces.Count; i += 3)
            {
                var a = Verteces[i].Position;
                var b = Verteces[i + 1].Position;
                var c = Verteces[i + 2].Position;
                var normal = Vector3.Normalize(Vector3.Cross(c - a, b - a));
                //if (float.IsNaN(normal.X)) {
                //    normal = new Vector3(0,1,0);
                //}
                var i0 = Verteces[i];
                var i1 = Verteces[i + 1];
                var i2 = Verteces[i + 2];
                i0.Normal = i1.Normal = i2.Normal = normal;
                Verteces[i] = i0;
                Verteces[i + 1] = i1;
                Verteces[i + 2] = i2;
            }
            FlipNormals();
        }

        public void UnIndex()
        {
            if (Indeces.Count > 0)
            {
                var temp = new List<VertexPositionNormalTexture>(Verteces);

                Verteces.Clear();
                Verteces.Capacity = Indeces.Count;
                for (int i = 0; i < Indeces.Count; i++)
                {
                    Verteces.Add(temp[(int) Indeces[i]]);
                    Indeces[i] = (uint) i;
                }
            }
        }

        public bool saveSTL(string path) {
            if (File.Exists(path)) {
                File.Delete(path);
            }
            FileStream file = File.OpenWrite(path);
            StreamWriter sr = new StreamWriter(file);

            sr.WriteLine("solid {0}", path);
            for (int i = 0; i < Verteces.Count; i += 3)
            {
                
                sr.WriteLine(string.Format(ifp, "{0} {1} {2} {3}", "facet normal", Verteces[i].Normal.X, Verteces[i].Normal.Y, Verteces[i].Normal.Z));
                sr.WriteLine(string.Format(ifp, "{0}", "outer loop"));
                sr.WriteLine(string.Format(ifp, "{0} {1} {2} {3}", "vertex", Verteces[i].Position.X, Verteces[i].Position.Y, Verteces[i].Position.Z));
                sr.WriteLine(string.Format(ifp, "{0} {1} {2} {3}", "vertex", Verteces[i + 1].Position.X, Verteces[i + 1].Position.Y, Verteces[i + 1].Position.Z));
                sr.WriteLine(string.Format(ifp, "{0} {1} {2} {3}", "vertex", Verteces[i + 2].Position.X, Verteces[i + 2].Position.Y, Verteces[i + 2].Position.Z));
                sr.WriteLine(string.Format(ifp, "{0}", "endloop"));
                sr.WriteLine(string.Format(ifp, "{0}", "endfacet"));
            }
            sr.WriteLine("endsolid {0}", path);

            sr.Flush();
            sr.Close();
            file.Close();
            return true;
        }

        public void FlipNormals() {
            for (int i = 0; i < Verteces.Count; i++) {
                var vertex = Verteces[i];
                vertex.Normal *= -1;
                Verteces[i] = vertex;
            }
        }
    };
}