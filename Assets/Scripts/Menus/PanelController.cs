using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {


    [SerializeField]
    private GameObject barracksPanel;

    [SerializeField]
    private GameObject leftActionPanel;

    [HideInInspector]
    private List<GameObject> panelList = new List<GameObject>();
    void Start()
    {
        panelList.Add(barracksPanel);
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
    public void hidePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    private GameObject selectPanel(string panelName) {
        GameObject panel = null;

        switch (panelName) {
            case "Barracks Panel": {
                    panel = barracksPanel;
                    break;
                }
            case "LAction Panel":
                {
                    panel = leftActionPanel;
                    break;
                }
            default: break;


        }

        return panel;
    }

}
