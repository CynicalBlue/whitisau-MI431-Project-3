using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class Yes : MonoBehaviour
{
    private void OnMouseDown()
    {
        GridManager gridManagerTempReference = GameObject.Find("TiebreakerMain").GetComponent<GridManager>();
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player1PawnReference)
        {
            gridManagerTempReference.PromotePiece("player1Pawn");
        }
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player1SilverReference)
        {
            gridManagerTempReference.PromotePiece("player1Silver");
        }
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player1BishopReference)
        {
            gridManagerTempReference.PromotePiece("player1Bishop");
        }
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player1RookReference)
        {
            gridManagerTempReference.PromotePiece("player1Rook");
        }
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player2PawnReference)
        {
            gridManagerTempReference.PromotePiece("player2Pawn");
        }
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player2SilverReference)
        {
            gridManagerTempReference.PromotePiece("player2Silver");
        }
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player2BishopReference)
        {
            gridManagerTempReference.PromotePiece("player2Bishop");
        }
        if (gridManagerTempReference.previousPieceSelected == gridManagerTempReference.player2RookReference)
        {
            gridManagerTempReference.PromotePiece("player2Rook");
        }
    }
}
