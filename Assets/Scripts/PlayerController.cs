using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Abs(myRigidbody.velocity.y))
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
        else
            myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);

        if (myRigidbody.velocity == Vector2.zero)
            if (Input.anyKey)
            {
                if (Input.GetButtonDown("Left"))
                {
                    Walk("Left");
                }
                if (Input.GetButtonDown("Right"))
                {
                    Walk("Right");
                }
                if (Input.GetButtonDown("Up"))
                {
                    Walk("Up");
                }
                if (Input.GetButtonDown("Down"))
                {
                    Walk("Down");
                }
            }
    }

    void Walk(string direction)
    {
        switch (direction)
        {
            case "Left":
                myRigidbody.velocity = new Vector2(-speed, 0);
                break;
            case "Right":
                myRigidbody.velocity = new Vector2(speed, 0);
                break;
            case "Up":
                myRigidbody.velocity = new Vector2(0, speed);
                break;
            case "Down":
                myRigidbody.velocity = new Vector2(0, -speed);
                break;
        }
    }
}
