using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform barraVidaT;
    private Vector3 scaleVida;
    public float cantVida;
    public float maxVida;

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
            gameObject.SetActive(false);
        }
    }
    public void RecibirDanio(float danio)
    {
        cantVida -= danio;
    }
    public void OnDisable()
    {
        cantVida = maxVida;
    }
}
