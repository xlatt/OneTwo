using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureSpawner : MonoBehaviour {

    [SerializeField]
    private List<Button> unitButtons = new List<Button>();

    [HideInInspector]
    private bool isSelecting;

    [HideInInspector]
    private bool isPlacing;

    [HideInInspector]
    private string selectedBuilding;

    [HideInInspector]
    private BuildingPlacement buildingPlacement;

    [SerializeField]
    public SendLog sendlog;

    [SerializeField]
    public LayerMask clickMask;

    [SerializeField]
    private GameObject barracksObjectShadowTemplate;

    [SerializeField]
    private GameObject barracksObjectTemplate;

    [HideInInspector]
    private GameObject barracksObjectShadow;

    [HideInInspector]
    private Vector3 position;

    [HideInInspector]
    private Vector3 buildingPosition;

    // Use this for initialization
    void Start() {
        isSelecting = false;
        isPlacing = false;
        selectedBuilding = "none";
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedBuilding.Equals("Barracks") && isPlacing) {

            Vector3 mousePos = Input.mousePosition;
            mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.y);
            position = Camera.main.ScreenToWorldPoint(mousePos);

            if (isSelecting) {
                isSelecting = false;
                barracksObjectShadow = GameObject.Instantiate(barracksObjectShadowTemplate);
                buildingPlacement = barracksObjectShadow.GetComponent<BuildingPlacement>();
            }
            barracksObjectShadow.transform.position = new Vector3(position.x, 2, position.z);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (isLegalPosition())
                {
                    isSelecting = false;
                    GameObject barracksObject = GameObject.Instantiate(barracksObjectTemplate);
                    barracksObject.transform.position = new Vector3(position.x, 2, position.z);
                    barracksObject.GetComponent<BuildingController>().setSpawnPoint(barracksObject.transform.position);

                    foreach (Button unitButton in unitButtons) {
                        unitButton.GetComponent<SpawnPointChanger>().setSpawnPoint(barracksObject);
                    }
                    
                    Destroy(barracksObjectShadow);
                    selectedBuilding = "none";
                }
            }
        }
    }
    private bool isLegalPosition() {
        if (buildingPlacement.colliders.Count > 0)
            return false;
        else
            return true;
    }
        public void barracksBuilder() {

        sendlog.msgCasual("Building barracks");
            isSelecting = true;
            isPlacing = true;
            selectedBuilding = "Barracks";
        }
    }
