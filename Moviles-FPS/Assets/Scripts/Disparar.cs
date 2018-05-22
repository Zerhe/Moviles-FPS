using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    [SerializeField]
    private GameObject _proyectilObj;
    private GameObject[] _proyectilesInstanciados = new GameObject[10];
    private Proyectil _infoProyectil;
    [SerializeField]
    private Transform _spawnTransform;
    private string dispararButton;
    private int n;
    private bool disparar;
    private float timerDisparo;

    void Start ()
    {
        dispararButton = "Disparar";
        n = 0;
        disparar = true;

        for (int i = 0; i < _proyectilesInstanciados.Length; i++)
        {
            _proyectilesInstanciados[i] = Instantiate(_proyectilObj, _spawnTransform.position, _spawnTransform.rotation);
            _infoProyectil = _proyectilesInstanciados[i].GetComponent<Proyectil01>();
            _infoProyectil.Desactivarse();
        }
    }
	void Update ()
    {
        if (n == _proyectilesInstanciados.Length)
            n = 0;

        if (Input.GetButtonDown(dispararButton) && !_proyectilesInstanciados[n].activeInHierarchy && disparar)
        {
            _infoProyectil = _proyectilesInstanciados[n].GetComponent<Proyectil01>();
            _infoProyectil.Activarse(_spawnTransform.position, _spawnTransform.rotation);
            _infoProyectil.AddVelocity();
            n++;
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
    void InstanciarProyectil(GameObject proyectilObj, Transform puntoDisparo)
    {
    
    }
}
