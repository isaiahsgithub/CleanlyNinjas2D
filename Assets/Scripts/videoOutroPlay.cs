using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class videoOutroPlay : MonoBehaviour
{
    double maxVideoTime;
    double currentVideoTime;
    [SerializeField] Button returnToMainMenuBtn;
    [SerializeField] GameObject thanksForPlayingImg;
    [SerializeField] GameObject myVideo;

    // Start is called before the first frame update
    void Start()
    {
        thanksForPlayingImg.SetActive(false);
        returnToMainMenuBtn.gameObject.SetActive(false);
        maxVideoTime = myVideo.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        //When the video finishes, go to main menu
        //Source: https://forum.unity.com/threads/how-to-know-video-player-is-finished-playing-video.483935/

        currentVideoTime = myVideo.GetComponent<VideoPlayer>().time;
        if (currentVideoTime >= maxVideoTime)
        {
            thanksForPlayingImg.SetActive(true);

            returnToMainMenuBtn.gameObject.SetActive(true);
            this.gameObject.SetActive(false);

        }
    }

}
