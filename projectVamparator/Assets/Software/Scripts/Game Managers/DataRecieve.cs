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
        #region Resource
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
        public int resourceDataRecieve(string key)
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
            return int.Parse(data);
        }
        #endregion
        #region Money
        string filePathMoney = "userData_Money.txt";
        public float moneyDataRecieve()
        {
            float dataToRecieve = 0;
            using (StreamReader dataReader = new StreamReader(filePathMoney))
            {
                dataToRecieve = float.Parse(dataReader.ReadLine());
            }
            return dataToRecieve;
        }
        #endregion
    }
}
