using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelType
{
    Timer,
    Obstacle,
    Moves
}
public class Level : MonoBehaviour
{
    protected LevelType type;
    public LevelType Type => type;

    public Grid grid;

    public int score1Star;
    public int score2Star;
    public int score3Star;

    protected int currentScore;

    public virtual void GameWin()
    {
        Debug.Log("you win!");
        grid.GameOver();
    }
    public virtual void GameLose()
    {
        Debug.Log("you lose.");
        grid.GameOver();
    }
    public virtual void OnMove()
    {
        
    }
    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        Debug.Log("score: " + currentScore);
    }
}
