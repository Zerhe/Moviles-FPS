using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour {

    private bool abrir;
    [SerializeField]
    private float vel;

    private void Start()
    {
        abrir = false;
    }
    private void Update()
    {
        print(abrir);

        if (abrir && transform.position.y < 7)
        {
            transform.Translate(Vector3.up * Time.deltaTime * vel);

        }
        if (!abrir && transform.position.y > 2.48)
        {
            transform.Translate(Vector3.down * Time.deltaTime * vel);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            abrir = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            abrir = false;
        }
    }
}
