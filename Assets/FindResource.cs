using System;
using System.Collections.Generic;
using UnityEngine;

public class FindResource : MonoBehaviour {

    public int resourceCount;
    public bool foundResource;

    [SerializeField]
    List<GameObject> gameObjects = new List<GameObject>();

    [SerializeField]
    public SendLog sendLog;

    [SerializeField]
    private GameObject parentUnit;

    private bool move;


    private void Start() {
        move = false;
        foundResource = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if (foundResource) {
            int  nullResource = 0;
            bool removeResource = false;
            
            foreach (GameObject resource in gameObjects) {
                if (resource == null) {
                    removeResource = true;
                    break;
                }
                nullResource++;
            }
            if (removeResource) {
                resourceLostDeleted(nullResource);
            }

            if (move && (gameObjects.Count > 0)) {
                parentUnit.GetComponent<MovementController>().setEndPosition(gameObjects[gameObjects.Count - 1].transform.position);
                parentUnit.GetComponent<MovementController>().setMoving();
                move = false;
            }
         }
    }

    private void OnTriggerEnter(Collider collInfo) {

        if (collInfo.name == "Resource")
        {
            sendLog.msgCasual("Human Found a Resource:" + collInfo.name);
            sendLog.msgCasual("Resource:" + collInfo.gameObject.name);

            changeRadiusColor(Color.blue);
            resourceCount++;
            foundResource = true;
            gameObjects.Add(collInfo.gameObject);
        }
    }

    private void OnTriggerExit(Collider collInfo) {
        if (collInfo.name == "Resource")
        {
            sendLog.msgCasual("Human Lost track of a Resource: " + collInfo.name);
            resourceLostTriggered();
        }
        
    }

    private void resourceLostTriggered() {
        sendLog.msgCasual("Resource Lost");
        gameObjects.RemoveAt(gameObjects.Count - 1);

        if (resourceCount.Equals(0)) {
            changeRadiusColor(Color.green);
            foundResource = false;
        }
    }

    private void resourceLostDeleted(int nullIndexResource)
    {
        sendLog.msgCasual("Resource Lost");
        gameObjects.RemoveAt(nullIndexResource);

        if (gameObjects.Count.Equals(0))
        {
            changeRadiusColor(Color.green);
            foundResource = false;
        }
    }

    public void setMove(bool set) {
        move = set;
    }

    private void changeRadiusColor(Color color) {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
