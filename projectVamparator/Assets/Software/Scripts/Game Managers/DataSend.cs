using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceVandal.Data
{
    public class DataSend
    {
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

        public void resourceDataChange(string key, string process, int number)
        {

            byte keyIndex = 0;
            byte counter = 0;
            int oldValue = 0;
            string[] data = File.ReadAllLines(filePath);
            bool keyFounded = false;

            using (StreamReader dataReader = new StreamReader(filePath, true))
            {

                while (!dataReader.EndOfStream)
                {
                    if (dataReader.ReadLine() == key)
                    {
                        keyFounded = true;
                        keyIndex = counter;
                        break;
                    }
                    counter++;
                }
                if (!keyFounded)
                {
                    Debug.Log("Aranan deðer anahtarý bulunamadý.");
                }
            }
            oldValue = int.Parse(data[keyIndex + 1]);
            if (process == "Addition")
            {
                data[keyIndex + 1] = (oldValue + number).ToString();
            }
            if (process == "Subtraction")
            {
                if ((oldValue - number) < 0)
                {
                    Debug.Log("Resource deðerleri 0 dan küçük olamaz !");
                }
                else
                {
                    data[keyIndex + 1] = (oldValue - number).ToString();
                }
            }
            File.WriteAllLines(filePath, data);
        }

    }
}
