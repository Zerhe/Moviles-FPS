using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsPlayer : MonoBehaviour
{
    private Attribute attribute;
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
    private Slider fondoBarraVida;
    [SerializeField]
    private Slider fondoBarraMana;
    private int silverKeys;
    [SerializeField]
    private Text textSilverKey;
    private int goldKeys;
    [SerializeField]
    private Text textGoldKey;
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

    private void Awake()
    {
        attribute = GetComponent<Attribute>();
    }
    private void Start()
    {
        vida = maxVida;
        mana = maxMana;
    }
    void Update()
    {
        barraVida.value = vida;
        barraMana.value = mana;
        fondoBarraVida.value = maxVida;
        fondoBarraMana.value = maxMana;

        textSilverKey.text = "= " + silverKeys;
        textGoldKey.text = "= " + goldKeys;

        RegenerarMana();
        if (vida > maxVida)
            vida = maxVida;
        if (vida <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public float GetMana()
    {
        return mana;
    }
    public void SumMana(float value)
    {
        mana += value;
    }
    public void SumMaxMana(float value)
    {
        maxMana += value;
    }
    public void SumVida(float value)
    {
        vida += value;
    }
    public void SumMaxVida(float value)
    {
        maxVida += value;
    }
    public float GetSilverKeys()
    {
        return silverKeys;
    }
    public void SumSilverKeys(int cant)
    {
        silverKeys += cant;
    }
    public float GetGoldKeys()
    {
        return goldKeys;
    }
    public void SumGoldenKeys(int cant)
    {
        goldKeys += cant;
    }
    public void RecibirDanio(float damage, string damageAttribute)
    {
        float finalDamage = attribute.CalculateDamage(damage, damageAttribute);
        if (escudo.activeInHierarchy)
            RestarMana(finalDamage * 2);
        else
            vida -= finalDamage;
        print(attribute.GetAttribute());
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
            //print("MeDañaron");
            float damage = collision.gameObject.GetComponent<Proyectil>().GetDanio();
            string damageAttribute = collision.gameObject.GetComponent<Attribute>().GetAttribute();
            RecibirDanio(damage, damageAttribute);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SilverKey")
        {
            silverKeys++;
            print(silverKeys);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "GodKeys")
        {
            goldKeys++;
            print(goldKeys);
            other.gameObject.SetActive(false);
        }
    }
}
