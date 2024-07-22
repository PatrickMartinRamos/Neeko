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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(2);
        }
        else if (collision.gameObject.CompareTag("Dogs"))
        {
            playerCondition.causeDeath = 3;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(4);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(5);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
