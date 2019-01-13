using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {


    [SerializeField]
    private PanelController panelController;
    
    [SerializeField]
    private Material isNotClicked;

    [SerializeField]
    private bool isStructure;

    [SerializeField]
    private Material isClicked;

    [SerializeField]
    private SendLog sendLog;

    [HideInInspector]
    public bool currentlySelected = false;

    private MeshRenderer myRenderer;

    
    // Use this for initialization
    void Awake () {
       // currentlySelected = false;
        myRenderer = GetComponent<MeshRenderer>();
        Camera.main.gameObject.GetComponent<ObjectClicker>().selectableObjects.Add(this.gameObject);

    }

    public bool getIsStructure() {
        return isStructure;
    }

    public void setIsStructure(bool newIsStructure)
    {
        isStructure = newIsStructure;
    }

    public void clickMe() {
        if (currentlySelected.Equals(true))
        {
            panelController.showPanel("LAction");
           
                myRenderer.material = isClicked;
                sendLog.msgCasual("Object Highlight ON.");
        }
        else {
            myRenderer.material = isNotClicked;
            sendLog.msgCasual("Object Highlight OFF.");
        }
    }

    public bool getcurrentlySelected() {
        return currentlySelected;
    }


}
