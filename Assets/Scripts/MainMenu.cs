using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string level;
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void startGame() {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void exitGame() {
        Application.Quit(0);
    }

    
}
