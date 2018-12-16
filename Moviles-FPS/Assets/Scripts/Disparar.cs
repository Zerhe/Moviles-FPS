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
    private StatsPlayer statsPlayer;
    private string dispararButton;
    private bool disparar;
    private float timerDisparo;
    [SerializeField]
    private JoyButton shootJoyButton;
    [SerializeField]
    private GameObject escudo;
    [SerializeField]
    private float cadence;
    [SerializeField]
    private float costoMana;
    private AudioManager audioManager;
    private RaycastHit infColi;


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

        if (Input.GetButtonDown(dispararButton) && disparar && statsPlayer.GetMana() > 10 && !escudo.activeInHierarchy)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;
            objeto.GetComponent<Proyectil>().AddVelocity(Direction.CalculateDirection(target.position, _spawnTransform.position));
            audioManager.PlayAudio();
            statsPlayer.RestarMana(costoMana);
            disparar = false;
        }
#endif
#if UNITY_ANDROID

        if (SeeEnemy() && disparar && statsPlayer.GetMana() > 10 && !escudo.activeInHierarchy)
        {
            GameObject objeto = _poolProyectiles.GetPooledObject(_spawnTransform.position, _spawnTransform.rotation).gameObject;
            objeto.GetComponent<Proyectil>().AddVelocity(Direction.CalculateDirection(target.position, _spawnTransform.position));
            audioManager.PlayAudio();
            statsPlayer.RestarMana(costoMana);
            disparar = false;
        }
#endif

        if (disparar == false)
        {
            timerDisparo += Time.deltaTime;
        }
        if (timerDisparo > cadence)
        {
            disparar = true;
            timerDisparo -= timerDisparo;
        }
    }
    public bool SeeEnemy()
    {
        int layerMask = 1 << 2;
        layerMask = ~layerMask;

        if (Physics.Linecast(_spawnTransform.position, target.position, out infColi, layerMask))
        {
            if (infColi.collider.gameObject.tag == "Enemy")
            {
                Debug.DrawLine(_spawnTransform.position, target.position, Color.green);
                return true;
            }
        }
        return false;
    }
}
