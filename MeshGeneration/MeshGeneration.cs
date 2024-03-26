using ProceduralMeshes;
using ProceduralMeshes.Generators;
using ProceduralMeshes.Streams;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralMesh : MonoBehaviour {
    Mesh mesh;
    void Awake()
    {
        mesh = new Mesh
        {
            name = "Procedural Mesh"
        };
        GenerateMesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void GenerateMesh() {
        Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
        Mesh.MeshData meshData = meshDataArray[0];

        MeshJob<CreateCube, SingleStream>.ScheduleParallel(
            mesh, meshData, default
        ).Complete();

        Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, mesh);

        MeshInfo(mesh);

    }

    void MeshInfo(Mesh mesh)
    {
        using (var dataArray = Mesh.AcquireReadOnlyMeshData(mesh))
        {
            var data = dataArray[0];
            // prints "2"
            Debug.Log(data.vertexCount);
            var gotVertices = new NativeArray<Vector3>(mesh.vertexCount, Allocator.TempJob);
            //var gotUv = new NativeArray<Vector2>(mesh.uv, Allocator.TempJob);
            data.GetVertices(gotVertices);
            foreach (var v in gotVertices)
                Debug.Log(v);
            //foreach (var u in gotUv)
            //    Debug.Log(u);
            gotVertices.Dispose();
            //gotUv.Dispose();
        }
    }
}
