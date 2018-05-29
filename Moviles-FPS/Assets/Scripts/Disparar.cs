using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {
    [SerializeField]
    private Pool _poolProyectiles;
    private BolaFuego _proyectil;
    [SerializeField]
    private Transform _spawnTransform;
    private string dispararButton;
    private bool disparar;
    private float timerDisparo;

    void Start ()
    {
        dispararButton = "Disparar";
        disparar = true;

    }
	void Update ()
    {

        if (Input.GetButtonDown(dispararButton) && disparar)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;

            disparar = false;
        }


        if (disparar == false)
        {
            timerDisparo += Time.deltaTime;
        }
        if (timerDisparo > 0.5)
        {
            disparar = true;
            timerDisparo -= timerDisparo;
        }
    }

}
