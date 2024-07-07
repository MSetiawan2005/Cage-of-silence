using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUIWindow : MonoBehaviour
{
    public GameObject zoomedInViewCanvas;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(!RectTransformUtility.RectangleContainsScreenPoint(zoomedInViewCanvas.GetComponent<RectTransform>(), mousePos)){
                zoomedInViewCanvas.SetActive(false);
            }
        }
    }
}
