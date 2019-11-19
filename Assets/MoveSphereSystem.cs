using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using Unity.Transforms;

public class MoveSphereSystem : JobComponentSystem
{
    [BurstCompile]
    struct MoveSphereJob : IJobForEach<Translation, SphereComponentData>
    {
        public float DeltaTime;
        
        public void Execute(ref Translation translation, [ReadOnly] ref SphereComponentData sphereComponentData)
        {
            translation.Value.x += DeltaTime;
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new MoveSphereJob
        {
            DeltaTime = Time.deltaTime
        };

        return job.Schedule(this, inputDeps);
    }
}
