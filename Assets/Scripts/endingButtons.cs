using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class endingButtons : MonoBehaviour
{
    [SerializeField] GameObject ninjaCountUI;
    [SerializeField] GameObject soapCountUI;
    [SerializeField] Button retryBtn;
    [SerializeField] Button returnBtn;
    [SerializeField] GameObject timeObj;


    ////When button is clicked,  change ninja to 1, run displayText(), hide all the elements, return to main menu

    //When the retry button is clicked, the player restarts the level. Resets all the required variables.
    public void retryLevel()
    {
        soapCountUI.GetComponent<howMuchSoap>().resetSoapCount();
        ninjaCountUI.GetComponent<whichNinjaPlayedAs>().resetNinjaCount();
        this.gameObject.GetComponentInChildren<overlayManager>().displayText();
        retryBtn.gameObject.SetActive(false);
        returnBtn.gameObject.SetActive(false);
        timeObj.gameObject.GetComponent<timeManager>().resetTime();
        SceneManager.LoadScene("SampleScene");
    }

    //Go to the main menu. Reset all the proper variables to their original values.
    public void returnToMainMenu()
    {
        soapCountUI.GetComponent<howMuchSoap>().resetSoapCount();
        ninjaCountUI.GetComponent<whichNinjaPlayedAs>().resetNinjaCount();
        this.gameObject.GetComponentInChildren<overlayManager>().displayText();
        timeObj.gameObject.GetComponent<timeManager>().resetTime();
        retryBtn.gameObject.SetActive(false);
        returnBtn.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
