using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
    public event Action<GameObject> onObjectToRecycle;

    public void RecycleObject()
    {
        onObjectToRecycle?.Invoke(gameObject);
    }

}
