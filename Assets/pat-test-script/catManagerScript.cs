using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catManagerScript : MonoBehaviour
{
    public float heatMeter;

    [SerializeField] private float catMoveSpeed;
    public float CatMoveSpeed => catMoveSpeed = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cars"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
