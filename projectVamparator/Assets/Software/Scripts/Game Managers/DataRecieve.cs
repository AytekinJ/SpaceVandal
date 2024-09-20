using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceVandal.Data
{
    public class DataRecieve : MonoBehaviour
    {
        private string filePath = "userData_Resources.txt";
        public Dictionary<string,int> resourceDataRecieve()
        {
            Dictionary<string,int> dataToRecieve = new Dictionary<string,int>();
            using (StreamReader dataReader = new StreamReader(filePath))
            {
                while (!dataReader.EndOfStream)
                {
                    dataToRecieve.Add(dataReader.ReadLine(), int.Parse(dataReader.ReadLine()));
                }
            }
            return dataToRecieve;
        }
        public string resourceDataRecieve(string key)
        {
            string data = "";
            using (StreamReader dataReader = new StreamReader(filePath))
            {
                while (!dataReader.EndOfStream)
                {
                    string line = dataReader.ReadLine();

                    if (line == key)
                    {
                        data = line;
                        break;
                    }
                }
            }

            return data;
        }
        public void resourceDataChange(string key,string process,int number)
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
            oldValue = int.Parse(data[keyIndex+1]);
            if (process == "Addition")
            {
                data[keyIndex+1] = (oldValue + number).ToString();
            }
            if (process == "Subtraction")
            {
                if ((oldValue-number)<0)
                {
                    Debug.Log("Resource deðerleri 0 dan küçük olamaz !");
                }
                else
                {
                    data[keyIndex + 1] = (oldValue - number).ToString();
                }
            }
        }

    }
}
//string content = File.ReadAllText(filePath);

// 2. Eski deðeri bul ve yeni deðerle deðiþtir
//string oldValue = "eski_deger";
//string newValue = "yeni_deger";
//string newContent = content.Replace(oldValue, newValue);
