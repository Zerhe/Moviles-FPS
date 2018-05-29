using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego : Proyectil {

    [SerializeField]
    private float vel;
    private float timer = 0;
    private Rigidbody rgb;
    private PoolObject po;

    protected void Awake ()
    {
        rgb = GetComponent<Rigidbody>();
        po = GetComponent<PoolObject>();
    }
    void Update () {
        timer += Time.deltaTime;
        if (timer > 2)
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
    protected void OnDisable()
    {
        if (po)
        po.Recycle();
        timer -= timer;

    }
}
