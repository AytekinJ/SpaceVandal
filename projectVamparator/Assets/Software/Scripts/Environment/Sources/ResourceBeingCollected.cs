using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceBeingCollected : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask layerMask;
    private bool isPlayerNearby = false;
    [SerializeField] Dictionary<string,int> resourceType = new Dictionary<string,int>();
    void FixedUpdate() // casting
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0f, layerMask);
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
    public IEnumerator ResourceCollecting(GameObject player) // çalýþýyor, verilen saniye baþýnda range içinde resource toplama.
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
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    } //hell
}
