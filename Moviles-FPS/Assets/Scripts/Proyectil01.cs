using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil01 : Proyectil {

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
    public override void Activarse(Vector3 pos, Quaternion rot)
    {
        gameObject.transform.position = pos;
        gameObject.transform.rotation = rot;
        rgb.Sleep();
        gameObject.SetActive(true);

    }
    public override void Desactivarse()
    {
        timer -= timer;
        gameObject.SetActive(false);
    }
    public override void AddVelocity()
    {
        rgb.AddRelativeForce(Vector3.up * vel, ForceMode.VelocityChange);
    }
}
