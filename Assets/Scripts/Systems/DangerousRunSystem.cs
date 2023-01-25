﻿using Leopotam.EcsLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class DangerousRunSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems ecsSystems)
        {
            var filter = ecsSystems.GetWorld().Filter<DangerousComponent>().End();
            var dangerousPool = ecsSystems.GetWorld().GetPool<DangerousComponent>();

            foreach (var entity in filter)
            {
                ref var dangerousComponent = ref dangerousPool.Get(entity);
                Vector3 pos1 = dangerousComponent.pointA;
                Vector3 pos2 = dangerousComponent.pointB;

                dangerousComponent.obstacleTransform.localPosition = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time, 1.0f));
            }
        }
    }
}