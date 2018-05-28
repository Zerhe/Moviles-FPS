using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour {
    PoolObject po;

    private void Awake()
    {
        po = GetComponent<PoolObject>();
    }
    public virtual void Activarse(Vector3 pos, Quaternion rot)
    {
        gameObject.transform.position = pos;
        gameObject.transform.rotation = rot;

        gameObject.SetActive(true);
    }
    public virtual void Desactivarse()
    {
        po.Recycle();
        gameObject.SetActive(false);
    }
}
