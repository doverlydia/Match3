using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearColorPiece : ClearablePiece
{
    ColorType color;
    public ColorType Color
    {
        get => color;
        set => color = value;
    }
    public override void Clear()
    {
        base.Clear();
        piece.GridRef.ClearColor(color);
    }
}
