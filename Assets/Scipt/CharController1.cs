using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharController1: MonoBehaviour
{
    Animator anim;
    public float rotSpeed = 10;
    Vector3 moveDirection;
    public int health2 = 100;
    public int score = 0;
    private CharacterController characterController1;
    private Animator animator;
    public static Text scoreText;
    public static Slider healthSlider2;
    public GameObject death;
    public float gameOverDelay = 0.1f;
    private bool isGameOver = false;
   
    public AudioClip fightSound;
    public AudioClip hitSound;
    private AudioSource myAduioSource;
    void Start()
    {
        anim = GetComponent<Animator>();
        characterController1 = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        healthSlider2 = GameObject.Find("HealthSlider2P").GetComponent<Slider>();
        healthSlider2.maxValue = health2;
        healthSlider2.value = health2;
        myAduioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
     

        float h = Input.GetAxis("Horizontal2");
        float v = Input.GetAxis("Vertical2");

        Vector2 move = new Vector2(h, v);
        anim.SetFloat("speed", move.magnitude);

        moveDirection = new Vector3(h, 0, v);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;

       
     

        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown("[2]"))
        {
            anim.SetTrigger("punch");
           
        }

        if (Input.GetKeyDown("[1]"))
        {
            anim.SetTrigger("kick");
            
        }
        if ( Input.GetKeyDown("[3]"))
        {
            anim.SetTrigger("fireball");

        }


        scoreText.text = "Score: " + score.ToString();
        healthSlider2.value = health2;

       /* if (health <= 0 && !isGameOver)
        {
            isGameOver = true;
            GameOver();
        }*/
    }

    public void TakeDamage(int damage)
    {
        health2 -= damage;
        if (health2 <= 0 /*&& !isGameOver*/)
        {
            /*isGameOver = true;
            */
            GameOver();
        }
    }

    void GameOver()
    {

        death.SetActive(true);
        healthSlider2.value = 0;
        SceneManager.LoadScene("Title");
        Invoke("Restart", gameOverDelay);

    }

    void Restart()
    {

        health2 = 100; // 重置血量值
        healthSlider2.value = health2; // 更新血量條顯示
        SceneManager.LoadScene("Title");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CharController enemyController = other.gameObject.GetComponent<CharController>();
            if (enemyController != null)
            {
                enemyController.TakeDamage(10);
            }
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void AddHealth(int upHealth)
    {
        health2+= upHealth;
    }
    public void PlayFightSound()
    {
        myAduioSource.clip = fightSound;
        myAduioSource.Play();
    }
    public void PlayShootSound()
    {
        myAduioSource.clip = hitSound;
        myAduioSource.Play();
    }
}