using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAndAnswer : MonoBehaviour
{
    public GameObject alien;
    public Text answer;
    public GameObject spaceship;
    public Text question;
    // Start is called before the first frame update
    void Start()
    {
        MultiplyAliens(3);
        MultiplyAnswers(5);
        MultiplySpaceships(3);
        MultiplyQuestions(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MultiplyAliens(int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            GameObject alienClone = Instantiate(alien, new Vector3(2.5f*i, alien.transform.position.y, 0), alien.transform.rotation);
            alienClone.transform.localScale = new Vector3(0.6f, 0.7f, 1.1f);
            /*GameObject answerClone = Instantiate(answer, new Vector3(5 * i, alien.transform.position.y, 0), answer.transform.rotation);*/
        }
    }

    private void MultiplySpaceships(int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            GameObject spaceshipClone = Instantiate(spaceship, new Vector3(4 * i, spaceship.transform.position.y*Random.Range(1,1.5f), 0), spaceship.transform.rotation);
            spaceshipClone.transform.localScale = new Vector3(1f, 1.1f, 1.5f);
            /*GameObject answerClone = Instantiate(answer, new Vector3(5 * i, alien.transform.position.y, 0), answer.transform.rotation);*/
        }
    }
    private void MultiplyAnswers(int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            Text answerClone = Instantiate(answer, new Vector3(2 * i, answer.transform.position.y, 0), answer.transform.rotation);
            answerClone.transform.localScale = new Vector3(0.6f, 0.7f, 1.1f);
            answerClone.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            answerClone.text = "Hello" + i;
            /*GameObject answerClone = Instantiate(answer, new Vector3(5 * i, alien.transform.position.y, 0), answer.transform.rotation);*/
        }
    }

    private void MultiplyQuestions(int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            Text questionClone = Instantiate(question, new Vector3(2 * i, question.transform.position.y, 0), question.transform.rotation);
            questionClone.transform.localScale = new Vector3(0.6f, 0.7f, 1.1f);
            questionClone.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            questionClone.text = "Hello" + i;
            /*GameObject answerClone = Instantiate(answer, new Vector3(5 * i, alien.transform.position.y, 0), answer.transform.rotation);*/
        }
    }
}
