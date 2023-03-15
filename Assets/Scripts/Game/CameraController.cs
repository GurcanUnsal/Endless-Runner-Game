using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private Vector3 newPosition;
    private readonly float camSpeed = 1f;

    void Start()
    {
        offset = transform.position - target.position;
        newPosition.y = transform.position.y;
    }

    private void LateUpdate()
    {
        newPosition.x = target.position.x;
        newPosition.z = target.position.z + offset.z;
        transform.position = Vector3.Lerp(transform.position, newPosition, camSpeed);
    }
}
