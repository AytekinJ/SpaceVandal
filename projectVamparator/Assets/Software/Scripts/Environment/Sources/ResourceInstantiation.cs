using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInstantiation : MonoBehaviour
{
    [SerializeField] GameObject ResourcePrefab;
    public int numberOfPrefabs = 10;
    public float minDistance = 5f;

    void Start()
    {
        Vector2[] positions = new Vector2[numberOfPrefabs];
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Vector2 newPosition;
            do
            {
                newPosition = new Vector2(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            } while (!IsFarEnough(newPosition, positions, i));

            positions[i] = newPosition;
            GameObject instantiation = Instantiate(ResourcePrefab, newPosition, Quaternion.identity);
            instantiation.GetComponent<ResourceBeingCollected>().resourceCount = Random.Range(5,20);
        }
    }

    bool IsFarEnough(Vector2 newPosition, Vector2[] existingPositions, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (Vector2.Distance(newPosition, existingPositions[i]) < minDistance)
                return false;
        }
        return true;
    }
}
