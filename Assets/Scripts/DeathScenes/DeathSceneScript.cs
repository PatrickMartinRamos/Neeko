using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneScript : MonoBehaviour
{
    private CanvasGroup deathLine;
    private Transform backBtn;
    [SerializeField] private PlayerStatusScriptable playerStats;
    // Start is called before the first frame update
    void Awake()
    {
        deathLine = transform.GetChild(0).GetComponent<CanvasGroup>();
        backBtn = transform.GetChild(1);
        playerStats.PlayerLevel = level.one;
    }

    // Update is called once per frame
    void Update()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(deathLine.DOFade(1, 1f));
        seq.Append(backBtn.DOScale(1, 1f));
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
