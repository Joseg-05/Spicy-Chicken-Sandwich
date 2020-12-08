using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioS;
    // Start is called before the first frame update
    public void PlayClip(AudioClip clip)
    {
        audioS.PlayOneShot(clip);
    }
}
