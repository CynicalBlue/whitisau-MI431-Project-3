using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [SerializeField] public string pieceName = "";

    public void PlaceUnit()
    {
        Debug.Log("Pressed");
    }
}
