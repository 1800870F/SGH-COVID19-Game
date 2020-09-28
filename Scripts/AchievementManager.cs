using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{

    public GameObject achievementPrefab;

    public Sprite[] sprites;

    public GameObject achievementMenu;

    public GameObject visualAchievement;

    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    public Text textPoints;

    private static AchievementManager instance;

    private int fadeTime = 2;

    public static AchievementManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<AchievementManager>();
            }
            return AchievementManager.instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Delete this line when testing is done
        //PlayerPrefs.DeleteAll();

        CreateAchievement("General", "Personal Hygiene - Bronze", "Complete the Personal Hygiene quiz on Bronze level", 100, 2, 0);
        CreateAchievement("General", "Hand Hygiene - Bronze", "Complete the Hand Hygiene quiz on Bronze level", 100, 2, 0);
        CreateAchievement("General", "Social Distancing - Bronze", "Complete the Social Distancing quiz on Bronze level", 100, 2, 0);
        CreateAchievement("General", "Dormitory Hygiene - Bronze", "Complete the Dormitory Hygiene quiz on Bronze level", 100, 2, 0);
        CreateAchievement("General", "Workplace Hygiene - Bronze", "Complete the Workplace Hygiene quiz on Bronze level", 100, 2, 0);
        CreateAchievement("General", "Mastery - Bronze", "Complete all quizzes on Bronze level", 500, 2, 0, new string[]
            {
                "Personal Hygiene - Bronze", "Hand Hygiene - Bronze", "Social Distancing - Bronze", "Dormitory Hygiene - Bronze", "Workplace Hygiene - Bronze",
            });
        CreateAchievement("General", "Personal Hygiene - Silver", "Complete the Personal Hygiene quiz on Silver level", 100, 3, 0);
        CreateAchievement("General", "Hand Hygiene - Silver", "Complete the Hand Hygiene quiz on Silver level", 100, 3, 0);
        CreateAchievement("General", "Social Distancing - Silver", "Complete the Social Distancing quiz on Silver level", 100, 3, 0);
        CreateAchievement("General", "Dormitory Hygiene - Silver", "Complete the Dormitory Hygiene quiz on Silver level", 100, 3, 0);
        CreateAchievement("General", "Workplace Hygiene - Silver", "Complete the Workplace Hygiene quiz on Silver level", 100, 3, 0);
        CreateAchievement("General", "Mastery - Silver", "Complete all quizzes on Silver level", 500, 3, 0, new string[]
            {
                "Personal Hygiene - Silver", "Hand Hygiene - Silver", "Social Distancing - Silver", "Dormitory Hygiene - Silver", "Workplace Hygiene - Silver",
            });
        CreateAchievement("General", "Personal Hygiene - Gold", "Complete the Personal Hygiene quiz on Gold level", 100, 4, 0);
        CreateAchievement("General", "Hand Hygiene - Gold", "Complete the Hand Hygiene quiz on Gold level", 100, 4, 0);
        CreateAchievement("General", "Social Distancing - Gold", "Complete the Social Distancing quiz on Gold level", 100, 4, 0);
        CreateAchievement("General", "Dormitory Hygiene - Gold", "Complete the Dormitory Hygiene quiz on Gold level", 100, 4, 0);
        CreateAchievement("General", "Workplace Hygiene - Gold", "Complete the Workplace Hygiene quiz on Gold level", 100, 4, 0);
        CreateAchievement("General", "Mastery - Gold", "Complete all quizzes on Gold level", 500, 4, 0, new string[]
            {
                "Personal Hygiene - Gold", "Hand Hygiene - Gold", "Social Distancing - Gold", "Dormitory Hygiene - Gold", "Workplace Hygiene - Gold",
            });
        //CreateAchievement("General", "Press W", "Press W 5 times to unlock this achievement", 100, 0, 5);
        //CreateAchievement("General", "Press A", "Press A to unlock this achievement", 100, 0, 0);
        //CreateAchievement("General", "Press S", "Press S to unlock this achievement", 100, 0, 0);
        //CreateAchievement("General", "Press D", "Press D to unlock this achievement", 100, 0, 0);
        //CreateAchievement("General", "Press All Keys", "Press all keys to unlock this achievement", 200, 0, 0, new string[] 
        //{
        //    "Press W", "Press A", "Press S", "Press D",
        //});


        achievementMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    achievementMenu.SetActive(!achievementMenu.activeSelf);
        //}
        //if(Input.GetKeyDown(KeyCode.W))
        //{
        //    EarnAchievement("Press W");
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    EarnAchievement("Press A");
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    EarnAchievement("Press S");
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    EarnAchievement("Press D");
        //}
    }

    public void EarnAchievement(string title)
    {
        if(achievements[title].EarnAchievement())
        {
            GameObject achievement = (GameObject)Instantiate(visualAchievement);
            SetAchievementInfo("EarnCanvas", achievement, title);
            //textPoints.text = "Points: " + PlayerPrefs.GetInt("Points");
            StartCoroutine(FadeAchievement(achievement));
        }
    }

    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }

    public void CreateAchievement(string parent, string title, string description, int points, int spriteIndex, int progress, string[] dependencies = null)
    {
        GameObject achievement = (GameObject)Instantiate(achievementPrefab);

        Achievement newAchievement = new Achievement(title, description, points, spriteIndex, achievement, progress);

        achievements.Add(title, newAchievement);

        SetAchievementInfo(parent, achievement, title, progress);

        if(dependencies != null)
        {
            foreach(string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = title;
                newAchievement.AddDependency(dependency);
            }
        }
    }

    public void SetAchievementInfo(string parent, GameObject achievement, string title, int progression = 0)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        string progress = progression > 0 ? " " + PlayerPrefs.GetInt("Progression" + title) + "/" + progression.ToString() : string.Empty;
        achievement.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = title + progress;
        achievement.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = achievements[title].Description;
        achievement.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = achievements[title].Points.ToString();
        achievement.transform.GetChild(0).GetChild(3).GetComponent<Image>().sprite = sprites[achievements[title].SpriteIndex];
    }

    private IEnumerator FadeAchievement(GameObject achievement)
    {
        CanvasGroup canvasGroup = achievement.GetComponent<CanvasGroup>();

        float rate = 1.0f / fadeTime;

        int startAlpha = 0;
        int endAlpha = 1;

        for(int i = 0; i < 2; i++)
        {
            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }
            yield return new WaitForSeconds(2);
            startAlpha = 1;
            endAlpha = 0;
        }

        Destroy(achievement);

    }
}
