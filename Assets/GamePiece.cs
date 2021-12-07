using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    private int x;
    private int y;
    public int X
    {
        get { return x; }
        set { if (IsMovable()) x = value; }
    }
    public int Y
    {
        get { return y; }
        set { if (IsMovable()) y = value; }
    }
    private MovablePiece movableComponent;
    public MovablePiece MovableComponent => movableComponent;
    private PieceType type;
    public PieceType Type => type;
    private Grid grid;
    public Grid GridRef => grid;
    private void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
    }
    public void Init(int _x, int _y, Grid _grid, PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }
    public bool IsMovable()
    {
        return movableComponent != null;
    }
}
