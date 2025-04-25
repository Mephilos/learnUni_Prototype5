using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1.0f;
    private bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTargets()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);

            if(gameOver)
            {
                break;
            }
        }
    }
}
