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
    Pink,
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
    public ColorSprite colorSprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
