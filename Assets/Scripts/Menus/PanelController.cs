using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {


    [SerializeField]
    private GameObject barracksPanel;

    [SerializeField]
    private GameObject buildingPanel;

    [SerializeField]
    private GameObject leftActionPanel;

    [HideInInspector]
    private List<GameObject> panelList = new List<GameObject>();
    void Start()
    {
        panelList.Add(barracksPanel);
        panelList.Add(buildingPanel);
        panelList.Add(leftActionPanel);
    }

    public void showPanel(string panelName)
    {
        GameObject panel = selectPanel(panelName);
        if (panel != null)
        {
            foreach (GameObject obj in panelList) {
                if (!obj.Equals(panel) && obj.activeSelf) {
                    obj.SetActive(false);
                }
            }
            panel.SetActive(true);
        }
    }
    public void hidePanel(string panelName)
    {
        selectPanel(panelName).SetActive(false);
    }

    public bool isActivaPanel(string panelName)
    {
        return selectPanel(panelName).activeSelf;
    }

    private GameObject selectPanel(string panelName) {
        GameObject panel = null;

        switch (panelName) {
            case "Barracks": {
                    panel = barracksPanel;
                    break;
                }
            case "LAction":
                {
                    panel = leftActionPanel;
                    break;
                }
            case "Building":
                {
                    panel = buildingPanel;
                    break;
                }
            default: break;


        }

        return panel;
    }

}
