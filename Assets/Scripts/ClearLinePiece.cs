using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLinePiece : ClearablePiece
{
    public bool isRow;
    public override void Clear()
    {
        base.Clear();
        if (isRow)
        {
            piece.GridRef.ClearRow(piece.Y);
        }
        else
        {
            piece.GridRef.CleanColumn(piece.X);
        }
    }
}
