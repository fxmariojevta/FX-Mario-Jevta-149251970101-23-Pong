using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSizeUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public Collider2D paddleLeft;
    public Collider2D paddleRight;
    public float magnitude;
    public int sizeUptime;

    private int player;
    private int sizeUpLeft;
    private int sizeUpRight;
    private float timerSizeUpLeft;
    private float timerSizeUpRight;
    // private BallController ballController;

    // public string GetPlayer()
    // {
    //     string name_ = GameObject.Find(ballController.name_);
    //     Debug.Log("PlayerR " + name);
    //     return name;
    // }

    private void OnTriggerEnter2D(Collider2D collission) 
    {
        if (collission == ball)
        {
            // string name_ = GetPlayer();
            if (player == 1)
            {
                sizeUpRight = 1;
                paddleRight.GetComponent<PaddleController>().ActivatePUPaddleSizeUp(magnitude);
            }

            if (player == 0)
            {
                sizeUpLeft = 1;
                paddleLeft.GetComponent<PaddleController>().ActivatePUPaddleSizeUp(magnitude);
            }
            manager.RemovePowerUp(gameObject);
            Debug.Log("PlayerB " + player);
        }
    }

    void Update()
    {
        if (sizeUpLeft == 1)
        {
            timerSizeUpLeft += Time.deltaTime;

            if (timerSizeUpLeft > sizeUptime)
            {
                sizeUpLeft = 0;
                paddleLeft.GetComponent<PaddleController>().DeactivatePUPaddleSizeUp(magnitude);
                timerSizeUpLeft -= sizeUptime;
            }
        }

        if (sizeUpRight == 1)
        {
            timerSizeUpRight += Time.deltaTime;

            if (timerSizeUpRight > sizeUptime)
            {
                sizeUpRight = 0;
                paddleRight.GetComponent<PaddleController>().DeactivatePUPaddleSizeUp(magnitude);
                timerSizeUpRight -= sizeUptime;
            }
        }
    }
}
