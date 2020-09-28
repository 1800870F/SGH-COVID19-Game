using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestionsManager : MonoBehaviour
{
    public Questions[] questions;
    private static List<Questions> unansweredQuestions;

    private Questions currentQuestion;

    public Text scoreText;
    public Text questionHeaderText;
    public Text questionText;
    public Image questionImage;
    public Image answer1Image, answer2Image, answer3Image, answer4Image;
    public Text answer1text, answer2text, answer3text, answer4text;
    public Button answer1Button, answer2Button, answer3Button, answer4Button;
    public Canvas questionCanvas;
    public Canvas completePanel;

    public GameObject currentPanel;
    public int points;
    private int scoreCount = 0;
    public Text ScoreText { get { return scoreText; } }
    public PointsDisplay pointsDisplay;
    // Update is called once per frame
    //public Animator animator;
    public AudioSource correctSound, wrongSound;
    void Start()
    {
        scoreCount = 0;
        questionCanvas.enabled = true;
        EnableQuestionCanvas();
        SetQuestion();
        points = PlayerPrefs.GetInt("Points", points);
    }
    public void EnableQuestionCanvas()
    {
        StartCoroutine(TransitionToQuestion());
    }
    public void SetQuestion()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Questions>();
        }

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionHeaderText.text = currentQuestion.questionHeader;
        questionText.text = currentQuestion.question;
        questionImage.sprite = currentQuestion.questionImage;
        answer1Image.sprite = currentQuestion.answer1;
        answer1text.text = currentQuestion.answer1text;
        answer2Image.sprite = currentQuestion.answer2;
        answer2text.text = currentQuestion.answer2text;
        answer3Image.sprite = currentQuestion.answer3;
        answer3text.text = currentQuestion.answer3text;
        answer4Image.sprite = currentQuestion.answer4;
        answer4text.text = currentQuestion.answer4text;

        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }
    public void UserSelectAnswer1()
    {
        points = PlayerPrefs.GetInt("Points", points);
        //animator.SetTrigger("Answer1");
        if (currentQuestion.correctAnswer == 1)
        {
            PlayerPrefs.SetInt("Points", ++points);
            Debug.Log("CORRECT ANSWER!");
            scoreCount += 1;
            ScoreText.text = "Score:" + scoreCount;
            correctSound.Play();     
        }
        else if (currentQuestion.correctAnswer == 2)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
            
        }
        else if (currentQuestion.correctAnswer == 3)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.correctAnswer == 4)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }

        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0f);
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
        points = PlayerPrefs.GetInt("Points", points);
        //animator.SetTrigger("Answer2");
        if (currentQuestion.correctAnswer == 1)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();

        }
        else if (currentQuestion.correctAnswer == 2)
        {
            PlayerPrefs.SetInt("Points", ++points);
            Debug.Log("CORRECT ANSWER!");
            scoreCount += 1;
            ScoreText.text = "Score:" + scoreCount;
            correctSound.Play();
        }
        else if (currentQuestion.correctAnswer == 3)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.correctAnswer == 4)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0f);
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
        points = PlayerPrefs.GetInt("Points", points);
        //animator.SetTrigger("Answer3");
        if (currentQuestion.correctAnswer == 1)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();

        }
        else if (currentQuestion.correctAnswer == 2)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.correctAnswer == 3)
        {
            PlayerPrefs.SetInt("Points", ++points);
            Debug.Log("CORRECT ANSWER!");
            scoreCount += 1;
            ScoreText.text = "Score:" + scoreCount;
            correctSound.Play();
        }
        else if (currentQuestion.correctAnswer == 4)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0f);
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
        points = PlayerPrefs.GetInt("Points", points);
        //animator.SetTrigger("Answer4");
        if (currentQuestion.correctAnswer == 1)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();

        }
        else if (currentQuestion.correctAnswer == 2)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.correctAnswer == 3)
        {
            Debug.Log("WRONG ANSWER!");
            wrongSound.Play();
        }
        else if (currentQuestion.correctAnswer == 4)
        {
            PlayerPrefs.SetInt("Points", ++points);
            Debug.Log("CORRECT ANSWER!");
            scoreCount += 1;
            ScoreText.text = "Score:" + scoreCount;
            correctSound.Play();
        }
        if (unansweredQuestions.Count > 0)
        {
            //call SelectQuestion method again after 1s
            Invoke("SetQuestion", 0f);
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
        completePanel.enabled = true;
        currentPanel.SetActive(false);
        AchievementManager.Instance.EarnAchievement("Hand Hygiene - Bronze");
        //animator.SetTrigger("NoAnswer");
    }
}
