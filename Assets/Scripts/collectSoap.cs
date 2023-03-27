using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectSoap : MonoBehaviour
{
    //UPDATE THIS LATER
    //add chime sound effect when you collect a piece of soap

    GameObject whoCollectedTheSoap = null;
    [SerializeField] GameObject soapCountUI;
    [SerializeField] GameObject soapSound; 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the Ninja interacts with the soap, update the soap count. Then hide the soap, so it can't be collected again for the remainder of the level.
        if (collision.gameObject.name.Contains("Purple") || collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow") || collision.gameObject.name.Contains("Green") || collision.gameObject.name.Contains("White"))
        {
            soapSound.GetComponent<AudioSource>().Play();
            soapCountUI.GetComponent<howMuchSoap>().updateSoapHeld();
            soapCountUI.GetComponent<howMuchSoap>().updateSoapHeldText();
            whoCollectedTheSoap = collision.gameObject;
            this.gameObject.SetActive(false);
        }
    }

    //Re-enables the soap. For soft reset (r key) it checks to see if the ninja who collected the soap was the one who requested the soft reset. If so, respawn the soap
    //i.e. if Purple Ninja collects the soap and then presses r, then the soap is respawned.
    //If purple ninja collects the soap, and the player presses r as the RED ninja, the soap will not be respawned, as the one who collected it was the purple ninja.
    public void resetSoap(GameObject theNinja)
    {
        if (theNinja == whoCollectedTheSoap)
        {
            this.gameObject.SetActive(true);
            soapCountUI.GetComponent<howMuchSoap>().decreaseSoapHeld();
            soapCountUI.GetComponent<howMuchSoap>().updateSoapHeldText();
            whoCollectedTheSoap = null;
        }
    }

}
