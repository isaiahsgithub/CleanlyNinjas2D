using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goSecretEnding : MonoBehaviour
{
 
    public void loadEndingCutscene()
    {

        SceneManager.LoadScene("OutroCutscene");
    }
}
