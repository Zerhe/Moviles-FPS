using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private Pool pool;

    public void SetPool(Pool pool)
    {
        this.pool = pool;
    }
    public virtual void Recycle()
    {
        pool.AddToPool(this);
    }
}
