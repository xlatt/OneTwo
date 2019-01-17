using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitList : MonoBehaviour {

    [SerializeField]
    private SendLog sendLog;

    [SerializeField]
    private List<GameObject> unitList = new List<GameObject>();

    public GameObject getUnit(string unitName) {
        sendLog.msgCasual("[ENTER] getUnit - Searching for unit: " + unitName);
        GameObject desiredUnit = unitList.Where(obj => obj.name == unitName).SingleOrDefault();

        if (desiredUnit.Equals(null)) {
            sendLog.msgCasual("[EXIT] getUnit - Unit Not found in this list!");
            return null;
        }
        else {
            sendLog.msgCasual("[EXIT] getUnit - Unit " + unitName +" found in this list!");
            return desiredUnit;
        }
    }
}
