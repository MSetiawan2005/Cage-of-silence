using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject objectUIPrefab; // Prefab UI Canvas atau panel yang menampilkan informasi objek
    private GameObject objectUI; // Instance UI objek yang sedang ditampilkan

    private bool isUIVisible = false; // Status apakah UI objek sedang ditampilkan
    private int clickCount = 0;
    void Start()
    {
        // Setelah objek diinstansiasi, UI objek belum ditampilkan
        isUIVisible = false;
    }

    void Update()
    {
        // Mendeteksi klik pada objek
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPosition2D = new Vector2(clickPosition.x, clickPosition.y);

            // Mendeteksi klik menggunakan BoxCollider2D
            Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition2D);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                if (!isUIVisible)
                {
                    ShowUI();
                }
               
            }

            clickCount++;
            
            if (clickCount == 2)
            {
                DestroyObject();
            }
            else 
            {
                Invoke("Reset", 0.5f);
            }
        }
    }

    private void Reset()
    {
        clickCount = 0;
    }
    void ShowUI()
    {
        // Instantiate UI Canvas atau panel
        objectUI = Instantiate(objectUIPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        isUIVisible = true;
    }

    void DestroyObject()
    {
        // Hancurkan UI dan objek
        Destroy(objectUI);
        Destroy(gameObject);
        isUIVisible = false;
    }
}