using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onLevelLoad : MonoBehaviour
{

    GameObject characterInfo;
    GameObject cameraInfo;
    [SerializeField] GameObject[] ninjas;
    [SerializeField] Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        characterInfo = GameObject.FindGameObjectWithTag("characterPositionTag");
        cameraInfo = GameObject.FindGameObjectWithTag("cameraPositionTag");
        if(characterInfo != null && cameraInfo != null)
        {
            mainCamera.transform.position = cameraInfo.transform.position;
            foreach (GameObject n in ninjas)
            {
                n.transform.position = characterInfo.transform.position;
            }

        }
    }
}
