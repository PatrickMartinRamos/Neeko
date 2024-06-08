using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform initialPositionCamera;
    void Awake()
    {
        initialPositionCamera = transform.GetChild(0);
    }
    public void ChangeToMainMenu()
    {
        initialPositionCamera.gameObject.SetActive(false);
    }
    public void ChangeToInitial()
    {
        initialPositionCamera.gameObject.SetActive(true);
    }
}
