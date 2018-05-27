using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherHandler : MonoBehaviour {

    [SerializeField]
    private List<AudioClip> sounds;

    private AudioSource audiosrc;

    private void Awake()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    public void PlayDrawSound()
    {
        audiosrc.PlayOneShot(sounds[0], 1);
    }

    public void PlayShootSound()
    {
        audiosrc.PlayOneShot(sounds[1], 1);
    }

}
