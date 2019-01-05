using System;
using System.Collections.Generic;
using UnityEngine;

public class FindResource : MonoBehaviour {

    public int resourceCount = 0;
    private int assetDecreaser = 10;
    public bool foundResource = false;
    List<GameObject> gameObjects =  new List<GameObject>();

    float period = 0;
    // Update is called once per frame
    void Update() {
        if (foundResource) {
            
            if (period > 0.5f)
            {
                if (gameObjects[resourceCount-1] != null)
                {
                    gameObjects[resourceCount-1].SendMessage("decreaseResourceAssets", assetDecreaser);
                    FindObjectOfType<PlayerData>().addResources(assetDecreaser);
                }
               else resourceLost(gameObjects[resourceCount-1]);
                
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;  
        }
    }
    
        private void OnTriggerEnter(Collider collInfo)
    {
        
        if (collInfo.name == "Tree")
        {
            
            Debug.Log("Human Found a Resource:" + collInfo.name);
            Debug.Log("Resource:" + collInfo.gameObject.name);
            MeshRenderer meshRend = GetComponent<MeshRenderer>();
            meshRend.material.color = Color.blue;
            resourceCount++;
            foundResource = true;
            gameObjects.Add(collInfo.gameObject);
             
        }
    }

    private void OnTriggerExit(Collider collInfo)
    {

        // Revert the cube color to white.
  
        if (collInfo.name == "Tree")
        {
            Debug.Log("Human Lost track of a Resource: " + collInfo.name);
            resourceLost(collInfo.gameObject);
        }
    }

    private void resourceLost(GameObject gameObject) {
        Debug.Log("Resource Lost ");
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
