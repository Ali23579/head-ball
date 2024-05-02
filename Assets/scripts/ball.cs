using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{
    public Text BotScorer, panelbotscorer, panelplayerscorer, goal, PlayerScorer;
    public GameObject player2, player1;
    public AudioClip soundclip;
    private AudioSource soundsource;
    private float BOTSCORER = 0, PLAYERSCORER = 0, PANELBOTSCORER = 0, PANELPLAYERSCORER = 0, player1_location = 0, player2_location = 0;
    private bool isGoal = false, player1_ball = false, player2_ball = false;
    private Rigidbody2D x;

    private void Start()
    {
        x = GetComponent<Rigidbody2D>();
        soundsource = gameObject.AddComponent<AudioSource>();
        soundsource.clip = soundclip;
        soundsource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("leftcastle") && !isGoal)
        {
            BOTSCORER++;
            PANELBOTSCORER++;
            isGoal = true;
            goal.gameObject.SetActive(true);
            StartCoroutine(ResetGoal());
        }
        
        else if (collision.gameObject.CompareTag("rightcastle") && !isGoal)
        {
            PLAYERSCORER++;
            PANELPLAYERSCORER++;
            isGoal = true;
            goal.gameObject.SetActive(true);
            StartCoroutine(ResetGoal());
        }

        if(collision.gameObject.CompareTag("player1"))
        {
            player1_ball = true;
        }

        if(collision.gameObject.CompareTag("player2"))
        {
            player2_ball = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag ("player1"))
        {
            player1_ball = false;
        }

        if(other.gameObject.CompareTag("player2"))
        {
            player2_ball = false;
        }
    }

    IEnumerator ResetGoal()
    {
        yield return new WaitForSeconds(2f);
        goal.gameObject.SetActive(false);
        isGoal = false;

        if(transform != null)
        {
            transform.position = new Vector3(-0.17f ,2.19f , 0f);
        }

        player2.transform.position = new Vector3(-5.564732f,-2.281697f,0);
        player2.transform.eulerAngles = new Vector3(0,180,0);

        player1.transform.position = new Vector3(5.5f,-2.266368f,0);
        player2.transform.eulerAngles = new Vector3(0,0,0);
    }

    public void Update()
    {
        player1_location = player1.transform.eulerAngles.y;
        player2_location = player2.transform.eulerAngles.y;

        PlayerScorer.text = PLAYERSCORER.ToString();
        BotScorer.text = BOTSCORER.ToString();
        panelbotscorer.text = PANELBOTSCORER.ToString();
        panelplayerscorer.text = PANELPLAYERSCORER.ToString();

        if (Input.GetKeyDown(KeyCode.Space) && player2_ball == true)
        {
            if (player2_location >= 180)
            {
                x.velocity = new Vector2(-8, 4);
            }
            else
            {
                x.velocity = new Vector2(8, 4);
            }
        }

        
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) && player1_ball == true)
        {
            if (player1_location >= 180) 
            {
                x.velocity = new Vector2(-8, 4);
            }
            else 
            {
                x.velocity = new Vector2(8, 4);
            }
        }
    }
}
