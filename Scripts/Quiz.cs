using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{

    public string achievementName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickCorrectAnswer()
    {
        AchievementManager.Instance.EarnAchievement(achievementName);
    }
}
