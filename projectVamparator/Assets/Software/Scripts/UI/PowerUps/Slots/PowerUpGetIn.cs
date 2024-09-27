using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGetIn : MonoBehaviour
{
    bool snapped = false;
    bool isAvailable = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp") && isAvailable)
        {
            collision.gameObject.GetComponent<Dragging>().isInSlot = true;
            isAvailable = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!snapped)
        {
            if (!collision.gameObject.GetComponent<Dragging>().isDragging)
            {
                collision.gameObject.transform.position = transform.position;
                snapped = true;
                collision.gameObject.GetComponent<Dragging>().isInSlot = false;
                collision.gameObject.GetComponent<Dragging>().originalPosition = transform.position;
                collision.gameObject.GetComponent<Dragging>().snappedSlot = gameObject.tag;
                isAvailable = false;
            }
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (snapped)
        {
            snapped = false;
        }
        if (collision.gameObject.GetComponent<Dragging>().isInSlot)
        {
            collision.gameObject.GetComponent<Dragging>().isInSlot = false;
        }
        isAvailable = true;
    }
}
