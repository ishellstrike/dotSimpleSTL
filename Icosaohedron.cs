using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SimpleSTL
{
    static class Icosaohedron
    {
        const int VERTEXCOUNT = 12;
        const int INDEXCOUNT = 60;
        private static Mesh sm_mesh;
        static Random rnd = new Random();

        private static readonly int[] __indeces = new[] {
                0, 1, 2,
                0, 2, 3,
                0, 3, 4,
                0, 4, 5,
                0, 5, 1,

                11, 7, 6,
                11, 8, 7,
                11, 9, 8,
                11, 10, 9,
                11, 6, 10,

                2, 1, 6,
                3, 2, 7,
                4, 3, 8,
                5, 4, 9,
                1, 5, 10,

                6, 7, 2,
                7, 8, 3,
                8, 9, 4,
                9, 10, 5,
                10, 6, 1
            };

        public static Mesh GetMesh()
        {
            if (sm_mesh != null)
            {
                return sm_mesh;
            }
            var m = new Mesh();
            float magicAngle = (float)(Math.PI * 26.565 / 180);
            float segmentAngle = (float)(Math.PI * 72 / 180);
            float currentAngle = 0;

            var v = new Vector3[VERTEXCOUNT];
            v[0] = new Vector3(0, 0.5f, 0);
            v[11] = new Vector3(0, -0.5f, 0);

            for (int i = 1; i < 6; i++)
            {
                v[i] = new Vector3((float)(0.5 * Math.Sin(currentAngle) * Math.Cos(magicAngle)),
                    (float)(0.5 * Math.Sin(magicAngle)),
                    (float)(0.5 * Math.Cos(currentAngle) * Math.Cos(magicAngle)));
                currentAngle += segmentAngle;
            }
            currentAngle = (float)(Math.PI * 36 / 180);
            for (int i = 6; i < 11; i++)
            {
                v[i] = new Vector3((float)(0.5 * Math.Sin(currentAngle) * Math.Cos(-magicAngle)),
                    (float)(0.5 * Math.Sin(-magicAngle)),
                    (float)(0.5 * Math.Cos(currentAngle) * Math.Cos(-magicAngle)));
                currentAngle += segmentAngle;
            }

            m.Verteces.Clear();
            m.Indeces.Clear();

            for (int i = 0; i < VERTEXCOUNT; i++)
            {
                var vert = new VertexPositionNormalTexture();
                vert.Position = v[i];
                vert.Uv = new Vector2(rnd.Next(0, 100) / 100.0f, rnd.Next(0, 100) / 100.0f);
                m.Verteces.Add(vert);
            }

            for (int i = 0; i < INDEXCOUNT; i++)
            {
                m.Indeces.Add((uint)__indeces[i]);
            }

            sm_mesh = m;
            return m;
        }
    }
}
