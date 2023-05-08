using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : PoolBase
{
    PoolableObject poolableObject;

    private void Awake()
    {
        PopulatePool();
    }

   
}
