using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Attribute : MonoBehaviour {

    [SerializeField]
    private string attribute;
	
	void Update () {
		
	}
    public string GetAttribute()
    {
        return attribute;
    }
    public void SetAttribute(string newAttribute)
    {
        attribute = newAttribute;
    }
    public float CalculateDamage(float attackDamageReceived, string attackAttributeReceived)
    {
        float finalDamage = attackDamageReceived;

        switch(attribute)
        {
            case "Hielo":
                switch(attackAttributeReceived)
                {
                    case "Fuego":
                        finalDamage = attackDamageReceived * 2;
                        break;
                    case "Viento":
                        finalDamage = attackDamageReceived / 2;
                        break;
                    default:
                        finalDamage = attackDamageReceived;
                        break;

                }
                break;
            case "Fuego":
                switch (attackAttributeReceived)
                {
                    case "Hielo":
                        finalDamage = attackDamageReceived / 2;
                        break;
                    case "Viento":
                        finalDamage = attackDamageReceived * 2;
                        break;
                    default:
                        finalDamage = attackDamageReceived;
                        break;
                }
                break;
            case "Viento":
                switch (attackAttributeReceived)
                {
                    case "Hielo":
                        finalDamage = attackDamageReceived * 2;
                        break;
                    case "Fuego":
                        finalDamage = attackDamageReceived / 2;
                        break;
                    default:
                        finalDamage = attackDamageReceived;
                        break;
                }
                break;
            case "Luz":
                switch (attackAttributeReceived)
                {
                    case "Luz":
                        finalDamage = attackDamageReceived / 2;
                        break;
                    case "Oscuridad":
                        finalDamage = attackDamageReceived * 2;
                        break;
                    default:
                        finalDamage = attackDamageReceived;
                        break;
                }
                break;
            case "Oscuridad":
                switch (attackAttributeReceived)
                {
                    case "Luz":
                        finalDamage = attackDamageReceived * 2;
                        break;
                    case "Oscuridad":
                        finalDamage = attackDamageReceived / 2;
                        break;
                    default:
                        finalDamage = attackDamageReceived;
                        break;
                }
                break;
        }
        return finalDamage;
    }
}
