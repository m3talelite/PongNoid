using UnityEngine;
using System.Collections;
using System;

public class PaddleAIController : MonoBehaviour {

    public float paddleSpeed = 0.1f;
    public GameObject puckOne;
    public GameObject puckTwo;

    private Vector3 playerPosition;

    // Use this for initialization
    void Start () {
        playerPosition = gameObject.tag.Equals("PaddlePlayerOne") ? new Vector3(-6.75f, 0, 0) : new Vector3(6.75f, 0, 0);
        switch (PlayerPrefs.GetInt("Difficulty"))
        {
            case 0: transform.localScale = new Vector3(0.25f, 4.0f, 0.5f); break;
            case 1: transform.localScale = new Vector3(0.25f, 2.5f, 0.5f); break;
            case 2: transform.localScale = new Vector3(0.25f, 2.5f, 0.5f); break;
            default: transform.localScale = new Vector3(0.25f, 4.0f, 0.5f); break;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        try
        {
            MoveClosestPuck();
        }
        catch(MissingReferenceException ex)
        {
            fixException();
            Debug.Log("Caught missing exception");
        }
        catch (NullReferenceException ex)
        {
            fixException();
            Debug.Log("Caught null ref exception");
        }
    }

    void MoveClosestPuck()
    {
        float distanceOne = Vector3.Distance(puckOne.transform.localPosition, transform.localPosition);
        float distanceTwo = Vector3.Distance(puckTwo.transform.localPosition, transform.localPosition);
        //set target
        Transform other = distanceOne < distanceTwo ? puckOne.transform : puckTwo.transform;
        
        if (other.localPosition.y > transform.localPosition.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y + paddleSpeed, -5 + (transform.localScale.y / 2), 5f - (transform.localScale.y / 2)), transform.localPosition.z);
        }
        else if (other.localPosition.y < transform.localPosition.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y - paddleSpeed, -5 + (transform.localScale.y / 2), 5f - (transform.localScale.y / 2)), transform.localPosition.z);
        }
    }

    private void fixException()
    {
        puckOne = GameObject.FindGameObjectWithTag("BallPlayerOne");
        puckTwo = GameObject.FindGameObjectWithTag("BallPlayerTwo");
    }
}
