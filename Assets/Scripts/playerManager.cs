using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class playerManager : MonoBehaviour
{

    [SerializeField] GameObject purpleNinja;
    [SerializeField] GameObject redNinja;
    [SerializeField] GameObject yellowNinja;
    [SerializeField] GameObject greenNinja;
    [SerializeField] GameObject whiteNinja;
    [SerializeField] GameObject entireMapScope;

    [SerializeField] GameObject ninjaCountUI;
    [SerializeField] GameObject soapCountUI;

    [SerializeField] GameObject overlayUI;
    [SerializeField] Camera mainCamera;

    public List<Transform> allSoap;



    Vector3 purpleInitialPosition;
    Vector3 redInitialPosition;
    Vector3 yellowInitialPosition;
    Vector3 greenInitialPosition;
    Vector3 whiteInitialPosition;

    Vector3 playerStartPosition;
    
    void Start()
    {
        //Get starting positions
        purpleInitialPosition = purpleNinja.transform.position;
        redInitialPosition = redNinja.transform.position;
        yellowInitialPosition = yellowNinja.transform.position;
        greenInitialPosition = greenNinja.transform.position;
        whiteInitialPosition = whiteNinja.transform.position;

        //Disable the other ninjas
        redNinja.SetActive(false);
        yellowNinja.SetActive(false);
        greenNinja.SetActive(false);
        whiteNinja.SetActive(false);

        //Gets all soap throughout the entire scope of the game. Since all levels will be in the same scene this is the acceptable way to do  it.
        allSoap = entireMapScope.GetComponentsInChildren<Transform>().ToList().FindAll(x => x.name.Contains("soap") == true);

    }

    private void Update()
    {
        //Restart one of the clones
        if (Input.GetKeyDown("r"))
        {
            //Bug fix, you can't restart a character while the overlay is active.
            if(overlayUI.activeInHierarchy == false) { 

                playerStartPosition.y = -3.48f;
                playerStartPosition.z = 0f;
                if (mainCamera.transform.position.x == 0)
                {
                    playerStartPosition.x = -10f;
                }
                else if (mainCamera.transform.position.x == 60)
                {
                    playerStartPosition.x = 50f;
                }
                else if (mainCamera.transform.position.x == 120)
                {
                    playerStartPosition.x = 110f;
                }
                else if (mainCamera.transform.position.x == 180)
                {
                    playerStartPosition.x = 170f;
                }

                //Determine which ninja pressed the r key, and reset the values accordingly.
                if (purpleNinja.GetComponent<moveNinja>().canIMove == true)
                {

                    purpleNinja.transform.position = new Vector3(playerStartPosition.x, playerStartPosition.y, playerStartPosition.z);
                    purpleNinja.GetComponent<moveNinja>().restartStuff();
                    purpleNinja.GetComponent<moveNinja>().startRecord = false;
                    purpleNinja.GetComponent<moveNinja>().playerPosition.Clear();
                    purpleNinja.GetComponent<moveNinja>().enabled = false;
                    purpleNinja.GetComponent<moveNinja>().enabled = true;
                    purpleNinja.GetComponent<moveNinja>().startRecord = true;
                    purpleNinja.GetComponent<moveNinja>().playbackLocs = new int[] { 0, 0, 0, 0 };
                    purpleNinja.GetComponent<moveNinja>().startAllPlays = new bool[] { true, true, true, true };
                    purpleNinja.GetComponent<moveNinja>().areAnyTrue = false;


                    foreach (Transform soapObjs in allSoap)
                    {
                        soapObjs.GetComponent<collectSoap>().resetSoap(purpleNinja);
                    }
                }
                else if (redNinja.GetComponent<moveNinja>().canIMove == true)
                {
                    redNinja.transform.position = new Vector3(playerStartPosition.x, playerStartPosition.y, playerStartPosition.z);
                    redNinja.GetComponent<moveNinja>().restartStuff();
                    redNinja.GetComponent<moveNinja>().startRecord = false;
                    redNinja.GetComponent<moveNinja>().playerPosition.Clear();
                    redNinja.GetComponent<moveNinja>().enabled = false;
                    redNinja.GetComponent<moveNinja>().enabled = true;
                    redNinja.GetComponent<moveNinja>().startRecord = true;
                    redNinja.GetComponent<moveNinja>().playbackLocs = new int[] { 0, 0, 0, 0 };
                    redNinja.GetComponent<moveNinja>().startPlay = true;
                    redNinja.GetComponent<moveNinja>().startAllPlays = new bool[] { true, true, true, true };
                    redNinja.GetComponent<moveNinja>().areAnyTrue = false;

                    foreach (Transform soapObjs in allSoap)
                    {
                        soapObjs.GetComponent<collectSoap>().resetSoap(redNinja);
                    }
                }
                else if (yellowNinja.GetComponent<moveNinja>().canIMove == true)
                {
                    yellowNinja.transform.position = new Vector3(playerStartPosition.x, playerStartPosition.y, playerStartPosition.z);
                    yellowNinja.GetComponent<moveNinja>().restartStuff();
                    yellowNinja.GetComponent<moveNinja>().startRecord = false;
                    yellowNinja.GetComponent<moveNinja>().playerPosition.Clear();
                    yellowNinja.GetComponent<moveNinja>().enabled = false;
                    yellowNinja.GetComponent<moveNinja>().enabled = true;
                    yellowNinja.GetComponent<moveNinja>().startRecord = true;
                    yellowNinja.GetComponent<moveNinja>().playbackLocs = new int[] { 0, 0, 0, 0 };
                    yellowNinja.GetComponent<moveNinja>().startPlay = true;
                    yellowNinja.GetComponent<moveNinja>().startAllPlays = new bool[] { true, true, true, true };
                    yellowNinja.GetComponent<moveNinja>().areAnyTrue = false;

                    foreach (Transform soapObjs in allSoap)
                    {
                        soapObjs.GetComponent<collectSoap>().resetSoap(yellowNinja);
                    }
                }
                else if (greenNinja.GetComponent<moveNinja>().canIMove == true)
                {
                    greenNinja.transform.position = new Vector3(playerStartPosition.x, playerStartPosition.y, playerStartPosition.z);
                    greenNinja.GetComponent<moveNinja>().restartStuff();
                    greenNinja.GetComponent<moveNinja>().startRecord = false;
                    greenNinja.GetComponent<moveNinja>().playerPosition.Clear();
                    greenNinja.GetComponent<moveNinja>().enabled = false;
                    greenNinja.GetComponent<moveNinja>().enabled = true;
                    greenNinja.GetComponent<moveNinja>().startRecord = true;
                    greenNinja.GetComponent<moveNinja>().playbackLocs = new int[] { 0, 0, 0, 0 };
                    greenNinja.GetComponent<moveNinja>().startPlay = true;
                    greenNinja.GetComponent<moveNinja>().startAllPlays = new bool[] { true, true, true, true };
                    greenNinja.GetComponent<moveNinja>().areAnyTrue = false;

                    foreach (Transform soapObjs in allSoap)
                    {
                        soapObjs.GetComponent<collectSoap>().resetSoap(greenNinja);
                    }
                }
                else if (whiteNinja.GetComponent<moveNinja>().canIMove == true)
                {
                    whiteNinja.transform.position = new Vector3(playerStartPosition.x, playerStartPosition.y, playerStartPosition.z);
                    whiteNinja.GetComponent<moveNinja>().restartStuff();
                    whiteNinja.GetComponent<moveNinja>().startRecord = false;
                    whiteNinja.GetComponent<moveNinja>().playerPosition.Clear();
                    whiteNinja.GetComponent<moveNinja>().enabled = false;
                    whiteNinja.GetComponent<moveNinja>().enabled = true;
                    whiteNinja.GetComponent<moveNinja>().startRecord = true;
                    whiteNinja.GetComponent<moveNinja>().playbackLocs = new int[] { 0, 0, 0, 0 };
                    whiteNinja.GetComponent<moveNinja>().startPlay = true;
                    whiteNinja.GetComponent<moveNinja>().startAllPlays = new bool[] { true, true, true, true };
                    whiteNinja.GetComponent<moveNinja>().areAnyTrue = false;

                    foreach (Transform soapObjs in allSoap)
                    {
                        soapObjs.GetComponent<collectSoap>().resetSoap(whiteNinja);
                    }
                }
            }

        }


        //Restart entire level
        if (Input.GetKeyDown("f"))
        {
            soapCountUI.GetComponent<howMuchSoap>().resetSoapCount();
            ninjaCountUI.GetComponent<whichNinjaPlayedAs>().resetNinjaCount();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
