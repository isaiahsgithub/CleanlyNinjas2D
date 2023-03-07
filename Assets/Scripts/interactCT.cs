using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class interactCT : MonoBehaviour
{

    TextMeshProUGUI remainingCountTxt;
    int maxCount = 999;
    int remainingCount = 999;

    [SerializeField] GameObject blockageObject;

    //Countable buttons are buttons that require to be stepped on X times. When the game starts, initialize that X value.
    void Start()
    {
        remainingCountTxt = this.gameObject.GetComponentInChildren<Canvas>().gameObject.GetComponentInChildren<TextMeshProUGUI>();
        remainingCount = int.Parse(remainingCountTxt.text);
        maxCount = remainingCount;
    }

    //When a countable button is stepped on by a player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Purple") || collision.gameObject.name.Contains("Red") || collision.gameObject.name.Contains("Yellow") || collision.gameObject.name.Contains("Green") || collision.gameObject.name.Contains("White"))
        {
            //If the player steps on countable button, but does not complete it (step on it until it reaches 0)
            if (remainingCount > 0)
            {
                //Decrease count, inform user on how many more times they need to step on the counting tile
                remainingCount -= 1;
                remainingCountTxt.text = remainingCount.ToString();

                //If completed after this process
                if(remainingCount == 0)
                {
                    //Change color to green to indicate it is activated
                    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 255);

                    //Delete blockage
                    blockageObject.SetActive(false);
                }
            }
        }


    }

    //Used for a reset&new ninja. If the player steps on a countable button then resets, reset the progress of the button.
    public void resetCT()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 255);
        blockageObject.SetActive(true);
        remainingCount = maxCount;
        remainingCountTxt.text = remainingCount.ToString();
    }

}
