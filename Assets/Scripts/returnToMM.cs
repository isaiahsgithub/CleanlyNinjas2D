using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMM : MonoBehaviour
{
    
    public void goMM()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
