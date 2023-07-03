using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header ("Ending Camera Animation")]
    [SerializeField] Vector3 initialPosition, endPosition;
    [SerializeField] Vector3 initialRotation, endRotation;
    [SerializeField] float desiredDuration;

    float elapsedTime;

    private void Awake()
    {
        transform.localPosition = initialPosition;
    }

    private void Update()
    {
        if(PlayerMovement.cameraViewOn)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if(PlayerMovement.cameraViewOn)
        {
            float percentage = elapsedTime / desiredDuration;
            transform.localEulerAngles = Vector3.Lerp(initialRotation, endRotation, percentage);
            transform.localPosition = Vector3.Lerp(initialPosition, endPosition, percentage);
        }
    }
}
