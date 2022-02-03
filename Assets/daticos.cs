using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class daticos : MonoBehaviour
{
    [SerializeField]
    string text;
    [SerializeField]
    TMP_InputField inputf;
 

    // Update is called once per frame
    public void UpdateMSG()
    {
        inputf.text = text;
    }
    public void saveMSG()
    {
        text = inputf.text;
    }
}
