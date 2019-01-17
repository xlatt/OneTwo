using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointChanger : MonoBehaviour {

    [SerializeField]
    SendLog sendLog;

    [SerializeField]
    private GameObject unitFactory;

    [HideInInspector]
    GameObject actualBarracks;

    [HideInInspector]
    private bool spawnPointSet;

    public void spawnKnightWoodcutter() {
        spawnOnClick("KnightWoodcutter");
    }

    public void spawnKnightWarrior()
    {
        spawnOnClick("KnightWarrior");
    }

    private void spawnOnClick(string unitName) {
        if (spawnPointSet) {
            sendLog.msgCasual("[ENTER] spawnOnClick - requesting: " + unitName);
            unitFactory.GetComponent<UnitFactory>().spawnUnit(unitName, actualBarracks);
        }        
    }

    public void setSpawnPoint(GameObject gameObject ){
        actualBarracks = gameObject;
        spawnPointSet = true;
    }
    
}
