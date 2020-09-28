using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class IntermediateManager : MonoBehaviour
{
    public QuestionsInter[] interquestions;
    private static List<QuestionsInter> unansweredQuestions;

    private QuestionsInter currentQuestion;

    public Text questionHeaderText;
    public Text questionText;
    public Image answer1Image, answer2Image, answer3Image, answer4Image;
    public Text answer1text, answer2text, answer3text, answer4text;
    public Button answer1Button, answer2Button, answer3Button, answer4Button;
    public Canvas questionCanvas;

    public int points;
    public PointsDisplay pointsDisplay;
    public Text answer1IndicatorText, answer2IndicatorText, answer3IndicatorText, answer4IndicatorText;
    // Update is called once per frame
    //public Animator animator;
    public AudioSource correctSound, wrongSound;
    void Start()
    {
        questionCanvas.enabled = true;
        EnableQuestionCanvas();
        SetQuestion();
        points = PlayerPrefs.GetInt("Points", 0);
    }
    public void EnableQuestionCanvas()
    {
        StartCoroutine(TransitionToQuestion());
    }
    public void SetQuestion()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = interquestions.ToList<QuestionsInter>();
        }

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionHeaderText.text = currentQuestion.interquestionHeader;
        questionText.text = currentQuestion.interquestion;
        answer1Image.sprite = currentQuestion.interanswer1;
        answer1text.text = currentQuestion.interanswer1text;
        answer2Image.sprite = currentQuestion.interanswer2;
        answer2text.text = currentQuestion.interanswer2text;
        answer3Image.sprite = currentQuestion.interanswer3;
        answer3text.text = currentQuestion.interanswer3text;
        answer4Image.sprite = currentQuestion.interanswer4;
        answer4text.text = currentQuestion.interanswer4text;

        unansweredQuestions.RemoveAt(randomQuestionIndex);





        if (currentQuestion.intercorrectAnswer == 1)
        {
            answer1IndicatorText.text = "Correct answer! You gained 1 point.";
            answer2IndicatorText.text = "Wrong answer!";
            answer3IndicatorText.text = "Wrong answer!";
            answer4IndicatorText.text = "Wrong answer!";
        }
        else if (currentQuestion.intercorrectAnswer == 2)
        {
            answer1IndicatorText.text = "Wrong answer!";
            answer2IndicatorText.text = "Correct answer! You gained 1 point.";
            answer3IndicatorText.text = "Wrong answer!";
            answer4IndicatorText.text = "Wrong answer!";
        }
        else if (currentQuestion.intercorrectAnswer == 3)
        {
            answer1IndicatorText.text = "Wrong answer!";
            answer2IndicatorText.text = "Wrong answer!";
            answer3IndicatorText.text = "Correct answer! You gained 1 point.";
            answer4IndicatorText.text = "Wrong answer!";
        }
        else if (currentQuestion.intercorrectAnswer == 4)
        {
            answer1IndicatorText.text = "Wrong answer!";
            answer2IndicatorText.text = "Wrong answer!";
            answer3IndicatorText.text = "Wrong answer!.";
            answer4IndicatorText.text = "Correct answer! You gained 1 point.";
        }
    }
    public void UserSelectAnswer1()
    {
        //animator.SetTrigger("Answer1");
        if (currentQuestion.intercorrectAnswer == 1)
        {
            Debug.Log("CORRECT ANSWER!");
            correctSound.Play();
            PlayerPrefs.SetInt("Points", ++points);
        }
        else if (currentQuestion.intercorrectAnswer == 2)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();

        }
        else if (currentQuestion.intercorrectAnswer == 3)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.intercorrectAnswer == 4)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0.4f);
        }
        else
        {
            answer1Button.interactable = false;
            answer2Button.interactable = false;
            answer3Button.interactable = false;
            answer4Button.interactable = false;
            StartCoroutine(TransitionBackToBoard());
        }
    }
    public void UserSelectAnswer2()
    {
        //animator.SetTrigger("Answer2");
        if (currentQuestion.intercorrectAnswer == 1)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();

        }
        else if (currentQuestion.intercorrectAnswer == 2)
        {
            Debug.Log("CORRECT ANSWER!");
            correctSound.Play();
            PlayerPrefs.SetInt("Points", ++points);
        }
        else if (currentQuestion.intercorrectAnswer == 3)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.intercorrectAnswer == 4)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0.4f);
        }
        else
        {
            answer1Button.interactable = false;
            answer2Button.interactable = false;
            answer3Button.interactable = false;
            answer4Button.interactable = false;
            StartCoroutine(TransitionBackToBoard());
        }
    }
    public void UserSelectAnswer3()
    {
        //animator.SetTrigger("Answer3");
        if (currentQuestion.intercorrectAnswer == 1)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();

        }
        else if (currentQuestion.intercorrectAnswer == 2)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.intercorrectAnswer == 3)
        {
            Debug.Log("CORRECT ANSWER!");
            correctSound.Play();
            PlayerPrefs.SetInt("Points", ++points);
        }
        else if (currentQuestion.intercorrectAnswer == 4)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0.4f);
        }
        else
        {
            answer1Button.interactable = false;
            answer2Button.interactable = false;
            answer3Button.interactable = false;
            answer4Button.interactable = false;
            StartCoroutine(TransitionBackToBoard());
        }
    }
    public void UserSelectAnswer4()
    {
        //animator.SetTrigger("Answer4");
        if (currentQuestion.intercorrectAnswer == 1)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();

        }
        else if (currentQuestion.intercorrectAnswer == 2)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.intercorrectAnswer == 3)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.intercorrectAnswer == 4)
        {
            Debug.Log("CORRECT ANSWER!");
            correctSound.Play();
            PlayerPrefs.SetInt("Points", ++points);
        }
        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0.4f);
        }
        else
        {
            answer1Button.interactable = false;
            answer2Button.interactable = false;
            answer3Button.interactable = false;
            answer4Button.interactable = false;
            StartCoroutine(TransitionBackToBoard());
        }
    }
    IEnumerator TransitionToQuestion()
    {
        yield return new WaitForSeconds(1f);

        questionCanvas.enabled = true;
    }
    public IEnumerator TransitionBackToBoard()
    {
        yield return new WaitForSeconds(2f);
        answer1Button.interactable = true;
        answer2Button.interactable = true;
        answer3Button.interactable = true;
        answer4Button.interactable = true;
        questionCanvas.enabled = false;
        //animator.SetTrigger("NoAnswer");
    }
}
