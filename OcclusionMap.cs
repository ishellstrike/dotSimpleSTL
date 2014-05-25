using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace SimpleSTL
{
    class OcclusionMap {
        public List<float> OcclusionFactor;

        public static void AmbientOcclusionRecalc(Mesh mesh) {
            for (int i = 0; i < mesh.Verteces.Count; i+=3) {
                var v0 = mesh.Verteces[i];
                var v1 = mesh.Verteces[i+1];
                var v2 = mesh.Verteces[i+2];
                
                var center1 = (v0.Position + v1.Position + v2.Position)/3;
                v0.Ao = v1.Ao = v2.Ao = 1.0f;
                for (int j = 0; j < mesh.Verteces.Count; j += 3*3*3) {
                    if (j < i || j > i+2) {
                        var vv0 = mesh.Verteces[j];
                        var vv1 = mesh.Verteces[j + 1];
                        var vv2 = mesh.Verteces[j + 2];
                        var center2 = (vv0.Position + vv1.Position + vv2.Position)/3;
                        var rsq = (center1 - center2).LengthSquared;
                        var a = (vv0.Position - vv1.Position).LengthFast;
                        var b = (vv1.Position - vv2.Position).LengthFast;
                        var c = (vv0.Position - vv2.Position).LengthFast;
                        var s = (a + b + c) / 2.0f;
                        var square = (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));
                        var res = ElementShadow(center1, rsq, v0.Normal, vv0.Normal, square);
                        if (float.IsNaN(res) || res == 0) {
                            continue;
                        }
                        v0.Ao /= 1 + res;
                        v1.Ao /= 1 + res;
                        v2.Ao /= 1 + res;

                        mesh.Verteces[i] = v0;
                        mesh.Verteces[i + 1] = v1;
                        mesh.Verteces[i + 2] = v2;
                    }
                }
            }
        }

        static float ElementShadow(Vector3 v, float rSquared, Vector3 receiverNormal,

                    Vector3 emitterNormal, float emitterArea)
        {



            // we assume that emitterArea has already been divided by PI

            return (1 - Q_rsqrt(emitterArea / rSquared + 1)) *

                   SstlHelper.Clamp(Vector3.Dot(emitterNormal, v), 0, 1) *

                   SstlHelper.Clamp(4 * Vector3.Dot(receiverNormal, v), 0, 1);

        }

        static unsafe float Q_rsqrt(float number)
        {
            long i;
            float x2, y;
            const float threehalfs = 1.5F;

            x2 = number * 0.5F;
            y = number;
            i = *(long*)&y;                      
            i = 0x5f3759df - (i >> 1);              
            y = *(float*)&i;
            y = y * (threehalfs - (x2 * y * y));   

            return y;
        }

        bool FullIntersect(Ray r, VertexPositionNormalTexture Vertex1, VertexPositionNormalTexture Vertex2, VertexPositionNormalTexture Vertex3)
        {
            if (Vector3.Dot(r.direction, Vertex1.Normal) < 0) return false;
            Vector3 a, b, v;
            a = Vertex1.Position - r.position;
            b = Vertex2.Position - r.position;
            v = Vector3.Cross(a, b);
            var ip1 = Vector3.Dot(r.direction, v);
            a = Vertex2.Position - r.position;
            b = Vertex3.Position - r.position;
            v = Vector3.Cross(a, b);
            var ip2 = Vector3.Dot(r.direction, v);
            a = Vertex3.Position - r.position;
            b = Vertex1.Position - r.position;
            v = Vector3.Cross(a, b);
            var ip3 = Vector3.Dot(r.direction, v);

            //if (((ip1 < 0) && (ip2 < 0) && (ip3 < 0)) || ((ip1 > 0) && (ip2 > 0) && (ip3 > 0)))
            //{
            //    var d = dot(Normal, r->direction);
            //    if (fabs(d) < epsilon) return false;
            //    ips.t[0] = (-dot(Normal, r->position) - distanse) / d;
            //    return ips.t[0] >= 0;
            //}
            return false;
        } 
    }

    class Ray {
        public Vector3 position;
        public Vector3 direction;
    }
}
