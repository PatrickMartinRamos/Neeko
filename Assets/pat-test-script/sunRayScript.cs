using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunRayScript : MonoBehaviour
{
    private HeatPointsManager _heatPointManager;
    private ParticleSystem _sunRayParticleSystem;
    public PlayerStatusScriptable playerCondition;
    //public GameObject sunRayGameObject;
    public status playerStatus;
    public bool isParticlePlaying = false;
    private Coroutine angleCoroutine;



    private void Awake()
    {
        _heatPointManager = FindObjectOfType<HeatPointsManager>();
        _sunRayParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        //sunRayGameObject.SetActive(false);
        GetComponent<ParticleSystem>().Clear();
        HeatPointsManager.onSunRayTrigger.AddListener(sunRay);
    }

    private void Update()
    {
        sunRay();
    }

    void sunRay()
    {
        playerStatus = playerCondition.PlayerStatus;

        if (playerStatus == status.underSun && !isParticlePlaying)
        {
            _sunRayParticleSystem.Play();
            isParticlePlaying = true;
            angleCoroutine = StartCoroutine(DecreaseAngle());
        }
        else if (playerStatus != status.underSun && isParticlePlaying)
        {
            _sunRayParticleSystem.Stop();
            isParticlePlaying = false;
            if (angleCoroutine != null)
            {
                StopCoroutine(angleCoroutine);
                angleCoroutine = null;

                var shape = _sunRayParticleSystem.shape;
                shape.angle = 3f;
            }
        }
    }

    private IEnumerator DecreaseAngle()
    {
        var shape = _sunRayParticleSystem.shape;
        shape.angle = 2f;

        while (shape.angle > 0)
        {
            shape.angle -= 0.1f;
            if (shape.angle < 0) shape.angle = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
