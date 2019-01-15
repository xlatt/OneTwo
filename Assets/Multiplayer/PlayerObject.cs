using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Instantiate(playerUnitPrefab);
	}

    public GameObject playerUnitPrefab;
	// Update is called once per frame
	void Update () {
		
	}
}
