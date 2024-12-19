using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 1;  // Nilai skor yang diberikan
    private AudioSource audioSource;  // Referensi untuk AudioSource
    public AudioClip soundEffect;  // AudioClip yang akan dimainkan

    void Start()
    {
        // Mendapatkan referensi ke AudioSource yang ada di objek ini
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found on " + gameObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Menambah skor
            GameManager gm = FindObjectOfType<GameManager>();
            gm.AddScore(scoreValue);

            // Memainkan suara jika AudioSource ada
            if (audioSource != null && soundEffect != null)
            {
                Debug.Log("Playing sound...");
                audioSource.PlayOneShot(soundEffect);  // Mainkan suara saat koin diambil
            }
            else
            {
                Debug.LogWarning("AudioSource or AudioClip is null on " + gameObject.name);
            }

            // Menghancurkan objek koin setelah diambil
            Destroy(gameObject);
        }
    }
}
