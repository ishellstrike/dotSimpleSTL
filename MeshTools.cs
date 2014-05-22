using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSTL
{
    class MeshTools
    {
        public static Mesh Tesselate(int iters, Mesh mesh)
        {
            Mesh m = new Mesh(mesh);
            for (int i = 0; i < iters; i++)
            {
                m = SubTesselate(m);
                m.UnIndex();
            }
            return m;
        }

        public static Mesh Normalize(Mesh mesh) {
            Mesh m = new Mesh(mesh);


            for (int i = 0; i < mesh.Verteces.Count; i++) {
                var t = mesh.Verteces[i];
                t.Position.Normalize();
                mesh.Verteces[i] = t;
            }

            return m;
        }

        private static Mesh SubTesselate(Mesh mesh)
        {
            Mesh m = new Mesh();

            int off = 0;
            for (int i = 0; i < mesh.Indeces.Count - 2; i += 3)
            {
                VertexPositionNormalTexture t;

                m.Verteces.Add(mesh.Verteces[(int)mesh.Indeces[i]]);
                m.Verteces.Add(mesh.Verteces[(int)mesh.Indeces[i + 1]]);
                m.Verteces.Add(mesh.Verteces[(int)mesh.Indeces[i + 2]]);

                t = (mesh.Verteces[(int)mesh.Indeces[i]] + mesh.Verteces[(int)mesh.Indeces[i + 1]]) / 2;
                m.Verteces.Add(t);

                t = (mesh.Verteces[(int)mesh.Indeces[i]] + mesh.Verteces[(int)mesh.Indeces[i + 2]]) / 2;
                m.Verteces.Add(t);

                t = (mesh.Verteces[(int)mesh.Indeces[i + 1]] + mesh.Verteces[(int)mesh.Indeces[i + 2]]) / 2;
                m.Verteces.Add(t);

                m.Indeces.Add((uint)off + 0);
                m.Indeces.Add((uint)off + 3);
                m.Indeces.Add((uint)off + 4);

                m.Indeces.Add((uint)off + 5);
                m.Indeces.Add((uint)off + 3);
                m.Indeces.Add((uint)off + 1);
               

                m.Indeces.Add((uint)off + 5);
                m.Indeces.Add((uint)off + 2);
                m.Indeces.Add((uint)off + 4);

                m.Indeces.Add((uint)off + 3);
                m.Indeces.Add((uint)off + 5);
                m.Indeces.Add((uint)off + 4);

                off += 6;
            }
            return m;
        }
    }
}
