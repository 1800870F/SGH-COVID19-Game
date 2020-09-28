using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement
{
    private string name;

    private string description;

    private bool unlocked;

    private int points;

    private int spriteIndex;

    private GameObject achievementRef;
    private List<Achievement> dependencies = new List<Achievement>();
    private string child;

    private int currentProgression;

    private int maxProgression;

    public Achievement(string name, string description, int points, int spriteIndex, GameObject achievementRef, int maxProgression)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.points = points;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef;
        this.maxProgression = maxProgression;
        LoadAchievement();
    }

    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public bool Unlocked { get => unlocked; set => unlocked = value; }
    public int Points { get => points; set => points = value; }
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }
    public string Child { get => child; set => child = value; }

    public void AddDependency(Achievement dependency)
    {
        dependencies.Add(dependency);
    }

    public bool EarnAchievement()
    {
        if(!unlocked && !dependencies.Exists(x => x.unlocked == false) && CheckProgress())
        {
            achievementRef.transform.GetComponent<Image>().color = new Color32(176, 141, 87, 255);
            achievementRef.transform.GetChild(0).GetComponent<Image>().color = new Color32(1, 111, 255, 255);
            SaveAchievement(true);

            if(child != null)
            {
                AchievementManager.Instance.EarnAchievement(child);
            }
            return true;
        }
        return false;
    }

    public void SaveAchievement(bool value)
    {
        unlocked = value;

        int tmpPoints = PlayerPrefs.GetInt("Points");

        if(unlocked)
        {
            PlayerPrefs.SetInt("Points", tmpPoints += points);
        }

        PlayerPrefs.SetInt("Progression" + Name, currentProgression);

        PlayerPrefs.SetInt(name, value ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;

        if(unlocked)
        {
            //AchievementManager.Instance.textPoints.text = "Points: " + PlayerPrefs.GetInt("Points");
            currentProgression = PlayerPrefs.GetInt("Progression" + Name);
            achievementRef.transform.GetComponent<Image>().color = new Color32(176, 141, 87, 255);
            achievementRef.transform.GetChild(0).GetComponent<Image>().color = new Color32(1, 111, 255, 255);
        }
    }

    public bool CheckProgress()
    {
        currentProgression++;

        if(maxProgression > 0)
        {
            achievementRef.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Name + " " + currentProgression + "/" + maxProgression;
        }

        SaveAchievement(false);

        if(maxProgression == 0)
        {
            return true;
        }
        if(currentProgression >= maxProgression)
        {
            return true;
        }
        return false;
    }
}
