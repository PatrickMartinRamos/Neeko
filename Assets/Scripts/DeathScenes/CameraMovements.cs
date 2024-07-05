using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{


    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponentInChildren<CinemachineTrackedDolly>().m_PathPosition = Mathf.Lerp(1,0,Time.deltaTime/1000);
    }
}
