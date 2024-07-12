using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class FountainDogsManager : MonoBehaviour
{
    private Transform puddle;
    [SerializeField] private List<Animator> _animators = new List<Animator>(); // Initialize the list
    public static UnityEvent onFountainQuestComplete = new UnityEvent();
    private bool completed = false;


    void Start()
    {
        // Ensure the children exist
        if (transform.childCount > 2)
        {
            puddle = transform.GetChild(1);
            foreach (var anim in transform.GetChild(2).GetComponentsInChildren<Animator>())
            {
                _animators.Add(anim);
            }
        }
        else
        {
            Debug.LogError("Insufficient children in the hierarchy.");
        }
    }

    void Update()
    {

        if (completed == false && puddle != null && puddle.transform.localPosition.z >= 0.35f)
        {
            completed = true;
            onFountainQuestComplete.Invoke();
            foreach (var animator in _animators)
            {
                animator.SetBool("Move", true);
            }
        }
        else if (puddle.transform.localPosition.z < 0.35f)
        {
            foreach (var animator in _animators)
            {
                animator.SetBool("Move", false);
            }
        }

    }

    private void IncreaseWater()
    {
        if (puddle != null)
        {
            puddle.transform.localPosition = new Vector3(puddle.transform.localPosition.x, puddle.transform.localPosition.y, Mathf.Clamp(puddle.transform.localPosition.z + 0.07f,0,0.35f));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WaterBottle")
        {
            IncreaseWater();
            Destroy(collision.gameObject);
        }
    }
}