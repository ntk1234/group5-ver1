using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MyPauseMenu : MonoBehaviour
{
    public CharController charController;
    public Weapon weapon;

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

    public void ATK(string sceneName)
    {      
        Time.timeScale = 1;
        weapon.damage += 5;
       
        SceneManager.LoadScene(sceneName);
    }

    public void HP(string sceneName)
    {
        Time.timeScale = 1;
        charController.health += 20;
        SceneManager.LoadScene(sceneName);
    }
}