using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : Proyectil {

    [SerializeField]
    private float vel;
    private float timer = 0;
    private float timeAlive = 2;
    private Rigidbody rgb;

    protected void Awake ()
    {
        rgb = GetComponent<Rigidbody>();
        danio = 10;
    }
    void Update ()
    {
        timer += Time.deltaTime;
        if (timer > timeAlive)
            gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision coll)
    {
        gameObject.SetActive(false);
    }
    public override void AddVelocity()
    {
        rgb.AddRelativeForce(Vector3.up * vel, ForceMode.VelocityChange);
    }
    protected void OnEnable()
    {
        rgb.Sleep();
        AddVelocity();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        timer -= timer;
    }
}