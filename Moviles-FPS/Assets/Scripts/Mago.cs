﻿using System.Collections;
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
    private Transform target;
    [SerializeField]
    private Transform magoEyesT;
    private RaycastHit infColi;
    private float timeMove = 0.1f;
    private bool still = false;
    private bool collPlayer = false;

    private void Awake()
    {
        vida = GetComponent<VidaEnemy>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        attack = GetComponent<MagoDisparar>();
        lookPlayer = GetComponent<LookAtPlayer>();
        target = GameObject.FindGameObjectWithTag("TargetEnemy").transform;
    }
    private void Start()
    {
        agent.isStopped = true;
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
        if (attack.GetDisparar() && still && collPlayer && SeePlayer())
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
    public bool SeePlayer()
    {
        int layerMask = 1 << 2;
        layerMask = ~layerMask;

        if (Physics.Linecast(magoEyesT.position, target.position, out infColi, layerMask))
        {
            if (infColi.collider.gameObject.tag == "PlayerCuerpo")
            {
                Debug.DrawLine(magoEyesT.position, target.position, Color.blue);
                return true;
            }
        }
        return false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Proyectil")
        {
            float damage = collision.gameObject.GetComponent<Proyectil>().GetDanio();
            string damageAttribute = collision.gameObject.GetComponent<Attribute>().GetAttribute();
            vida.RecibirDanio(damage, damageAttribute);
            if (agent.isStopped)
            {
                lookPlayer.enabled = true;
                agent.isStopped = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            collPlayer = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SeePlayer() && agent.isStopped)
            {
                lookPlayer.enabled = true;
                agent.isStopped = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collPlayer = false;
            lookPlayer.enabled = false;
            agent.isStopped = true;
        }
    }
}
