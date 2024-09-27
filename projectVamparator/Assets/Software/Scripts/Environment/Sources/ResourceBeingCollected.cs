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
    [SerializeField] string[] containedResourceTypes; // i�levsiz, konu�ulacak
    [SerializeField] int[] containedResourceAmounts; // i�levsiz, konu�ulacak
    private void Start()
    {
        //for (int i = 0; i < containedResourceTypes.Length; i++)
        //{
        //    resourceType.Add(containedResourceTypes[i], containedResourceAmounts[i]);
        //}
        //Debug.Log("Resource ayarlamas� tamamland�, kaynaklar eklendi.");
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
    public IEnumerator ResourceCollecting(GameObject player) // �al���yor, verilen saniye ba��nda range i�inde resource toplama. (�uan de�il)
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
                        Debug.Log(fillCollect + " Resource topland�.");
                        resourceBar.fillAmount -= fillCollect * fillAmount;
                        resourceCount -= fillCollect;
                    }
                    else if (resourceCount < collectAmount)
                    {
                        storageManager.CurrentStorage += resourceCount;
                        Debug.Log(resourceCount + " Resource topland�.");
                        resourceBar.fillAmount -= resourceCount * fillAmount;
                        resourceCount = 0;
                    }
                    else
                    {
                        storageManager.CurrentStorage += collectAmount;
                        Debug.Log(collectAmount + " Resource topland�.");
                        resourceBar.fillAmount -= collectAmount * fillAmount;
                        resourceCount -= collectAmount;
                    }
                }
                else
                {
                    Debug.Log("Kaynak bitti. Toplanam�yor.");
                    resourceBar.fillAmount = 0;
                }
            }
            else
            {
                Debug.Log("Storage dolu. Toplanam�yor.");
            }
            yield return new WaitForSeconds(player.GetComponent<PlayerStorageManager>().collectSpeed);
            isPlayerNearby = false;
        }
        //// T�m key'leri s�rayla i�le
        //foreach (var key in myDictionary.Keys)
        //{
        //    // Bu key'in de�eri s�f�ra inene kadar d�ng� devam edecek
        //    while (myDictionary[key] > 0)
        //    {
        //        // De�eri bir azalt
        //        myDictionary[key]--;
        //        Debug.Log($"{key} de�eri: {myDictionary[key]}");

        //        // Bir sonraki kareye kadar bekle
        //        yield return null;
        //    }
        //}

        //Debug.Log("T�m de�erler s�f�ra indirildi!");
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    } //hell
}
