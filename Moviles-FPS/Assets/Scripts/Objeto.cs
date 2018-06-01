using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour {

    protected PoolObject po;

    protected virtual void Awake()
    {
        po = GetComponent<PoolObject>();
    }
    protected virtual void OnDisable()
    {
        if (po)
        {
            po.Recycle();
            print("seRecicla");
        }
    }
}
