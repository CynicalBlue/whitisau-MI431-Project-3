using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] public GameObject _selection;

    public GridManager gridManagerReference;
    public GameObject currentPieceUnder;
    public bool hasPlayer1Piece = false;
    public bool hasPlayer2Piece = false;
    public bool cutOffPath1 = false;
    public bool cutOffPath2 = false;
    public bool cutOffPath3 = false;
    public bool cutOffPath4 = false;

    public bool isOffBoard = false;
    public bool isPawn1VerticalPath = false;
    public bool isPawn2VerticalPath = false;

    private void Start()
    {
        gridManagerReference = GameObject.Find("TiebreakerMain").GetComponent<GridManager>();
    }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor; // If the tile is offset, set the color to the offset color, else set it to the base color
    }

    void OnMouseEnter()
    {
        if (_selection.activeSelf != true)
        {
            _highlight.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        cutOffPath1 = false;
        cutOffPath2 = false;
        cutOffPath3 = false;
        cutOffPath4 = false;
        if (isOffBoard && (hasPlayer1Piece || hasPlayer2Piece))
        {
            gridManagerReference.currentPieceSelected = currentPieceUnder;
            if (currentPieceUnder != gridManagerReference.player2PawnReference)
            {
                foreach (var tileReference in gridManagerReference._tiles)
                {
                    if (!tileReference.Value.hasPlayer1Piece && !tileReference.Value.hasPlayer2Piece && !tileReference.Value.isOffBoard)
                    {
                        tileReference.Value._selection.SetActive(true);
                    }
                }
            }
            else
            {
                foreach (var tileReference in gridManagerReference._tiles)
                {
                    if (!tileReference.Value.hasPlayer1Piece && !tileReference.Value.hasPlayer2Piece && !tileReference.Value.isOffBoard && !tileReference.Value.isPawn1VerticalPath && !tileReference.Value.isPawn2VerticalPath)
                    {
                        tileReference.Value._selection.SetActive(true);
                    }
                }
            }
        }
        if (_selection.activeSelf == true)
        {
            if (hasPlayer2Piece && (gridManagerReference.currentPieceSelected == gridManagerReference.player1PawnReference || gridManagerReference.currentPieceSelected == gridManagerReference.player1KingReference
                || gridManagerReference.currentPieceSelected == gridManagerReference.player1GoldReference || gridManagerReference.currentPieceSelected == gridManagerReference.player1SilverReference
                || gridManagerReference.currentPieceSelected == gridManagerReference.player1BishopReference || gridManagerReference.currentPieceSelected == gridManagerReference.player1RookReference)){
                gridManagerReference.currentPieceSelected.transform.position = currentPieceUnder.transform.position;
                if (currentPieceUnder == gridManagerReference.player2PawnReference)
                {
                    currentPieceUnder.transform.position = new Vector2(6, 0);
                    currentPieceUnder.transform.localScale = new Vector3(currentPieceUnder.transform.localScale.x, currentPieceUnder.transform.localScale.y * -1, currentPieceUnder.transform.localScale.z);
                }
                if (currentPieceUnder == gridManagerReference.player2SilverReference)
                {
                    currentPieceUnder.transform.position = new Vector2(7, 0);
                    currentPieceUnder.transform.localScale = new Vector3(currentPieceUnder.transform.localScale.x, currentPieceUnder.transform.localScale.y * -1, currentPieceUnder.transform.localScale.z);
                }
                if (currentPieceUnder == gridManagerReference.player2GoldReference)
                {
                    currentPieceUnder.transform.position = new Vector2(8, 0);
                    currentPieceUnder.transform.localScale = new Vector3(currentPieceUnder.transform.localScale.x, currentPieceUnder.transform.localScale.y * -1, currentPieceUnder.transform.localScale.z);
                }
                if (currentPieceUnder == gridManagerReference.player2BishopReference)
                {
                    currentPieceUnder.transform.position = new Vector2(9, 0);
                    currentPieceUnder.transform.localScale = new Vector3(currentPieceUnder.transform.localScale.x, currentPieceUnder.transform.localScale.y * -1, currentPieceUnder.transform.localScale.z);
                }
                if (currentPieceUnder == gridManagerReference.player2RookReference)
                {
                    currentPieceUnder.transform.position = new Vector2(10, 0);
                    currentPieceUnder.transform.localScale = new Vector3(currentPieceUnder.transform.localScale.x, currentPieceUnder.transform.localScale.y * -1, currentPieceUnder.transform.localScale.z);
                }
                gridManagerReference.UpdatePiecePositions();
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1PawnReference && (gridManagerReference.player1PawnPosition == new Vector2(0, 4) || gridManagerReference.player1PawnPosition == new Vector2(1, 4)
                    || gridManagerReference.player1PawnPosition == new Vector2(2, 4) || gridManagerReference.player1PawnPosition == new Vector2(3, 4) || gridManagerReference.player1PawnPosition == new Vector2(4, 4)) &&
                    !gridManagerReference.player1PawnPromoted)
                {
                    gridManagerReference.promoteQuestion.SetActive(true);
                    gridManagerReference.yesOption.SetActive(true);
                    gridManagerReference.noOption.SetActive(true);
                }
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1SilverReference && (gridManagerReference.player1SilverPosition == new Vector2(0, 4) || gridManagerReference.player1SilverPosition == new Vector2(1, 4)
                    || gridManagerReference.player1SilverPosition == new Vector2(2, 4) || gridManagerReference.player1SilverPosition == new Vector2(3, 4) || gridManagerReference.player1SilverPosition == new Vector2(4, 4)) &&
                    !gridManagerReference.player1SilverPromoted)
                {
                    gridManagerReference.promoteQuestion.SetActive(true);
                    gridManagerReference.yesOption.SetActive(true);
                    gridManagerReference.noOption.SetActive(true);
                }
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1BishopReference && (gridManagerReference.player1BishopPosition == new Vector2(0, 4) || gridManagerReference.player1BishopPosition == new Vector2(1, 4)
                    || gridManagerReference.player1BishopPosition == new Vector2(2, 4) || gridManagerReference.player1BishopPosition == new Vector2(3, 4) || gridManagerReference.player1BishopPosition == new Vector2(4, 4)) &&
                    !gridManagerReference.player1BishopPromoted)
                {
                    gridManagerReference.promoteQuestion.SetActive(true);
                    gridManagerReference.yesOption.SetActive(true);
                    gridManagerReference.noOption.SetActive(true);
                }
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1RookReference && (gridManagerReference.player1RookPosition == new Vector2(0, 4) || gridManagerReference.player1RookPosition == new Vector2(1, 4)
                    || gridManagerReference.player1RookPosition == new Vector2(2, 4) || gridManagerReference.player1RookPosition == new Vector2(3, 4) || gridManagerReference.player1RookPosition == new Vector2(4, 4)) &&
                    !gridManagerReference.player1RookPromoted)
                {
                    gridManagerReference.promoteQuestion.SetActive(true);
                    gridManagerReference.yesOption.SetActive(true);
                    gridManagerReference.noOption.SetActive(true);
                }
                return;
            }
            else
            {
                gridManagerReference.currentPieceSelected.transform.position = gameObject.transform.position;
                gridManagerReference.UpdatePiecePositions();
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1PawnReference && (gridManagerReference.player1PawnPosition == new Vector2(0, 4) || gridManagerReference.player1PawnPosition == new Vector2(1, 4)
                    || gridManagerReference.player1PawnPosition == new Vector2(2, 4) || gridManagerReference.player1PawnPosition == new Vector2(3, 4) || gridManagerReference.player1PawnPosition == new Vector2(4, 4)))
                {
                    gridManagerReference.PromotePiece("player1Pawn");
                }
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1SilverReference && (gridManagerReference.player1SilverPosition == new Vector2(0, 4) || gridManagerReference.player1SilverPosition == new Vector2(1, 4)
                    || gridManagerReference.player1SilverPosition == new Vector2(2, 4) || gridManagerReference.player1SilverPosition == new Vector2(3, 4) || gridManagerReference.player1SilverPosition == new Vector2(4, 4)))
                {
                    gridManagerReference.PromotePiece("player1Silver");
                }
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1BishopReference && (gridManagerReference.player1BishopPosition == new Vector2(0, 4) || gridManagerReference.player1BishopPosition == new Vector2(1, 4)
                    || gridManagerReference.player1BishopPosition == new Vector2(2, 4) || gridManagerReference.player1BishopPosition == new Vector2(3, 4) || gridManagerReference.player1BishopPosition == new Vector2(4, 4)))
                {
                    gridManagerReference.PromotePiece("player1Bishop");
                }
                if (gridManagerReference.currentPieceSelected == gridManagerReference.player1RookReference && (gridManagerReference.player1RookPosition == new Vector2(0, 4) || gridManagerReference.player1RookPosition == new Vector2(1, 4)
                    || gridManagerReference.player1RookPosition == new Vector2(2, 4) || gridManagerReference.player1RookPosition == new Vector2(3, 4) || gridManagerReference.player1RookPosition == new Vector2(4, 4)))
                {
                    gridManagerReference.PromotePiece("player1Rook");
                }
                return;
            }
        }
        if (currentPieceUnder == gridManagerReference.player1PawnReference)
        {
            gridManagerReference.currentPieceSelected = gridManagerReference.player1PawnReference;
            if (!gridManagerReference.player1PawnPromoted)
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
                if (tempTile != null && !tempTile.hasPlayer1Piece)
                {
                    tempTile._selection.SetActive(true);
                }
            }
            else
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
                if (tempTile != null && !tempTile.hasPlayer1Piece)
                {
                    tempTile._selection.SetActive(true);
                }
                Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1));
                if (tempTile2 != null && !tempTile2.hasPlayer1Piece)
                {
                    tempTile2._selection.SetActive(true);
                }
                Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1));
                if (tempTile3 != null && !tempTile3.hasPlayer1Piece)
                {
                    tempTile3._selection.SetActive(true);
                }
                Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y));
                if (tempTile4 != null && !tempTile4.hasPlayer1Piece)
                {
                    tempTile4._selection.SetActive(true);
                }
                Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y));
                if (tempTile5 != null && !tempTile5.hasPlayer1Piece)
                {
                    tempTile5._selection.SetActive(true);
                }
                Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1));
                if (tempTile6 != null && !tempTile6.hasPlayer1Piece)
                {
                    tempTile6._selection.SetActive(true);
                }
            }
        }
        if (currentPieceUnder == gridManagerReference.player1KingReference)
        {
            gridManagerReference.currentPieceSelected = gridManagerReference.player1KingReference;
            Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
            if (tempTile != null && !tempTile.hasPlayer1Piece)
            {
                tempTile._selection.SetActive(true);
            }
            Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1));
            if (tempTile2 != null && !tempTile2.hasPlayer1Piece)
            {
                tempTile2._selection.SetActive(true);
            }
            Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1));
            if (tempTile3 != null && !tempTile3.hasPlayer1Piece)
            {
                tempTile3._selection.SetActive(true);
            }
            Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y));
            if (tempTile4 != null && !tempTile4.hasPlayer1Piece)
            {
                tempTile4._selection.SetActive(true);
            }
            Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y));
            if (tempTile5 != null && !tempTile5.hasPlayer1Piece)
            {
                tempTile5._selection.SetActive(true);
            }
            Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1));
            if (tempTile6 != null && !tempTile6.hasPlayer1Piece)
            {
                tempTile6._selection.SetActive(true);
            }
            Tile tempTile7 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 1));
            if (tempTile7 != null && !tempTile7.hasPlayer1Piece)
            {
                tempTile7._selection.SetActive(true);
            }
            Tile tempTile8 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1));
            if (tempTile8 != null && !tempTile8.hasPlayer1Piece)
            {
                tempTile8._selection.SetActive(true);
            }
        }
        if (currentPieceUnder == gridManagerReference.player1GoldReference)
        {
            gridManagerReference.currentPieceSelected = gridManagerReference.player1GoldReference;
            Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
            if (tempTile != null && !tempTile.hasPlayer1Piece)
            {
                tempTile._selection.SetActive(true);
            }
            Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x+1, gameObject.transform.position.y + 1));
            if (tempTile2 != null && !tempTile2.hasPlayer1Piece)
            {
                tempTile2._selection.SetActive(true);
            }
            Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x-1, gameObject.transform.position.y + 1));
            if (tempTile3 != null && !tempTile3.hasPlayer1Piece)
            {
                tempTile3._selection.SetActive(true);
            }
            Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x+1, gameObject.transform.position.y));
            if (tempTile4 != null && !tempTile4.hasPlayer1Piece)
            {
                tempTile4._selection.SetActive(true);
            }
            Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x-1, gameObject.transform.position.y));
            if (tempTile5 != null && !tempTile5.hasPlayer1Piece)
            {
                tempTile5._selection.SetActive(true);
            }
            Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1));
            if (tempTile6 != null && !tempTile6.hasPlayer1Piece)
            {
                tempTile6._selection.SetActive(true);
            }
        }
        if (currentPieceUnder == gridManagerReference.player1SilverReference)
        {
            gridManagerReference.currentPieceSelected = gridManagerReference.player1SilverReference;
            if (!gridManagerReference.player1SilverPromoted)
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
                if (tempTile != null && !tempTile.hasPlayer1Piece)
                {
                    tempTile._selection.SetActive(true);
                }
                Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1));
                if (tempTile2 != null && !tempTile2.hasPlayer1Piece)
                {
                    tempTile2._selection.SetActive(true);
                }
                Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1));
                if (tempTile3 != null && !tempTile3.hasPlayer1Piece)
                {
                    tempTile3._selection.SetActive(true);
                }
                Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1));
                if (tempTile4 != null && !tempTile4.hasPlayer1Piece)
                {
                    tempTile4._selection.SetActive(true);
                }
                Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 1));
                if (tempTile5 != null && !tempTile5.hasPlayer1Piece)
                {
                    tempTile5._selection.SetActive(true);
                }
            }
            else
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
                if (tempTile != null && !tempTile.hasPlayer1Piece)
                {
                    tempTile._selection.SetActive(true);
                }
                Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1));
                if (tempTile2 != null && !tempTile2.hasPlayer1Piece)
                {
                    tempTile2._selection.SetActive(true);
                }
                Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1));
                if (tempTile3 != null && !tempTile3.hasPlayer1Piece)
                {
                    tempTile3._selection.SetActive(true);
                }
                Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y));
                if (tempTile4 != null && !tempTile4.hasPlayer1Piece)
                {
                    tempTile4._selection.SetActive(true);
                }
                Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y));
                if (tempTile5 != null && !tempTile5.hasPlayer1Piece)
                {
                    tempTile5._selection.SetActive(true);
                }
                Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1));
                if (tempTile6 != null && !tempTile6.hasPlayer1Piece)
                {
                    tempTile6._selection.SetActive(true);
                }
            }
        }
        if (currentPieceUnder == gridManagerReference.player1BishopReference)
        {
            gridManagerReference.currentPieceSelected = gridManagerReference.player1BishopReference;
            if (!gridManagerReference.player1BishopPromoted)
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1));
                if (tempTile != null && !tempTile.hasPlayer1Piece && !tempTile.isOffBoard)
                {
                    tempTile._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile != null && tempTile.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y + 2));
                if (tempTile2 != null && !tempTile2.hasPlayer1Piece && !cutOffPath1 && !tempTile2.isOffBoard)
                {
                    tempTile2._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile2 != null && tempTile2.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 3, gameObject.transform.position.y + 3));
                if (tempTile3 != null && !tempTile3.hasPlayer1Piece && !cutOffPath1 && !tempTile3.isOffBoard)
                {
                    tempTile3._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile3 != null && tempTile3.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 4, gameObject.transform.position.y + 4));
                if (tempTile4 != null && !tempTile4.hasPlayer1Piece && !cutOffPath1 && !tempTile4.isOffBoard)
                {
                    tempTile4._selection.SetActive(true);
                }
                Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 1));
                if (tempTile5 != null && !tempTile5.hasPlayer1Piece && !tempTile5.isOffBoard)
                {
                    tempTile5._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile5 != null && tempTile5.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y - 2));
                if (tempTile6 != null && !tempTile6.hasPlayer1Piece && !cutOffPath2 && !tempTile6.isOffBoard)
                {
                    tempTile6._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile6 != null && tempTile6.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile7 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 3, gameObject.transform.position.y - 3));
                if (tempTile7 != null && !tempTile7.hasPlayer1Piece && !cutOffPath2 && !tempTile7.isOffBoard)
                {
                    tempTile7._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile7 != null && tempTile7.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile8 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 4, gameObject.transform.position.y - 4));
                if (tempTile8 != null && !tempTile8.hasPlayer1Piece && !cutOffPath2 && !tempTile8.isOffBoard)
                {
                    tempTile8._selection.SetActive(true);
                }
                Tile tempTile9 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1));
                if (tempTile9 != null && !tempTile9.hasPlayer1Piece && !tempTile9.isOffBoard)
                {
                    tempTile9._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile9 != null && tempTile9.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile10 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y + 2));
                if (tempTile10 != null && !tempTile10.hasPlayer1Piece && !cutOffPath3 && !tempTile10.isOffBoard)
                {
                    tempTile10._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile10 != null && tempTile10.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile11 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y + 3));
                if (tempTile11 != null && !tempTile11.hasPlayer1Piece && !cutOffPath3 && !tempTile11.isOffBoard)
                {
                    tempTile11._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile11 != null && tempTile11.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile12 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 4, gameObject.transform.position.y + 4));
                if (tempTile12 != null && !tempTile12.hasPlayer1Piece && !cutOffPath3 && !tempTile12.isOffBoard)
                {
                    tempTile12._selection.SetActive(true);
                }
                Tile tempTile13 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1));
                if (tempTile13 != null && !tempTile13.hasPlayer1Piece && !tempTile13.isOffBoard)
                {
                    tempTile13._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile13 != null && tempTile13.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile14 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y - 2));
                if (tempTile14 != null && !tempTile14.hasPlayer1Piece && !cutOffPath4 && !tempTile14.isOffBoard)
                {
                    tempTile14._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile14 != null && tempTile14.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile15 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y - 3));
                if (tempTile15 != null && !tempTile15.hasPlayer1Piece && !cutOffPath4 && !tempTile15.isOffBoard)
                {
                    tempTile15._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile15 != null && tempTile15.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile16 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 4, gameObject.transform.position.y - 4));
                if (tempTile16 != null && !tempTile16.hasPlayer1Piece && !cutOffPath4 && !tempTile16.isOffBoard)
                {
                    tempTile16._selection.SetActive(true);
                }
            }
            else
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1));
                if (tempTile != null && !tempTile.hasPlayer1Piece && !tempTile.isOffBoard)
                {
                    tempTile._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile != null && tempTile.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y + 2));
                if (tempTile2 != null && !tempTile2.hasPlayer1Piece && !cutOffPath1 && !tempTile2.isOffBoard)
                {
                    tempTile2._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile2 != null && tempTile2.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 3, gameObject.transform.position.y + 3));
                if (tempTile3 != null && !tempTile3.hasPlayer1Piece && !cutOffPath1 && !tempTile3.isOffBoard)
                {
                    tempTile3._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile3 != null && tempTile3.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 4, gameObject.transform.position.y + 4));
                if (tempTile4 != null && !tempTile4.hasPlayer1Piece && !cutOffPath1 && !tempTile4.isOffBoard)
                {
                    tempTile4._selection.SetActive(true);
                }
                Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 1));
                if (tempTile5 != null && !tempTile5.hasPlayer1Piece && !tempTile5.isOffBoard)
                {
                    tempTile5._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile5 != null && tempTile5.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y - 2));
                if (tempTile6 != null && !tempTile6.hasPlayer1Piece && !cutOffPath2 && !tempTile6.isOffBoard)
                {
                    tempTile6._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile6 != null && tempTile6.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile7 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 3, gameObject.transform.position.y - 3));
                if (tempTile7 != null && !tempTile7.hasPlayer1Piece && !cutOffPath2 && !tempTile7.isOffBoard)
                {
                    tempTile7._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile7 != null && tempTile7.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile8 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 4, gameObject.transform.position.y - 4));
                if (tempTile8 != null && !tempTile8.hasPlayer1Piece && !cutOffPath2 && !tempTile8.isOffBoard)
                {
                    tempTile8._selection.SetActive(true);
                }
                Tile tempTile9 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1));
                if (tempTile9 != null && !tempTile9.hasPlayer1Piece && !tempTile9.isOffBoard)
                {
                    tempTile9._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile9 != null && tempTile9.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile10 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y + 2));
                if (tempTile10 != null && !tempTile10.hasPlayer1Piece && !cutOffPath3 && !tempTile10.isOffBoard)
                {
                    tempTile10._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile10 != null && tempTile10.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile11 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y + 3));
                if (tempTile11 != null && !tempTile11.hasPlayer1Piece && !cutOffPath3 && !tempTile11.isOffBoard)
                {
                    tempTile11._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile11 != null && tempTile11.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile12 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 4, gameObject.transform.position.y + 4));
                if (tempTile12 != null && !tempTile12.hasPlayer1Piece && !cutOffPath3 && !tempTile12.isOffBoard)
                {
                    tempTile12._selection.SetActive(true);
                }
                Tile tempTile13 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1));
                if (tempTile13 != null && !tempTile13.hasPlayer1Piece && !tempTile13.isOffBoard)
                {
                    tempTile13._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile13 != null && tempTile13.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile14 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y - 2));
                if (tempTile14 != null && !tempTile14.hasPlayer1Piece && !cutOffPath4 && !tempTile14.isOffBoard)
                {
                    tempTile14._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile14 != null && tempTile14.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile15 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y - 3));
                if (tempTile15 != null && !tempTile15.hasPlayer1Piece && !cutOffPath4 && !tempTile15.isOffBoard)
                {
                    tempTile15._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile15 != null && tempTile15.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile16 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 4, gameObject.transform.position.y - 4));
                if (tempTile16 != null && !tempTile16.hasPlayer1Piece && !cutOffPath4 && !tempTile16.isOffBoard)
                {
                    tempTile16._selection.SetActive(true);
                }
                Tile tempTile17 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
                if (tempTile17 != null && !tempTile17.hasPlayer1Piece)
                {
                    tempTile17._selection.SetActive(true);
                }
                Tile tempTile18 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y));
                if (tempTile18 != null && !tempTile18.hasPlayer1Piece)
                {
                    tempTile18._selection.SetActive(true);
                }
                Tile tempTile19 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y));
                if (tempTile19 != null && !tempTile19.hasPlayer1Piece)
                {
                    tempTile19._selection.SetActive(true);
                }
                Tile tempTile20 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1));
                if (tempTile20 != null && !tempTile20.hasPlayer1Piece)
                {
                    tempTile20._selection.SetActive(true);
                }
            }
        }
        if (currentPieceUnder == gridManagerReference.player1RookReference)
        {
            gridManagerReference.currentPieceSelected = gridManagerReference.player1RookReference;
            if (!gridManagerReference.player1RookPromoted)
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y));
                if (tempTile != null && !tempTile.hasPlayer1Piece && !tempTile.isOffBoard)
                {
                    tempTile._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile != null && tempTile.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y));
                if (tempTile2 != null && !tempTile2.hasPlayer1Piece && !cutOffPath1 && !tempTile2.isOffBoard)
                {
                    tempTile2._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile2 != null && tempTile2.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 3, gameObject.transform.position.y));
                if (tempTile3 != null && !tempTile3.hasPlayer1Piece && !cutOffPath1 && !tempTile3.isOffBoard)
                {
                    tempTile3._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile3 != null && tempTile3.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 4, gameObject.transform.position.y));
                if (tempTile4 != null && !tempTile4.hasPlayer1Piece && !cutOffPath1 && !tempTile4.isOffBoard)
                {
                    tempTile4._selection.SetActive(true);
                }
                Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y));
                if (tempTile5 != null && !tempTile5.hasPlayer1Piece && !tempTile5.isOffBoard)
                {
                    tempTile5._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile5 != null && tempTile5.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y));
                if (tempTile6 != null && !tempTile6.hasPlayer1Piece && !cutOffPath2 && !tempTile6.isOffBoard)
                {
                    tempTile6._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile6 != null && tempTile6.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile7 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y));
                if (tempTile7 != null && !tempTile7.hasPlayer1Piece && !cutOffPath2 && !tempTile7.isOffBoard)
                {
                    tempTile7._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile7 != null && tempTile7.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile8 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 4, gameObject.transform.position.y));
                if (tempTile8 != null && !tempTile8.hasPlayer1Piece && !cutOffPath2 && !tempTile8.isOffBoard)
                {
                    tempTile8._selection.SetActive(true);
                }
                Tile tempTile9 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
                if (tempTile9 != null && !tempTile9.hasPlayer1Piece && !tempTile9.isOffBoard)
                {
                    tempTile9._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile9 != null && tempTile9.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile10 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2));
                if (tempTile10 != null && !tempTile10.hasPlayer1Piece && !cutOffPath3 && !tempTile10.isOffBoard)
                {
                    tempTile10._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile10 != null && tempTile10.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile11 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 3));
                if (tempTile11 != null && !tempTile11.hasPlayer1Piece && !cutOffPath3 && !tempTile11.isOffBoard)
                {
                    tempTile11._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile11 != null && tempTile11.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile12 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 4));
                if (tempTile12 != null && !tempTile12.hasPlayer1Piece && !cutOffPath3 && !tempTile12.isOffBoard)
                {
                    tempTile12._selection.SetActive(true);
                }
                Tile tempTile13 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1));
                if (tempTile13 != null && !tempTile13.hasPlayer1Piece && !tempTile13.isOffBoard)
                {
                    tempTile13._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile13 != null && tempTile13.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile14 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2));
                if (tempTile14 != null && !tempTile14.hasPlayer1Piece && !cutOffPath4 && !tempTile14.isOffBoard)
                {
                    tempTile14._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile14 != null && tempTile14.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile15 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 3));
                if (tempTile15 != null && !tempTile15.hasPlayer1Piece && !cutOffPath4 && !tempTile15.isOffBoard)
                {
                    tempTile15._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile15 != null && tempTile15.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile16 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 4));
                if (tempTile16 != null && !tempTile16.hasPlayer1Piece && !cutOffPath4 && !tempTile16.isOffBoard)
                {
                    tempTile16._selection.SetActive(true);
                }
            }
            else
            {
                Tile tempTile = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y));
                if (tempTile != null && !tempTile.hasPlayer1Piece && !tempTile.isOffBoard)
                {
                    tempTile._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile != null && tempTile.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile2 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 2, gameObject.transform.position.y));
                if (tempTile2 != null && !tempTile2.hasPlayer1Piece && !cutOffPath1 && !tempTile2.isOffBoard)
                {
                    tempTile2._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile2 != null && tempTile2.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile3 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 3, gameObject.transform.position.y));
                if (tempTile3 != null && !tempTile3.hasPlayer1Piece && !cutOffPath1 && !tempTile3.isOffBoard)
                {
                    tempTile3._selection.SetActive(true);
                }
                else
                {
                    cutOffPath1 = true;
                }
                if (tempTile3 != null && tempTile3.hasPlayer2Piece)
                {
                    cutOffPath1 = true;
                }
                Tile tempTile4 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 4, gameObject.transform.position.y));
                if (tempTile4 != null && !tempTile4.hasPlayer1Piece && !cutOffPath1 && !tempTile4.isOffBoard)
                {
                    tempTile4._selection.SetActive(true);
                }
                Tile tempTile5 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y));
                if (tempTile5 != null && !tempTile5.hasPlayer1Piece && !tempTile5.isOffBoard)
                {
                    tempTile5._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile5 != null && tempTile5.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile6 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 2, gameObject.transform.position.y));
                if (tempTile6 != null && !tempTile6.hasPlayer1Piece && !cutOffPath2 && !tempTile6.isOffBoard)
                {
                    tempTile6._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile6 != null && tempTile6.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile7 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 3, gameObject.transform.position.y));
                if (tempTile7 != null && !tempTile7.hasPlayer1Piece && !cutOffPath2 && !tempTile7.isOffBoard)
                {
                    tempTile7._selection.SetActive(true);
                }
                else
                {
                    cutOffPath2 = true;
                }
                if (tempTile7 != null && tempTile7.hasPlayer2Piece)
                {
                    cutOffPath2 = true;
                }
                Tile tempTile8 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 4, gameObject.transform.position.y));
                if (tempTile8 != null && !tempTile8.hasPlayer1Piece && !cutOffPath2 && !tempTile8.isOffBoard)
                {
                    tempTile8._selection.SetActive(true);
                }
                Tile tempTile9 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1));
                if (tempTile9 != null && !tempTile9.hasPlayer1Piece && !tempTile9.isOffBoard)
                {
                    tempTile9._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile9 != null && tempTile9.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile10 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2));
                if (tempTile10 != null && !tempTile10.hasPlayer1Piece && !cutOffPath3 && !tempTile10.isOffBoard)
                {
                    tempTile10._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile10 != null && tempTile10.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile11 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 3));
                if (tempTile11 != null && !tempTile11.hasPlayer1Piece && !cutOffPath3 && !tempTile11.isOffBoard)
                {
                    tempTile11._selection.SetActive(true);
                }
                else
                {
                    cutOffPath3 = true;
                }
                if (tempTile11 != null && tempTile11.hasPlayer2Piece)
                {
                    cutOffPath3 = true;
                }
                Tile tempTile12 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 4));
                if (tempTile12 != null && !tempTile12.hasPlayer1Piece && !cutOffPath3 && !tempTile12.isOffBoard)
                {
                    tempTile12._selection.SetActive(true);
                }
                Tile tempTile13 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1));
                if (tempTile13 != null && !tempTile13.hasPlayer1Piece && !tempTile13.isOffBoard)
                {
                    tempTile13._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile13 != null && tempTile13.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile14 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2));
                if (tempTile14 != null && !tempTile14.hasPlayer1Piece && !cutOffPath4 && !tempTile14.isOffBoard)
                {
                    tempTile14._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile14 != null && tempTile14.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile15 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 3));
                if (tempTile15 != null && !tempTile15.hasPlayer1Piece && !cutOffPath4 && !tempTile15.isOffBoard)
                {
                    tempTile15._selection.SetActive(true);
                }
                else
                {
                    cutOffPath4 = true;
                }
                if (tempTile15 != null && tempTile15.hasPlayer2Piece)
                {
                    cutOffPath4 = true;
                }
                Tile tempTile16 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 4));
                if (tempTile16 != null && !tempTile16.hasPlayer1Piece && !cutOffPath4 && !tempTile16.isOffBoard)
                {
                    tempTile16._selection.SetActive(true);
                }
                Tile tempTile17 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y + 1));
                if (tempTile17 != null && !tempTile17.hasPlayer1Piece)
                {
                    tempTile17._selection.SetActive(true);
                }
                Tile tempTile18 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y + 1));
                if (tempTile18 != null && !tempTile18.hasPlayer1Piece)
                {
                    tempTile18._selection.SetActive(true);
                }
                Tile tempTile19 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x + 1, gameObject.transform.position.y - 1));
                if (tempTile19 != null && !tempTile19.hasPlayer1Piece)
                {
                    tempTile19._selection.SetActive(true);
                }
                Tile tempTile20 = gridManagerReference.GetTileAtPosition(new Vector2(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1));
                if (tempTile20 != null && !tempTile20.hasPlayer1Piece)
                {
                    tempTile20._selection.SetActive(true);
                }
            }
        }
    }

    public void UpdateCurrentPieceUnder(GameObject piece)
    {
        currentPieceUnder = piece;
    }
}
