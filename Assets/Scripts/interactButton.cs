using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactButton : MonoBehaviour
{
    Sprite buttonOffSprite;
    [SerializeField] Sprite buttonOnSprite;
    [SerializeField] GameObject blockageObject;
    

    //At the start of the game, save the original off sprite. This will be used when a player steps off of the button.
    private void Start()
    {
        buttonOffSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    
    //When the player stands on a button
    private void OnTriggerStay2D(Collider2D collision)
    {
        //A player must stay on the button in order for the blockage to disappear.
        if (collision.gameObject.name.Contains("Purple") || collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow") || collision.gameObject.name.Contains("Green") || collision.gameObject.name.Contains("White"))
        {

           

            blockageObject.SetActive(false);

            //Show that the button is being stood on
            this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonOnSprite;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //When the player gets off the button, the blockage re-appears.
        if (collision.gameObject.name.Contains("Purple") || collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow") || collision.gameObject.name.Contains("Green") || collision.gameObject.name.Contains("White"))
        {
            blockageObject.SetActive(true);

            //Show that the button is no longer being stood on

            this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonOffSprite;
        }
    }
}
