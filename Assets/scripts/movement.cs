using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private Rigidbody2D player1_rb, player2_rb;
    public GameObject player1, player2;
    private void Start()
    {
        player1_rb = player1.GetComponent<Rigidbody2D>();
        player2_rb = player2.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {   
            player1_rb.velocity = new Vector2(0,7);
        }

        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            player1.transform.eulerAngles = new Vector3(0, 180, 0);
            player1_rb.velocity = new Vector2(-7, -2);
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            player1.transform.eulerAngles = new Vector3(0, 0, 0);
            player1_rb.velocity = new Vector2(7, -2);
        }


        if(Input.GetKey(KeyCode.W))
        {
            player2_rb.velocity = new Vector2(0,7);
        }

        else if(Input.GetKey(KeyCode.A))
        {
            player2_rb.velocity = new Vector2(-7,-2);
            player2.transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            player2_rb.velocity = new Vector2(7,-2);
            player2.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
