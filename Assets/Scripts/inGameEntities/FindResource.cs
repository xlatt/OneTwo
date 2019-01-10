using System;
using System.Collections.Generic;
using UnityEngine;

public class FindResource : MonoBehaviour {

    public int resourceCount = 0;
    private int assetDecreaser = 10;
    public bool foundResource = false;
    List<GameObject> gameObjects =  new List<GameObject>();

    [SerializeField]
    public SendLog sendLog;

    float period = 0;
    // Update is called once per frame
    void Update() {
        if (foundResource) {
            
            if (period > 2f)
            {
                if (gameObjects[resourceCount-1] != null)
                {
                    gameObjects[resourceCount-1].SendMessage("decreaseResourceAssets", assetDecreaser);
                }
               else resourceLost(gameObjects[resourceCount-1]);
                
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;  
        }
    }
    
        private void OnTriggerEnter(Collider collInfo)
    {
        
        if (collInfo.name == "Resource")
        {
            sendLog.msgCasual("Human Found a Resource:" + collInfo.name);
            sendLog.msgCasual("Resource:" + collInfo.gameObject.name);

            MeshRenderer meshRend = GetComponent<MeshRenderer>();
            meshRend.material.color = Color.blue;
            resourceCount++;
            foundResource = true;
            gameObjects.Add(collInfo.gameObject);
             
        }
    }

    private void OnTriggerExit(Collider collInfo)
    {
        if (collInfo.name == "Resource")
        {
            sendLog.msgCasual("Human Lost track of a Resource: " + collInfo.name);
            resourceLost(collInfo.gameObject);
        }
    }

    private void resourceLost(GameObject gameObject) {
        sendLog.msgCasual("Resource Lost ");
        MeshRenderer meshRend = GetComponent<MeshRenderer>(); ;

        gameObjects.RemoveAt(resourceCount-1);
        resourceCount--;
        if (resourceCount == 0)
        {
            meshRend.material.color = Color.green;
            foundResource = false;
        }
    }

}
