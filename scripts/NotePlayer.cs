using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    public ChromaticScale chromaticScale;
    public bool playingNotes = false;

    void Update()
    {
        if (playingNotes)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                chromaticScale.PlayNoteAt(261.63f);  // C4
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                chromaticScale.PlayNoteAt(293.66f);  // D4
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                chromaticScale.PlayNoteAt(329.63f);  // E4
            }
            // Add more notes as needed
        }
    }
}