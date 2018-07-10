using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotObject : MonoBehaviour {
    [SerializeField]
    private float velRot;
    [SerializeField]
    private Vector3 vectorRotar;
    private float multi = 10;
	void Start () {
	}
	
	void Update () {
        transform.Rotate(vectorRotar * Time.deltaTime * (velRot * multi));
	}
}
