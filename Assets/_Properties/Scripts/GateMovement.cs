using UnityEngine;

public class GateMovement : MonoBehaviour
{
    Vector3 startPos, endPos;
    float elapsedTime, duration;

    private void Start()
    {
        duration = Random.Range(0.5f, 3f);
    }

    private void Update()
    {
        if(transform.position.x == 0 || transform.position.x == 1.5)
        {
            elapsedTime = 0;
            startPos = transform.position;
            endPos = transform.position;
            
            endPos.x = transform.position.x == 0 ? 1.5f : 0f;

            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime / duration;

            transform.position = Vector3.Lerp(startPos, endPos, percentage);
        }
        else
        {
            elapsedTime += Time.deltaTime;
            float percentage = elapsedTime / duration;

            transform.position = Vector3.Lerp(startPos, endPos, percentage);
        }
    }
}
