using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : Proyectil {

    [SerializeField]
    private float vel;
    private float timer = 0;
    private Rigidbody rgb;

    void Awake () {
        rgb = GetComponent<Rigidbody>();
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
        base.Activarse(pos, rot);
        rgb.Sleep();
    }
    public override void Desactivarse()
    {
        base.Desactivarse();
        timer -= timer;
    }
    public override void AddVelocity()
    {
        rgb.AddRelativeForce(Vector3.up * vel, ForceMode.VelocityChange);
    }
}
