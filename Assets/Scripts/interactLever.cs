using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactLever : MonoBehaviour
{
    Sprite leverOff; 
    [SerializeField] Sprite leverOn;
    bool isActivated;
    [SerializeField] GameObject blockageObject;

    //Saves the lever off sprite.
    void Start()
    {
        leverOff = this.gameObject.GetComponent<SpriteRenderer>().sprite;
        isActivated = false;
    }

    //When the player interacts with the lever.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("Purple") || collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow") || collision.gameObject.name.Contains("Green") || collision.gameObject.name.Contains("White"))
        {
           //If the lever isn't activated, activate it.
           if(isActivated == false)
            {
                //Update switch
                this.gameObject.GetComponent<SpriteRenderer>().sprite = leverOn;

                //Delete Blockage
                blockageObject.SetActive(false);
                

            }
            /*else
            {
                //Update switch to be back off
                this.gameObject.GetComponent<SpriteRenderer>().sprite = leverOff;

                //Re-enable blockage
                blockageObject.SetActive(true);
            }

            isActivated = !isActivated;*/
        }
        
    }

    //Used for reset&new ninja. Re-disables the lever.
    public void resetLever()
    {
        isActivated = false;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = leverOff;
        blockageObject.SetActive(true);
    }
}
