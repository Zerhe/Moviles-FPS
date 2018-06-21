using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad : MonoBehaviour
{
    StatsPlayer stats;
    [SerializeField]
    GameObject go;
    private string habilidadButton = "Habilidad";

    void Awake()
    {
        stats = GetComponent<StatsPlayer>();
    }
    void Update()
    {
        if (Input.GetButton(habilidadButton) && stats.mana > 0)
        {
            go.SetActive(true);
        }
        else if (Input.GetButtonUp(habilidadButton))
        {
            go.SetActive(false);
        }
        if (stats.mana < 0)
            go.SetActive(false);
    }
}
