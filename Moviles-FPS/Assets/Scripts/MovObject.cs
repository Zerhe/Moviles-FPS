using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovObject : MonoBehaviour
{
    [SerializeField]
    private float velMov;
    [SerializeField]
    private float rangoMov;
    [SerializeField]
    private Vector3 vectorMover;
    private Vector3 positioniInicial;
    private bool movPos;
    private bool movneg;

    void Start()
    {
        positioniInicial = transform.position;
        movPos = true;
        movneg = false;
    }
    void Update()
    {
        if (vectorMover.x != 0)
        {
            if (transform.position.x < positioniInicial.x - rangoMov)
            {
                movPos = true;
                movneg = false;
            }
            else if (transform.position.x > positioniInicial.x + rangoMov)
            {
                movPos = false;
                movneg = true;
            }
        }
        else if (vectorMover.y != 0)
        {
            if (transform.position.y < positioniInicial.y - rangoMov)
            {
                movPos = true;
                movneg = false;
            }
            else if (transform.position.y > positioniInicial.y + rangoMov)
            {
                movPos = false;
                movneg = true;
            }
        }
        else if (vectorMover.z != 0)
        {
            if (transform.position.z < positioniInicial.z - rangoMov)
            {
                movPos = true;
                movneg = false;
            }
            else if (transform.position.z > positioniInicial.z + rangoMov)
            {
                movPos = false;
                movneg = true;
            }
        }
        if (movPos)
            transform.Translate(vectorMover * Time.deltaTime * velMov);
        else if (movneg)
            transform.Translate(vectorMover * Time.deltaTime * -velMov);
    }
}
