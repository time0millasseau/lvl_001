using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [Header("Offset position")]
    public float offsetX = 4f;   // décale le joueur vers la gauche
    public float offsetY = 1f;

    [Header("Smooth")]
    public float smoothSpeed = 5f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(
            target.position.x + offsetX,
            target.position.y + offsetY,
            transform.position.z
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            1f / smoothSpeed
        );
    }
}
