using UnityEngine;
using UnityEngine.UI;

public class TextLogItem : MonoBehaviour {

    public void setText(string myText, Color myColor) {
        GetComponent<Text>().text = myText;
        GetComponent<Text>().color = myColor;
    }
}
