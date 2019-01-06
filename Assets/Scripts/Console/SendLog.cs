using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendLog : MonoBehaviour {

    [SerializeField]
    public InputField inputField;

    [SerializeField]
    private Color myColor;

    [SerializeField]
    private TextLogControl logControl;



    public void LogText(){
        if (inputField.text != "")
        {
            logControl.logText(inputField.text, myColor);
            inputField.text = "";
        }

    }


    public void msgError(string messageText)
    {
        logControl.logText("[ERROR] " + messageText, Color.red);

    }
    public void msgWarning(string messageText) {
        logControl.logText("[WARN] " + messageText, Color.yellow);

    }
    public void msgCasual(string messageText)
    {
        Debug.Log(messageText);
        logControl.logText("[INFO] " + messageText, Color.white);

    }
    

}