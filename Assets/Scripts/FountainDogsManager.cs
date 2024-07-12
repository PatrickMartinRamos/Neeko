using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FountainDogsManager : MonoBehaviour
{
    private Transform puddle;
    [SerializeField] private List<Animator> _animators = new List<Animator>(); // Initialize the list

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
        if (puddle != null && puddle.transform.localPosition.z >= 0.35f)
        {
            foreach (var animator in _animators)
            {
                animator.SetBool("Move", true);
            }
        }
        else
        {
            foreach (var animator in _animators)
            {
                animator.SetBool("Move", false);
            }
        }

    }

    public void IncreaseWater()
    {
        if (puddle != null)
        {
            puddle.transform.position = new Vector3(puddle.transform.position.x, puddle.transform.position.y, puddle.transform.position.z + 0.07f);
        }
    }
}