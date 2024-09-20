using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceVandal.Data
{
    public class DataRecieve
    {
        string filePath = "userData_Resources.txt";
        public Dictionary<string,int> resourceDataRecieve()
        {
            if (!File.Exists(filePath))
            {
                // Dosya yoksa oluþtur
                File.Create(filePath).Close(); // Dosyayý oluþtur ve hemen kapat
            }
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
            if (!File.Exists(filePath))
            {
                // Dosya yoksa oluþtur
                File.Create(filePath).Close(); // Dosyayý oluþtur ve hemen kapat
            }
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
    }
}
