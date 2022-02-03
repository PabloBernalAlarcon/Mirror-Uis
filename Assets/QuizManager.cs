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

    //Creates a new quiz. Called before filling out answers
    public void Save()
    {
        quizito = new Quiz(
            quizName.text,
           int.Parse( numberOfQuestions.text),
            randomize.isOn
            );
    }

    //Sets all toggles off except for the clicked one
    public void updateToggles(int toggleToChange)
    {
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            if (i == toggleToChange) correctAnswers[i].isOn = true;
            else correctAnswers[i].isOn = false;
        }
    }

    //Allows navigation between quiz questions, displaying on UI the current question's contents
    public void changeQuestion(int moveBy)
    {
        currentQuestion += moveBy;
        if (currentQuestion < 0 || currentQuestion> (quizito.m_numOfQuestions-1))
        {
            currentQuestion -= moveBy;
            return;
        }

        //Update questions on UI
        questionName.text = quizito.m_questions[currentQuestion].question;

        //Update answers on UI
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].text = quizito.m_questions[currentQuestion].m_answers[i];
        }
        //Update current Question's UI
        currentQuestionText.text = (currentQuestion+1).ToString();


        //TO DO
        //Update correct toggle selections for current answer
    }

    //Stores the current UI´s data onto the quiz instance
    public void UpdateQuestion()
    {
        //SAve questions from UI
        quizito.m_questions[currentQuestion].question =questionName.text;

        //Update answers from UI
        for (int i = 0; i < answers.Length; i++)
        {
            quizito.m_questions[currentQuestion].m_answers[i] = answers[i].text;
        }

        //TO DO
        //Savee correct toggle selections for current answer
    }
}
