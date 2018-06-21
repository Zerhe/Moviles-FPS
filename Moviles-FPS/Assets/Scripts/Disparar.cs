using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {
    [SerializeField]
    private Pool _poolProyectiles;
    private BolaFuego _proyectil;
    [SerializeField]
    private Transform _spawnTransform;
    [SerializeField]
    private StatsPlayer statsP;
    private string dispararButton;
    private bool disparar;
    private float timerDisparo;
    [SerializeField]
    private float costoDisparo;

    void Start ()
    {
        dispararButton = "Disparar";
        disparar = true;

    }
	void Update ()
    {

        if (Input.GetButtonDown(dispararButton) && disparar && statsP.mana > 10)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;
            statsP.mana -= costoDisparo;
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
