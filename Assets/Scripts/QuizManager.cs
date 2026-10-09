using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
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
            listButton[answerID].GetComponent<Image>().color = new Color(0, 255, 0);
        }
        else
        {
            Debug.Log("mauvaise réponse");
            listButton[answerID].GetComponent<Image>().color = new Color(255, 0, 0);
        }

        StartCoroutine(WaitForQuestion());
    }

    private void UpdateQuestionUI()
    {
        question.text = currentQuestion.question;

        for (int i = 0; i < listButton.Count; i++)
        {
            TMPro.TextMeshProUGUI buttonText = listButton[i].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            buttonText.text = currentQuestion.answers[i];
            listButton[i].GetComponent<Image>().color = new Color(255, 255, 255);
        }
    }

    private IEnumerator WaitForQuestion()
    {
        yield return new WaitForSeconds(1f);
        SelectQuestion();
    }
}
