using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {

    [SerializeField]
    private Material isNotClicked;

    [SerializeField]
    private Material isClicked;

    [HideInInspector]
    public bool currentlySelected = false;

    private MeshRenderer myRenderer;

    
    // Use this for initialization
    void Start () {
        myRenderer = GetComponent<MeshRenderer>();
	}

    public void clickMe() {
        if (currentlySelected.Equals(false)) {
            myRenderer.material = isClicked;
            currentlySelected = true;
        }
    }

    public void unclickMe() {
        currentlySelected = false;
        myRenderer.material = isNotClicked;
    }

}
