using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionAndAnswer : MonoBehaviour
{
    public Text answer;
    public Text question;

    // Start is called before the first frame update
    void Start()
    {
        MultiplyAnswers(3);
        MultiplyQuestions(3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MultiplyAnswers(int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            Text answerClone = Instantiate(answer, new Vector3(2 * i, answer.transform.position.y, 0), answer.transform.rotation);
            answerClone.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            answerClone.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            answerClone.text = "Hello" + i;
        }
    }

    private void MultiplyQuestions(int alienNum)
    {
        for (int i = 0; i < alienNum; i++)
        {
            Text questionClone = Instantiate(question, new Vector3(2 * i, question.transform.position.y, 0), question.transform.rotation);
            questionClone.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            questionClone.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            questionClone.text = "HelloPyetje" + i;
        }
    }
}

