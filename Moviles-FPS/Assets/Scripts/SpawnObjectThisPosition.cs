using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectThisPosition : MonoBehaviour {

    [SerializeField]
    private Pool poolObjects;

	void Start ()
    {
        poolObjects.GetPooledObject(transform.position, transform.rotation);
    }

}
