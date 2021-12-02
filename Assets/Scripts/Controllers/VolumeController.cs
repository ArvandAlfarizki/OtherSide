using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    public static VolumeController Instance { get; set; }

    private AudioSource audioSrc;

    private float musicVolume = 1f;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    
}
