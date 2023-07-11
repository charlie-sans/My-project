using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromaticScale : MonoBehaviour
{
    public float basePitch = 261.63f;  // C4
    public AudioClip audioClip;

    private List<float> pitches = new List<float>();
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Generate the pitches for a chromatic scale
        for (int i = 0; i < 13; i++)
        {
            float pitch = basePitch * Mathf.Pow(2f, i/12f);
            pitches.Add(pitch);
        }
    }

    IEnumerator PlayScale()
    {
        foreach (float pitch in pitches)
        {
            audioSource.pitch = pitch / basePitch;
            audioSource.PlayOneShot(audioClip);
            yield return new WaitForSeconds(audioClip.length);
        }
    }

    public void PlayNoteAt(float pitch)
    {
        audioSource.pitch = pitch / basePitch;
        audioSource.PlayOneShot(audioClip);
    }
}