using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] bool randomizeContents = false; //varsay�lan olarak kapal�
    [SerializeField] Dictionary<string,int> resourceContents = new Dictionary<string,int>();
    
    void Start()
    {
        if (randomizeContents)
        {
            //help me
        }
    }
   
}
