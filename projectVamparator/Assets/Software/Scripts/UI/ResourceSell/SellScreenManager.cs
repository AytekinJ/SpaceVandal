using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellScreenManager : MonoBehaviour
{
    [SerializeField] GameObject sellScreen;
    private bool SellScreenOpen = false;
    public void SellButtonClicked()
    {

    }
    public void SellScreenTriggerClicked()
    {
        sellScreen.SetActive(!SellScreenOpen);
        SellScreenOpen = !SellScreenOpen;
    }
    
}
