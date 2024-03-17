using UnityEngine;

public class ScorerBox : MonoBehaviour
{
    [SerializeField] int points;
    private GameManager gameManager;
    private BallsSpawner ballsSpawner;
    private AudioSource scoreAudio;
    [SerializeField] ParticleSystem scoreEffect;

    void Start(){
        GameObject gameManagerGO = GameObject.Find("GameManager");
        gameManager = gameManagerGO.GetComponent<GameManager>();
        ballsSpawner = gameManagerGO.GetComponent<BallsSpawner>();
        scoreAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        gameManager.AddPoints(points);
        ballsSpawner.BallScored();
        scoreEffect.Play();
        scoreAudio.Play();
    }
}
