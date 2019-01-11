using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused)
            {
                resumeGame();
            }
            else pauseGame();
        }
    }

    public void resumeGame(){
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void pauseGame(){
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void loadMenu() {
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("Going to Menu");
        SceneManager.LoadScene(0);
    }

    public void exitGame() {
        Debug.Log("Exiting Game!");
        Application.Quit();
    }
}
