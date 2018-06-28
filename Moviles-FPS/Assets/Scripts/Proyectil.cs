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
    private float timeAlive;
    private Rigidbody rgb;

    protected void Awake()
    {
        rgb = GetComponent<Rigidbody>();
        danio = 10;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeAlive)
            gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision coll)
    {
        gameObject.SetActive(false);
    }
    public void AddVelocity()
    {
        rgb.AddRelativeForce(Vector3.forward * vel, ForceMode.VelocityChange);
    }
    public float GetDanio()
    {
        return danio;
    }
    protected void OnEnable()
    {
        rgb.Sleep();
        AddVelocity();
    }
    public void OnDisable()
    {
        timer -= timer;
    }
}
