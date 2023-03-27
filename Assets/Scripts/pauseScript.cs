using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameObject overlayUI;
    [SerializeField] GameObject backgroundIMG;
    private void Start()
    {
        backgroundIMG.gameObject.GetComponent<Image>().color = new Color(backgroundIMG.gameObject.GetComponent<Image>().color.r, backgroundIMG.gameObject.GetComponent<Image>().color.g, backgroundIMG.gameObject.GetComponent<Image>().color.b, 0.35f);
        PauseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //You can only pause when the overlay UI is not active.   
        if(overlayUI.activeInHierarchy == false)
        {
            //If the user presses escape, they can either pause or unpause the game from this screen.
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //Pause (if pause is not currently up)
                if (PauseScreen.activeInHierarchy == false)
                {
                    pauseGame();
                }
                else
                {
                    //Press escape again to unpause.
                    unpauseGame();
                }



            }
        }



    }

    //Pauses game
    public void pauseGame()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    //Unpauses game
    public void unpauseGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    //Returns to main menu.
    public void returnToMM()
    {
        unpauseGame();
        GameObject charP = GameObject.FindGameObjectWithTag("characterPositionTag");
        GameObject camP = GameObject.FindGameObjectWithTag("cameraPositionTag");
        if (charP != null)
        {
            Destroy(charP);
        }
        if (camP != null)
        {
            Destroy(camP);
        }


        SceneManager.LoadScene("MainMenu");
    }

}
