using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ColorType
{
    Yellow,
    Purple,
    Red,
    Blue,
    Green,
    Orange,
    Any,
    Count
};
[System.Serializable]
public struct ColorSprite
{
    public ColorType color;
    public Sprite sprite;
};
public class ColorPiece : MonoBehaviour
{
    public ColorSprite[] colorSprites;

    private ColorType color;
    public ColorType Color
    {
        get { return color; }
        set { SetColor(value); }
    }
    public int NumColors
    {
        get { return colorSprites.Length; }
    }
    private SpriteRenderer sprite;
    private Dictionary<ColorType, Sprite> colorSpritesDict;
    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        colorSpritesDict = new Dictionary<ColorType, Sprite>();
        foreach (var sprite in colorSprites)
        {
            if (!colorSpritesDict.ContainsKey(sprite.color))
            {
                colorSpritesDict.Add(sprite.color, sprite.sprite);
            }
        }
    }
    public void SetColor(ColorType newColor)
    {
        color = newColor;
        if (colorSpritesDict.ContainsKey(newColor))
        {
            sprite.sprite = colorSpritesDict[newColor];
        }
    }
}
