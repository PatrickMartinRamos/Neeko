using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catManagerScript : MonoBehaviour
{
    public float heatMeter;

    [SerializeField] private float catMoveSpeed;
    public float CatMoveSpeed => catMoveSpeed = 5f;
    
}
