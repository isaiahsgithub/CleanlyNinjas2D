using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class howMuchSoap : MonoBehaviour
{
   
    public int maxSoap = 999;
    public int currentSoapHeld = 0;
    
    [SerializeField] TextMeshProUGUI soapCountText;
    [SerializeField] Camera mainCamera;

    
    //Set max soap according to level.
    void Start()
    {
        //Camera position determines level (e.g. position (X,Y) = tutorial, (X+n, Y+n) = level 1, (X+m, Y+m) = level 2, etc.)
        //Level determines soap count
        //Therefore Camera --> Soap Count (level determines soap count)
        if(mainCamera.transform.position.x == 0 && mainCamera.transform.position.y == 0)
        {
            maxSoap = 1;
        }
        //TODO: OTHER LOCATIONS
        /*else if(mainCamera.transform.position.x == NEW_VALUE && mainCamera.transform.position.y == NEW_VALUE)
        {

        }*/

        updateSoapHeldText();
    }

    //Reset the soap held (if required)
    public void resetSoapCount()
    {
        currentSoapHeld = 0;
    }

    //Update the soap held by 1 (used when collecting a piece of soap)
    public void updateSoapHeld()
    {
        currentSoapHeld += 1;
    }

    //Decrease the soap held by 1 (used when soft resetting / r)
    public void decreaseSoapHeld()
    {
        currentSoapHeld -= 1;
    }

    //Whenever a change is made to the soap in the players inventory, update the text accordingly.
    public void updateSoapHeldText()
    {
        soapCountText.text = currentSoapHeld.ToString() + "/" + maxSoap.ToString();
    }

}
