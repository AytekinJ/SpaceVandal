using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    private Vector3 originalPosition;  // Baþlangýç pozisyonu
    private bool isDragging = false;   // Sürükleniyor mu?
    private Vector3 offset;            // Fare týklamasý ile obje arasýndaki mesafe

    void Start()
    {
        // Nesnenin baþlangýç pozisyonunu kaydet
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        // Fare týklamasý baþladýðýnda sürüklemeyi baþlat
        isDragging = true;

        // Fare ile obje arasýndaki mesafeyi kaydet
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Fare pozisyonunu al ve objeyi ona göre hareket ettir
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
            objPosition.z = 0; // Z eksenini sabit tut (2D oyunlar için)
            transform.position = objPosition;
        }
    }

    void OnMouseUp()
    {
        // Fareyi býraktýðýnda sürüklemeyi býrak
        isDragging = false;

        // Objeyi orijinal pozisyonuna döndür
        transform.position = originalPosition;
    }
}
