using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMove : MonoBehaviour
{
    [SerializeField] private byte screenIndex = 0;
    [SerializeField] private byte maxIndex = 10;
    private bool isAvailable = true;
    private float moveDistance = 5f; // Distance to move up or down
    private float moveDuration = 0.5f; // Duration for the movement

    public void MoveUpwards()
    {
        if (screenIndex < maxIndex && isAvailable)
        {
            Vector2 positionToGo = new Vector2(transform.position.x, transform.position.y + moveDistance);
            StartCoroutine(MoveToPosition(positionToGo));
            screenIndex++;
        }
    }

    public void MoveDownwards()
    {
        if (screenIndex > 0 && isAvailable)
        {
            Vector2 positionToGo = new Vector2(transform.position.x, transform.position.y - moveDistance);
            StartCoroutine(MoveToPosition(positionToGo));
            screenIndex--;
        }
    }

    private IEnumerator MoveToPosition(Vector2 positionToGo)
    {
        isAvailable = false;
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveDuration)
        {
            // Calculate the fraction of the movement
            float t = elapsedTime / moveDuration;

            // Apply an ease-in-out effect using SmoothStep
            t = t * t * (3f - 2f * t);

            // Lerp the position with the eased time
            transform.position = Vector3.Lerp(startingPosition, positionToGo, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }

        transform.position = positionToGo; // Ensure the position is set correctly at the end
        isAvailable = true;
    }
}
