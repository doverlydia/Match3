using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : Level
{
    public float timeInSeconds;
    public int targetScore;

    bool timeOut;

    [SerializeField] private float timer;

    private void Start()
    {
        type = LevelType.Timer;

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);

        hud.SetRemaining(string.Format("{0}:{1:00}", Mathf.Max(timeInSeconds / 60), Mathf.Max(timeInSeconds % 60)));
    }
    private void Update()
    {
        if (!timeOut)
        {
            timer += Time.deltaTime;

            hud.SetRemaining(string.Format("{0}:{1:00}", (int)Mathf.Max((timeInSeconds - timer) / 60), (int)Mathf.Max(timeInSeconds - timer) % 60, 0));

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
