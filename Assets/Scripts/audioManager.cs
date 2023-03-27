using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] private GameObject gameAudio;
    private bool isMusicPlaying = false;

    void Start()
    {
        gameAudio.GetComponent<AudioSource>().Play();
        gameAudio.GetComponent<AudioSource>().loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
