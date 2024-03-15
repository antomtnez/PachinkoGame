using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    private int startGameCounter = 0;
    [SerializeField][Range (1, 5)] int counterTime = 3;
    [SerializeField] GameObject ballsDoor;

    [Header("UI Elements")]
    [SerializeField] GameObject titlePanel;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI scoreText;

    public void Play(){
        score = 0;
        startGameCounter = counterTime;
        titlePanel.SetActive(false);
        UpdateScoreText();

        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown(){
        while(startGameCounter >= 0){
            countdownText.SetText($"{startGameCounter}");
            yield return new WaitForSeconds(1);
            startGameCounter--;
        }

        countdownText.gameObject.SetActive(false);
        OpenDoor();
    }

    void OpenDoor(){
        ballsDoor.SetActive(false);
    }

    public void AddPoints(int scoreToAdd){
        score += scoreToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText(){
        scoreText.SetText($"{score}");
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
