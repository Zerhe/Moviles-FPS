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
    [SerializeField]
    Transform moveT;
    private CharacterController charCon;
    [SerializeField]
    private Joystick moveJoystick;

    private void Awake()
    {
        charCon = GetComponent<CharacterController>();
    }
    void Start () {
        moveXButton = "Horizontal";
        moveYButton = "Vertical";
	}
	
	void Update ()
    {
#if UNITY_STANDALONE_WIN

        if (Input.GetAxis(moveXButton) > 0)
            charCon.Move(moveT.right * Time.deltaTime * velMov);
        else if (Input.GetAxis(moveXButton) < 0)
            charCon.Move(-moveT.right * Time.deltaTime * velMov);

        if (Input.GetAxis(moveYButton) > 0)
            charCon.Move(moveT.forward * Time.deltaTime * velMov);
        else if (Input.GetAxis(moveYButton) < 0)
            charCon.Move(-moveT.forward * Time.deltaTime * velMov);
#endif
#if UNITY_ANDROID

        if (moveJoystick.Horizontal > 0)
            charCon.Move(moveT.right * Time.deltaTime * velMov);
        else if (moveJoystick.Horizontal < 0)
            charCon.Move(-moveT.right * Time.deltaTime * velMov);

        if (moveJoystick.Vertical > 0)
            charCon.Move(moveT.forward * Time.deltaTime * velMov);
        else if (moveJoystick.Vertical < 0)
            charCon.Move(-moveT.forward * Time.deltaTime * velMov);

#endif
        charCon.Move(Vector3.down * Time.deltaTime * gravity);
    }
}
