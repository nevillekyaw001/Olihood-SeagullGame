using MoreMountains.InfiniteRunnerEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : PickableObject
{
    public float EffectDuration = 5f;

    protected override void ObjectPicked()
    {
        if (LevelManager.Instance == null)
        {
            return;
        }
        LevelManager.Instance.TemporarilyAttractCoin(EffectDuration);
    }
}
