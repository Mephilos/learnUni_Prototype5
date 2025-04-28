
//using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    public int targetValue = 0;
    private float maxForce = 16.0f;
    private float minForce = 12.0f;
    private float randomTorque = 6.0f;
    private float randomSpawnPosX = 4.0f;
    private float spawnPosY = 0.0f;
    public ParticleSystem boomParticle;
    private Rigidbody targetRb;
    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = gameObject.GetComponent<Rigidbody>();
        targetRb.AddForce(FireForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(boomParticle, transform.position, transform.rotation);
        if(!gameManager.isGameOver)
        {
            gameManager.UpdateScore(targetValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.gameOverText.gameObject.SetActive(true);
            gameManager.GameOver();
        }
    }
}
