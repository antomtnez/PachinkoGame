using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;

    private int startGameCounter = 0;
    [SerializeField][Range (1, 5)] int counterTime = 3;
    [SerializeField] GameObject ballsDoor;
    private float finishGameCountdown = 15f;
    private bool isGameFinished;
    private AudioSource buttonAudio;

    [Header("UI Elements")]
    [SerializeField] GameObject titlePanel;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button restartButton;

    void Start(){
        buttonAudio = GetComponent<AudioSource>();
    }

    public void Play(){
        isGameFinished = false;
        score = 0;
        startGameCounter = counterTime;
        titlePanel.SetActive(false);
        UpdateScoreText();
        buttonAudio.Play();

        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown(){
        while(startGameCounter >= 0){
            UpdateCountdownText();
            yield return new WaitForSeconds(1);
            startGameCounter--;
        }

        countdownText.gameObject.SetActive(false);
        OpenDoor();
        StartCoroutine(StartFinishCountdown());
    }

    void UpdateCountdownText(){
        if(startGameCounter == 0){
            countdownText.SetText("Start");
        }else{
            countdownText.SetText($"{startGameCounter}");
        }
    }

    void OpenDoor(){
        ballsDoor.SetActive(false);
    }

    IEnumerator StartFinishCountdown(){
        while(finishGameCountdown > 0){
            yield return new WaitForSeconds(1);
            finishGameCountdown--;
        }

        Debug.Log("Is finished by time");
        FinishGame();
    }

    public void AddPoints(int scoreToAdd){
        score += scoreToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText(){
        scoreText.SetText($"{score}");
    }

    public void FinishGame(){
        if(!isGameFinished){
            restartButton.interactable = true;
            isGameFinished = true;
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        buttonAudio.Play();
    }
}
