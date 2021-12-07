using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PieceType
{
    Empty,
    Normal,
    Count
};
[System.Serializable]
public struct PiecePrefab
{
    public PieceType Type;
    public GameObject prefab;
};
public class Grid : MonoBehaviour
{
    public int xDim;
    public int yDim;
    public PiecePrefab[] piecePrefabs;
    public GameObject backgroundPrefab;
    private Dictionary<PieceType, GameObject> PiecePrefabDict;
    private GamePiece[,] pieces;
    void Start()
    {
        PiecePrefabDict = new Dictionary<PieceType, GameObject>();
        foreach (var piece in piecePrefabs)
        {
            if (!PiecePrefabDict.ContainsKey(piece.Type))
            {
                PiecePrefabDict.Add(piece.Type, piece.prefab);
            }
        }
        for (int i = 0; i < xDim; i++)
        {
            for (int j = 0; j < yDim; j++)
            {
                GameObject background = Instantiate(backgroundPrefab, GetWorldPosition(i, j), Quaternion.identity, transform);
            }
        }
        pieces = new GamePiece[xDim, yDim];
        for (int i = 0; i < xDim; i++)
        {
            for (int j = 0; j < yDim; j++)
            {
                GameObject newPiece = Instantiate(PiecePrefabDict[PieceType.Normal], Vector2.zero, Quaternion.identity, transform);
                newPiece.name = $"Piece({i},{j})";
                
                pieces[i, j] = newPiece.GetComponent<GamePiece>();
                pieces[i, j].Init(i, j, this, PieceType.Normal);

                if (pieces[i, j].IsMovable())
                {
                    pieces[i,j].MovableComponent.Move(i, j);
                }
                if (pieces[i, j].IsColored())
                {
                    pieces[i, j].ColorComponent.SetColor((ColorType)Random.Range(0, pieces[i,j].ColorComponent.NumColors));
                }
            }
        }

    }
    public Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(transform.position.x - xDim / 2.0f + x, transform.position.y + yDim / 2.0f - y);
    }
}
