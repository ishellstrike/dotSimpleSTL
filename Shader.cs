using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace SimpleSTL
{
    public class Shader
    {
        private int program;
        private List<int> shaders = new List<int>();

        public int shaderMVLocation_, shaderPLocation_;

        public Shader()
        {
            program = GL.CreateProgram();
        }

        public void LocateStd() {
            shaderMVLocation_ = GL.GetUniformLocation(program, "modelview_matrix");
            shaderPLocation_ = GL.GetUniformLocation(program, "projection_matrix");
        }

        public void loadShaderFromSource(ShaderType type, string source)
        {
            StringBuilder ss = new StringBuilder();
            ss.AppendLine("#version 430");
            string name = "";
            if (type == ShaderType.FragmentShader)
            {
                name = "#define _FRAGMENT_";
                ss.AppendLine(name);
            }
            else if (type == ShaderType.VertexShader)
            {
                name = "#define _VERTEX_";
                ss.AppendLine(name);
            }
            else if (type == ShaderType.GeometryShader)
            {
                name = "#define _GEOMETRY_";
                ss.AppendLine(name);
            }
            else if (type == ShaderType.TessEvaluationShader)
            {
                name = "#define _TESSEVAL_";
                ss.AppendLine(name);
            }
            else if (type == ShaderType.TessControlShader)
            {
                name = "#define _TESSCONTROL_";
                ss.AppendLine(name);
            }
            else if (type == ShaderType.ComputeShader)
            {
                name = "#define _COMPUTE_";
                ss.AppendLine(name);
            }

            using (StreamReader file = new StreamReader(source))
            {
                ss.AppendLine(file.ReadToEnd());
            }
            int id = GL.CreateShader(type);
            GL.ShaderSource(id, ss.ToString());
            GL.CompileShader(id);
            Log.Add(source, " file ", name, "PART");
            PrintLog(id);
            GL.AttachShader(program, id);
            shaders.Add(id);
        }

        public bool Link()
        {
            GL.LinkProgram(program);
            Log.Add("Program ", program, " linking");
            PrintLog(program);
            Log.Add("----------");
            return true;
        }

        private static void PrintLog(int obj)
        {
            string infoLog = GL.IsShader(obj) ? GL.GetShaderInfoLog(obj) : GL.GetProgramInfoLog(obj);
            Log.Add(infoLog.Length > 0 ? infoLog : "     no errors");
        }

        public void Use() {
            GL.UseProgram(program);
        }

        public int ID
        {
            get { return program; }
        }
    }

}


