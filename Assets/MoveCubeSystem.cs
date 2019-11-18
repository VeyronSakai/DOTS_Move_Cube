using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class MoveCubeSystem : JobComponentSystem
{
    [BurstCompile]
    struct MoveCubeJob : IJobForEach<Translation, CubeComponentData>
    {
        public void Execute(ref Translation translation, [ReadOnly] ref CubeComponentData cubeComponentData)
        {

        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new MoveCubeJob();

        return job.Schedule(this, inputDeps);
    }
}
