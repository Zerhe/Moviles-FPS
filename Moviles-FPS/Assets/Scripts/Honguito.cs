using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honguito : Enemy
{
    VidaEnemy vida;

    private void Awake()
    {
        vida = GetComponent<VidaEnemy>();
    }
    private void Update()
    {
        if (vida.cantVida <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Proyectil")
        {
            print("MeDañaron");
            vida.cantVida--;
        }
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        vida.cantVida = vida.maxVida;
    }
}
