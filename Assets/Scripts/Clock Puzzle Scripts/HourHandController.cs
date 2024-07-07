using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHandController : MonoBehaviour
{
    public float rotationSpeed = 30f; // Degrees per click
    private float totalRotation = 0f; // Total rotation in degrees

    private void OnMouseDown()
    {
        RotateHand();
        CheckSolution();
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

    public void CheckSolution()
    {
        // Assume the target time is 5:15
        int targetHour = 5;
        int targetMinute = 15;

        // Calculate the current time based on total rotation
        int currentHourSolution = Mathf.FloorToInt(totalRotation / 30f); // 30 degrees per hour

        // Check if the current hour matches the target hour
        if (currentHourSolution == targetHour)
        {
            // Now check the minute hand (handled by MinuteHandController)
            FindObjectOfType<MinuteHandController>().CheckMinuteHand(targetMinute);
        }
    }
}
