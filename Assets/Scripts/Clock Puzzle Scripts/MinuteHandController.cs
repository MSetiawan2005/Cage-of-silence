using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinuteHandController : MonoBehaviour
{
    public float rotationSpeed = 30f; // Degrees per click
    private float totalRotation = 0f; // Total rotation in degrees

    [SerializeField]
    private GameObject key;

    private void Start()
    {
        key.SetActive(false);
    }

    public void CheckMinuteHand(int targetMinute)
    {
        // Calculate the current minute based on total rotation
        int currentMinute = Mathf.FloorToInt((totalRotation % 360f) / 6f); // 6 degrees = 1 minute

        // Check if the current minute matches the target minute
        if (currentMinute == targetMinute)
        {
            key.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        RotateHand();
        FindObjectOfType<HourHandController>().CheckSolution();
    }

    private void RotateHand()
    {
        // Rotate the hand by the specified speed
        transform.Rotate(Vector3.back * rotationSpeed);

        // Update the total rotation
        totalRotation += rotationSpeed;

        // Keep the total rotation within 0-360 range
        totalRotation %= 360f;
    }
}
