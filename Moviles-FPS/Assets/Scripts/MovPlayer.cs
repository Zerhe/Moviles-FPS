using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    private string moveXButton;
    private string moveYButton;
    [SerializeField]
    private float velMov;
    [SerializeField]
    private float gravity;
    CharacterController charCon;
    [SerializeField]
    Transform moveT;

    private void Awake()
    {
        charCon = GetComponent<CharacterController>();
    }
    void Start () {
        moveXButton = "Horizontal";
        moveYButton = "Vertical";
	}
	
	void Update () {
        if (Input.GetAxis(moveXButton) > 0)
            charCon.Move(moveT.right * Time.deltaTime * velMov);
        else if (Input.GetAxis(moveXButton) < 0)
            charCon.Move(-moveT.right * Time.deltaTime * velMov);

        if (Input.GetAxis(moveYButton) > 0)
            charCon.Move(moveT.forward * Time.deltaTime * velMov);
        else if (Input.GetAxis(moveYButton) < 0)
            charCon.Move(-moveT.forward * Time.deltaTime * velMov);
        charCon.Move(Vector3.down * Time.deltaTime * gravity);
    }
}
