using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public GameObject existingHourHand;
    private CircleCollider2D clockCollider;

    private void Start()
    {
        clockCollider = GetComponent<CircleCollider2D>();
    }

    public void HandleHourHandCollision()
    {
        existingHourHand.GetComponent<SpriteRenderer>().enabled = true;
        existingHourHand.GetComponent<Collider2D>().enabled = true;
        clockCollider.enabled = false;
    }
}
