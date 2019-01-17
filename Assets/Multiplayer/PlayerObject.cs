using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        // is this my own local player object?
        if (!isLocalPlayer) {
            // nope, someone else
            return;
        }

        // I am invisible so spawn something physical
        Instantiate(PlayerUnitPrefab);

        Debug.Log("PlayerObject::Start - Spawned ");
	}

    public GameObject PlayerUnitPrefab;
	// Update is called once per frame
	void Update () {
		// This runs on everyone's computer weather or not they own this object
	}

    ///////////// COMMANDS
    /// Commands are executed only on server
    [Command]
    void CmdSpawnMyUnit() {
        Debug.Log("SRV CMD - Spawning player");
        GameObject go = Instantiate(PlayerUnitPrefab);
        // Object exists on server, propagate to clients
        NetworkServer.Spawn(go);
        Debug.Log("SRV CMD - Player spawned");
    }
}
