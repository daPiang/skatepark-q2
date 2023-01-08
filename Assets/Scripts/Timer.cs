using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    private bool TimerOn;
    public Text TimerText;
    public GameObject GameOver;
    public GameObject player;
    public Text ObjectiveText;
    public string SetObjective;
    public LevelManager levelmgr;
    public GameObject door;

    private void Start()
    {
        TimerOn = true;
        ObjectiveText.text = SetObjective;
        // GameOver.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(TimeLeft > 0) {
            TimeLeft -= Time.deltaTime;
            updateTimer(TimeLeft);
        }

        if(TimeLeft <= 0) {
            TimerOn = false;
            GameOver.SetActive(true);
            // player.SetActive(false);
            player.SendMessage("GameOver");
            levelmgr.SendMessage("nSolved");
            door.SetActive(false);
        }
    }

    private void updateTimer(float currentTime) {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = seconds.ToString();
    }

    public void retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
