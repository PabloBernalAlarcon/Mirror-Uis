using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuizManager : MonoBehaviour
{
    [Header("Creating Quiz")]
    [SerializeField]
    private TMP_InputField quizName;
    [SerializeField]
    private TMP_InputField  numberOfQuestions;
    [SerializeField]
    private Toggle randomize;

    [Header("Filling out questions")]
    [SerializeField]
    TMP_InputField questionName;
    [SerializeField]
    TMP_Text currentQuestionText;
    [SerializeField]
    TMP_InputField[] answers;
    [SerializeField]
    Toggle[] correctAnswers;
    [SerializeField]
    private int currentQuestion =0;

    Quiz quizito;
    public void Save()
    {
        quizito = new Quiz(
            quizName.text,
           int.Parse( numberOfQuestions.text),
            randomize.isOn
            );
    }
    public void updateToggles(int toggleToChange)
    {
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            if (i == toggleToChange) correctAnswers[i].isOn = true;
            else correctAnswers[i].isOn = false;
        }
    }

    public void changeQuestion(int moveBy)
    {
        currentQuestion += moveBy;
        if (currentQuestion < 0 || currentQuestion> (quizito.m_numOfQuestions-1))
        {
            currentQuestion -= moveBy;
            return;
        }

        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].text = quizito.m_questions[currentQuestion].m_answers[i];
        }
        currentQuestionText.text = (currentQuestion+1).ToString();
    }

    public void UpdateQuestion()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            quizito.m_questions[currentQuestion].m_answers[i] = answers[i].text;
        }
    }
}
