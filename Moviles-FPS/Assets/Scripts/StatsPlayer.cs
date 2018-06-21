using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    public float maxVida;
    public float vida;
    public float maxMana;
    public float mana;
    [SerializeField]
    private Slider barraVida;
    [SerializeField]
    private Slider barraMana;
    [SerializeField]
    private GameObject escudo;
    [SerializeField]
    private float regeMana;

    private void Start()
    {
        vida = maxVida;
        mana = maxMana;
    }
    void Update()
    {
        barraVida.value = vida;
        barraMana.value = mana;
        if (mana < maxMana)
            mana += regeMana;
        if (vida <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Honguito")
        {
            //RecibirDanio(2);
        }
    }
    public void RecibirDanio(float danio)
    {
        if (escudo.activeInHierarchy)
            mana -= danio*2;
        else
            vida -= danio;

    }
}
