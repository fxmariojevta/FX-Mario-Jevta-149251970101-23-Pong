using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public Collider2D paddleLeft;
    public Collider2D paddleRight;
    public int magnitude;
    public int speedUptime;

    private int player;
    private int speedUpLeft;
    private int speedUpRight;
    private float timerSpeedUpLeft;
    private float timerSpeedUpRight;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log( "collide (name) : " + collision.collider.name );
        Debug.Log( "collide (tag) : " + collision.collider.tag );
        
            if (collision.collider.name == "Paddle Right")
            {
                player = 1;
                Debug.Log("PlayerR " + player);
            }
            if (collision.collider.name == "Paddle Left")
            {
                player = 0;
                Debug.Log("PlayerR " + player);
            }
        
    }

    private void OnTriggerEnter2D(Collider2D collission) 
    {
        if (collission == ball)
        {
            if (player == 1)
            {
                speedUpRight = 1;
                paddleRight.GetComponent<PaddleController>().ActivatePUPaddleSpeedUp(magnitude);
            }

            if (player == 0)
            {
                speedUpLeft = 1;
                paddleLeft.GetComponent<PaddleController>().ActivatePUPaddleSpeedUp(magnitude);
            }
            manager.RemovePowerUp(gameObject);
            Debug.Log("PlayerB " + player);
        }
    }

    void Update()
    {
        if (speedUpLeft == 1)
        {
            timerSpeedUpLeft += Time.deltaTime;

            if (timerSpeedUpLeft > speedUptime)
            {
                speedUpLeft = 0;
                paddleLeft.GetComponent<PaddleController>().DeactivatePUPaddleSpeedUp(magnitude);
                timerSpeedUpLeft -= speedUptime;
            }
        }

        if (speedUpRight == 1)
        {
            timerSpeedUpRight += Time.deltaTime;

            if (timerSpeedUpRight > speedUptime)
            {
                speedUpRight = 0;
                paddleRight.GetComponent<PaddleController>().DeactivatePUPaddleSpeedUp(magnitude);
                timerSpeedUpRight -= speedUptime;
            }
        }
    }
}
