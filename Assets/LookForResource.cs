using System;
using System.Collections.Generic;
using UnityEngine;

public class LookForResource : MonoBehaviour {

    public int resourceCount;
    public bool foundResource = false;
    List<GameObject> gameObjects = new List<GameObject>();

    [SerializeField]
    public SendLog sendLog;

    [SerializeField]
    private GameObject parentUnit;

    private bool move;
    
    [HideInInspector]
    private float period = 0;

    private void Start()
    {
        move = false;
        resourceCount = 0;
    }
    // Update is called once per frame
    void Update()
    {
        

            if (foundResource) {
            if (gameObjects[resourceCount - 1].Equals(null))
            {
                resourceLost(gameObjects[resourceCount - 1]);
                move = false;
            }

            if ((move ) && (gameObjects.Count > 0))
            {
                
                parentUnit.GetComponent<MovementController>().setEndPosition(gameObjects[resourceCount - 1].transform.position);
                parentUnit.GetComponent<MovementController>().setMoving();
                move = false;
            }
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

    private void resourceLost(GameObject gameObject)
    {
        sendLog.msgCasual("Resource Lost ");
        MeshRenderer meshRend = GetComponent<MeshRenderer>(); ;

        gameObjects.RemoveAt(resourceCount - 1);
        resourceCount--;
        if (resourceCount == 0)
        {
            meshRend.material.color = Color.green;
            foundResource = false;
        }
    }

    public void setMove(bool set) {
        move = set;
    }

}
