using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int score = 0;
    public static Text scoreText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        if (score >= 200)
        {
            DestroyBuilding();
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
    }
    public GameObject buildingToDestroy;

   

    void DestroyBuilding()
    {
        Destroy(buildingToDestroy);
    }
}
