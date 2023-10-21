using UnityEngine;

public class CameraProxy : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void LateUpdate()
    {
        transform.rotation = target.rotation;
    }
}
