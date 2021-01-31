using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;

    public float smootSpeed = 10f;
    public Vector3 offset;

    private void LateUpdate()
    {
        if (target)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smootSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
