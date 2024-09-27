using SpaceVandal.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DataSend ds = new DataSend();
            DataRecieve dr = new DataRecieve();
            int dataToGo = collision.gameObject.GetComponent<PlayerStorageManager>().CurrentStorage;
            ds.resourceDataChange("Wood", "Addition", dataToGo);
            collision.gameObject.GetComponent<PlayerStorageManager>().CurrentStorage = 0;
            Debug.Log("Kaynaklar gemiye yüklendi : " + dataToGo);
        }
    }

}
