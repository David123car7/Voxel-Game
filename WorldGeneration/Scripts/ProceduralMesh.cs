using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Jobs;
using Unity.Burst;
using UnityEngine.Rendering;
using static UnityEngine.Mesh;
using Unity.Mathematics;
using static Unity.Mathematics.math;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))] //It creates those modifiers automatic 
public class ProceduralMesh : MonoBehaviour
{
    int vertexAttributeCount = 4;
    int vertexCount = 4;
    int triangleIndexCount = 6;

    void Start()
    {
        // Allocate mesh data for one mesh.
        Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
        Mesh.MeshData meshData = meshDataArray[0];

        var mesh = new Mesh
        {
            name = "Procedural Mesh"
        };

        //Vertex Attributes
        var vertexAttributes = new NativeArray<VertexAttributeDescriptor>(
            vertexAttributeCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory
        );
        vertexAttributes[0] = new VertexAttributeDescriptor(dimension: 3);
        vertexAttributes[1] = new VertexAttributeDescriptor(
            VertexAttribute.Normal, dimension: 3, stream: 1
        );
        vertexAttributes[2] = new VertexAttributeDescriptor(
        );
        vertexAttributes[3] = new VertexAttributeDescriptor(
            VertexAttribute.TexCoord0, dimension: 2, stream: 3
        );
        meshData.SetVertexBufferParams(vertexCount, vertexAttributes);
        vertexAttributes.Dispose();

        //Setting Vertices
        NativeArray<float3> positions = meshData.GetVertexData<float3>();
        positions[0] = 0f;
        positions[1] = right();
        positions[2] = up();
        positions[3] = float3(1f, 1f, 0f);

        NativeArray<float3> normals = meshData.GetVertexData<float3>(1);
        normals[0] = normals[1] = normals[2] = normals[3] = back();

        NativeArray<float4> tangents = meshData.GetVertexData<float4>(2);
        tangents[0] = tangents[1] = tangents[2] = tangents[3] = float4(1f, 0f, 0f, -1f);

        NativeArray<float2> texCoords = meshData.GetVertexData<float2>(3);
        texCoords[0] = 0f;
        texCoords[1] = float2(1f, 0f);
        texCoords[2] = float2(0f, 1f);
        texCoords[3] = 1f;

        //Setting Triangles
        meshData.SetIndexBufferParams(triangleIndexCount, IndexFormat.UInt16);
        NativeArray<ushort> triangleIndices = meshData.GetIndexData<ushort>();
        triangleIndices[0] = 0;
        triangleIndices[1] = 2;
        triangleIndices[2] = 1;
        triangleIndices[3] = 1;
        triangleIndices[4] = 2;
        triangleIndices[5] = 3;

        //Setting SubMesh
        meshData.subMeshCount = 1;
        meshData.SetSubMesh(0, new SubMeshDescriptor(0, triangleIndexCount));

        Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);
        GetComponent<MeshFilter>().mesh = mesh;

        ReadMesh(mesh);
    }

    void ReadMesh(Mesh mesh) {
        using (var dataArray = Mesh.AcquireReadOnlyMeshData(mesh))
        {
            var data = dataArray[0];
            // prints "2"
            Debug.Log(data.vertexCount);
            var gotVertices = new NativeArray<Vector3>(mesh.vertexCount, Allocator.TempJob);
            data.GetVertices(gotVertices);
            // prints "(1.0, 1.0, 1.0)" and "(0.0, 0.0, 0.0)"
            foreach (var v in gotVertices)
                Debug.Log(v);
            gotVertices.Dispose();
        }
    }
}

