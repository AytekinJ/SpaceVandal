using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGetIn : MonoBehaviour
{
    bool snapped = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            collision.gameObject.GetComponent<Dragging>().isInSlot = true;
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
            }
        }   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        snapped = false;
    }
}
