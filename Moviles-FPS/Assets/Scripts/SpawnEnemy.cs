using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    [SerializeField]
    private Pool poolEnemy;
    [SerializeField]
    private Transform posSpawn01;
    [SerializeField]
    private Transform posSpawn02;
    [SerializeField]
    private Transform posSpawn03;
    private bool spawn = false;
    private float timer = 0;
    private float cantSpawn = 0;

    private void Update()
    {
        if (spawn)
            timer += Time.deltaTime;
        if (timer > 2)
        {
            poolEnemy.GetPooledObject(RandomPosition(), Quaternion.identity);
            cantSpawn++;
            timer -= timer;
        }
        if (cantSpawn == poolEnemy.Count)
            spawn = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            spawn = true;
        }
    }
    Vector3 RandomPosition()
    {
        Vector3 randomPosition;
        switch(Random.Range(1,4))
        {
            case 1:
                randomPosition = posSpawn01.position;
                break;
            case 2:
                randomPosition = posSpawn02.position;
                break;
            default:
                randomPosition = posSpawn03.position;
                break;
        }
        return randomPosition;
    }
}
