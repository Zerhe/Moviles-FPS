using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honguito : Enemy
{
    VidaEnemy vida;
    Animator anim;
    StatsPlayer statsP;
    float timer = 0;
    [SerializeField]
    float danio;

    private void Awake()
    {
        vida = GetComponent<VidaEnemy>();
        anim = GetComponent<Animator>();
        statsP = GameObject.FindGameObjectWithTag("PlayerCuerpo").GetComponent<StatsPlayer>();
    }
    private void Update()
    {
        if (vida.cantVida <= 0)
        {
            gameObject.SetActive(false);
        }
        if (timer > 0.8)
        {
            statsP.RecibirDanio(danio);
            timer -= timer;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Proyectil")
        {
            print("MeDañaron");
            vida.cantVida--;
        }
        if (other.gameObject.tag == "Player")
        {
            timer = 0;
            anim.SetBool("Atacar", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Atacar", false);
        }
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        vida.cantVida = vida.maxVida;
    }
}
