using UnityEngine;

public class BallsSpawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;

    private float xAxisOffset = 1f;
    private float zAxisOffset = 10f;
    private int ballsLimit = 80;
    private int ballsPointedCount = 0;

    private GameManager gameManager;

    void Start(){
        gameManager = GetComponent<GameManager>();
        GenerateBalls();
    }

    void GenerateBalls(){
        for(int i=0; i <= ballsLimit; i++){
            SpawnBall();
        }
    }

    void SpawnBall(){
        Instantiate(ballPrefab, GenerateRandomPosition(), ballPrefab.transform.rotation, transform);
    }

    Vector3 GenerateRandomPosition(){
        return new Vector3(transform.position.x + Random.Range(-xAxisOffset, xAxisOffset),
                    transform.position.y,
                    transform.position.z + Random.Range(-zAxisOffset, zAxisOffset));
    }

    public void BallScored(){
        ballsPointedCount++;
        CheckAllBallsScored();
    }

    void CheckAllBallsScored(){
        if(ballsPointedCount == ballsLimit)
            gameManager.FinishGame();
    }
}
