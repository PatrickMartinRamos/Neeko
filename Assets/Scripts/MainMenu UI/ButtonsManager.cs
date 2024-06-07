using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public static UnityEvent onPressSetting = new UnityEvent();
    public static UnityEvent onPressCtrls = new UnityEvent();
    public static UnityEvent onPressQuit = new UnityEvent();
    public static UnityEvent onPressBack = new UnityEvent();
    public void StartGame()
    {
        // Add sfx
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        // Add sfx
        if (onPressSetting != null)
        {
            onPressSetting.Invoke();
        }
    }
    public void Controls()
    {
        // Add sfx
        if (onPressCtrls != null)
        {
            onPressCtrls.Invoke();
        }
    }
    public void Quit()
    {
        // Add sfx
        if (onPressQuit != null)
        {
            onPressQuit.Invoke();
        }
    }
    public void Back()
    {
        // Add sfx
        if (onPressBack != null)
        {
            onPressBack.Invoke();
        }
    }
}
