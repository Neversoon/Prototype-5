using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public bool isGameActive;
    public Button restartButton; 
     public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void GameOver(){
    isGameActive = false;
    gameOverText.gameObject.SetActive(true);
    restartButton.gameObject.SetActive(true);
    }
    IEnumerator StartTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void RestartGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty){
        spawnRate /= difficulty;
        isGameActive = true;
        score = 0;
        StartCoroutine(StartTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
