using UnityEngine;

public class DebugConsole : MonoBehaviour {

    public static bool isConsoleOpen = false;
    //public GameObject debugConsoleUi;
    public Animator animator;
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
            else
            {
                consoleOpen();
            }
    }

    public void consoleOpen() {
        animator.SetBool("InitDown", true);
        animator.SetBool("Up", false);
        //debugConsoleUi.SetActive(true);
        isConsoleOpen = true;
    }

    public void consoleClose()
    {
        animator.SetBool("Up", true);
        //debugConsoleUi.SetActive(false);
        isConsoleOpen = false ;
    }

}
