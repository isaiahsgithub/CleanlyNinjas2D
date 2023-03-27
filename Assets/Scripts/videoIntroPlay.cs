using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class videoIntroPlay : MonoBehaviour
{
    double maxVideoTime;
    double currentVideoTime;
    [SerializeField] GameObject myVideo;
    // Start is called before the first frame update
    void Start()
    {
        maxVideoTime = myVideo.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        
        //If the user presses any key, go to main menu.
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainMenu");

        }

        //When the video finishes, go to main menu
        //Source: https://forum.unity.com/threads/how-to-know-video-player-is-finished-playing-video.483935/

        currentVideoTime = myVideo.GetComponent<VideoPlayer>().time;
        if(currentVideoTime >= maxVideoTime)
        {
            SceneManager.LoadScene("MainMenu");

        }

    }
}
