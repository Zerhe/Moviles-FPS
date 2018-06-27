using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoDisparar : MonoBehaviour {

    Pool poolProyectiles;
    Transform spawnProyectil;
    RaycastHit infColi;
    Transform playerT;

    void Awake()
    {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (Physics.Raycast(transform.position, playerT.position, out infColi, 10))
        {

            //infColi.rigidbody.AddForceAtPosition(transform.up * fuerzaDisparo, infColi.point, ForceMode.Impulse);

        }
    }
}
