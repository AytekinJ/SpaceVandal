using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceBeingCollected : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask layerMask;
    private bool isPlayerNearby = false;
    void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 5f, layerMask);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.name == "Player" && isPlayerNearby == false)
            {
                isPlayerNearby=true;
                StartCoroutine(ResourceCollecting(hit.collider.gameObject));
                break;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public IEnumerator ResourceCollecting(GameObject player)
    {
        while (isPlayerNearby)
        {
            if (player.GetComponent<PlayerStorageManager>().CurrentStorage < player.GetComponent<PlayerStorageManager>().maxStorage)
            {
                player.GetComponent<PlayerStorageManager>().CurrentStorage += player.GetComponent<PlayerStorageManager>().collectAmount;
                Debug.Log("1 Resource toplandý.");
            }
            else
            {
                Debug.Log("Storage dolu.");
            }
            yield return new WaitForSeconds(player.GetComponent<PlayerStorageManager>().collectSpeed);
            isPlayerNearby = false;
        }
    }
}
