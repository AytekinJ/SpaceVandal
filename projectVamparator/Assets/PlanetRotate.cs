using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0,0,Time.deltaTime*speed));
    }
}
