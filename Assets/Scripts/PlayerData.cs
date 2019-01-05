using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerData : MonoBehaviour {

    public int playerResources;
    public static PlayerData instance;

    public TextMeshProUGUI playerResourcesText = null;
    // Use this for initialization
    void Start () {
        playerResources = 0;
        playerResourcesText.text = playerResources.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void addResources(int addResources) {

        playerResources += addResources;
        playerResourcesText.text = playerResources.ToString();
    }

    public void decreaseResources(int subResources)
    {
        playerResources -= subResources;
        playerResourcesText.text = playerResources.ToString();
    }
}
