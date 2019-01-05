using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        FindObjectOfType<AudioManager>().Stop();
        switch (SceneManager.GetActiveScene().buildIndex) {
            case 0: {
                    FindObjectOfType<AudioManager>().Play("MainSoundtrack1");
                    break;
                }

            case 1: {
                    FindObjectOfType<AudioManager>().Play("MainSoundtrack2");
                    break;
                }
            default: break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
