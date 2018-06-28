using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honguito : MonoBehaviour
{
    [SerializeField]
    float ataque;
    float timer = 0;
    float TiempoAtacar = 0.8f;
    VidaEnemy vida;
    Animator anim;
    StatsPlayer statsP;

    private void Awake()
    {
        vida = GetComponent<VidaEnemy>();
        anim = GetComponent<Animator>();
        statsP = GameObject.FindGameObjectWithTag("PlayerCuerpo").GetComponent<StatsPlayer>();
    }
    private void Update()
    {     
        if (timer > TiempoAtacar)
        {
            statsP.RecibirDanio(ataque);
            timer -= timer;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Proyectil")
        {
            print("MeDañaron");
            float danio = other.gameObject.GetComponent<Proyectil>().GetDanio();
            vida.RecibirDanio(danio);
        }
        if (other.gameObject.tag == "Player")
        {
            timer -= timer;
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
    
}
