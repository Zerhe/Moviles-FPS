using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoDisparar : MonoBehaviour
{
    [SerializeField]
    private string namePool;
    private Pool poolProyectiles;
    [SerializeField]
    private Transform spawnProyectil;
    private Transform target;
    private float timer = 0;
    [SerializeField]
    private float timeToShot;
    private float disparos = 0;
    [SerializeField]
    private float maxDisparos;
    private bool disparar = true;
    private Mago mago;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("TargetEnemy").transform;
        poolProyectiles = GameObject.Find(namePool).GetComponent<Pool>();
        mago = GetComponent<Mago>();
    }
    void Update()
    {
        CadenciaDisparo();
        Debug.DrawLine(spawnProyectil.position, target.position, Color.red);
    }
    public void Disparar() //usada en evento de animacion
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
