using UnityEngine;

public class BallFX : MonoBehaviour
{
    private AudioSource impactAudio;

    void Start(){
        impactAudio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enviroment"))
            impactAudio.Play();
    }
}