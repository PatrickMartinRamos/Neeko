using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public List<GameObject> tutorials; // List to hold all tutorial GameObjects
    public GameObject closeButton; // Reference to the close button
    private int currentIndex = 0; // Index of the currently active tutorial
    public GameObject TutorialUI;
    private audioManager _audioManagerInstance;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Tutorial Script");
        ShowCurrentTutorial();
        PauseGame();
        TutorialUI.SetActive(true);
    }

    private void Awake()
    {
        _audioManagerInstance = audioManager.instance;
        Debug.Log(_audioManagerInstance != null ? "AudioManager instance found." : "AudioManager instance is null.");
    }

    public void ShowNextTutorial()
    {
        Debug.Log("Showing next tutorial");
        if (tutorials.Count == 0)
        {
            Debug.LogWarning("Tutorial list is empty");
            return;
        }

        tutorials[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % tutorials.Count;
        ShowCurrentTutorial();
        playButtonSFX();
    }

    public void ShowPreviousTutorial()
    {
        Debug.Log("Showing previous tutorial");
        if (tutorials.Count == 0)
        {
            Debug.LogWarning("Tutorial list is empty");
            return;
        }

        tutorials[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + tutorials.Count) % tutorials.Count;
        ShowCurrentTutorial();
        playButtonSFX();
    }

    private void ShowCurrentTutorial()
    {
        Debug.Log($"Showing tutorial at index {currentIndex}");
        tutorials[currentIndex].SetActive(true);
        if (currentIndex == tutorials.Count - 1)
        {
            closeButton.SetActive(true);
        }
        else
        {
            closeButton.SetActive(false);
        }
    }

    public void CloseTutorial()
    {
        Debug.Log("Closing tutorial");
        playButtonSFX();
        TutorialUI.SetActive(false);
        closeButton.SetActive(false);
        ResumeGame();
        HideCursor();
    }

    void playButtonSFX()
    {
        if (_audioManagerInstance != null)
        {
            _audioManagerInstance.Play("ButtonSFX");
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null, cannot play sound");
        }
    }

    private void PauseGame()
    {
        Debug.Log("Pausing game");
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Debug.Log("Resuming game");
        Time.timeScale = 1f;
    }

    private void HideCursor()
    {
        Debug.Log("Hiding cursor");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}