using UnityEngine;

public class ScorerBox : MonoBehaviour
{
    [SerializeField] int points;
    private GameManager gameManager;

    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other) {
        gameManager.AddPoints(points);
    }
}
