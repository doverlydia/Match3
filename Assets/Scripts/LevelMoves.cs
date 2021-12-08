using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoves : Level
{
    public int numMoves;
    public int targetScore;

    private int movesUsed=0;
    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.Moves;
        Debug.Log("number of moves: " + numMoves + " target score: " + targetScore);
    }

    public override void OnMove()
    {
        movesUsed++;

        Debug.Log("moves remaining" + (numMoves - movesUsed));

        if (numMoves - movesUsed == 0)
        {
            if (currentScore >= targetScore)
            {
                GameWin();
            }
            else
            {
                GameLose();
            }
        }
    }
}
