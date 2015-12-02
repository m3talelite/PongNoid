using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas QuitCanvas;
    public Button EasyButton;
    public Button MediumButton;
    public Button HardButton;
    public Button ExitButton;

    // Use this for initialization
    void Start () {
        QuitCanvas = QuitCanvas.GetComponent<Canvas>();
        QuitCanvas.enabled = false;

        EasyButton = EasyButton.GetComponent<Button>();
        MediumButton = MediumButton.GetComponent<Button>();
        HardButton = HardButton.GetComponent<Button>();
        ExitButton = ExitButton.GetComponent<Button>();
    }

    public void ExitButtonPressed()
    {
        QuitCanvas.enabled = true;
        EasyButton.enabled = false;
        MediumButton.enabled = false;
        HardButton.enabled = false;
        ExitButton.enabled = false;
    }

    public void ExitMenuYes()
    {
        Application.Quit();
    }

    public void ExitMenuNo()
    {
        QuitCanvas.enabled = false;
        EasyButton.enabled = true;
        MediumButton.enabled = true;
        HardButton.enabled = true;
        ExitButton.enabled = true;
    }
    public void PlayLevelEasy()
    {
        //TODO add difficulty switch
        Application.LoadLevel(1);
    }
    public void PlayLevelMedium()
    {
        //TODO add difficulty switch
        Application.LoadLevel("PongNoidLevel");
    }
    public void PlayLevelHard()
    {
        //TODO add difficulty switch
        Application.LoadLevel("PongNoidLevel");
    }
}
