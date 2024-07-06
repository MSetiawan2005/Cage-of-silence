using UnityEngine;
using UnityEngine.UI;

public class InspectOnClick : MonoBehaviour
{
    public GameObject inspectPanel; // Referensi ke panel inspeksi UI
    public Image objectImage; // Referensi ke UI Image untuk menampilkan gambar objek

    private bool isInspecting = false;

    void Start()
    {
        inspectPanel.SetActive(false); // Panel inspeksi dimatikan secara default
    }

    void Update()
    {
        // Tombol kembali ke menu seharusnya ditekan di sini
        if (Input.GetKeyDown(KeyCode.Escape) && isInspecting)
        {
            CloseInspectPanel();
        }
    }

    void OnMouseDown()
    {
        if (!isInspecting)
        {
            // Aktifkan panel inspeksi
            inspectPanel.SetActive(true);
            isInspecting = true;

            // Tampilkan gambar dari GameObject ini
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                objectImage.sprite = spriteRenderer.sprite; // Menampilkan sprite dari SpriteRenderer jika ada
            }
            else
            {
                // Jika tidak ada SpriteRenderer, tampilkan pesan atau handle sesuai kebutuhan
                Debug.LogWarning("Tidak ada SpriteRenderer pada GameObject ini.");
            }

            // Jangan lupa untuk menonaktifkan interaksi dengan objek lainnya saat inspeksi
            // Misalnya, jika ada input lain yang akan diabaikan selama inspeksi.
        }
    }

    void CloseInspectPanel()
    {
        // Menonaktifkan panel inspeksi
        inspectPanel.SetActive(false);
        isInspecting = false;

        // Aktifkan kembali interaksi dengan objek lainnya setelah inspeksi selesai
    }
}