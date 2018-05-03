using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && transform.position.y < 40)
        {
            print("asdd");
            transform.Translate(Vector3.up * Time.deltaTime * 3);
        }
    }
    private void OnTriggerExit(Collider other)
    {
            transform.Translate(Vector3.down * Time.deltaTime * 5);

    }
}
