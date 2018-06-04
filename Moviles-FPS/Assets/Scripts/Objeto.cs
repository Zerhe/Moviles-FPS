using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour {

    protected PoolObject po;

    protected virtual void OnDisable()
    {
        if (po)
        {
            po.Recycle();
            print("seRecicla");
        }
        else
        {
            po = GetComponent<PoolObject>();
            po.Recycle();
            print("seRecicla");
        }
    }
}