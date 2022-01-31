using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public float timeValue = 90;
    public Text timerText;
    public Text timeUp = null;
    public Text answer = null;
    public Spaceship[] spaceships;
    
    void Update()
    {
        spaceships = FindObjectsOfType<Spaceship>();
        
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
/*        CheckCorrectAnswers();*/
    }

/*    int CheckCorrectAnswers()
    {
        foreach (Spaceship spaceship in spaceships)
        {
            if (spaceship.CheckAnswer())
            {
                return correct++;
            }
        }
        return correct;*/
/*    }*/
    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        int spaceshipNum = spaceships.Length / 3 - 1;
        if (spaceshipNum <= 1)
        {
            SceneManager.LoadScene("GameOver");
            timeUp.text = "";
            answer.text = "All questions answered!";
            timeToDisplay = 0;
        }
        if (Mathf.Approximately(minutes, 0) && seconds <= 0)
        {
            SceneManager.LoadScene("GameOver");
            timeUp.text = "Time's up!";
            answer.text = "";
            timeToDisplay = 0;
            /*Debug.Log("go");*/
        }
        
    }
}
