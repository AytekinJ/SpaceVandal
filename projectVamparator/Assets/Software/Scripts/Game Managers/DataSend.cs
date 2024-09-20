using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SpaceVandal.Data
{
    public class DataSend : MonoBehaviour
    {

        StreamWriter dataWriter;
        string filePath = "userData_Resources.txt";
        public void resourceDataSend(Dictionary<string, int> data,bool overwrite)
        {
            using (StreamWriter dataWriter = new StreamWriter(filePath,true))
            {
                if (!overwrite)
                {
                    File.WriteAllText(filePath,"");
                }
                foreach (var item in data)
                {
                    dataWriter.WriteLine(item.Key);
                    dataWriter.WriteLine(item.Value);
                }
            }
        }

    }
}
