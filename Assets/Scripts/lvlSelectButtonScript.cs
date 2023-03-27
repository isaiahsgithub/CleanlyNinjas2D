using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class lvlSelectButtonScript : MonoBehaviour
{


    [SerializeField] Button suspiciousButton;
    [SerializeField] public GameObject lvlCameraPosition;
    [SerializeField] public GameObject playerPosition;

    private void Start()
    {
        //Prevent clicking on the button, and reduce its opacity.
        suspiciousButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "???";
        suspiciousButton.enabled = false;
        suspiciousButton.gameObject.GetComponent<Image>().color = new Color(suspiciousButton.gameObject.GetComponent<Image>().color.r, suspiciousButton.gameObject.GetComponent<Image>().color.g, suspiciousButton.gameObject.GetComponent<Image>().color.b, 0.35f);
        lvlCameraPosition.transform.position = new Vector3(0, 0, -10);
        playerPosition.transform.position = new Vector3(-10f, -3.48f, 0f);
        DontDestroyOnLoad(lvlCameraPosition);
        DontDestroyOnLoad(playerPosition);
    }

    public void returnToMainMenu()
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

        SceneManager.LoadScene("MainMenu");
    }

    public void startLevel1()
    {
        lvlCameraPosition.transform.position = new Vector3(60, 0, -10);
        playerPosition.transform.position = new Vector3(50f, -3.48f, 0f);
        SceneManager.LoadScene("SampleScene");
    }

    public void startLevel2()
    {
        lvlCameraPosition.transform.position = new Vector3(120, 0, -10);
        playerPosition.transform.position = new Vector3(110f, -3.48f, 0f);
        SceneManager.LoadScene("SampleScene");

    }

    public void startLevel3()
    {

        lvlCameraPosition.transform.position = new Vector3(180, 0, -10);
        playerPosition.transform.position = new Vector3(170f, -3.48f, 0f);
        SceneManager.LoadScene("SampleScene");
    }

    public void completeRewardBtn()
    {
        Debug.Log("here");
    }

}
