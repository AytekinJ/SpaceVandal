using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public Vector3 originalPosition;  // Ba�lang�� pozisyonu
    public bool isDragging = false;   // S�r�kleniyor mu?
    private Vector3 offset;
    public bool isInSlot = false;
    void Start()
    {
        // Nesnenin ba�lang�� pozisyonunu kaydet
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        // Fare t�klamas� ba�lad���nda s�r�klemeyi ba�lat
        isDragging = true;

        // Fare ile obje aras�ndaki mesafeyi kaydet
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Fare pozisyonunu al ve objeyi ona g�re hareket ettir
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
            objPosition.z = 0; // Z eksenini sabit tut (2D oyunlar i�in)
            transform.position = objPosition;
        }
    }

    void OnMouseUp()
    {
        // Fareyi b�rakt���nda s�r�klemeyi b�rak
        isDragging = false;

        if (!isInSlot)
        {
            transform.position = originalPosition;
        }
    }
}
