using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carLogic : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform targetPOS;

    private void Start()
    {
        targetPOS = GameObject.FindGameObjectWithTag("carTargetPos").transform;
    }
    private void Update()
    {
        carMove();
    }
    void carMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPOS.position, speed * Time.deltaTime);
        transform.LookAt(targetPOS);

        if(transform.position == targetPOS.position)
        {
            Destroy(this.gameObject);
        }
    }
}
