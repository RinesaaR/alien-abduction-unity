using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipAndAlien : MonoBehaviour
{
   
    public GameObject alien;
    public GameObject spaceship;


    // Start is called before the first frame update
    void Start()
    {
        MultiplyAliens(3);
        MultiplySpaceships(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MultiplyAliens(int alienNum)
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
            GameObject spaceshipClone = Instantiate(spaceship, new Vector3(6 * i, spaceship.transform.position.y*Random.Range(1,1.5f), 0), spaceship.transform.rotation);
            spaceshipClone.transform.localScale = new Vector3(1f, 1.1f, 1.5f);
            Text question = Component.FindObjectOfType<Text>();
            question.text = "Hello " + (1 + i);
           
        }
    }   
}
