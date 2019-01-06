using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour {

    [SerializeField]
    public SendLog sendLog;

    public LayerMask clickMask;
    private GameObject actualObject;
    private Vector3 clickPosition;
    ControlMovement controlMovement;
    // Use this for initialization
    void Start() {
        
}

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(position);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    clickPosition = hit.point;
                    setActualObject(hit.transform.gameObject);

                    sendLog.msgCasual("mouse clickPosition: " + clickPosition);

                }
            }
        }

        else if (Input.GetMouseButtonDown(1))
        {
            if (actualObject.name.Equals("human1")) {
                Vector3 position = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f, clickMask))
                {
                    if (hit.transform != null)
                    {
                        clickPosition = hit.point;
                        sendLog.msgCasual("startPosition: " + actualObject.transform.position);
                        sendLog.msgCasual("mouse clickPosition: " + clickPosition);
                        
                        actualObject.SendMessage("setEndPosition", clickPosition);
                        actualObject.SendMessage("setMoving", true);
                        
                    }
                }
                
               
                
            }
        }

      

    }
    private void setActualObject(GameObject go)
    {
        sendLog.msgCasual(go.name);
        actualObject = go;
    }
}
