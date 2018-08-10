using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;
    [SerializeField]
    private Image[] weaponImages;
    [SerializeField]
    private Sprite[] weaponSprites;
    private Attribute playerAttribute;
    private bool[] haveWeapon = new bool[5];
    private string[] weaponInput = new string[5];

    private void Awake()
    {
        playerAttribute = GetComponent<Attribute>();
    }
    void Start()
    {
        for (int i = 0; i < weaponInput.Length; i++)
        {
            weaponInput[i] = "Weapon0" + (i + 1);
        }
        for (int i = 0; i < haveWeapon.Length; i++)
        {
            haveWeapon[i] = true;
        }
    }

    void Update()
    {
        for(int i = 0; i < haveWeapon.Length; i++)
        {
            if (haveWeapon[i])
            {
                weaponImages[i].sprite = weaponSprites[i];
            }
        }
#if UNITY_STANDALONE_WIN

        for (int i = 0; i < weapons.Length; i++)
        {
            if (Input.GetButtonDown(weaponInput[i]) && haveWeapon[i])
            {
                DesactiveWeapons();
                weapons[i].SetActive(true);
                playerAttribute.SetAttribute(weapons[i].GetComponent<Attribute>().GetAttribute());
            }
        }
#endif
    }
    public void ChangeWeapon(int num)
    {
        DesactiveWeapons();
        weapons[num].SetActive(true);
        playerAttribute.SetAttribute(weapons[num].GetComponent<Attribute>().GetAttribute());
    }
    public void DesactiveWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }
}
