using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {

    [SerializeField]
    private Material isNotClicked;

    [SerializeField]
    private Material isClicked;

    [SerializeField]
    private SendLog sendLog;

    [HideInInspector]
    public bool currentlySelected = false;

    private MeshRenderer myRenderer;

    
    // Use this for initialization
    void Start () {
        myRenderer = GetComponent<MeshRenderer>();
        Camera.main.gameObject.GetComponent<ObjectClicker>().selectableObjects.Add(this.gameObject);

    }

    public void clickMe() {
        if (currentlySelected.Equals(true))
        {
            myRenderer.material = isClicked;
            
            sendLog.msgCasual("Object Highlight ON.");
        }
        else {
            myRenderer.material = isNotClicked;
            sendLog.msgCasual("Object Highlight OFF.");
        }
    }


}
