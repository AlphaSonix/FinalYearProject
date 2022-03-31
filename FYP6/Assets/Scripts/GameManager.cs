using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject GOPanel; 

    public static MeshDetector md;

    public Text questionText;
    public Text scoreTxt;

    int totalQuestions;
    public int score;

    //when player reaches a certain score, the game over panel displays
    void GameOver()
    {

        if (score == totalQuestions)
        {
            GOPanel.SetActive(true);  
        }  
              
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
    public void correct()
    {
        if (score <= totalQuestions)
        {
            score += 1;
            scoreTxt.text = score + "/" + totalQuestions;
            Debug.Log("Question is Correct! This is being printed");
        }

    }
    
    public void wrong()
    {
        Debug.Log("Question is Incorrect!");
    }

    public void Start()
    {
        totalQuestions = 7; 
        GOPanel.SetActive(false);

        assignQuestion();

    }

    public void Update()
    {

        GameOver();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

   void assignQuestion()
    {
            currentQuestion = Random.Range(0,QnA.Count);
            questionText.text = QnA[currentQuestion].Question;
            SetAnswers(); 
    }
}
