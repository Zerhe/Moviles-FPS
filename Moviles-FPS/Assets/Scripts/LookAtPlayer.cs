using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        if (tag == "Enemy")
        {
            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = rotation;
        }
        else
            transform.LookAt(target);
    }
}
