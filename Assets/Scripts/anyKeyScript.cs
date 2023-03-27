using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class anyKeyScript : MonoBehaviour
{

    int changingValue = 1;
    double newAlpha = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(newAlpha >= 1)
        {
            changingValue = -1;
        }
        else if (newAlpha <= 0)
        {
            changingValue = 1;
        }
        newAlpha = this.gameObject.GetComponent<TextMeshProUGUI>().color.a + (0.01 * changingValue);
        float floatingAlpha = (float)newAlpha;
        this.gameObject.GetComponent<TextMeshProUGUI>().color = new Color(this.gameObject.GetComponent<TextMeshProUGUI>().color.r, this.gameObject.GetComponent<TextMeshProUGUI>().color.g, this.gameObject.GetComponent<TextMeshProUGUI>().color.b,
            floatingAlpha);
    }
}
