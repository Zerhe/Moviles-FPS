using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    [SerializeField]
    private Pool _poolProyectiles;
    [SerializeField]
    private Transform _spawnTransform;
    [SerializeField]
    private StatsPlayer statsP;
    private string dispararButton;
    private bool disparar;
    private float timerDisparo;
    [SerializeField]
    private float costoDisparo;
    [SerializeField]
    private float waitTimeShoot;
    [SerializeField]
    private JoyButton shootJoyButton;

    void Start ()
    {
        dispararButton = "Disparar";
        disparar = true;

    }
	void Update ()
    {
#if UNITY_STANDALONE_WIN

        if (Input.GetButtonDown(dispararButton) && disparar && statsP.GetMana() > 10)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;
            statsP.RestarMana(costoDisparo);
            disparar = false;
        }
#endif
#if UNITY_ANDROID

        if (shootJoyButton.GetPressed() && disparar && statsP.GetMana() > 10)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;
            statsP.RestarMana(costoDisparo);
            disparar = false;
        }
#endif

        if (disparar == false)
        {
            timerDisparo += Time.deltaTime;
        }
        if (timerDisparo > waitTimeShoot)
        {
            disparar = true;
            timerDisparo -= timerDisparo;
        }
    }

}
