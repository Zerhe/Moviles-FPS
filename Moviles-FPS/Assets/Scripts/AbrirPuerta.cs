using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour {

    private bool abrir;
    [SerializeField]
    private float vel;
    [SerializeField]
    private float maxAlto = 7;
    [SerializeField]
    private float maxBajo = 0;

    private void Start()
    {
        abrir = false;
        maxAlto += transform.position.y;
        maxBajo += transform.position.y;

    }
    private void Update()
    {
        if (abrir && transform.position.y < maxAlto)
        {
            transform.Translate(Vector3.up * Time.deltaTime * vel);

        }
        if (!abrir && transform.position.y > maxBajo)
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
