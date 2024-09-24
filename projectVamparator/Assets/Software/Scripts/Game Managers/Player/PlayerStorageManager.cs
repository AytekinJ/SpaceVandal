using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStorageManager : MonoBehaviour
{
    [SerializeField] public int maxStorage = 20;
    [SerializeField] public int CurrentStorage = 0;
    [SerializeField] public float collectSpeed = 0.5f;
    [SerializeField] public int collectAmount = 1;
}
