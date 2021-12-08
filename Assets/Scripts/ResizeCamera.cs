using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeCamera : MonoBehaviour
{
    [SerializeField] Grid grid;
    float widthToBeSeen;
    void Awake()
    {
        Debug.Log(Camera.main.orthographicSize);
        widthToBeSeen = grid.backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x * grid.xDim * 1.5f;
        Camera.main.orthographicSize = (widthToBeSeen * Screen.height / Screen.width * 0.5f);
        Debug.Log(Camera.main.orthographicSize);
    }
}
