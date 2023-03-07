using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class whichNinjaPlayedAs : MonoBehaviour
{
    public int maxNinja = 5;
    public int currentNinja = 1;
    [SerializeField] TextMeshProUGUI ninjaCountTxt;

    //This script is used to inform the UI/player which ninja they are playing as out of 5.

    //When you first start, you are ninja 1.
    private void Awake()
    {
        currentNinja = 1;
    }

    //When resetting, you go back to ninja 1.
    public void resetNinjaCount()
    {
        currentNinja = 1;
    }

    //When progressing, you progress by 1 ninja.
    public void updateNinjaCount()
    {
        currentNinja += 1;
    }

    //Update the UI text, so the player knows which ninja they are playing as.
    public void updateNinjaCountText()
    {
        ninjaCountTxt.text = currentNinja.ToString() + "/" + maxNinja.ToString();
    }

    //When the game first starts, ensure the text is correct.
    private void Start()
    {
        updateNinjaCountText();
    }
}
