using UnityEngine;

public class FadeOutAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeTime = 3f;

    private float initialVolume;
    private float currentVolume;
    private bool isFading = false;

    void Start()
    {
        initialVolume = audioSource.volume;
        currentVolume = initialVolume;
    }

    void Update()
    {
        if (isFading)
        {
            currentVolume -= initialVolume * Time.deltaTime / fadeTime;
            audioSource.volume = currentVolume;
            if (currentVolume <= 0)
            {
                audioSource.Stop();
                isFading = false;
            }
        }
    }

    public void StartFadeOut()
    {
        isFading = true;
    }
}
