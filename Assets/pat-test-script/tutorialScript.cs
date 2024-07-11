using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    public List<GameObject> tutorials; // List to hold all tutorial GameObjects
    public GameObject closeButton; // Reference to the close button
    private int currentIndex = 0; // Index of the currently active tutorial
    public GameObject TutorialUI;

    // Start is called before the first frame update
    void Start()
    {
        ShowCurrentTutorial();
        PauseGame();
        TutorialUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowNextTutorial()
    {
        tutorials[currentIndex].SetActive(false);
        currentIndex = (currentIndex + 1) % tutorials.Count;
        ShowCurrentTutorial();
    }

    public void ShowPreviousTutorial()
    {
        tutorials[currentIndex].SetActive(false);
        currentIndex = (currentIndex - 1 + tutorials.Count) % tutorials.Count;
        ShowCurrentTutorial();
    }

    private void ShowCurrentTutorial()
    {
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
        TutorialUI.SetActive(false);
        closeButton.SetActive(false);
        ResumeGame();
        HideCursor();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //public void ActivateTutorialUI()
    //{
    //    TutorialUI.SetActive(true);
    //    ShowCurrentTutorial();
    //    PauseGame();
    //}
}
