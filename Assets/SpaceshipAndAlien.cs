using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
/*using Microsoft.Data.Sqlite;*/
using System;

public class SpaceshipAndAlien : MonoBehaviour
{
   
    public GameObject alien;
    public GameObject spaceship;

    private string dbName = "URI=file:alienAbduction.db";

    // Start is called before the first frame update
    void Start()
    {
        CreateDB();
        /*MultiplyAliens(3);*/
        /*MultiplySpaceships(3);*/
        DisplayQuestion();
        DisplayAnswer();
        DisplayOptions();
    }

    public void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS Questions (Id VARCHAR(30), QuestionText VARCHAR(200), Answer VARCHAR(50), Option VARCHAR(50), QuiziId VARCHAR(30))";

                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DisplayQuestion()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
               /* int countQuestions = 0;
                command.CommandText = "SELECT COUNT QuestionText FROM Questions WHERE QuiziId = \"00ea167e-a0bd-4889-81fa-433119531680\"";
                command.ExecuteNonQuery();
                countQuestions = Int32.Parse(command.CommandText);*/
                command.CommandText = "SELECT QuestionText FROM Questions WHERE QuiziId = \"00ea167e-a0bd-4889-81fa-433119531680\"";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GameObject spaceshipClone = Instantiate(spaceship, new Vector3(UnityEngine.Random.Range(-9, 6), spaceship.transform.position.y * UnityEngine.Random.Range(1, 1.5f), 0), spaceship.transform.rotation);
                        spaceshipClone.transform.localScale = new Vector3(1f, 1.1f, 1.5f);
                        Text question = Component.FindObjectOfType<Text>();
                        question.text += reader["QuestionText"];
                    }
                }
            }
            connection.Close();
        }
    }

    public void DisplayAnswer()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                /* int countQuestions = 0;
                 command.CommandText = "SELECT COUNT QuestionText FROM Questions WHERE QuiziId = \"00ea167e-a0bd-4889-81fa-433119531680\"";
                 command.ExecuteNonQuery();
                 countQuestions = Int32.Parse(command.CommandText);*/
                command.CommandText = "SELECT Answer FROM Questions WHERE QuiziId = \"00ea167e-a0bd-4889-81fa-433119531680\"";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /*Debug.Log("HELLO");*/
                        GameObject alienClone = Instantiate(alien, new Vector3(UnityEngine.Random.Range(-9, 6), alien.transform.position.y, 0), alien.transform.rotation);
                        alienClone.transform.localScale = new Vector3(0.6f, 0.7f, 1.1f);
                        Text answer = Component.FindObjectOfType<Text>();
                        answer.text += reader["Answer"];
                    }
                }
            }
            connection.Close();
        }
    }
    public void DisplayOptions()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                /* int countQuestions = 0;
                 command.CommandText = "SELECT COUNT QuestionText FROM Questions WHERE QuiziId = \"00ea167e-a0bd-4889-81fa-433119531680\"";
                 command.ExecuteNonQuery();
                 countQuestions = Int32.Parse(command.CommandText);*/
                command.CommandText = "SELECT Option FROM Questions WHERE QuiziId = \"00ea167e-a0bd-4889-81fa-433119531680\"";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /*Debug.Log("HELLO");*/
                        GameObject alienClone = Instantiate(alien, new Vector3(alien.transform.position.x-3, alien.transform.position.y, 0), alien.transform.rotation);
                        alienClone.transform.localScale = new Vector3(0.6f, 0.7f, 1.1f);
                        Text answer = Component.FindObjectOfType<Text>();
                        answer.text += reader["Option"];
                    }
                }
            }
            connection.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    private void MultiplyAliens(int alienNum)
    {
        for (int i = -1; i < alienNum -1; i++)
        {
            GameObject alienClone = Instantiate(alien, new Vector3(5 * i, alien.transform.position.y, 0), alien.transform.rotation);
            alienClone.transform.localScale = new Vector3(0.6f, 0.7f, 1.1f);
            Text answer = Component.FindObjectOfType<Text>();
            answer.text = "Bye " + (1 +i);
           


        }
    }
    private void MultiplySpaceships(int alienNum)
    {
        for (int i = -1; i < alienNum -1; i++)
        {
            GameObject spaceshipClone = Instantiate(spaceship, new Vector3(6 * i, spaceship.transform.position.y* UnityEngine.Random.Range(1,1.5f), 0), spaceship.transform.rotation);
            spaceshipClone.transform.localScale = new Vector3(1f, 1.1f, 1.5f);
            Text question = Component.FindObjectOfType<Text>();
            question.text = "Hello " + (1 + i);
           
        }
    } */  
}
