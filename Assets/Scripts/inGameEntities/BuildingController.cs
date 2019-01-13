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
    
    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject unit;

    [HideInInspector]
    private float period = 0;


    [HideInInspector]
    string structureName = "Barracks";
    
    void Start() {
        initbuildingPosition();
        setSpawnPoint(initSpawnPosition());
        spawnPoint.SetActive(false);
    }
    
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
    
    private void initbuildingPosition() {
        buildingPosition = gameObject.transform.position;
        

    }

    public Vector3 initSpawnPosition() {
        initbuildingPosition();
        Vector3 position = buildingPosition;
        position.x += 4;
        position.z += 4;
        return position;
    }
}