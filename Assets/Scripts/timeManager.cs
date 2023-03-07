using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeManager : MonoBehaviour
{


    [SerializeField] GameObject overlayUI;
    public float theTime = 0f;
    public float savedTime = 0f;

    public bool dontInstantlyDisappear = false;

    //Ensure the time is set to 0 when you start the game.
    void Start()
    {
        theTime = 0f;
        dontInstantlyDisappear = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Only increment the time when the player is able to move.
        //This can only be done when the overlay UI is not active.
        if(overlayUI.activeInHierarchy == false)
        {
            //Bug fix: When soft restarting via r, the timer will properly reset.
            if (Input.GetKeyDown("r"))
            {
                theTime = savedTime;

                //Bug fix: When pressing R, re-show the overlay UI. "(Ready _ Ninja)".
                overlayUI.SetActive(true);

                dontInstantlyDisappear = true;
            }
            //Update time
            theTime += Time.deltaTime;

            //Minutes and seconds source: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
            this.gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(theTime / 60), Mathf.FloorToInt(theTime % 60));

        }
        else
        {
            //When the UI is active, it means that the player is either playing with a new ninja, or they have completed the level.
            //If it's the first one, save the time before playing as the new ninja, as if a soft reset occurs, we can properly revert back to the proper previous time.
            savedTime = theTime;
        }


    }
    //Reset the time values back to 0, and reflect that in the text as well.
    public void resetTime()
    {
        savedTime = 0f;
        theTime = 0f;
        this.gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(theTime / 60), Mathf.FloorToInt(theTime % 60));
    }
}
