using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SpaceVandal.Data;
using UnityEngine;

public class PlayerStorageManager : MonoBehaviour
{
    [SerializeField] public int maxStorage = 20;
    [SerializeField] public int CurrentStorage = 0;
    [SerializeField] public float collectSpeed = 0.5f;
    [SerializeField] public int collectAmount = 1;
    [SerializeField] private Dictionary<string, int> storageValues = new Dictionary<string, int>();
    DataSend ds;
    DataRecieve dr;
    private void Start()
    {
        ds = new DataSend();
        dr = new DataRecieve();
        Debug.Log("PlayerStorageManager ba�lat�ld�.");
    }

    public void addResourceToStorage(string resource,int value) // belli de�il �uanl�k tek t�r kaynak oldu�u i�in i�levi yok.
    {
        if (dr.resourceDataRecieve().ContainsKey(resource))
        {
            ds.resourceDataChange(resource,"Addition",value);
            Debug.Log("Oyuncu deposuna "+value+" adet "+resource+" kayna�� eklendi.");
        }
        else
        {
            ds.resourceDataSend(resource,value,true);
            Debug.Log("Yeni veri girdisi olu�turuldu : " + resource + ", " + value);
        }

    }
}
