using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour {
    
    [HideInInspector]
    private Quaternion unitQuaternion = new Quaternion();

    [SerializeField]
    private SendLog sendLog;

    [SerializeField]
    private GameObject unitList;
    
    // Use this for initialization
    
    public void spawnUnit(string unitName, GameObject activeSpawn) {

        GameObject desiredUnit = unitList.GetComponent<UnitList>().getUnit(unitName);
        if (!desiredUnit.Equals(null))
        {
            sendLog.msgCasual("[ENTER] spawnUnit - Unit " + unitName + " being generated.");
            GameObject generatedUnit = GameObject.Instantiate(desiredUnit, activeSpawn.GetComponent<BuildingController>().initSpawnPosition(), unitQuaternion);

            generatedUnit.GetComponent<MovementController>().setEndPosition(activeSpawn.GetComponent<BuildingController>().getSpawnPoint());
            generatedUnit.GetComponent<MovementController>().setMoving();
        }
        else {
            sendLog.msgCasual("Unit " + unitName + " NOT Generated properly!.");
        }
    } 
}
