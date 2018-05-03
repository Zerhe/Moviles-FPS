using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotPlayer : MonoBehaviour {

    private string rotXButton;
    private string rotYButton;
    [SerializeField]
    private float velRot;

    void Start () {
        rotXButton = "MouseX";
        rotYButton = "MouseY";
	}
	
	void Update () {
        if (Input.GetAxis(rotXButton) > 0)
            transform.Rotate(Vector3.up * Time.deltaTime * velRot);
        else if (Input.GetAxis(rotXButton) < 0)
            transform.Rotate(Vector3.down * Time.deltaTime * velRot, Space.World);

        /*if (Input.GetAxis(rotYButton) > 0)
            transform.Rotate(Vector3.left * Time.deltaTime * velRot, Space.World);
        else if (Input.GetAxis(rotYButton) < 0)
            transform.Rotate(Vector3.right * Time.deltaTime * velRot, Space.World);*/
    }
}
