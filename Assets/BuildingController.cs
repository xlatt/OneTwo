using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    [HideInInspector]
    private Vector3 spawnPointPosition;

    [SerializeField]
    private GameObject spawnPoint;

    [HideInInspector]
    private float period = 0;

    // Use this for initialization
    void Start () {
        spawnPointPosition.Set(0, 0, 0);
        spawnPoint.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (spawnPoint.activeSelf) {
            if (period > 2f)
            {
                hideSpawnPoint();
                period = 0;
            }
            period += UnityEngine.Time.deltaTime;
        }
		
	}

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
}

