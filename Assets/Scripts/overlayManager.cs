using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class overlayManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ninjaNumberTxt;
    [SerializeField] TextMeshProUGUI readyNinja;
    [SerializeField] Button retryBtn;
    [SerializeField] Button returnBtn;
    
    //Make the background color for the overlay have low opacity.
    void Start()
    {
        retryBtn.gameObject.SetActive(false);
        returnBtn.gameObject.SetActive(false);
        this.gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.35f);
        displayText();
    }

    //Updates the overlay UI text, to inform the player which ninja they will be playing as.
    public void displayText()
    {
        string theNinja = whichNinja();
        readyNinja.text = "Ready " + theNinja + " Ninja?";
    }

    //Starting Text "Ready _ Ninja". This determines which color ninja the player will be playing as for their turn.
    public string whichNinja()
    {
        string ninjaNumber = ninjaNumberTxt.text.Substring(0, 1);
        if(ninjaNumber == "5")
        {
            return "Blue";
        }
        else if(ninjaNumber == "4"){
            return "Green";
        }
        else if(ninjaNumber == "3")
        {
            return "Yellow";
        }
        else if(ninjaNumber == "2")
        {
            return "Red";
        }
        else
        {
            return "Purple";
        }
    }

}
