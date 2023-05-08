using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolableBulletBase : PoolableObject
{
    [SerializeField] LayerMask KillBullet;
    protected void DestroyObstacle(bool notify = false)
    {
        if (notify)
            GetComponent<PoolableObject>().RecycleObject();
    }

    private void Update()
    {
        if (transform.position.y > 8f)
        {
            DestroyObstacle(true);
        }
    }

}
