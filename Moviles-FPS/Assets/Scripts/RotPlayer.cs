using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotPlayer : MonoBehaviour
{

    private string rotXButton;
    private string rotYButton;
    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float smoothing;
    Vector2 mouseLook;
    Vector2 smoothV;
    GameObject character;
    [SerializeField]
    private Joystick rotJoystick;

    void Start()
    {
        rotXButton = "MouseX";
        rotYButton = "MouseY";

        character = this.transform.parent.gameObject;
    }

    void FixedUpdate()
    {
#if UNITY_STANDALONE_WIN
        Vector2 md = new Vector2(Input.GetAxisRaw(rotXButton), Input.GetAxisRaw(rotYButton));
#endif
#if UNITY_ANDROID
        Vector2 md = new Vector2(rotJoystick.Horizontal, rotJoystick.Vertical);
#endif
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
