using UnityEngine;
using UnityEngine.UI;

public class PaddleController : MonoBehaviour {

    public float paddleSpeed = 0.1f;
    public GameObject prefab;
    public Button launchButton;
    public Text playerScoreText;

    private bool isBallAlive = true;

    private int score;
    private Vector3 playerPosition;

	void Start()
    {
        playerPosition = gameObject.tag.Equals("PaddlePlayerOne") ? new Vector3(-6.75f, 0, 0) : new Vector3(6.75f, 0, 0);
        score = 0;
        switch (PlayerPrefs.GetInt("Difficulty")) { 
            case 0: transform.localScale = new Vector3(0.25f, 4.0f, 0.5f); paddleSpeed = 0.1f; break;
            case 1: transform.localScale = new Vector3(0.25f, 2.5f, 0.5f); paddleSpeed = 0.12f; break;
            case 2: transform.localScale = new Vector3(0.25f, 1.5f, 0.5f); paddleSpeed = 0.14f; break;
            default: transform.localScale = new Vector3(0.25f, 4.0f, 0.5f); paddleSpeed = 0.1f; break;
        }
        prefab.GetComponent<BallController>().owner = this.gameObject;
    }

    void Update()
    {
        if (!isBallAlive)
        {
            prefab.transform.localPosition = new Vector3(prefab.transform.localPosition.x, transform.localPosition.y, prefab.transform.localPosition.z);
            Instantiate(prefab);
            isBallAlive = true;
            if (GetComponent<PaddleAIController>() != null)
            {
                var script = GetComponent<PaddleAIController>();
                script.puckOne = GameObject.FindGameObjectWithTag("BallPlayerOne");
                script.puckTwo = GameObject.FindGameObjectWithTag("BallPlayerTwo");
            }
        }
    }

    void FixedUpdate()
    {
        if (gameObject.tag.Equals("PaddlePlayerOne")) {
            int direction = 0;
            if (GameManager.isUpPressed) direction = 1;
            if (GameManager.isDownPressed) direction = -1;
            float posY = transform.position.y + (/*Input.GetAxis("Vertical")*/ direction * paddleSpeed);
            playerPosition = new Vector3(playerPosition.x, Mathf.Clamp(posY, -5 + (transform.localScale.y / 2), 5f - (transform.localScale.y / 2)), playerPosition.z);
            transform.position = playerPosition;
        } 
        else {
            float posY = transform.position.y + (Input.GetAxis("VerticalTwo") * paddleSpeed);
            playerPosition = new Vector3(playerPosition.x, Mathf.Clamp(posY, -5 + (transform.localScale.y / 2), 5f - (transform.localScale.y / 2)), playerPosition.z);
            transform.position = playerPosition;
        }
    }

    public void UpdateScore(int totalScore)
    {
        this.score = totalScore;
        UpdateText();
    }

    public void IncreaseScore(int number)
    {
        this.score += number;
        UpdateText();
    }

    public void DecreaseScore(int number)
    {
        this.score -= number;
        UpdateText();
    }
    public void UpdateText()
    {
        this.playerScoreText.text = this.score.ToString();
    }
    public void setIsBallAlive(bool b)
    {
        this.isBallAlive = b;
    }
    public bool getIsBallAlive()
    {
        return this.isBallAlive;
    }
}
