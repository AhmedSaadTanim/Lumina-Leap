using UnityEngine;

public class LevelBoard : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Vector3 initialRotation;
    [SerializeField] float offset, scaleDivider, increment;

    private void Awake()
    {
        initialRotation = transform.eulerAngles;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + offset + (transform.localScale.y * (increment * transform.localScale.y)), playerTransform.position.z);
        transform.localScale = playerTransform.parent.transform.localScale / scaleDivider;
        transform.eulerAngles = new Vector3(playerTransform.eulerAngles.x + initialRotation.x, playerTransform.eulerAngles.y + initialRotation.y, 0);
    }
}
