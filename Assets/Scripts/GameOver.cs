using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;

public class GameOver : MonoBehaviour
{
    // public TextMeshProUGUI gameOverText; // The Text UI component that displays the "game over" message
    // public Canvas canvas;

    // [SerializeField]
    //  Camera mainCamera;
    public GameObject gameOverUI;
    private bool isGameOver = false;

    public AudioClip gamesound;
    public AudioClip gameOversound;

    private AudioSource audioSource;

   private void Start() 
    {
               gameOverUI.SetActive(false);
               audioSource = GetComponent<AudioSource>();
               audioSource.clip = gamesound;
               audioSource.Play();

    }
    
  private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the game object we want to detect
        if (other.gameObject.tag == "Obstacles")
        {
            isGameOver = true;
            audioSource.Stop();

        }
    }

    private void Update()
    {
        if (isGameOver)
        {
            Debug.Log("Collision detected");
            gameOverUI.SetActive(true);
            audioSource.clip = gameOversound;
            audioSource.Play();

        }
    }
}