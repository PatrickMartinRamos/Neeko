using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogFollower : MonoBehaviour
{
    private Transform initialLocation;
    private GameObject dog;
    private GameObject player;
    private Animator dogAnim;
    [SerializeField] private PlayerStatusScriptable playerCondition;
    private audioManager _audioManagerInstance;

    private void Awake()
    {
        initialLocation = this.gameObject.transform;
        dog = transform.GetChild(0).gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        dogAnim = dog.GetComponent<Animator>();

        _audioManagerInstance = audioManager.instance;
        Debug.Log(_audioManagerInstance != null ? "AudioManager instance found." : "AudioManager instance is null.");

    }
    private void Update()
    {
        if (withinTravelDistance())
        {
            if (withinDistance())
            {
                dogAnim.SetBool("seePlayer", true);
                dog.transform.LookAt(player.transform);
                if (_audioManagerInstance != null)
                {
                    _audioManagerInstance.Play("DogBark");
                }
                else
                {
                    Debug.LogWarning("AudioManager instance is null, cannot play sound");
                }
            }
            else if (!withinDistance())
            {
                _audioManagerInstance.Stop("DogBark");
                dogAnim.SetBool("seePlayer", false);
            }

            if (withinRange())
            {
                dogAnim.SetBool("inRange", true);
                dog.transform.position = Vector3.MoveTowards(dog.transform.position, player.transform.position, 1f * Time.deltaTime);
            }
            else if (!withinRange())
            {
                dogAnim.SetBool("inRange", false);
                dog.transform.LookAt(initialLocation.transform);
                dog.transform.position = Vector3.MoveTowards(dog.transform.position, initialLocation.position, 1f * Time.deltaTime);
            }
        }
        else
        {
            dogAnim.SetBool("seePlayer", false);
            dogAnim.SetBool("inRange", false);
            dog.transform.LookAt(initialLocation.transform);
            dog.transform.position = Vector3.MoveTowards(dog.transform.position, initialLocation.position, 1f * Time.deltaTime);
        }
    }
    private bool withinDistance()
    {
        if (Vector3.Distance(player.transform.position, dog.transform.position) < 10f)
            return true;
        else return false;
    }
    private bool withinRange()
    {
        if (Vector3.Distance(player.transform.position, dog.transform.position) < 5f)
            return true;
        else return false;
    }
    private bool withinTravelDistance()
    {
        if (Vector3.Distance(initialLocation.position, dog.transform.position) < 15f)
            return true;
        else return false;
    }


}
