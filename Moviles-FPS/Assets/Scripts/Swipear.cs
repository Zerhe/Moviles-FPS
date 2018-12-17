using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems;

public class Swipear : MonoBehaviour {

    private Touch initTouch = new Touch();
    GameObject character;
    float rotX = 0f;
    float rotY = 0f;
    Vector3 origRot;
    [SerializeField]
    float rotSpeed;
    [SerializeField]
    float dir;
    bool swipe = false;

#if UNITY_ANDROID
    private void Awake()
    {
        //cam = GetComponent<Camera>();
    }
    void Start ()
    {		
        origRot = transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
        character = this.transform.parent.gameObject;
    }
    private void FixedUpdate()
    {
        foreach (Touch touch in Input.touches)
        {
            //int pointerID = touch.fingerId;
            //if(EventSystem.current.IsPointerOverGameObject(pointerID))
            //{
            //    return;
            //}

            if(touch.phase == TouchPhase.Began && touch.position.x > Screen.width/2)
            {
                initTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved && touch.position.x > Screen.width / 2)
            {
                if(swipe)
                {
                    float deltaX = initTouch.position.x - touch.position.x;
                    float deltaY = initTouch.position.y - touch.position.y;
                    rotX -= deltaY * Time.deltaTime * rotSpeed * dir;
                    rotY += deltaX * Time.deltaTime * rotSpeed * dir;
                    rotX = Mathf.Clamp(rotX, -80, 80);
                    transform.eulerAngles = new Vector3(rotX, rotY, 0f);
                    character.transform.eulerAngles = new Vector3(0f, rotY, 0f);
                }
            }
            else if (touch.phase == TouchPhase.Ended && touch.position.x > Screen.width / 2)
            {
                initTouch = new Touch();
            }
        }
    }
    public void SetSwipe(bool val)
    {
        swipe = val;
    }
#endif
}
