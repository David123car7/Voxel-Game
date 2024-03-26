using Unity.Mathematics;
using UnityEngine;
using static Unity.Mathematics.math;

namespace ProceduralMeshes
{
    public interface IMeshGenerator
    {
        int VertexCount { get; }
        int IndexCount { get; }
        int JobLength { get; }

        Bounds Bounds { get; }
        void Execute<S>(int i, S streams) where S : struct, IMeshStreams;
    }
}