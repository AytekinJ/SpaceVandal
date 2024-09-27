using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class ResourceBeingCollected : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask layerMask;
    private bool isPlayerNearby = false;
    Dictionary<string, int> resourceType = new Dictionary<string, int>();
    [SerializeField] public int resourceCount;
    [SerializeField] string[] containedResourceTypes; // iþlevsiz, konuþulacak
    [SerializeField] int[] containedResourceAmounts; // iþlevsiz, konuþulacak
    private void Start()
    {
        //for (int i = 0; i < containedResourceTypes.Length; i++)
        //{
        //    resourceType.Add(containedResourceTypes[i], containedResourceAmounts[i]);
        //}
        //Debug.Log("Resource ayarlamasý tamamlandý, kaynaklar eklendi.");
    }
    void FixedUpdate() // circle casting
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
        int maxStorage = player.GetComponent<PlayerStorageManager>().maxStorage;
        int collectAmount = player.GetComponent<PlayerStorageManager>().collectAmount;
        while (isPlayerNearby)
        {
            if (player.GetComponent<PlayerStorageManager>().CurrentStorage < player.GetComponent<PlayerStorageManager>().maxStorage)
            {
                if (resourceCount > 0)
                {
                    if (player.GetComponent<PlayerStorageManager>().CurrentStorage + collectAmount > maxStorage)
                    {
                        int fillCollect = maxStorage - player.GetComponent<PlayerStorageManager>().CurrentStorage;
                        player.GetComponent<PlayerStorageManager>().CurrentStorage += fillCollect;
                        Debug.Log(fillCollect + " Resource toplandý.");
                        resourceCount -= fillCollect;
                    }
                    if (resourceCount < collectAmount)
                    {
                        player.GetComponent<PlayerStorageManager>().CurrentStorage += resourceCount;
                        Debug.Log(resourceCount + " Resource toplandý.");
                        resourceCount = 0;
                    }
                    else
                    {
                        player.GetComponent<PlayerStorageManager>().CurrentStorage += player.GetComponent<PlayerStorageManager>().collectAmount;
                        Debug.Log(collectAmount+" Resource toplandý.");
                        resourceCount -= player.GetComponent<PlayerStorageManager>().collectAmount;
                    }
                    

                }
                else
                {
                    Debug.Log("Kaynak bitti. Toplanamýyor.");
                }
            }
            else
            {
                Debug.Log("Storage dolu. Toplanamýyor.");
            }
            yield return new WaitForSeconds(player.GetComponent<PlayerStorageManager>().collectSpeed);
            isPlayerNearby = false;
        }
        //// Tüm key'leri sýrayla iþle
        //foreach (var key in myDictionary.Keys)
        //{
        //    // Bu key'in deðeri sýfýra inene kadar döngü devam edecek
        //    while (myDictionary[key] > 0)
        //    {
        //        // Deðeri bir azalt
        //        myDictionary[key]--;
        //        Debug.Log($"{key} deðeri: {myDictionary[key]}");

        //        // Bir sonraki kareye kadar bekle
        //        yield return null;
        //    }
        //}

        //Debug.Log("Tüm deðerler sýfýra indirildi!");
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    } //hell
}
