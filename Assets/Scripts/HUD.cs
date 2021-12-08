using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUD : MonoBehaviour
{
    public Level level;

    public TMP_Text remainingText;
    public TMP_Text remainingSubText;
    public TMP_Text targetText;
    public TMP_Text targetSubText;
    public TMP_Text scoreText;
    public TMP_Text scoreSubText;

    public GameObject[] stars;

    public GameOver gameOver;

    private int starIdx = 0;

    private void Start()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == starIdx)
            {
                stars[i].SetActive(true);
            }
            else
            {
                stars[i].SetActive(false);
            }
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
        int visibleStar = 0;
        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }
        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == visibleStar)
            {
                stars[i].SetActive(true);
            }
        }
        starIdx = visibleStar;
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }
    public void SetLevelType(LevelType type)
    {
        switch (type)
        {
            case LevelType.Moves:
                remainingSubText.text = "moves remaining";
                targetSubText.text = "target score";
                break;
            case LevelType.Obstacle:
                remainingSubText.text = "moves remaining";
                targetSubText.text = "bubbles remaining";
                break;
            case LevelType.Timer:
                remainingSubText.text = "time remaining";
                targetSubText.text = "target score";
                break;
        }
    }

    public void OnGameWin(int score)
    {
        gameOver.ShowWin(score, starIdx);
    }
    public void OnGameLose(int score)
    {
        gameOver.ShowLose(score, starIdx);
    }
}
