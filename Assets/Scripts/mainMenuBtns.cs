using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuBtns : MonoBehaviour
{
    

   public void lvlSelect()
    {
        //Load up level selection screen scene
        SceneManager.LoadScene("LevelSelectScene");
    }


    //Loads up the tutorial.
    public void tutorial()
    {
        SceneManager.LoadScene("SampleScene");
    }


    //Quit the game - only works when in the build of the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
