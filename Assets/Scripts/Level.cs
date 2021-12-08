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
    public HUD hud;

    public int score1Star;
    public int score2Star;
    public int score3Star;

    protected int currentScore;
    private void Start()
    {
        hud.SetScore(currentScore);
    }
    public virtual void GameWin()
    {
        Debug.Log("you win!");
        hud.OnGameWin(currentScore);
        grid.GameOver();
    }
    public virtual void GameLose()
    {
        Debug.Log("you lose.");
        hud.OnGameLose(currentScore);
        grid.GameOver();
    }
    public virtual void OnMove()
    {
        
    }
    public virtual void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }
}
