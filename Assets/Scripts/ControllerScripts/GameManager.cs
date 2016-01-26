using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    public GameObject level;
    public static bool isUpPressed = false;
    public static bool isDownPressed = false;
    public static bool isLaunchPressed = false;

    public Canvas GameOverCanvas;
    public UnityEngine.UI.Button btnUp;
    public UnityEngine.UI.Button btnDown;
    public UnityEngine.UI.Button btnLaunch;


    void Start ()
    {
        GameOverCanvas = GameOverCanvas.GetComponent<Canvas>();
        GameOverCanvas.enabled = false;
        btnUp = btnUp.GetComponent<UnityEngine.UI.Button>();
        btnDown = btnDown.GetComponent<UnityEngine.UI.Button>();
        btnLaunch = btnLaunch.GetComponent<UnityEngine.UI.Button>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	    if (level.transform.childCount == 0 || Input.GetButtonDown("Test"))
        {
            GameOverSenario();
        }
	}

    private void GameOverSenario()
    {
        Destroy(GameObject.FindGameObjectWithTag("PlayerOne"));
        Destroy(GameObject.FindGameObjectWithTag("PlayerTwo"));
        Destroy(GameObject.FindGameObjectWithTag("BallPlayerOne"));
        Destroy(GameObject.FindGameObjectWithTag("BallPlayerTwo"));
        btnUp.enabled = false;
        btnLaunch.enabled = false;
        btnDown.enabled = false;

        GameOverCanvas.enabled = true;
    }
    public void BackToMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void OnUpPressed()
    {
        isUpPressed = true;
    }
    public void OnUpReleased()
    {
        isUpPressed = false;
    }
    public void OnDownPressed()
    {
        isDownPressed = true;
    }
    public void OnDownReleased()
    {
        isDownPressed = false;
    }
    public void OnLaunchPressed()
    {
        isLaunchPressed = true;
    }
    public void OnLaunchReleased()
    {
        isLaunchPressed = false;
    }
}
