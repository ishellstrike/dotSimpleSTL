using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SimpleSTL
{
    static class Tetrahedral
    {
        private static Mesh sm_mesh;

        public static Mesh GetMesh()
        {
            if (sm_mesh != null)
            {
                return new Mesh(sm_mesh);
            }
            var m = new Mesh();

            var tetrahedralAngle = Math.PI * 109.4712f / 180;
            var segmentAngle = (float)(Math.PI * 2 / 3);
            var currentAngle = 0f;

            float radius = 1;
            var v = new Vector3[4];
            v[0] = new Vector3(0, radius, 0);
            for (var i = 1; i <= 3; i++)
            {
                v[i] = new Vector3((float)(radius * Math.Sin(currentAngle) * Math.Sin(tetrahedralAngle)),
                                    (float)(radius * Math.Cos(tetrahedralAngle)),
                                    (float)(radius * Math.Cos(currentAngle) * Math.Sin(tetrahedralAngle)));
                currentAngle = currentAngle + segmentAngle;
                
            }

            for (var i = 0; i <= 3; i++)
            {
                var t = new VertexPositionNormalTexture();
                t.Position = v[i];
                m.Verteces.Add(t);
            }

            m.Indeces.AddRange(new uint[] {0,1,2,1,3,2,0,2,3,0,3,1 });

            sm_mesh = m;
            return new Mesh(m);
        }
    }
}
