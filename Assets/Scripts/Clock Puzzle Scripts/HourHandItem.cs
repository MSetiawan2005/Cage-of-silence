using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHandItem : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 initialPosition;

    private void OnMouseDown()
    {
        isDragging = true;
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Clock"))
            {
                FindObjectOfType<ClockController>().HandleHourHandCollision();
                Destroy(gameObject);
            }
        }
        transform.position = initialPosition;
    }
}
