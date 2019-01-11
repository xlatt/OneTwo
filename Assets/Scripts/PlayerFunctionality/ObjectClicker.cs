using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour {

    [SerializeField]
    public SendLog sendLog;


    [HideInInspector]
    public List<GameObject> selectableObjects;
    public List<GameObject> selectedObjects;

    [HideInInspector]
    public LayerMask clickMask;

   

    private Vector3 mPos1;
    private Vector3 mPos2;
    
    private Vector3 clickPosition;
    MovementController MovementController;
    // Use this for initialization
    void Awake() {
        selectedObjects = new List<GameObject>();
        selectableObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            mPos1 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    GameObject foundGameObject = hit.collider.gameObject;
                    ClickableObject clickableObjectScript = foundGameObject.GetComponent<ClickableObject>();
                    
                    if (Input.GetKey(KeyCode.LeftControl) && foundGameObject.tag.Equals("Controllable"))
                    {
                        if (clickableObjectScript.currentlySelected == false)
                        {
                            ;

                            if (foundStructureInSelected(selectedObjects).Equals(true))
                                clearSelection();
                            if (!foundGameObject.GetComponent<ClickableObject>().getIsStructure())
                            {
                                selectedObjects.Add(foundGameObject);
                                clickableObjectScript.currentlySelected = true;
                                clickableObjectScript.clickMe();
                            }
                        }
                        else
                        {
                            selectedObjects.Remove(foundGameObject);
                            clickableObjectScript.currentlySelected = false;
                            clickableObjectScript.clickMe();
                        }
                    }
                    else
                    {
                        clearSelection();
                        sendLog.msgCasual("Found game object: " + foundGameObject.name);
                        if (foundGameObject.tag.Equals("Controllable"))
                        {
                            selectedObjects.Add(foundGameObject);
                            clickableObjectScript.currentlySelected = true;
                            clickableObjectScript.clickMe();
                        }
                    }
                    clickPosition = hit.point;
                    sendLog.msgCasual("mouse clickPosition: " + clickPosition);
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            mPos2 = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (mPos1 != mPos2) {
                selectObjects();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (selectedObjects.Count.Equals(1) && selectedObjects[0].GetComponent<ClickableObject>().getIsStructure())
            {
                Vector3 position = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f, clickMask))
                {
                    setSpawnpoint(selectedObjects[0], hit);
                }
            }
            else if (selectedObjects.Count > 0)
            {
                Vector3 position = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f, clickMask))
                {
                   moveObjects(hit);
                }
            }
        }
    }

    private void setSpawnpoint(GameObject gameObject, RaycastHit hit) {
        if (gameObject.GetComponent<ClickableObject>().getIsStructure()) {
            BuildingController buildingController = gameObject.GetComponent<BuildingController>();

            clickPosition = hit.point;
            buildingController.setSpawnPoint(clickPosition);
         }
    }

    private void moveObjects(RaycastHit endPosition)
    {
        if (endPosition.transform != null)
        {
            clickPosition = endPosition.point;
            // sendLog.msgCasual("EndClick position: " + clickPosition);
            int selectedUnits = selectedObjects.Count;
            int i = 0;
            int maxRow = 4;

            float unitOffsetConstX = 3f;
            float unitOffsetConstZ = 2.5f;
            float unitOffsetX = 0f;
            float unitOffsetZ = 0f;

            float centerMouseClickX;

            if (selectedUnits < maxRow)
                centerMouseClickX = (unitOffsetConstX * (selectedUnits - 1)) / 2;
            else
                centerMouseClickX = (unitOffsetConstX * (maxRow - 1)) / 2;
            
              sendLog.msgCasual(selectedUnits + "  units currently moving!");
            foreach (GameObject obj in selectedObjects)
            {
                Vector3 newUnitPosition = clickPosition;
                newUnitPosition.x -= centerMouseClickX;
                MovementController movementController = obj.GetComponent<MovementController>();
                if (i < maxRow)
                {
                    newUnitPosition.x += unitOffsetX;
                    newUnitPosition.z += unitOffsetZ;

                    sendLog.msgCasual("startPosition of obj: " + obj.transform.position);
                    movementController.setEndPosition(newUnitPosition);
                    movementController.setMoving();
                    sendLog.msgCasual(" i=" + i + " unit position: " + newUnitPosition);

                    unitOffsetX += unitOffsetConstX;
                    i++;
                }
                else
                {
                    i = 0;
                    unitOffsetX = 0;
                    unitOffsetZ += unitOffsetConstZ;
                    
                    newUnitPosition.x += unitOffsetX;
                    newUnitPosition.z += unitOffsetZ;

                    sendLog.msgCasual("startPosition of obj: " + obj.transform.position);
                    movementController.setEndPosition(newUnitPosition);
                    movementController.setMoving();
                    sendLog.msgCasual(" i=" + i + " unit position starting new row: " + newUnitPosition);

                    unitOffsetX += unitOffsetConstX;
                    i++;
                }
            }
        }
    }
    
    private void clearSelection() {
        if (selectedObjects.Count > 0)
        {
            foreach (GameObject obj in selectedObjects)
            {
                obj.GetComponent<ClickableObject>().currentlySelected = false;
                obj.GetComponent<ClickableObject>().clickMe();
            }
            selectedObjects.Clear();
        }
    }

    private bool foundStructureInSelected(List<GameObject> selectedObjects) {
        bool match = false;
        foreach (GameObject obj in selectedObjects)
        {
            if (obj.GetComponent<ClickableObject>().getIsStructure())
                match = true;
        }
        return match;
    }

    private void selectObjects()
    {
        List<GameObject> removeObjects = new List<GameObject>();

        if (Input.GetKey(KeyCode.LeftControl) == false)
        {
            clearSelection();
        }
        Rect selectRect = new Rect(mPos1.x, mPos1.y, mPos2.x - mPos1.x, mPos2.y - mPos1.y);
        
        foreach (GameObject obj in selectableObjects)
        {
            if (obj != null)
            {

                if (selectRect.Contains(Camera.main.WorldToViewportPoint(obj.transform.position), true))
                {
                    if (!obj.GetComponent<ClickableObject>().getIsStructure())
                    {
                        selectedObjects.Add(obj);
                        obj.GetComponent<ClickableObject>().currentlySelected = true;
                        obj.GetComponent<ClickableObject>().clickMe();
                    }
                }
            }
            else
            {
                removeObjects.Add(obj);
            }
        }
        if (removeObjects.Count > 0) {
            foreach (GameObject obj in removeObjects) {
                selectableObjects.Remove(obj);
            }
            removeObjects.Clear();
        }
    }


}
