using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

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

        public static Mesh TracertTest(Mesh mesh) {
            Mesh m = new Mesh(mesh);



            return m;
        }

        public static Mesh RemoveInternal(Mesh mesh) {
            Mesh m = new Mesh(mesh);
           // m.UnIndex();

            double totalAo = 0, minAo = m.Verteces[0].Ao;
            for (int i = 0; i < m.Verteces.Count; i+=3) {
                totalAo += m.Verteces[i].Ao;
                if (m.Verteces[i].Ao < minAo) {
                    minAo = m.Verteces[i].Ao;
                }
            }
            totalAo /= m.Verteces.Count;

            mesh.Verteces.Clear();
            for (int i = 0; i < m.Verteces.Count; i+=3) {
                if (m.Verteces[i].Ao >= totalAo) {
                    mesh.Verteces.Add(m.Verteces[i]);
                    mesh.Verteces.Add(m.Verteces[i+1]);
                    mesh.Verteces.Add(m.Verteces[i+2]);
                }
            }

            m.Verteces = mesh.Verteces;

            m.Indeces.Clear();
            for (int i = 0; i < m.Verteces.Count; i++)
            {
                m.Indeces.Add((uint)i);
            }

            return m;
        }

        public static Mesh RobertsSimplify(Mesh mesh) {
            Mesh m = mesh;
            m.UnIndex();

            var W = MeshBarycentric(m);
            Vector3 P = new Vector3(1000);
            for (int i = 0; i < m.Verteces.Count; i+=3) {
                var V1 = m.Verteces[i];
                var V2 = m.Verteces[i+1];
                var V3 = m.Verteces[i+2];

                Vector3 Vec1 = new Vector3(), Vec2 = new Vector3();
                Vec1.X = V1.Position.X - V2.Position.X;
                Vec2.X = V3.Position.X - V2.Position.X;
                Vec1.Y = V1.Position.Y - V2.Position.Y;
                Vec2.Y = V3.Position.Y - V2.Position.Y;
                Vec1.Z = V1.Position.Z - V2.Position.Z;
                Vec2.Z = V3.Position.Z - V2.Position.Z;

                var A = Vec1.Y*Vec2.Z - Vec2.Y*Vec1.Z;
                var B = Vec1.Z*Vec2.X - Vec2.Z*Vec1.X;
                var C = Vec1.X*Vec2.Y - Vec2.X*Vec1.Y;
                var D = -(A*V1.Position.X + B*V1.Position.Y + C*V1.Position.Z);

                
                var M = -Math.Sign(A*W.X + B*W.Y + C*W.Z + D);

                A *= M;
                B *= M;
                C *= M;
                D *= M;

                if (A*P.X + B*P.Y + C*P.Z + D > 0) {

                }
                else {
                    if (i >= m.Verteces.Count) {
                        m.UnIndex();
                        return m;
                    }
                    m.Verteces.RemoveAt(i);
                    m.Verteces.RemoveAt(i);
                    m.Verteces.RemoveAt(i);
                    i -= 3;
                }
            }

            m.Indeces.Clear();
            for (int i = 0; i < m.Verteces.Count; i++) {
                m.Indeces.Add((uint) i);
            }

            return m;
        }

        public static Vector3 MeshBarycentric(Mesh mesh) {
            Vector3 a = new Vector3();

            for (int i = 0; i < mesh.Verteces.Count; i++) {
                a += mesh.Verteces[i].Position;
            }
            a /= mesh.Verteces.Count;

            return a;
        }

        public static Mesh Normalize(Mesh mesh) {
            Mesh m = new Mesh(mesh);


            for (int i = 0; i < m.Verteces.Count; i++) {
                var t = m.Verteces[i];
                t.Position.Normalize();
                m.Verteces[i] = t;
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

        public static Mesh SmartTesselate(Mesh mesh)
        {
            Mesh m = new Mesh();

            float size = 0;

            for (int i = 0; i < mesh.Indeces.Count; i += 3)
            {
                size += SstlHelper.TriangleSquare(mesh.Verteces[(int)mesh.Indeces[i]],
                                                   mesh.Verteces[(int)mesh.Indeces[i + 1]],
                                                   mesh.Verteces[(int)mesh.Indeces[i + 2]]);
            }
            size /= mesh.Indeces.Count;

            int off = 0;
            for (int i = 0; i < mesh.Indeces.Count; i += 3)
            {
                VertexPositionNormalTexture t;

                var sq = SstlHelper.TriangleSquare(mesh.Verteces[(int) mesh.Indeces[i]],
                                                   mesh.Verteces[(int) mesh.Indeces[i + 1]],
                                                   mesh.Verteces[(int) mesh.Indeces[i + 2]]);
                if (sq <= size*6) {
                    m.Verteces.Add(mesh.Verteces[(int)mesh.Indeces[i]]);
                    m.Verteces.Add(mesh.Verteces[(int)mesh.Indeces[i + 1]]);
                    m.Verteces.Add(mesh.Verteces[(int)mesh.Indeces[i + 2]]);
                    m.Indeces.Add((uint)off + 0);
                    m.Indeces.Add((uint)off + 1);
                    m.Indeces.Add((uint)off + 2);
                    off += 3;
                    continue;
                }

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
