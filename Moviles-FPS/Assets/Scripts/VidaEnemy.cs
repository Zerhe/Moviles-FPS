using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform barraVidaT;
    private Vector3 scaleVida;
    private Animator anim;
    public float cantVida;
    public float maxVida;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        cantVida = maxVida;
        scaleVida = Vector3.one;
    }

    void Update()
    {
        scaleVida.x = cantVida / maxVida;
        barraVidaT.localScale = scaleVida;
        if (cantVida <= 0)
        {
            barraVidaT.parent.gameObject.SetActive(false);
            anim.SetBool("Die", true);
        }
    }
    public void RecibirDanio(float danio)
    {
        cantVida -= danio;
    }
    public void Die()
    {
        cantVida = maxVida;
        anim.SetBool("Die", false);
        gameObject.SetActive(false);
    }
}
