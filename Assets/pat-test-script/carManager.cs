using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carManager : MonoBehaviour
{
    [SerializeField]private Vector2 speedRange;
    public Vector2 SpeedRange => speedRange;
    [SerializeField] private float detectionRange;
    public float DetectionRange => detectionRange;
    [SerializeField] private float slowSpeed;
    public float SlowSpeed => slowSpeed;

}
