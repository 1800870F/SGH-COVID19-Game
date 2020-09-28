using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RewardManager : MonoBehaviour
{
    public Reward[] rewards;
    private static List<Reward> unclaimrewards;
    private Reward currentReward;
    public Image rewardImage;
    public GameObject startMenu;
    public GameObject claimMenu;

    private Reward currentRewards;
    public int tenPoint = 10;
    public int threeHundredPoint = 300;
    public int points;
    void Start()
    {
        SetImage();
    }
    public void Rewards()
    {
        if (PlayerPrefs.GetInt("Points", 0) < 300)
        {
            startMenu.SetActive(true);
        }
        else 
        {
            points = PlayerPrefs.GetInt("Points", 0);
            points -= threeHundredPoint;
            PlayerPrefs.SetInt("Points", points);
            claimMenu.SetActive(true);
        }
    }
    public void SetImage()
    {
        if (unclaimrewards == null || unclaimrewards.Count == 0)
        {
            unclaimrewards = rewards.ToList<Reward>();
        }

        int randomQuestionIndex = Random.Range(0, unclaimrewards.Count);
        currentRewards = unclaimrewards[randomQuestionIndex];

        rewardImage.sprite = currentRewards.rewardImage;

        unclaimrewards.RemoveAt(randomQuestionIndex);
    }
}
