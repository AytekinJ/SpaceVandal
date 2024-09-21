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
    Dictionary<string, int> resourceData = new Dictionary<string, int>();
    [SerializeField] TMP_Text woodAmount;
    [SerializeField] TMP_Text ironAmount;
    private void Start()
    {
        ds = new DataSend();
        dr = new DataRecieve();
        fi = new FileInfo(filePath);
        woodAmount.text = dr.resourceDataRecieve("Wood") + "/0";
        ironAmount.text = dr.resourceDataRecieve("Iron") + "/0";
    }
    public void AddResource()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }
        if (fi.Length == 0) 
        {
            resourceData.Add("Wood", 10);
            resourceData.Add("Iron", 10);
            ds.resourceDataSend(resourceData,true);
        }
        else
        {
            ds.resourceDataChange("Wood","Addition",10);
            ds.resourceDataChange("Iron","Addition",10);
        }

        woodAmount.text = dr.resourceDataRecieve("Wood") + "/0";
        ironAmount.text = dr.resourceDataRecieve("Iron") + "/0";
    }
}
