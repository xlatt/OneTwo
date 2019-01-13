using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RActionPanelController : MonoBehaviour {

    [SerializeField]
    private PanelController panelController;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buildingPanelControl() {
        if (panelController.isActivaPanel("Building")) {
            panelController.hidePanel("Building");
        }else
            panelController.showPanel("Building");
        
    }

}
