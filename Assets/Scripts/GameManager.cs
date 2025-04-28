using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;




public class GameManager : MonoBehaviour
{
    private int score;
    
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public float spawnRate = 1.0f;
    public bool isGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        isGameOver = false;
        StartCoroutine(SpawnTargets());
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTargets()
    {
        while(!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        isGameOver = true;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
