using OpenTK;

namespace SimpleSTL {
    public struct VertexPositionNormalTexture {
        public Vector3 Position;
        public Vector2 Uv;
        public Vector3 Normal;
        public float Ao;

        public VertexPositionNormalTexture(Vector3 pos, Vector3 norm, Vector2 uv)
        {
            Position = pos;
            Normal = norm;
            Uv = uv;
            Ao = 1;
        }

        public static VertexPositionNormalTexture operator +(VertexPositionNormalTexture a, VertexPositionNormalTexture b)
        {
            return new VertexPositionNormalTexture(a.Position + b.Position, a.Normal + b.Normal, a.Uv + b.Uv);
        }

        public static VertexPositionNormalTexture operator /(VertexPositionNormalTexture a, float b)
        {
            return new VertexPositionNormalTexture(a.Position / b, a.Normal / b, a.Uv / b);
        }

        public static int Size
        {
            get { return Vector3.SizeInBytes * 2 + Vector2.SizeInBytes; }
        }
    }
}