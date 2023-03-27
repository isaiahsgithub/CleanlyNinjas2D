using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class displayAllTimes : MonoBehaviour
{
    loaderSaver tempLS;
    [SerializeField] TextMeshProUGUI L1A;
    [SerializeField] TextMeshProUGUI L1F;
    [SerializeField] TextMeshProUGUI L2A;
    [SerializeField] TextMeshProUGUI L2F;
    [SerializeField] TextMeshProUGUI L3A;
    [SerializeField] TextMeshProUGUI L3F;



    [SerializeField] TextMeshProUGUI LQA;
    [SerializeField] TextMeshProUGUI LQF;
    int lsDATA = 999;
    int minutes = 999;
    int seconds = 999;
    // Start is called before the first frame update
    void Start()
    {
        tempLS = this.gameObject.GetComponent<loaderSaver>();

        // 11 - level 1, any%
        lsDATA = tempLS.loadToDisplay("/11.txt");
        minutes = Mathf.FloorToInt(lsDATA / 60);
        seconds = Mathf.FloorToInt(lsDATA % 60);
        L1A.text = "Any %: " + minutes.ToString() + ":" + seconds.ToString();

        // 10 - level 0, full%
        lsDATA = tempLS.loadToDisplay("/10.txt");
        minutes = Mathf.FloorToInt(lsDATA / 60);
        seconds = Mathf.FloorToInt(lsDATA % 60);
        L1F.text = "100 %: " + minutes.ToString() + ":" + seconds.ToString();

        // 21 - level 2, any%
        lsDATA = tempLS.loadToDisplay("/21.txt");
        minutes = Mathf.FloorToInt(lsDATA / 60);
        seconds = Mathf.FloorToInt(lsDATA % 60);
        L2A.text = "Any %: " + minutes.ToString() + ":" + seconds.ToString();

        // 20 - level 2, full%
        lsDATA = tempLS.loadToDisplay("/20.txt");
        minutes = Mathf.FloorToInt(lsDATA / 60);
        seconds = Mathf.FloorToInt(lsDATA % 60);
        L2F.text = "100 %: " + minutes.ToString() + ":" + seconds.ToString();

        // 31 - level 3, any%
        lsDATA = tempLS.loadToDisplay("/31.txt");
        minutes = Mathf.FloorToInt(lsDATA / 60);
        seconds = Mathf.FloorToInt(lsDATA % 60);
        L3A.text = "Any %: " + minutes.ToString() + ":" + seconds.ToString();

        // 30 - level 3, full%
        lsDATA = tempLS.loadToDisplay("/30.txt");
        minutes = Mathf.FloorToInt(lsDATA / 60);
        seconds = Mathf.FloorToInt(lsDATA % 60);
        L3F.text = "100 %: " + minutes.ToString() + ":" + seconds.ToString();


        //Hide text
        LQA.gameObject.SetActive(false);
        LQF.gameObject.SetActive(false);
    }


    
}
