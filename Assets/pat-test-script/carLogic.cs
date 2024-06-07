using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carLogic : MonoBehaviour
{
    private Transform targetPOS;
    private carManager _carManager;
    private float randomSpeed;

    private void Awake()
    {
        _carManager = FindObjectOfType<carManager>();
    }

    private void Start()
    {
        randomSpeed = Random.Range(_carManager.SpeedRange.x, _carManager.SpeedRange.y);

    }

    public void SetTarget(Transform target)
    {
        targetPOS = target;
    }

    private void Update()
    {
        if (targetPOS != null)
        {
            carMove();
        }
        adjustSpeed();
    }

    void carMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPOS.position, randomSpeed * Time.deltaTime);
        transform.LookAt(targetPOS);

        if (Vector3.Distance(transform.position, targetPOS.position) < 0.1f)
        {
            Destroy(this.gameObject);
        }
    }

    void adjustSpeed()
    {
        // Cast a ray forward from the car's position
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * _carManager.DetectionRange, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, _carManager.DetectionRange))
        {
            // Check if the ray hits another car
            if (hit.collider.CompareTag("Cars"))
            {
                // Reduce the speed of the car
                randomSpeed = Mathf.Min(randomSpeed, _carManager.SlowSpeed);
            }
        }
        else
        {
            // Restore the speed to the original random speed
            randomSpeed = Random.Range(_carManager.SpeedRange.x, _carManager.SpeedRange.y);
        }

        
    }
}
