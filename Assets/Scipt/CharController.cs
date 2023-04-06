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
    public int score = 0;
    private CharacterController characterController;
    private Animator animator;
    public Text scoreText;
    public Slider healthSlider;
    public GameObject death;
    public float gameOverDelay = 1f;
    private bool isGameOver = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        health = 100;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        healthSlider.maxValue = health;
        healthSlider.value = health;
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

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
        }

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("moveAttack");
        }

        scoreText.text = "Score: " + score.ToString();
        healthSlider.value = health;

        if (health <= 0 && !isGameOver)
        {
            isGameOver = true;
            GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null && health <= 0)
        {
            controller.enabled = false;
            Invoke("Restart", gameOverDelay);
        }
    }

    void GameOver()
    {
        death.SetActive(true);
        Invoke("Restart", 1f);
    }

    void Restart()
    {
        SceneManager.LoadScene("Title");
    }

    private void OnTriggerEnter(Collider other)
    {

    
if (other.gameObject.CompareTag("Enemy") && other.gameObject.GetComponent<CharController>() != null)
        {
            other.gameObject.GetComponent<CharController>().TakeDamage(10);
        }
    }
}