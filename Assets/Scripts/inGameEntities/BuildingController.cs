using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {
    
    [SerializeField]
    private PanelController panelController;

    [HideInInspector]
    private Vector3 buildingPosition;

    [HideInInspector]
    private Vector3 spawnPointPosition;

    [HideInInspector]
    private Quaternion unitQuaternion = new Quaternion();

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject unit;

    [HideInInspector]
    private float period = 0;

    [HideInInspector]
    GameObject generatedUnit;

    [HideInInspector]
    string structureName = "Barracks";


    // Use this for initialization
    void Start() {
        spawnPointPosition.Set(0, 0, 0);
        spawnPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (spawnPoint.activeSelf) {
            if (period > 2f)
            {
                hideSpawnPoint();
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;
        }

        if (gameObject.GetComponent<ClickableObject>().getcurrentlySelected())
        {
            panelController.showPanel(structureName);

        }

    }
    //[Begin]----------------BuildingDefinition---------------------------\\
    public void setStructureName(string structure) {
            structureName = structure;
        }
        public string getStructureName(){
                return structureName;  
        }

    //[End]----------------BuildingDefinition---------------------------\\

    //[Begin]----------------SpawnPointMethods------------------------\\
    public void setSpawnPoint(Vector3 newSpawnPointPosition) {
        spawnPointPosition = newSpawnPointPosition;
        spawnPoint.transform.position = spawnPointPosition;
        spawnPoint.SetActive(true);
    }

    public void resetSpawnPoint()
    {
        spawnPointPosition.Set(0, 0, 0);
        spawnPoint.transform.position = spawnPointPosition;
        spawnPoint.SetActive(false);
    }

    public Vector3 getSpawnPoint()
    {
        return spawnPointPosition;
    }

    private void hideSpawnPoint() {
        spawnPoint.SetActive(false);
    }
    //[End]----------------SpawnPointMethods------------------------\\
    //[Begin]----------------UnitSpawner---------------------------\\
    public void spawnUnit() {
        generatedUnit = GameObject.Instantiate(unit, initSpawnPosition(), unitQuaternion);

        generatedUnit.GetComponent<MovementController>().setEndPosition(getSpawnPoint());
        generatedUnit.GetComponent<MovementController>().setMoving();
    }
    //[End]----------------UnitSpawner---------------------------\\
    private void initbuildingPosition() {
        buildingPosition = gameObject.transform.position;
        

    }

    private Vector3 initSpawnPosition() {
        initbuildingPosition();
        Vector3 position = buildingPosition;
        position.x += 4;
        position.z += 4;
        return position;
    }
}

