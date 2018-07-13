using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoDisparar : MonoBehaviour
{

    private Pool poolProyectiles;
    [SerializeField]
    private Transform spawnProyectil;
    [SerializeField]
    private Transform target;
    private float timer = 0;
    [SerializeField]
    private float timeToShot;
    [SerializeField]
    private float disparos = 0;
    [SerializeField]
    private float maxDisparos;
    private bool disparar = true;
    private Mago mago;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("TargetEnemy").transform;
        poolProyectiles = GameObject.Find("PoolBolasHielo").GetComponent<Pool>();
        mago = GetComponent<Mago>();
    }
    void Update()
    {
        CadenciaDisparo();
        Debug.DrawLine(spawnProyectil.position, target.position, Color.red);
    }
    public void Disparar()
    {        
        GameObject objeto = poolProyectiles.GetPooledObject(spawnProyectil.position, spawnProyectil.rotation).gameObject;
        objeto.GetComponent<Proyectil>().AddVelocity(Direction.CalculateDirection(target.position, spawnProyectil.position));
        disparos++;
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
    }
    public bool GetDisparar()
    {
        return disparar;
    }
}
