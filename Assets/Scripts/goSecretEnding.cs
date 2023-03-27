using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goSecretEnding : MonoBehaviour
{
 
    public void loadEndingCutscene()
    {

        GameObject chPT = GameObject.FindGameObjectWithTag("characterPositionTag");
        GameObject caPT = GameObject.FindGameObjectWithTag("cameraPositionTag");
        if (chPT != null)
        {
            Destroy(chPT);
        }
        if (caPT != null)
        {
            Destroy(caPT);
        }

        SceneManager.LoadScene("OutroCutscene");
    }
}
