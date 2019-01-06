using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour {

    [SerializeField]
    public SendLog sendLog;

    private int resourceAssets;
    
	// Use this for initialization
	void Start () {
        resourceAssets = 100;
    }
	
	// Update is called once per frame
	void Update () {
        if (resourceAssets == 0) {

            Destroy(gameObject);
        }
	}

    public int getResourceAssets() {

        return resourceAssets;
    }

    public void setResourceAssets(int newResourceAssets)
    {

        resourceAssets = newResourceAssets;
    }

    public void decreaseResourceAssets(int subResourceAssets)
    {
      if(subResourceAssets >= resourceAssets) {
            resourceAssets = 0;
        }
      else
            resourceAssets -= subResourceAssets;

        sendLog.msgCasual("resourceAssets of " + gameObject.name + " decreased by " + subResourceAssets + "! Actual value is : " + resourceAssets);
    }
}
