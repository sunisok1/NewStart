using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridSingle : MonoBehaviour
{
    [SerializeField] private TextMeshPro TMP;

    public void UpdateInfomation(Vector3Int vector)
    {
        TMP.text = $"({vector.x},{vector.y})";
    }
}