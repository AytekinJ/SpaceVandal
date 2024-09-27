using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBeingCollected : MonoBehaviour
{
    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Image resourceBar;
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
    public IEnumerator ResourceCollecting(GameObject player) // çalýþýyor, verilen saniye baþýnda range içinde resource toplama. (þuan deðil)
    {
        int maxStorage = player.GetComponent<PlayerStorageManager>().maxStorage;
        int collectAmount = player.GetComponent<PlayerStorageManager>().collectAmount;
        while (isPlayerNearby)
        {
            PlayerStorageManager storageManager = player.GetComponent<PlayerStorageManager>();

            if (storageManager.CurrentStorage < storageManager.maxStorage)
            {
                // Calculate fillAmount only when needed
                float fillAmount = 1f / resourceCount;

                if (resourceCount > 0)
                {
                    if (storageManager.CurrentStorage + collectAmount > storageManager.maxStorage)
                    {
                        int fillCollect = storageManager.maxStorage - storageManager.CurrentStorage;
                        storageManager.CurrentStorage += fillCollect;
                        Debug.Log(fillCollect + " Resource toplandý.");
                        resourceBar.fillAmount -= fillCollect * fillAmount;
                        resourceCount -= fillCollect;
                    }
                    else if (resourceCount < collectAmount)
                    {
                        storageManager.CurrentStorage += resourceCount;
                        Debug.Log(resourceCount + " Resource toplandý.");
                        resourceBar.fillAmount -= resourceCount * fillAmount;
                        resourceCount = 0;
                    }
                    else
                    {
                        storageManager.CurrentStorage += collectAmount;
                        Debug.Log(collectAmount + " Resource toplandý.");
                        resourceBar.fillAmount -= collectAmount * fillAmount;
                        resourceCount -= collectAmount;
                    }
                }
                else
                {
                    Debug.Log("Kaynak bitti. Toplanamýyor.");
                    resourceBar.fillAmount = 0;
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
