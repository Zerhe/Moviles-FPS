using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoDisparar : MonoBehaviour
{

    private Pool poolProyectiles;
    [SerializeField]
    private Transform spawnProyectil;
    //private RaycastHit infColi;
    //private Transform playerT;
    private float timer = 0;
    private float timer2 = 0;
    [SerializeField]
    private float timeToShot;
    [SerializeField]
    private float timeBetweenShot;
    private float disparos = 0;
    [SerializeField]
    private float maxDisparos;
    private bool disparar = true;
    private bool shooting = true;
    private Mago mago;

    void Awake()
    {
        //playerT = GameObject.FindGameObjectWithTag("PlayerCuerpo").transform;
        poolProyectiles = GameObject.Find("PoolBolasHielo").GetComponent<Pool>();
        mago = GetComponent<Mago>();
    }
    void Update()
    {
        CadenciaDisparo();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (mago.SeePlayer())
            {
                Debug.DrawLine(spawnProyectil.position, other.gameObject.transform.position, Color.red);

                if (disparar && mago.GetStill())
                {
                    if (shooting)
                    {
                        GameObject objeto = poolProyectiles.GetPooledObject(spawnProyectil.position, spawnProyectil.rotation).gameObject;
                        disparos++;
                        shooting = false;
                    }
                }

            }
        }
    }
    public void CadenciaDisparo()
    {
        if (disparos == maxDisparos)
        {
            disparos -= disparos;
            disparar = false;
        }
        if (!disparar)
        {
            timer += Time.deltaTime;
        }
        if (timer > timeToShot)
        {
            timer -= timer;
            disparar = true;
        }
        if (disparar && !shooting)
        {
            timer2 += Time.deltaTime;
        }
        if (timer2 > timeBetweenShot)
        {
            timer2 -= timer2;
            shooting = true;
        }
    }
    public bool GetDisparar()
    {
        return disparar;
    }
}
