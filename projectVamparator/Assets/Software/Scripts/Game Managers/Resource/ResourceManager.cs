using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceVandal.Data;
using System.IO;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;


public class ResourceManager : MonoBehaviour
{
    DataSend ds;
    DataRecieve dr;
    FileInfo fi;
    string filePath = "userData_Resources.txt";
    private void Start()
    {
        ds = new DataSend();
        dr = new DataRecieve();
        fi = new FileInfo(filePath);
    }

    Dictionary<string, int> resourceData = new Dictionary<string, int>();
    [SerializeField] TMP_Text woodAmount;
    [SerializeField] TMP_Text ironAmount;
    public void AddResource()
    {
        if (!File.Exists(filePath))
        {
            // Dosya yoksa oluþtur
            File.Create(filePath).Close(); // Dosyayý oluþtur ve hemen kapat
        }
        if (fi.Length == 0) 
        {
            resourceData.Add("Wood", 10);
            resourceData.Add("Iron", 10);
            ds.resourceDataSend(resourceData,false);
        }
        else
        {
            ds.resourceDataChange("Wood","Addition",10);
            ds.resourceDataChange("Iron","Addition",10);
        }
        woodAmount.text = dr.resourceDataRecieve("Wood");
        ironAmount.text = dr.resourceDataRecieve("Iron");
    }
}
