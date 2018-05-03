using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil01 : MonoBehaviour {

    private Rigidbody rgb;
    [SerializeField]
    private float vel;
    private float timer;

    void Awake()
    {
        rgb = GetComponent<Rigidbody>();
    }
    void Start () {
        timer = 0;
	}
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
            Desactivarse();
    }
    void OnCollisionEnter(Collision coll)
    {
        Desactivarse();
    }
    public void Desactivarse()
    {
        timer = 0;
        gameObject.SetActive(false);
    }
    public void Activarse(Vector3 pos, Quaternion rot)
    {
        gameObject.transform.position = pos;
        gameObject.transform.rotation = rot;
        rgb.Sleep();
        gameObject.SetActive(true);

    }
    public void AddVelocity()
    {
        rgb.AddRelativeForce(Vector3.up * vel, ForceMode.VelocityChange);
    }
}
