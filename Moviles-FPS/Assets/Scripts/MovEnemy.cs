using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemy : MonoBehaviour {

    [SerializeField]
    private float velMov;
    [SerializeField]
    private Transform playerTransform;
    private Vector3 positionToMove;

	void Start () {
        positionToMove = Vector3.zero;
	}
	
	void Update ()
    {
        if (transform.position.x > playerTransform.position.x +5)
            positionToMove.x = -1;
        else if (transform.position.x < playerTransform.position.x +5)
            positionToMove.x = 1;
        if (transform.position.z > playerTransform.position.z)
            positionToMove.z = -1;
        else if (transform.position.z < playerTransform.position.z)
            positionToMove.z = 1;


        transform.Translate(positionToMove * Time.deltaTime * velMov);
	}
}
