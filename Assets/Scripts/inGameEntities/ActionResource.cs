using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionResource : MonoBehaviour {

    public int resourceCount = 0;
    private int assetDecreaser = 10;
    public bool foundResource = false;
    List<GameObject> gameObjects =  new List<GameObject>();

    [SerializeField]
    private GameObject parentUnit;

    [SerializeField]
    private FindResource findRadius;

    [SerializeField]
    public SendLog sendLog;

    [HideInInspector]
    private float period = 0;

    void Update() {
        
        if (foundResource) {
            findRadius.GetComponent<FindResource>().setMove(false);
            if (period > 1f)
            {
                if (gameObjects[gameObjects.Count - 1] != null)
                {
                    gameObjects[gameObjects.Count - 1].SendMessage("decreaseResourceAssets", assetDecreaser);
                }
                else
                {
                    resourceLost(gameObjects[gameObjects.Count - 1]);
                }
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;  
        }
    }

    private void OnTriggerEnter(Collider collInfo) {
        
        if (collInfo.name == "Resource") {
            sendLog.msgCasual("Human Found a Resource:" + collInfo.name);
            sendLog.msgCasual("Resource:" + collInfo.gameObject.name);

            changeRadiusColor(Color.blue);
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
        gameObjects.RemoveAt(gameObjects.Count -1);

        if (gameObjects.Count.Equals(0)) {
            changeRadiusColor(Color.green);
            foundResource = false;
            findRadius.GetComponent<FindResource>().setMove(true);
        }
    }

    private void changeRadiusColor(Color color) {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

}
