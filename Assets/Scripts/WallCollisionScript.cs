using UnityEngine;
using System.Collections;

public class WallCollisionScript : MonoBehaviour {

    public GameObject playerOne;
    public GameObject playerTwo;


    void OnCollisionEnter(Collision collision)
    {
        var one = playerOne.GetComponent<PaddleController>();
        var two = playerTwo.GetComponent<PaddleController>();

        if (tag.Equals("WallLeft"))
        {
            one.DecreaseScore(1);
            if (collision.gameObject.tag.Equals("BallPlayerTwo"))
            {
                two.IncreaseScore(1);
            }
        }
        if (tag.Equals("WallRight"))
        {
            two.DecreaseScore(1);
            if (collision.gameObject.tag.Equals("BallPlayerOne"))
            {
                one.IncreaseScore(1);
            }
        }
        if (collision.gameObject.tag.Equals("BallPlayerOne"))
        {
            one.setIsBallAlive(false);
        }
        if (collision.gameObject.tag.Equals("BallPlayerTwo"))
        {
            two.setIsBallAlive(false);
        }
        Destroy(collision.gameObject);
    }
}
