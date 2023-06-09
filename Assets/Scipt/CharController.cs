using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharController : MonoBehaviour
{
    Animator anim;
    public float rotSpeed = 10;
    Vector3 moveDirection;
    public int health = 100;
    
    private CharacterController characterController;
    private Animator animator;
    public int score = 0;
    public static Text scoreText;
    public static Slider healthSlider;
    public GameObject death;
    public float gameOverDelay = 0.1f;
    private bool isGameOver = false;
    public int scoreCheck = 200;

    public AudioClip fightSound;
    public AudioClip hitSound;
    private AudioSource myAduioSource;
    void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        healthSlider.maxValue = health;
        healthSlider.value = health;
        myAduioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
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

        if (Input.GetKeyDown("k"))
        {
            anim.SetTrigger("attack");
           
        }

        if (Input.GetKeyDown("l")| Input.GetKeyDown("j"))
        {
            anim.SetTrigger("moveAttack");
            
        }

        scoreText.text = "Score: " + score.ToString();

      if (score >= scoreCheck)
        {
            DestroyBuilding();
        }

        healthSlider.value = health;

       /* if (health <= 0 && !isGameOver)
        {
            isGameOver = true;
            GameOver();
        }*/
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0 /*&& !isGameOver*/)
        {
            /*isGameOver = true;
            */
            GameOver();
        }
    }

    void GameOver()
    {
        
        death.SetActive(true);
        /*PlayerPrefs.SetInt("health", health); // �Nhealth�ȫO�s��PlayerPrefs��*/
        SceneManager.LoadScene("Title");
        Invoke("Restart", gameOverDelay);
        
    }

    void Restart()
    {
        
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
        health+= upHealth;
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
   public GameObject buildingToDestroy;

    void DestroyBuilding()
    {
        Destroy(buildingToDestroy);
    }
}