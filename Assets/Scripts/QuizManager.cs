using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private List<QuestionData> listQuestion;
    private QuestionData currentQuestion;
    
    [Header("UI Refs")] 
    [SerializeField] private List<UnityEngine.UI.Button> listButton;
    [SerializeField] private TMPro.TextMeshProUGUI question;

    private void Start()
    {
        SelectQuestion();
    }

    private void SelectQuestion()
    {
        int randomQuestionID = Random.Range(0, listQuestion.Count);
        currentQuestion = listQuestion[randomQuestionID];
        UpdateQuestionUI();
    }
    
    public void EnterAnswer(int answerID)
    {
        if (answerID == currentQuestion.correctAnswerID)
        {
            Debug.Log("bonne réponse");
        }
        else
        {
            Debug.Log("mauvaise réponse");
        }
        
        SelectQuestion();
    }

    private void UpdateQuestionUI()
    {
        question.text = currentQuestion.question;

        for (int i = 0; i < listButton.Count; i++)
        {
            TMPro.TextMeshProUGUI buttonText = listButton[i].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            buttonText.text = currentQuestion.answers[i];
        }
    }
}
