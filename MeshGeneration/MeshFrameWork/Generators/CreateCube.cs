using Unity.Mathematics;
using UnityEngine;

using static Unity.Mathematics.math;

namespace ProceduralMeshes.Generators
{
    public struct CreateCube : IMeshGenerator
    {
        public Bounds Bounds => new Bounds(new Vector3(0.5f, 0.5f), new Vector3(1f, 1f));
        public int VertexCount => 8;  //6
        public int IndexCount => 36; //9
        public int JobLength => 1;

        public void Execute<S>(int i, S streams) where S : struct, IMeshStreams
        {
            var vertex = new Vertex();
            vertex.normal.z = -1f;
            vertex.tangent.xw = float2(1f, -1f);

            int aux = 0;
            int aux2 = 0;

            for (int vv = 0; vv < 8; vv++) //Creates the vertices
            {
                vertex.position = VoxelData.voxelVerts[aux2];
                streams.SetVertex(aux2, vertex);
                aux2++;
            }
            for(int v = 0; v< 6; v++) //Creates the faces
            {
                streams.SetTriangle(aux, VoxelData.voxelTris[aux]);
                aux++;
                streams.SetTriangle(aux, VoxelData.voxelTris[aux]);
                aux++;
            }
        }

    }   
}

/*
  public void Execute<S>(int i, S streams) where S : struct, IMeshStreams
        {
            var vertex = new Vertex();
            vertex.normal.z = -1f;
            vertex.tangent.xw = float2(1f, -1f);

            streams.SetVertex(0, vertex);

            vertex.position = float3(0f, 0f, 1f);
            vertex.texCoord0 = float2(1f, 0f);
            streams.SetVertex(1, vertex);

            vertex.position = float3(1f, 0f, 0f);
            vertex.texCoord0 = float2(0f, 1f);
            streams.SetVertex(2, vertex);

            vertex.position = float3(1f, 0f, 1f);
            vertex.texCoord0 = 1f;
            streams.SetVertex(3, vertex);

            streams.SetTriangle(0, int3(0, 2, 1));
            streams.SetTriangle(1, int3(1, 2, 3));
        }
 */

/*
 public void Execute<S>(int i, S streams) where S : struct, IMeshStreams
        {
            //Vertices
            var vertex = new Vertex(); // pos of this vertice = float3(0f, 0f, 0f); & textCord = float2(0f, 0f);
            vertex.normal.z = -1f;
            vertex.tangent.xw = float2(1f, -1f);
            streams.SetVertex(0, vertex);

            vertex.position = float3(1f, 0f, 0f);
            //vertex.texCoord0 = float2(0f, 1f);
            streams.SetVertex(1, vertex);

            vertex.position = float3(1f, 1f, 0f);
            //vertex.texCoord0 = float2(1f, 0f);
            streams.SetVertex(2, vertex);

            vertex.position = float3(0f, 1f, 0f);
            //vertex.texCoord0 = float2(1f, 1f);
            streams.SetVertex(3, vertex);

            vertex.position = float3(0f, 0f, 1f);
            //vertex.texCoord0 = float2(0f, 0f);
            streams.SetVertex(4, vertex);

            vertex.position = float3(1f, 0f, 1f);
            //vertex.texCoord0 = float2(0f, 1f);
            streams.SetVertex(5, vertex);

            vertex.position = float3(1f, 1f, 1f);
            //vertex.texCoord0 = float2(1f, 0f);
            streams.SetVertex(6, vertex);

            vertex.position = float3(0f, 1f, 1f);
            //vertex.texCoord0 = float2(1f, 1f);
            streams.SetVertex(7, vertex);

            //Triangles Face1 (Side)
            streams.SetTriangle(0, int3(0, 3, 1));
            streams.SetTriangle(1, int3(1, 3, 2));

            //Triangles Face2 (Side)
            streams.SetTriangle(2, int3(1, 2, 5));
            streams.SetTriangle(3, int3(5, 2, 6));

            //Triangles Face2 (Side)
            streams.SetTriangle(4, int3(5, 6, 4));
            streams.SetTriangle(5, int3(4, 6, 7));

            //Triangles Face2 (Side)
            streams.SetTriangle(6, int3(4, 7, 0));
            streams.SetTriangle(7, int3(0, 7, 3));

            //Triangles Face2 (Top)
            streams.SetTriangle(8, int3(3, 7, 2));
            streams.SetTriangle(9, int3(2, 7, 6));

            //Triangles Face2 (Down)
            streams.SetTriangle(10, int3(4, 0, 5));
            streams.SetTriangle(11, int3(5, 0, 1));
        }
 */