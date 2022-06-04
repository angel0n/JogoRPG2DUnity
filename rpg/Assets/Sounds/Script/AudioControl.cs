using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{

    [SerializeField] private AudioClip bgmMusic;
    private AudioManager audioM;
    // Start is called before the first frame update
    void Start()
    {
        audioM = FindObjectOfType<AudioManager>();
        audioM.playBGM(bgmMusic);
    }

}
