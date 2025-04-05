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
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player1PawnReference)
        {
            gridManagerTempReference.PromotePiece("player1Pawn");
        }
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player1SilverReference)
        {
            gridManagerTempReference.PromotePiece("player1Silver");
        }
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player1BishopReference)
        {
            gridManagerTempReference.PromotePiece("player1Bishop");
        }
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player1RookReference)
        {
            gridManagerTempReference.PromotePiece("player1Rook");
        }
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player2PawnReference)
        {
            gridManagerTempReference.PromotePiece("player2Pawn");
        }
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player2SilverReference)
        {
            gridManagerTempReference.PromotePiece("player2Silver");
        }
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player2BishopReference)
        {
            gridManagerTempReference.PromotePiece("player2Bishop");
        }
        if (gridManagerTempReference.currentPieceSelected == gridManagerTempReference.player2RookReference)
        {
            gridManagerTempReference.PromotePiece("player2Rook");
        }
    }
}
