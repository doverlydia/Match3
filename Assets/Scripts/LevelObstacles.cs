using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObstacles : Level
{
    public int numMoves;
    public PieceType[] obstaclesTypes;

    private int movesUsed = 0;
    private int numObstaclesLeft;
    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.Obstacle;

        for (int i = 0; i < obstaclesTypes.Length; i++)
        {
            numObstaclesLeft += grid.GetPiecesOfType(obstaclesTypes[i]).Count;
        }
    }

    public override void OnMove()
    {
        movesUsed++;
        Debug.Log("moves remaining: " + (numMoves - movesUsed));
        if (numMoves - movesUsed == 0 && numObstaclesLeft > 0)
        {
            GameLose();
        }
    }

    public override void OnPieceCleared(GamePiece piece)
    {
        base.OnPieceCleared(piece);
        for (int i = 0; i < obstaclesTypes.Length; i++)
        {
            if (obstaclesTypes[i] == piece.Type)
            {
                numObstaclesLeft--;
                if (numObstaclesLeft == 0)
                {
                    currentScore += 1000 * (numMoves - movesUsed);
                    Debug.Log("current score: " + currentScore);
                    GameWin();
                }
            }
        }
    }
}
