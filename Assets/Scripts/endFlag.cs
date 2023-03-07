using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class endFlag : MonoBehaviour
{

    [SerializeField] GameObject overlayUI;
    [SerializeField] TextMeshProUGUI readyText;
    [SerializeField] TextMeshProUGUI soapCollectedText;
    [SerializeField] GameObject soapInfo;

    [SerializeField] Button retryBtn;
    [SerializeField] Button returnBtn;
    [SerializeField] GameObject timeObj;

    [SerializeField] Camera mainCamera;

    bool anyPercent = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a ninja collides with the ending flag
        if (collision.gameObject.name.Contains("Purple") || collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow") || collision.gameObject.name.Contains("Green") || collision.gameObject.name.Contains("White"))
        {
            
            //Block movement 
            collision.gameObject.GetComponent<moveNinja>().canIMove = false;

            //TODO Play sound effect




            //Show UI
            overlayUI.SetActive(true);

            //Set text to show: 
            //You win! \n
            //Time taken \n
            //Soap collected \n
            //Category qualified for (100% or any% clear) \n
            //Minutes and seconds source: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
            string endPrompt = string.Format("Level cleared! \n Time taken: {0:00}:{1:00} \n " +
                "Soap collected: " + soapCollectedText.text.Substring(0, 1) + " \n Category qualified for: ", 
                Mathf.FloorToInt(timeObj.gameObject.GetComponent<timeManager>().theTime / 60), Mathf.FloorToInt(timeObj.gameObject.GetComponent<timeManager>().theTime % 60));

            //TODO - check if this works for later levels when the soap count is greater than 1 digit (as we are only checking 1 digit right now).
            //Determine if the player performed a 100% run or an any% run (did not collect all soap)
            if (int.Parse(soapCollectedText.text.Substring(0, 1)) == soapInfo.GetComponent<howMuchSoap>().maxSoap)
            {
                endPrompt += "100% \n";
                anyPercent = false;
            }
            else
            {
                endPrompt += "Any% \n";
                anyPercent = true;
            }
            readyText.text = endPrompt;

            string theFileName = "/99.txt";
            //Save game FORMAT: 00 - level 0, 100% | 01 - level 0, any% | 10 - level 1, 100% | 11 - level 1, any% | etc
            //Camera position determines which level you are on.
            if (mainCamera.transform.position.x == 0.00 && mainCamera.transform.position.y == -46.50)
            {
                //We are in the tutorial level: (0)
                if (anyPercent == true)
                {
                    theFileName = "/01.txt";
                }
                else
                {
                    theFileName = "/00.txt";
                }
                
                //Converts the players time into proper minutes and seconds
                int minutes = Mathf.FloorToInt(timeObj.gameObject.GetComponent<timeManager>().theTime / 60);
                int seconds = Mathf.FloorToInt(timeObj.gameObject.GetComponent<timeManager>().theTime % 60);

                //Check if a PB is made, if so save it
                overlayUI.GetComponent<loaderSaver>().loadToCheckIfSave(theFileName, minutes, seconds);
            }

            //Show a button saying "Return to main menu" and a button that enables a restart.
            //When button is clicked,  change ninja to 1, run displayText(), hide all the elements, return to main menu or restart the level. (other script)
            retryBtn.gameObject.SetActive(true);
            returnBtn.gameObject.SetActive(true);

        }




    }
}
