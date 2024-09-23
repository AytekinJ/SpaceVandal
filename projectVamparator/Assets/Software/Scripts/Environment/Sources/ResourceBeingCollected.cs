using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceBeingCollected : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask layerMask;
    private bool isPlayerNearby = false;
    void Update()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 5f, layerMask);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.name == "Player")
            {
                isPlayerNearby=true; break;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public IEnumerator ResourceCollecting()
    {
        return null;
    }
}
