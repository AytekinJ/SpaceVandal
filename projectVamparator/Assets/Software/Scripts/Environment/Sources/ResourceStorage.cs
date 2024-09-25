using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] bool randomizeContents = false; //varsayýlan olarak kapalý
    [SerializeField] Dictionary<string,int> resourceContents = new Dictionary<string,int>();
    
    void Start()
    {
        if (randomizeContents)
        {
            //help me
        }
    }
   
}
