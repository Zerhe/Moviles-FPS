using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclePoolObject : MonoBehaviour {

    private PoolObject po;

    public virtual void OnDisable()
    {
        if (po)
        {
            po.Recycle();
            //print("seRecicla");
        }
        else
        {
            po = GetComponent<PoolObject>();
            po.Recycle();
            //print("seRecicla");
        }
    }
}