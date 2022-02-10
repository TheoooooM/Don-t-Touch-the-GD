using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    
    [HideInInspector] private bool goRight = true;

    [SerializeField] private SpikeEnabler SE;
    [Header("==== Player Stats ====")] 
    [SerializeField] float jumpForce = 5; 
    [SerializeField] float speed = 5;
    [SerializeField] private float maxForce;
    private bool started = false;
    public GameObject gameOverCanvas;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && GameManager.Instance.currentGameState != GameManager.GameState.dead)
        {
            rb.velocity = Vector2.up*jumpForce;
            if (GameManager.Instance.currentGameState == GameManager.GameState.menu) GameManager.Instance.currentGameState = GameManager.GameState.inGame;
        }
        else if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            SceneManager.LoadScene(0);
        }
        

        if (rb.velocity.y > maxForce) rb.velocity = new Vector2(rb.velocity.x, maxForce);
        //else if (rb.velocity.y < -maxForce)rb.velocity = new Vector2(rb.velocity.x, -maxForce);
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentGameState == GameManager.GameState.inGame)
        {
            if(started == false) StartParty();
            rb.simulated = true;
            transform.Translate(speed, 0, 0);
        }
        else if(GameManager.Instance.currentGameState == GameManager.GameState.dead)
        {
            Debug.Log("not in game");
        }
        else rb.simulated = false;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GameManager.Instance.currentGameState != GameManager.GameState.dead)
        {
            switch (other.transform.tag)
            {
                case "Walls":
                    goRight = !goRight;
                    speed = -speed;
                    GameManager.Instance.Score++;
                    SE.EnableSpikes(goRight, GameManager.Instance.Score);
                    break;

                case "Spike":
                    Death();
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bonbon")) SE.PickupBonbon();
    }


    void StartParty()
    {
        SE.EnableSpikes(goRight, GameManager.Instance.Score);
        if (MenuUIManager.Instance != null)
        {
            Debug.Log("change canvas");
            MenuUIManager.Instance.loadedCanvas.SetActive(false);
            MenuUIManager.Instance.inGameCanavs.SetActive(true);
        }

        started = true;
    }
    
    void Death()
    {
        GameManager.Instance.currentGameState = GameManager.GameState.dead;
        gameOverCanvas.SetActive(true);
        GameManager.Instance.totalBonbon += GameManager.Instance.currentGameBonbon;
        PlayerPrefs.SetInt("bonbon", GameManager.Instance.totalBonbon);
        
        if (GameManager.Instance.Score > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", GameManager.Instance.Score);
        }
        PlayerPrefs.SetInt("partyPlayed", PlayerPrefs.GetInt("partyPlayed")+1);
        
        MenuUIManager.Instance.deathHighscoreTxt.text = $"Highscore : {PlayerPrefs.GetInt("highScore")}";
        MenuUIManager.Instance.deathPlayedGamesTxt.text = $"Played Games : {PlayerPrefs.GetInt("partyPlayed")}";
        MenuUIManager.Instance.scoreText.text = $"Score : {GameManager.Instance.Score}";

    }
}
