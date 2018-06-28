using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad : MonoBehaviour
{
    StatsPlayer stats;
    [SerializeField]
    GameObject go;
    private string habilidadButton = "Habilidad";
    [SerializeField]
    private JoyButton skillJoyButton;

    void Awake()
    {
        stats = GetComponent<StatsPlayer>();
    }
    void Update()
    {
#if UNITY_STANDALONE_WIN

        if (Input.GetButton(habilidadButton) && stats.GetMana() > 0)
        {
            go.SetActive(true);
        }
        else if (Input.GetButtonUp(habilidadButton))
        {
            go.SetActive(false);
        }
#endif
#if UNITY_ANDROID

        if (skillJoyButton.GetPressed() && stats.GetMana() > 0)
        {
            go.SetActive(true);
        }
        else if (!skillJoyButton.GetPressed())
        {
            go.SetActive(false);
        }
#endif

        if (stats.GetMana() < 0)
            go.SetActive(false);
    }
}
