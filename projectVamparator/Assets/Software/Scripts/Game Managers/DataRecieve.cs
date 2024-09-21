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
                        data = dataReader.ReadLine();
                        break;
                    }
                }
            }
            return data;
        }
    }
}
