using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class catManagerScript : MonoBehaviour
{
    //public float heatMeter;
    [SerializeField] PlayerStatusScriptable playerCondition;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cars"))
        {
            playerCondition.causeDeath = 1;
            SceneManager.LoadScene(2);
        }
    }
}
