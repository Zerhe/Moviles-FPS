using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject Prefab;
    public int Count = 10;

    private List<PoolObject> pool = new List<PoolObject>();

	void Awake ()
    {
        for (int i = 0; i < Count; i++)
        {
            PoolObject po = CreateObject();
            AddToPool(po);
        }
	}

    public PoolObject GetPooledObject()
    {
        if (pool.Count > 0)
        {
            PoolObject po = pool[0];
            pool.RemoveAt(0);
            return po;
        }
        else
        {
            PoolObject po = CreateObject();

            Debug.LogWarning("Creando objeto en realtime.");

            return po;
        }
    }

    public void AddToPool(PoolObject po)
    {
        if (!pool.Contains(po))
            pool.Add(po);
    }

    private PoolObject CreateObject()
    {
        GameObject go = Instantiate(Prefab, this.transform);

        PoolObject po = go.AddComponent<PoolObject>();
        po.SetPool(this);
        gameObject.SetActive(false);
        return po;
    }
}
