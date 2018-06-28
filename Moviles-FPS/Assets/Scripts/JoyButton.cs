using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool pressed = false;
    private void Start()
    {
#if UNITY_STANDALONE_WIN
        gameObject.SetActive(false);
#endif
    }
    public bool GetPressed()
    {
        return pressed;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
