using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelAudioScript : MonoBehaviour
{
    [SerializeField] GameObject returnBtn;


    [SerializeField] GameObject levelBGM;
    [SerializeField] GameObject victoryAudio;

    bool victoryIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        victoryAudio.GetComponent<AudioSource>().loop = false;
        levelBGM.GetComponent<AudioSource>().Play();
        levelBGM.GetComponent<AudioSource>().loop = true;
        victoryIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(victoryIsActive == false)
        {
            if(returnBtn.activeInHierarchy == true)
            {
                levelBGM.GetComponent<AudioSource>().Stop();
                victoryAudio.GetComponent<AudioSource>().Play();
                victoryIsActive = true;
            }
        }
    }
}
