using System;
using System.Collections.Generic;
using UnityEngine;

public class FindResource : MonoBehaviour {

    public int resourceCount = 0;
    private int assetDecreaser = 10;
    public bool foundResource = false;
    List<GameObject> gameObjects =  new List<GameObject>();

    [SerializeField]
    private GameObject parentUnit;

    [SerializeField]
    private GameObject findRadius;

    [SerializeField]
    public SendLog sendLog;

    [HideInInspector]
    private float period = 0;

    void Update() {
        
        if (foundResource) {
            findRadius.GetComponent<LookForResource>().setMove(false);
            if (period > 1f)
            {
                if (gameObjects[resourceCount - 1] != null)
                {
                    gameObjects[resourceCount - 1].SendMessage("decreaseResourceAssets", assetDecreaser);
                }
                else
                {
                    resourceLost(gameObjects[resourceCount - 1]);
                }
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


            parentUnit.GetComponent<MovementController>().setEndPosition(parentUnit.transform.position);
            parentUnit.GetComponent<MovementController>().setMoving();
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
            findRadius.GetComponent<LookForResource>().setMove(true);
        }
    }

}
