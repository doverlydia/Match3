using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePiece : MonoBehaviour
{
    private GamePiece piece;
    private IEnumerator moveCorutine;
    private void Awake()
    {
        piece = GetComponent<GamePiece>();
    }
    public void Move(int newX, int newY, float time)
    {
        if (moveCorutine != null)
        {
            StopCoroutine(moveCorutine);
        }

        moveCorutine = MoveCoroutine(newX, newY, time);
        StartCoroutine(moveCorutine);
    }

    IEnumerator MoveCoroutine(int newX, int newY, float time)
    {
        piece.X = newX;
        piece.Y = newY;

        Vector2 startPos = transform.position;
        Vector2 endPos = piece.GridRef.GetWorldPosition(newX, newY);

        for (float t = 0; t <= 1*time; t+=Time.deltaTime)
        {
            piece.transform.position = Vector2.Lerp(startPos, endPos, t / time);
            yield return null;
        }
        piece.transform.position = endPos;
    }
}
