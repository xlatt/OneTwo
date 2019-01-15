using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitFactory : MonoBehaviour {

    [SerializeField]
    private List<GameObject> unitList = new List<GameObject>();

    [SerializeField]
    private List<string> factionList = new List<string>();

    [HideInInspector]
    private Quaternion unitQuaternion = new Quaternion();

    [SerializeField]
    private SendLog sendLog;


    // Use this for initialization
    void Start () {

        //for future use
        factionList.Add("Viking");
        factionList.Add("Knight");
        factionList.Add("Samurai");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void SpawnUnit(string unitName, GameObject activeSpawn) {
        sendLog.msgCasual("[ENTER] SpawnUnit - Searching for unit: " + unitName);
        GameObject desiredUnit = unitList.Where(obj => obj.name == unitName).SingleOrDefault();

        if (!desiredUnit.Equals(null))
        {
            sendLog.msgCasual("Unit " + unitName + " found and being generated.");
            GameObject generatedUnit = GameObject.Instantiate(desiredUnit, activeSpawn.GetComponent<BuildingController>().initSpawnPosition(), unitQuaternion);

            generatedUnit.GetComponent<MovementController>().setEndPosition(activeSpawn.GetComponent<BuildingController>().getSpawnPoint());
            generatedUnit.GetComponent<MovementController>().setMoving();
        }
        else {
            sendLog.msgCasual("Unit " + unitName + " NOT found!.");
        }
    }

    
}
