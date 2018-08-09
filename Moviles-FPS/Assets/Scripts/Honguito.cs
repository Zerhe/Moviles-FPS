using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honguito : MonoBehaviour
{
    [SerializeField]
    private float ataque;
    private bool collPlayer = false;
    private VidaEnemy vida;
    private Animator anim;
    private StatsPlayer statsP;

    private void Awake()
    {
        vida = GetComponent<VidaEnemy>();
        anim = GetComponent<Animator>();
        statsP = GameObject.FindGameObjectWithTag("PlayerCuerpo").GetComponent<StatsPlayer>();
    }
    private void Update()
    {

    }
    public void DamagePlayer()
    {
        if (collPlayer)
        {
            string attribute = GetComponent<Attribute>().GetAttribute();
            print(attribute);
            statsP.RecibirDanio(ataque, attribute);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Proyectil")
        {
            //print("MeDañaron");
            float damage = other.gameObject.GetComponent<Proyectil>().GetDanio();
            string damageAttribute = other.gameObject.GetComponent<Attribute>().GetAttribute();
            vida.RecibirDanio(damage, damageAttribute);
        }
        if (other.gameObject.tag == "Player")
        {
            collPlayer = true;
            anim.SetBool("Attack", true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collPlayer = false;
            anim.SetBool("Attack", false);
        }
    }

}
