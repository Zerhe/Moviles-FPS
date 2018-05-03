using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    private string moveXButton;
    private string moveYButton;
    [SerializeField]
    private float velMov;

    void Start () {
        moveXButton = "Horizontal";
        moveYButton = "Vertical";
	}
	
	void Update () {
        if (Input.GetAxis(moveXButton) > 0)
            transform.Translate(Vector3.right * Time.deltaTime * velMov);
        else if (Input.GetAxis(moveXButton) < 0)
            transform.Translate(Vector3.left * Time.deltaTime * velMov);

        if (Input.GetAxis(moveYButton) > 0)
            transform.Translate(Vector3.forward * Time.deltaTime * velMov);
        else if (Input.GetAxis(moveYButton) < 0)
            transform.Translate(Vector3.back * Time.deltaTime * velMov);
    }
}
