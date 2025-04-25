
//using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    private float maxForce = 16.0f;
    private float minForce = 12.0f;
    private float randomTorque = 10.0f;
    private float randomSpawnPosX = 4.0f;
    private float spawnPosY = 6.0f;
    private Rigidbody targetRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = gameObject.GetComponent<Rigidbody>();
        targetRb.AddForce(FireForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 FireForce()
    {
        return Vector3.up * Random.Range(minForce,maxForce);
    }
    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-randomTorque,randomTorque),
                           Random.Range(-randomTorque,randomTorque),
                           Random.Range(-randomTorque,randomTorque));
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3 (Random.Range(-randomSpawnPosX, randomSpawnPosX), spawnPosY);
    }
}
