using UnityEngine;

public class DebugConsole : MonoBehaviour {

    public static bool isConsoleOpen = false;
    public GameObject debugConsoleUi;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.BackQuote))
            if (isConsoleOpen)
            {
                consoleClose();
            }
            else consoleOpen();
    }

    public void consoleOpen() {
        debugConsoleUi.SetActive(true);
        isConsoleOpen = true;
    }

    public void consoleClose()
    {
        debugConsoleUi.SetActive(false);
        isConsoleOpen = false ;
    }

}
