using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneScript : MonoBehaviour
{
    private CanvasGroup deathLine;
    private Transform backBtn;
    // Start is called before the first frame update
    void Awake()
    {
        deathLine = transform.GetChild(0).GetComponent<CanvasGroup>();
        backBtn = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(deathLine.DOFade(1, 0.5f));
        seq.Append(backBtn.DOScale(1, 0.5f));
    }
}
