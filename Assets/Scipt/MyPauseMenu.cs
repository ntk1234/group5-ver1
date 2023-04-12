using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MyPauseMenu : MonoBehaviour
{
    public CharController charController;
    public Weapon weapon;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pauseButton;
    void Start()

    {
        Time.timeScale = 0f;
        charController = FindObjectOfType<CharController>();
        weapon = FindObjectOfType<Weapon>();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        // TODO°G≈„•‹º»∞±µÊ≥Ê
    }

    public void PauseButton()
    {      
        Time.timeScale = 1.0f;
        weapon.damage += 5;
        _pauseMenu.SetActive(true);
        _pauseButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        _pauseButton.SetActive(true);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}