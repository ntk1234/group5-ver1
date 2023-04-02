using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        anim = GetComponent<Animator>();
        health = 100;
        characterController = GetComponent<CharacterController>();
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
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetTrigger("death");
            characterController.enabled = false;
            // Game over
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            score += 10;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }
}