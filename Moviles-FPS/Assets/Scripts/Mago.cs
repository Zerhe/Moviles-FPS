using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mago : MonoBehaviour
{
    private VidaEnemy vida;
    private Animator anim;
    private NavMeshAgent agent;
    private MagoDisparar attack;
    private LookAtPlayer lookPlayer;
    private float timeMove = 0.1f;
    private bool still = false;

    private void Awake()
    {
        vida = GetComponent<VidaEnemy>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<MagoDisparar>();
        lookPlayer = GetComponent<LookAtPlayer>();
    }
    private void Start()
    {
        //agent.isStopped = true;
    }
    private void Update()
    {
        if (agent.velocity.x > timeMove ||
            agent.velocity.z > timeMove || 
            agent.velocity.x < -timeMove ||
            agent.velocity.z < -timeMove)
        {
            still = false;
            anim.SetBool("Move", true);
        }
        else
        {
            still = true;
            anim.SetBool("Move", false);
        }
        if (attack.GetDisparar() && still)
        {
            anim.SetBool("Attack", true);
        }
        else
            anim.SetBool("Attack", false);

    }
    public bool GetStill()
    {
        return still;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Proyectil")
        {
            float danio = collision.gameObject.GetComponent<Proyectil>().GetDanio();
            vida.RecibirDanio(danio);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lookPlayer.enabled = true;
            agent.isStopped = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lookPlayer.enabled = false;
            agent.isStopped = true;
        }
    }*/
}
