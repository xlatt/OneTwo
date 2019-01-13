using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointChanger : MonoBehaviour {

    GameObject actualBarracks;

    [HideInInspector]
    GameObject generatedUnit;

    [HideInInspector]
    private Quaternion unitQuaternion = new Quaternion();

    [SerializeField]
    private GameObject unit;

    private bool spawnPointSet;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void barracksChanger() {
        if (spawnPointSet)
            spawnUnit();
    }

    public void spawnUnit()
    {

        generatedUnit = GameObject.Instantiate(unit, actualBarracks.GetComponent<BuildingController>().initSpawnPosition(), unitQuaternion);

        generatedUnit.GetComponent<MovementController>().setEndPosition(actualBarracks.GetComponent<BuildingController>().getSpawnPoint());
        generatedUnit.GetComponent<MovementController>().setMoving();
    }

    public void setSpawnPoint(GameObject gameObject ){
        actualBarracks = gameObject;
        spawnPointSet = true;
    }
    
}
