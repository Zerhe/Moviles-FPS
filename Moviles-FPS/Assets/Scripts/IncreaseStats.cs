using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStats : MonoBehaviour
{

    private enum Stats
    {
        Vida, Mana, MaxVida, MaxMana
    }
    private StatsPlayer statsPlayer;
    [SerializeField]
    private Stats statIncrease;
    [SerializeField]
    private float valueIncrease;

    private void Awake()
    {
        statsPlayer = GameObject.FindGameObjectWithTag("PlayerCuerpo").GetComponent<StatsPlayer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerCuerpo")
        {
            print("asd");
            switch((int)statIncrease)
            {
                case 0:
                    statsPlayer.SumVida(valueIncrease);
                    gameObject.SetActive(false);
                    break;
                case 1:
                    statsPlayer.SumMana(valueIncrease);
                    gameObject.SetActive(false);
                    break;
                case 2:
                    statsPlayer.SumMaxVida(valueIncrease);
                    gameObject.SetActive(false);
                    break;
                default:
                    statsPlayer.SumMaxMana(valueIncrease);
                    gameObject.SetActive(false);
                    break;
            }
        }
    }
}
