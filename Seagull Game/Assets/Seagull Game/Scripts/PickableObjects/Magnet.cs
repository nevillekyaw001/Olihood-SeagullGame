using MoreMountains.InfiniteRunnerEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : PickableObject
{
    public float effectDuration = 15f;
    public float magnetRange = 20f;

    protected override void ObjectPicked()
    {
        if (LevelManager.Instance == null)
        {
            return;
        }
        LevelManager.Instance.TemporarilyAttractCoin(magnetRange, effectDuration);
    }
}
