using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {

    [SerializeField]
    private Pool _poolProyectiles;
    [SerializeField]
    private Transform _spawnTransform;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private StatsPlayer statsP;
    private string dispararButton;
    private bool disparar;
    private float timerDisparo;
    [SerializeField]
    private JoyButton shootJoyButton;
    [SerializeField]
    private GameObject escudo;
    [SerializeField]
    private float costoDisparo;
    [SerializeField]
    private float waitTimeShoot;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GetComponent<AudioManager>();
    }
    void Start ()
    {
        dispararButton = "Disparar";
        disparar = true;
    }
	void Update ()
    {
        Debug.DrawLine(_spawnTransform.position, target.position, Color.green);
#if UNITY_STANDALONE_WIN

        if (Input.GetButtonDown(dispararButton) && disparar && statsP.GetMana() > 10 && !escudo.activeInHierarchy)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;
            objeto.GetComponent<Proyectil>().AddVelocity(Direction.CalculateDirection(target.position, _spawnTransform.position));
            audioManager.PlayShoot();
            statsP.RestarMana(costoDisparo);
            disparar = false;
        }
#endif
#if UNITY_ANDROID

        if (shootJoyButton.GetPressed() && disparar && statsP.GetMana() > 10 && !escudo.activeInHierarchy)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;
            objeto.GetComponent<Proyectil>().AddVelocity(Direction.CalculateDirection(target.position, _spawnTransform.position));
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
