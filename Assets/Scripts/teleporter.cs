using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class teleporter : MonoBehaviour
{
    [SerializeField] Vector3 moveToLoc;
    [SerializeField] Camera mainCamera;
    [SerializeField] TextMeshProUGUI tutorialTextBox;
    string[] possibleTextOptions;

    //For the tutorial, when the game starts show the initial tutorial text.
    private void Start()
    {
        if(tutorialTextBox != null)
        {
            possibleTextOptions = tutorialTextBox.GetComponent<tutorialText>().textOptions;
            tutorialTextBox.text = possibleTextOptions[tutorialTextBox.GetComponent<tutorialText>().textPosition];
        }
    }

    //When a player enters the trigger collider that the door has.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a Ninja interacts with a door/teleporter.
        if(collision.gameObject.name.Contains("Purple") || collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow") || collision.gameObject.name.Contains("Green") || collision.gameObject.name.Contains("White")){
            collision.gameObject.transform.position = moveToLoc;
            //Only move the camera if the ninja who enters the door is the primary ninja (i.e. don't move the camera if a clone passes through a door).
            if(collision.gameObject.GetComponent<moveNinja>().canIMove == true)
            {
                //Have the camera show the next part of the level.
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, (mainCamera.transform.position.y - 15.5f), mainCamera.transform.position.z);
            }
            //If we are in the tutorial, update the informative text.
            if (tutorialTextBox != null)
            {
                //Only update the text if the ninja who enters the door is the primary ninja (i.e. don't update text if a clone passes through a door).
                if(collision.gameObject.GetComponent<moveNinja>().canIMove == true)
                {
                    tutorialTextBox.GetComponent<tutorialText>().textPosition += 1;
                    tutorialTextBox.text = possibleTextOptions[tutorialTextBox.GetComponent<tutorialText>().textPosition];

                }
            }
        }
    }


}
