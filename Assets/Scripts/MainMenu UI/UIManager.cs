using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup initialPromptCG;
    [SerializeField] CanvasGroup MainMenuCG;
    float fadeDuration = 1f;
    Tween fadeTween;
    public UnityEvent onPlay = new UnityEvent();

    void Start()
    {
        initialPromptCG = transform.GetChild(0).GetComponent<CanvasGroup>();
        MainMenuCG = transform.GetChild(1).GetComponent<CanvasGroup>();

        fadeTween = initialPromptCG.DOFade(0, fadeDuration)
            .SetLoops(-1, LoopType.Yoyo);

        ButtonsManager.onPressSetting.AddListener(ShowSettings);
        ButtonsManager.onPressCtrls.AddListener(ShowControls);
        ButtonsManager.onPressQuit.AddListener(QuitGame);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onPlay.Invoke();
            if (fadeTween != null && fadeTween.IsActive())
            {
                fadeTween.Pause();
            }
            ShowMainMenu();
        }
    }
    void ShowMainMenu()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(initialPromptCG.DOFade(0, fadeDuration));
        seq.Append(MainMenuCG.transform.DOScale(Vector2.one, 0.5f));
    }
    void ShowSettings()
    {
        // Add Show Settings

    }
    void HideSettings()
    {

    }
    void ShowControls()
    {

    }
    void HideControls()
    {

    }
    void QuitGame()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(MainMenuCG.transform.DOScale(Vector2.zero, 0.5f));
        seq.AppendInterval(2);
        seq.OnComplete(()=>fadeTween.Play()); 
    }
}
