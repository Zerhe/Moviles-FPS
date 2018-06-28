using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoDisparar : MonoBehaviour
{

    private Pool poolProyectiles;
    [SerializeField]
    private Transform spawnProyectil;
    private RaycastHit infColi;
    private Transform playerT;
    private float timer = 0;
    [SerializeField]
    private float waitTimeShoot;
    private float disparos = 0;
    [SerializeField]
    private float maxDisparos;
    private bool disparar = true;
    private Mago mago;

    void Awake()
    {
        playerT = GameObject.FindGameObjectWithTag("PlayerCuerpo").transform;
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
            if (Physics.Linecast(spawnProyectil.position, playerT.position, out infColi))
            {
                Debug.DrawLine(spawnProyectil.position, playerT.position, Color.red);

                if (infColi.collider.gameObject.tag == "PlayerCuerpo")
                {
                    if (disparar && mago.GetStill())
                    {
                        GameObject objeto = poolProyectiles.GetPooledObject(spawnProyectil.position, spawnProyectil.rotation).gameObject;
                        disparos++;
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
        if (timer > waitTimeShoot)
        {
            timer -= timer;
            disparar = true;
        }
    }
    public bool GetDisparar()
    {
        return disparar;
    }
}
