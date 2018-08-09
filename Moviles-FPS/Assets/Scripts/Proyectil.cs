using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField]
    private float vel;
    [SerializeField]
    private float danio;
    private float timer = 0;
    [SerializeField]
    private float range;
    private Rigidbody rgb;

    protected void Awake()
    {
        rgb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > range)
            gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision coll)
    {
        gameObject.SetActive(false);
    }
    public void AddVelocity(Vector3 direccion)
    {
        rgb.AddForce(direccion * vel, ForceMode.VelocityChange);
    }
    public float GetDanio()
    {
        return danio;
    }
    protected void OnEnable()
    {
        rgb.Sleep();
    }
    public void OnDisable()
    {
        timer -= timer;
    }
}
