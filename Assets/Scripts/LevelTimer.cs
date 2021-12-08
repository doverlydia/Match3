using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : Level
{
    public int timeInSeconds;
    public int targetScore;

    bool timeOut;

    [SerializeField] private float timer;

    private void Start()
    {
        type = LevelType.Timer;
        Debug.Log("time: " + timeInSeconds + " seconds. Target score: " + targetScore);
    }
    private void Update()
    {
        if (!timeOut)
        {
            timer += Time.deltaTime;

            if (timeInSeconds - timer <= 0)
            {
                if (currentScore >= targetScore)
                {
                    GameWin();
                }
                else
                {
                    GameLose();
                }

                timeOut = true;
            }
        }
    }
}
