using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SimpleSTL
{
    static class Sphere
    {
        private static Mesh sm_mesh;

        public static Mesh GetMesh()
        {
            if (sm_mesh != null)
            {
                return new Mesh(sm_mesh);
            }
            var m = new Mesh();
            float radius = 1;
            int tessLevel = 12;
            int cou = 0;
            for (int i = 0; i < tessLevel; i++)
            {
                for (int j = 0; j < tessLevel; j++)
                {
                    var vert = new VertexPositionNormalTexture();
                    vert.Position = new Vector3();

                    float h = (float)(Math.PI * 2 * (float)i) / (tessLevel - 1);
                    float v = (float)(-Math.PI / 2 + (Math.PI * (float)j) / (tessLevel - 2));

                    float x = (float)(Math.Cos(h) * Math.Cos(v));
                    float y = (float)(Math.Sin(v));
                    float z = (float)(Math.Sin(h) * Math.Cos(v));

                    vert.Normal = new Vector3(x,y,z);
                    vert.Position = new Vector3(x * radius, y * radius, z * radius);

                    m.Verteces.Add(vert);
                }
            }


            for (int j = 0; j < tessLevel - 1; j++)
            {
                for (int i = 0; i < tessLevel - 2; i++)
                {
                    m.Indeces.Add((uint)(j * tessLevel + i));
                    m.Indeces.Add((uint)(((j + 1) * tessLevel) + i));
                    m.Indeces.Add((uint)(j * tessLevel + i + 1));

                    m.Indeces.Add((uint)((j + 1) * tessLevel + i + 1));
                    m.Indeces.Add((uint)((j + 1) * tessLevel + i));
                    m.Indeces.Add((uint)(((j) * tessLevel) + i + 1));

                    

                    
                    
                    
                    
                }
            }

            sm_mesh = m;
            return new Mesh(m);
        }
    }
}
