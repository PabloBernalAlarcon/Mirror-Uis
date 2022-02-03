using System.Collections;
using System.Collections.Generic;

public class Quiz 
{
    public string m_QuizName;
    public int m_numOfQuestions;
    public bool m_randomize;
    public Question[] m_questions;
    public Quiz(string name, int amountofQuestions, bool randomize)
    {
        m_QuizName = name;
        m_numOfQuestions = amountofQuestions;
        m_randomize = randomize;
        m_questions = new Question[4];
        for (int i = 0; i < 4; i++)
        {
            m_questions[i] = new Question();
        }
    }

}

public class Question
{
   public string question;
   public string[] m_answers;
   public int m_rightAns;
    public int m_chosenAns;
    public Question()
    {
        question = string.Empty;
        m_answers = new string[4];
        m_rightAns = 0;
        m_chosenAns = -1;
    }

}