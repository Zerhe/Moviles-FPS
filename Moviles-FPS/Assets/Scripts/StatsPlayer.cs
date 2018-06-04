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
            mana += 0.5f;
        if (vida <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Honguito")
        {
            vida--;
        }
    }
}
