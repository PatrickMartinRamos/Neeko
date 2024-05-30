using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.InputSystem.InputAction;

public class catMoveScript : MonoBehaviour
{
    /// <summary>
    /// Handle Player motion
    /// </summary>

    //system var
    private Camera _camera;
    private NavMeshAgent _agent;

    private bool isRotating = false;
    [SerializeField]
    private float rotationSpeed = 3f;

    private void Start()
    {
        _camera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        rotateMotion();
    }

    #region walk / rotation 
    public void WalkMotion()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            _agent.SetDestination(hit.point);
            _agent.isStopped = true;
            isRotating = true; 
        }
    }

    void rotateMotion()
    {
        if (isRotating)
        {
            Vector3 direction = _agent.destination - transform.position;
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            }
            if (Quaternion.Angle(transform.rotation, Quaternion.LookRotation(direction)) < 5f)
            {
                isRotating = false;
                _agent.isStopped = false;
            }
        }
        else
        {
            // If not rotating, maintain the current rotation
            _agent.updateRotation = false;
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            _agent.updateRotation = true;
        }
    }
    #endregion
}
