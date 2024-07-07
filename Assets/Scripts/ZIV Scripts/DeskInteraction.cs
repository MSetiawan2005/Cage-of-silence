using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInteraction : MonoBehaviour
{
    public GameObject zoomedInViewCanvas;

    private bool drawerOpen = false;

    private void OnMouseDown()
    {
        zoomedInViewCanvas.SetActive(true);
    }
}
