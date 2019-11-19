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
        public float DeltaTime;
        public void Execute(ref Translation translation, [ReadOnly] ref CubeComponentData cubeComponentData)
        {
            translation.Value.y += DeltaTime;
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new MoveCubeJob()
        {
            DeltaTime = Time.deltaTime
        };

        return job.Schedule(this, inputDeps);
    }
}
