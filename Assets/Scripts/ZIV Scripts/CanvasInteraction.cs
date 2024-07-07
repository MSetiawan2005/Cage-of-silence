using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasInteraction : MonoBehaviour
{
    public GameObject closedDrawer;
    public GameObject openDrawer;
    public GameObject diaryItem;

    private Collider2D drawerCollider;

    private void Start()
    {
        drawerCollider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        OpenDrawer();
    }

    public void OpenDrawer()
    {
        drawerCollider.enabled = false;

        closedDrawer.SetActive(false);
        openDrawer.SetActive(true);
        diaryItem.SetActive(true);
    }
}
