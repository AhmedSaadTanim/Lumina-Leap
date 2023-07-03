using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 initialRotation;

    private void Awake()
    {
        initialRotation = transform.eulerAngles;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);

        transform.eulerAngles = new Vector3(playerTransform.eulerAngles.x + initialRotation.x, playerTransform.eulerAngles.y + initialRotation.y, 0);
    }
}
