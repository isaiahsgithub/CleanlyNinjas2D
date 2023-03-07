using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]
public class saveDataTimeClass
{
    public int minutes;
    public int seconds;

    //Constructor

    public saveDataTimeClass(int min, int sec)
    {
        this.minutes = min;
        this.seconds = sec;
    }
}

public class loaderSaver : MonoBehaviour
{
    //FORMAT: 00 - level 0, 100% | 01 - level 0, any% | 10 - level 1, 100% | 11 - level 1, any% | etc
   public void loadToCheckIfSave(string filename, int min, int sec)
    {
        //The path where the save file will be stored
        string path = Application.persistentDataPath + filename;

        //If the file exists
        if (File.Exists(path))
        {
            //Get the json from the text file
            string json = File.ReadAllText(path);

            //Convert the json into data
            saveDataTimeClass loadedData = JsonUtility.FromJson<saveDataTimeClass>(json);

            //If the data is not null, it means that there is data in the file.
            if(loadedData != null)
            {
                //If minutes are less, then we save.
                if (min < loadedData.minutes)
                {
                    saveNewPB(filename, min, sec);
                    Debug.Log("Saving due to new record! (In minutes!)");
                }
                //If minutes are the same but seconds are lower, then we save.
                else if(min == loadedData.minutes)
                {
                    if(sec < loadedData.seconds)
                    {
                        saveNewPB(filename, min, sec);
                        Debug.Log("Saving due to new record! (Due to seconds!)");
                    }
                    else
                    {
                        Debug.Log("No record. Not saving 2.");
                    }
                }
                else
                {
                    Debug.Log("No record. Not saving");
                }
            }
            else
            {
                //If the data is corrupted, we override the data and save our new PB.
                saveNewPB(filename, min, sec);
                Debug.Log("Saving due to corrupted data.");
            }

        }
        else
        {
            //If there is no file, then this will be the PB.
            saveNewPB(filename, min, sec);
            Debug.Log("Saving due to no existing file.");
        }
    }

    //For displaying the times on the main menu screen
    public int loadToDisplay(string filename)
    {
        //The path where the save file will be stored
        string path = Application.persistentDataPath + filename;

        //If the file exists
        if (File.Exists(path))
        {
            //Get the json from the text file
            string json = File.ReadAllText(path);

            //Convert the json into data
            saveDataTimeClass loadedData = JsonUtility.FromJson<saveDataTimeClass>(json);

            //If the data is not null, it means that there is data in the file.
            if (loadedData != null)
            {
                int totalTime = (loadedData.minutes * 60) + loadedData.seconds;
                Debug.Log("Loaded successfully: " + totalTime.ToString());
                return totalTime;
            }
            else
            {
                //If the data is corrupted, we save 99:99 as the pb (placeholder value)
                saveNewPB(filename, 99, 59);
                Debug.Log("Saving placeholder (99,59) due to corrupted data.");
            }
        }
        else
        {
            //If the file doesn't exist, save 99:99 as the pb. (placeholder value)
            saveNewPB(filename, 99, 59);
            Debug.Log("Saving placeholder (99,59) due to lack of data.");
        }

        return ((99 * 60) + 59);

    }


    public void saveNewPB(string filename, int min, int sec)
    {
        string path = Application.persistentDataPath + filename;
        saveDataTimeClass myDataToSave = new saveDataTimeClass(min, sec);

        string json = JsonUtility.ToJson(myDataToSave);
        File.WriteAllText(path, json);

        Debug.Log("Saved: " + min + " " + sec + " to: " + filename + "   " +path);
    }
}
