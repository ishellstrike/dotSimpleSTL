using OpenTK;

namespace SimpleSTL {
    static class Cube
    {
        private static Mesh sm_mesh;
        private static readonly int VERTEXCOUNT = 24;
        private static readonly int INDEXCOUNT = 36;
        static readonly Vector3[] __vertexPositions =
        {	
            new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0.5f, -0.5f, -0.5f), // front
            new Vector3(0.5f, -0.5f,0.5f), new Vector3(0.5f, 0.5f,0.5f), new Vector3(-0.5f, 0.5f,0.5f), new Vector3(-0.5f, -0.5f,0.5f), // back
            new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(-0.5f, 0.5f,0.5f), new Vector3(0.5f, 0.5f,0.5f), new Vector3(0.5f, 0.5f, -0.5f), // top
            new Vector3(-0.5f, -0.5f,0.5f), new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0.5f, -0.5f,0.5f), // bottom
            new Vector3(-0.5f, -0.5f,0.5f), new Vector3(-0.5f, 0.5f,0.5f), new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(-0.5f, -0.5f, -0.5f), // left
            new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f,0.5f), new Vector3(0.5f, -0.5f,0.5f) // right
        };

        static readonly uint[] __vertexIndex =
        {
            0, 3, 2, 2, 1, 0, // front
            4, 7, 6, 6, 5, 4, // back
            8,11, 10, 10,9, 8, // top
            12,15,14, 14,13,12, // bottom
            16,19,18, 18,17,16, // left
            20,23,22, 22,21,20 // right
        };

        public static Mesh GetMesh()
        {
            if (sm_mesh != null)
            {
                return new Mesh(sm_mesh);
            }

            Mesh m = new Mesh();
            m.Indeces.Clear();
            m.Verteces.Clear();
            for (int i = 0; i < 6; i++)
            {

                var vert = new VertexPositionNormalTexture();
                vert.Position = __vertexPositions[i * 4 + 0];
                vert.Uv = new Vector2(1, 1);
                m.Verteces.Add(vert);

                vert.Position = __vertexPositions[i * 4 + 1];
                vert.Uv = new Vector2(1, 0);
                m.Verteces.Add(vert);

                vert.Position = __vertexPositions[i * 4 + 2];
                vert.Uv = new Vector2(0, 0);
                m.Verteces.Add(vert);

                vert.Position = __vertexPositions[i * 4 + 3];
                vert.Uv = new Vector2(0, 1);
                m.Verteces.Add(vert);
            }

            for (int i = 0; i < INDEXCOUNT; i++)
            {
                m.Indeces.Add(__vertexIndex[i]);
            }

            sm_mesh = m;
            return new Mesh(m);
        }
    }
}