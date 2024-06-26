using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] CanvasGroup initialPromptCG;
    [SerializeField] CanvasGroup mainMenuCG;
    [SerializeField] CanvasGroup settingsCG;
    [SerializeField] CanvasGroup controlsCG;
    float fadeDuration = 1f;
    Tween fadeTween;
    public UnityEvent onPlay = new UnityEvent();

    void Start()
    {
        initialPromptCG = transform.GetChild(0).GetComponent<CanvasGroup>();
        mainMenuCG = transform.GetChild(1).GetComponent<CanvasGroup>();
        settingsCG = transform.GetChild(2).GetComponent<CanvasGroup>();
        controlsCG = transform.GetChild(3).GetComponent<CanvasGroup>();

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
            Sequence seq = DOTween.Sequence();
            ShowMainMenu(seq);
        }
    }
    void ShowMainMenu(Sequence seq)
    {
        seq.Append(initialPromptCG.DOFade(0, fadeDuration));
        seq.Append(mainMenuCG.transform.DOScale(Vector2.one, 0.5f));
    }
    void HideMainMenu(Sequence seq)
    {
        seq.Append(mainMenuCG.transform.DOScale(Vector2.zero, 0.5f));
    }
    void ShowSettings()
    {
        // Add Show Settings
        Sequence seq = DOTween.Sequence();
        HideMainMenu(seq);
        seq.Append(settingsCG.transform.DOScale(Vector2.one, 0.5f));
        ButtonsManager.onPressBack.AddListener(HideSettings);
    }
    void HideSettings()
    {
        // Add Show Settings
        Sequence seq = DOTween.Sequence();
        seq.Append(settingsCG.transform.DOScale(Vector2.zero, 0.5f));
        ButtonsManager.onPressBack.RemoveListener(ShowSettings);
        ShowMainMenu(seq);
    }

    void ShowControls()
    {
        Sequence seq = DOTween.Sequence();
        HideMainMenu(seq);
        seq.Append(controlsCG.transform.DOScale(Vector2.one, 0.5f));
        ButtonsManager.onPressBack.AddListener(HideControls);
    }
    void HideControls()
    {
        ButtonsManager.onPressBack.RemoveListener(HideControls);
        Sequence seq = DOTween.Sequence();
        seq.Append(controlsCG.transform.DOScale(Vector2.zero, 0.5f));
        ShowMainMenu(seq);

    }
    void QuitGame()
    {
        Sequence seq = DOTween.Sequence();
        HideMainMenu(seq);
        seq.AppendInterval(2);
        seq.OnComplete(()=>fadeTween.Play()); 
    }
}
