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
                SpawnNewPiece(i, j, PieceType.Empty);
            }
        }

    }
    public Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(transform.position.x - xDim / 2.0f + x, transform.position.y + yDim / 2.0f - y);
    }

    public GamePiece SpawnNewPiece(int x, int y, PieceType type)
    {
        GameObject newPiece = Instantiate(PiecePrefabDict[type], GetWorldPosition(x, y), Quaternion.identity, transform);
        pieces[x, y] = newPiece.GetComponent<GamePiece>();
        pieces[x,y].Init(x, y, this, type);
        return pieces[x, y];
    }

    public void Fill()
    {

    }
    public bool FillStep()
    {
        bool movedPiece = false;
        for (int y = yDim-2; y >=0; y--)
        {
            for (int x = 0; x < xDim; x++)
            {
                GamePiece piece = pieces[x, y];
                if (piece.IsMovable())
                {
                    GamePiece pieceBelow = pieces[x, y+1];
                    if(pieceBelow.Type == PieceType.Empty)
                    {
                        piece.MovableComponent.Move(x, y+1);
                        pieces[x, y + 1] = piece;
                        SpawnNewPiece(x, y, PieceType.Empty);
                        movedPiece = true;
                    }
                }
            }
        }
        return movedPiece;

    }
}
