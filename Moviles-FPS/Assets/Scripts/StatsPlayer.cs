using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    [SerializeField]
    private float maxVida;
    private float vida;
    [SerializeField]
    private float maxMana;
    private float mana;
    [SerializeField]
    private Slider barraVida;
    [SerializeField]
    private Slider barraMana;
    [SerializeField]
    private GameObject escudo;
    [SerializeField]
    private float cantManaRege;
    [SerializeField]
    private float timeToReneMana;
    private float timerRegeMana;
    private bool regeMana = false;
    private bool regeManaTimer = true;
    private bool breakRegeMana = false;

    private void Start()
    {
        vida = maxVida;
        mana = maxMana;
    }
    void Update()
    {
        barraVida.value = vida;
        barraMana.value = mana;
        RegenerarMana();
        if (vida <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public float GetMana()
    {
        return mana;
    }
    public void RecibirDanio(float danio)
    {
        if (escudo.activeInHierarchy)
            RestarMana(danio * 2);
        else
            vida -= danio;

    }
    public void RestarMana(float cant)
    {
        mana -= cant;
        breakRegeMana = true;
    }
    public void RegenerarMana()
    {
        if (mana < maxMana && regeManaTimer)
            timerRegeMana += Time.deltaTime;

        if (timerRegeMana > timeToReneMana)
        {
            timerRegeMana -= timerRegeMana;
            regeManaTimer = false;
            regeMana = true;
        }

        if (regeMana)
            mana += cantManaRege;
        if (mana > maxMana)
            mana = maxMana;
        if (mana == maxMana || breakRegeMana)
        {
            regeMana = false;
            regeManaTimer = true;
            breakRegeMana = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Proyectil")
        {
            print("MeDañaron");
            float danio = collision.gameObject.GetComponent<Proyectil>().GetDanio();
            RecibirDanio(danio);
        }
    }
}
