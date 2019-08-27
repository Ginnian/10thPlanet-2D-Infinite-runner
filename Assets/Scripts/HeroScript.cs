using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour
{
    public float jumpForce = 7.0f;
    private bool onGround = false;
    public bool iPeriod = false;
    public int movementSpeed = 7;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriRen;

    //UI Management
    public int maxLives = 10;
    private int livesLeft;
    public GameObject endGameMenu;
    public int score;
    public Text healthText;
    public Text distance;
    public Text finalScore;
    public bool acceptInput;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriRen = GetComponent<SpriteRenderer>();

        livesLeft = maxLives;
        healthText.text = "  " + new string('♥', livesLeft);
        acceptInput = true;

        Time.timeScale = 1f;
    }

    void FixedUpdate()
    {
        rb.freezeRotation = true;        
    }

    // Update is called once per frame
    void Update()
    {
        //distance.text = ((int)transform.position.x).ToString();
        score = (int)transform.position.x;
        distance.text = score.ToString();

        if (acceptInput && Input.GetButtonDown("Jump") && onGround)
        { 
            onGround = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
            anim.SetInteger("Transition", 2);
        } else if (acceptInput && Input.GetKey("right"))
        {
            if (onGround)
                anim.SetInteger("Transition", 1);
            spriRen.flipX = false;
            Vector2 currentPosition = transform.position;
            currentPosition.x = currentPosition.x + 0.2f;
            transform.position = currentPosition;
        } else if (acceptInput && Input.GetKey("left"))
        {
            if (onGround)
                anim.SetInteger("Transition", 1);
            spriRen.flipX = true;
            Vector2 currentPosition = transform.position;
            currentPosition.x = currentPosition.x + -0.2f;
            transform.position = currentPosition;
        } else if (onGround)
            anim.SetInteger("Transition", 4);
    }

    //check hero has touched the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        print("Hero has touched the ground"); 
    }

    //increase hero health
    public void HealthUp(int health)
    {
        livesLeft += health;
        if (livesLeft > maxLives)
            livesLeft = maxLives;

        healthText.text = "  " + new string('♥', livesLeft);
        print("Health up");
    }

    //decrease hero health
    public void HealthDown(int health)
    {
        livesLeft -= health;
        StartCoroutine(InvincFlash());

        if (livesLeft <= 0)
        {
            livesLeft = 0;
            acceptInput = false;
            endGameMenu.SetActive(true);
            Time.timeScale = 0f;
            finalScore.text = "Score " + score;
            anim.SetInteger("Transition", 3);
            
            Debug.Log("Death triggered");
        }
        
        healthText.text = "  " + new string('♥', livesLeft);
        print("Health down");
    }

    //Anim on injury
    public IEnumerator InvincFlash()
    {
        iPeriod = true;

        for(int i = 0; i < 5; i++)
        {
            spriRen.enabled = false;
            yield return new WaitForSeconds(.1f);
            spriRen.enabled = true;
            yield return new WaitForSeconds(.1f);
        }

        iPeriod = false;
        Debug.Log("Flashing");
    }
}
