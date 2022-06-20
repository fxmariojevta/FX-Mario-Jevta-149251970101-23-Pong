using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("Speed " + movement);
        rig.velocity = movement;
    }

    public void ActivatePUPaddleSizeUp(float magnitude)
    {
        transform.localScale += new Vector3(0, magnitude, 0);
    }

    public void DeactivatePUPaddleSizeUp(float magnitude)
    {
        transform.localScale -= new Vector3(0, magnitude, 0);
    }

    public void ActivatePUPaddleSpeedUp(int magnitude)
    {
        speed += magnitude;
    }

    public void DeactivatePUPaddleSpeedUp(int magnitude)
    {
        speed -= magnitude;
    }
}
