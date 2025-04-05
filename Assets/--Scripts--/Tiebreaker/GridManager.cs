using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cam;

    public Dictionary<Vector2, Tile> _tiles;

    public GameObject player1Pawn;
    public GameObject player1Silver;
    public GameObject player1Gold;
    public GameObject player1Bishop;
    public GameObject player1Rook;
    public GameObject player1King;
    public GameObject player2Pawn;
    public GameObject player2Silver;
    public GameObject player2Gold;
    public GameObject player2Bishop;
    public GameObject player2Rook;
    public GameObject player2King;

    public GameObject player1PawnReference;
    public GameObject player1SilverReference;
    public GameObject player1GoldReference;
    public GameObject player1BishopReference;
    public GameObject player1RookReference;
    public GameObject player1KingReference;
    public GameObject player2PawnReference;
    public GameObject player2SilverReference;
    public GameObject player2GoldReference;
    public GameObject player2BishopReference;
    public GameObject player2RookReference;
    public GameObject player2KingReference;

    public Vector2 player1PawnPosition;
    public Vector2 player1SilverPosition;
    public Vector2 player1GoldPosition;
    public Vector2 player1BishopPosition;
    public Vector2 player1RookPosition;
    public Vector2 player1KingPosition;
    public Vector2 player2PawnPosition;
    public Vector2 player2SilverPosition;
    public Vector2 player2GoldPosition;
    public Vector2 player2BishopPosition;
    public Vector2 player2RookPosition;
    public Vector2 player2KingPosition;

    public bool player1PawnPromoted = false;
    public bool player1SilverPromoted = false;
    public bool player1BishopPromoted = false;
    public bool player1RookPromoted = false;
    public bool player2PawnPromoted = false;
    public bool player2SilverPromoted = false;
    public bool player2BishopPromoted = false;
    public bool player2RookPromoted = false;

    public Sprite player1PawnPromotedSprite;
    public Sprite player1SilverPromotedSprite;
    public Sprite player1BishopPromotedSprite;
    public Sprite player1RookPromotedSprite;
    public Sprite player2PawnPromotedSprite;
    public Sprite player2SilverPromotedSprite;
    public Sprite player2BishopPromotedSprite;
    public Sprite player2RookPromotedSprite;

    public GameObject currentPieceSelected;
    public GameObject promoteQuestion;
    public GameObject yesOption;
    public GameObject noOption;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0); // Determines if the tile is offset or not
                spawnedTile.Init(isOffset); // Activates the tile's Tile.cs script to check if the color should be changed if true or false


                _tiles[new Vector2(x, y)] = spawnedTile; // Add the spawned tile to the dictionary
            }
        }
        var spawnedTile1 = Instantiate(_tilePrefab, new Vector3(6, 0), Quaternion.identity);
        spawnedTile1.name = $"Tile {6} {0}";
        spawnedTile1.Init(false);
        spawnedTile1.isOffBoard = true;
        _tiles[new Vector2(6, 0)] = spawnedTile1;
        var spawnedTile2 = Instantiate(_tilePrefab, new Vector3(7, 0), Quaternion.identity);
        spawnedTile2.name = $"Tile {7} {0}";
        spawnedTile2.Init(false);
        spawnedTile2.isOffBoard = true;
        _tiles[new Vector2(7, 0)] = spawnedTile2;
        var spawnedTile3 = Instantiate(_tilePrefab, new Vector3(8, 0), Quaternion.identity);
        spawnedTile3.name = $"Tile {8} {0}";
        spawnedTile3.Init(false);
        spawnedTile3.isOffBoard = true;
        _tiles[new Vector2(8, 0)] = spawnedTile3;
        var spawnedTile4 = Instantiate(_tilePrefab, new Vector3(9, 0), Quaternion.identity);
        spawnedTile4.name = $"Tile {9} {0}";
        spawnedTile4.Init(false);
        spawnedTile4.isOffBoard = true;
        _tiles[new Vector2(9, 0)] = spawnedTile4;
        var spawnedTile5 = Instantiate(_tilePrefab, new Vector3(10, 0), Quaternion.identity);
        spawnedTile5.name = $"Tile {10} {0}";
        spawnedTile5.Init(false);
        spawnedTile5.isOffBoard = true;
        _tiles[new Vector2(10, 0)] = spawnedTile5;

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10); // This centers the board in the camera
        SpawnPieces();
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile; // Checks if there's a tile at entered position and returns it if yes
        return null;
    }

    public void SpawnPieces()
    {
        player1PawnReference = Instantiate(player1Pawn, new Vector2(0, 1), Quaternion.identity);
        player1KingReference = Instantiate(player1King, new Vector2(0, 0), Quaternion.identity);
        player1GoldReference = Instantiate(player1Gold, new Vector2(1, 0), Quaternion.identity);
        player1SilverReference = Instantiate(player1Silver, new Vector2(2, 0), Quaternion.identity);
        player1BishopReference = Instantiate(player1Bishop, new Vector2(3, 0), Quaternion.identity);
        player1RookReference = Instantiate(player1Rook, new Vector2(4, 0), Quaternion.identity);
        player2PawnReference = Instantiate(player2Pawn, new Vector2(4, 3), Quaternion.identity);
        player2KingReference = Instantiate(player2King, new Vector2(4, 4), Quaternion.identity);
        player2GoldReference = Instantiate(player2Gold, new Vector2(3, 4), Quaternion.identity);
        player2SilverReference = Instantiate(player2Silver, new Vector2(2, 4), Quaternion.identity);
        player2BishopReference = Instantiate(player2Bishop, new Vector2(1, 4), Quaternion.identity);
        player2RookReference = Instantiate(player2Rook, new Vector2(0, 4), Quaternion.identity);
        UpdatePiecePositions();
    }

    public void UpdatePiecePositions()
    {
        foreach (var tileReference in _tiles)
        {
            tileReference.Value._selection.SetActive(false);
            tileReference.Value.currentPieceUnder = null;
            tileReference.Value.hasPlayer1Piece = false;
            tileReference.Value.hasPlayer2Piece = false;
            tileReference.Value.isPawn1VerticalPath = false;
            tileReference.Value.isPawn2VerticalPath = false;
            tileReference.Value.cutOffPath1 = false;
            tileReference.Value.cutOffPath2 = false;
            tileReference.Value.cutOffPath3 = false;
            tileReference.Value.cutOffPath4 = false;
        }
        player1PawnPosition = player1PawnReference.transform.position;
        Tile player1PawnTile = GetTileAtPosition(player1PawnPosition);
        if (player1PawnTile != null)
        {
            player1PawnTile.UpdateCurrentPieceUnder(player1PawnReference);
            if (player1PawnReference.transform.localScale.y != -.8)
            {
                player1PawnTile.hasPlayer1Piece = true;
            }
            else
            {
                player1PawnTile.hasPlayer2Piece = true;
            }
            Tile player1PawnTileUp1 = GetTileAtPosition(new Vector2(player1PawnReference.transform.position.x, player1PawnReference.transform.position.y + 1));
            if (player1PawnTileUp1 != null)
            {
                player1PawnTileUp1.isPawn1VerticalPath = true;
            }
            Tile player1PawnTileUp2 = GetTileAtPosition(new Vector2(player1PawnReference.transform.position.x, player1PawnReference.transform.position.y + 2));
            if (player1PawnTileUp2 != null)
            {
                player1PawnTileUp2.isPawn1VerticalPath = true;
            }
            Tile player1PawnTileUp3 = GetTileAtPosition(new Vector2(player1PawnReference.transform.position.x, player1PawnReference.transform.position.y + 3));
            if (player1PawnTileUp3 != null)
            {
                player1PawnTileUp3.isPawn1VerticalPath = true;
            }
            Tile player1PawnTileUp4 = GetTileAtPosition(new Vector2(player1PawnReference.transform.position.x, player1PawnReference.transform.position.y + 4));
            if (player1PawnTileUp4 != null)
            {
                player1PawnTileUp4.isPawn1VerticalPath = true;
            }
        }
        player1KingPosition = player1KingReference.transform.position;
        Tile player1KingTile = GetTileAtPosition(player1KingPosition);
        if (player1KingTile != null)
        {
            player1KingTile.UpdateCurrentPieceUnder(player1KingReference);
            player1KingTile.hasPlayer1Piece = true;
        }
        player1GoldPosition = player1GoldReference.transform.position;
        Tile player1GoldTile = GetTileAtPosition(player1GoldPosition);
        if (player1GoldTile != null)
        {
            player1GoldTile.UpdateCurrentPieceUnder(player1GoldReference);
            if (player1GoldReference.transform.localScale.y != -.8)
            {
                player1GoldTile.hasPlayer1Piece = true;
            }
            else
            {
                player1GoldTile.hasPlayer2Piece = true;
            }
        }
        player1SilverPosition = player1SilverReference.transform.position;
        Tile player1SilverTile = GetTileAtPosition(player1SilverPosition);
        if (player1SilverTile != null)
        {
            player1SilverTile.UpdateCurrentPieceUnder(player1SilverReference);
            if (player1SilverReference.transform.localScale.y != -.8)
            {
                player1SilverTile.hasPlayer1Piece = true;
            }
            else
            {
                player1SilverTile.hasPlayer2Piece = true;
            }
        }
        player1BishopPosition = player1BishopReference.transform.position;
        Tile player1BishopTile = GetTileAtPosition(player1BishopPosition);
        if (player1BishopTile != null)
        {
            player1BishopTile.UpdateCurrentPieceUnder(player1BishopReference);
            if (player1BishopReference.transform.localScale.y != -.8)
            {
                player1BishopTile.hasPlayer1Piece = true;
            }
            else
            {
                player1BishopTile.hasPlayer2Piece = true;
            }
        }
        player1RookPosition = player1RookReference.transform.position;
        Tile player1RookTile = GetTileAtPosition(player1RookPosition);
        if (player1RookTile != null)
        {
            player1RookTile.UpdateCurrentPieceUnder(player1RookReference);
            if (player1RookReference.transform.localScale.y != -.8)
            {
                player1RookTile.hasPlayer1Piece = true;
            }
            else
            {
                player1RookTile.hasPlayer2Piece = true;
            }
        }
        player2PawnPosition = player2PawnReference.transform.position;
        Tile player2PawnTile = GetTileAtPosition(player2PawnPosition);
        if (player2PawnTile != null)
        {
            player2PawnTile.UpdateCurrentPieceUnder(player2PawnReference);
            if (player2PawnReference.transform.localScale.y != -.8)
            {
                player2PawnTile.hasPlayer2Piece = true;
            }
            else
            {
                player2PawnTile.hasPlayer1Piece = true;
            }
            Tile player2PawnTileUp1 = GetTileAtPosition(new Vector2(player2PawnReference.transform.position.x, player2PawnReference.transform.position.y + 1));
            if (player2PawnTileUp1 != null)
            {
                player2PawnTileUp1.isPawn2VerticalPath = true;
            }
            Tile player2PawnTileUp2 = GetTileAtPosition(new Vector2(player2PawnReference.transform.position.x, player2PawnReference.transform.position.y + 2));
            if (player2PawnTileUp2 != null)
            {
                player2PawnTileUp2.isPawn2VerticalPath = true;
            }
            Tile player2PawnTileUp3 = GetTileAtPosition(new Vector2(player2PawnReference.transform.position.x, player2PawnReference.transform.position.y + 3));
            if (player2PawnTileUp3 != null)
            {
                player2PawnTileUp3.isPawn2VerticalPath = true;
            }
            Tile player2PawnTileUp4 = GetTileAtPosition(new Vector2(player2PawnReference.transform.position.x, player2PawnReference.transform.position.y + 4));
            if (player2PawnTileUp4 != null)
            {
                player2PawnTileUp4.isPawn2VerticalPath = true;
            }
        }
        player2KingPosition = player2KingReference.transform.position;
        Tile player2KingTile = GetTileAtPosition(player2KingPosition);
        if (player2KingTile != null)
        {
            player2KingTile.UpdateCurrentPieceUnder(player2KingReference);
            player2KingTile.hasPlayer2Piece = true;
        }
        player2GoldPosition = player2GoldReference.transform.position;
        Tile player2GoldTile = GetTileAtPosition(player2GoldPosition);
        if (player2GoldTile != null)
        {
            player2GoldTile.UpdateCurrentPieceUnder(player2GoldReference);
            if (player2GoldReference.transform.localScale.y != -.8)
            {
                player2GoldTile.hasPlayer2Piece = true;
            }
            else
            {
                player2GoldTile.hasPlayer1Piece = true;
            }
        }
        player2SilverPosition = player2SilverReference.transform.position;
        Tile player2SilverTile = GetTileAtPosition(player2SilverPosition);
        if (player2SilverTile != null)
        {
            player2SilverTile.UpdateCurrentPieceUnder(player2SilverReference);
            if (player2SilverReference.transform.localScale.y != -.8)
            {
                player2SilverTile.hasPlayer2Piece = true;
            }
            else
            {
                player2SilverTile.hasPlayer1Piece = true;
            }
        }
        player2BishopPosition = player2BishopReference.transform.position;
        Tile player2BishopTile = GetTileAtPosition(player2BishopPosition);
        if(player2BishopTile != null)
        {
            player2BishopTile.UpdateCurrentPieceUnder(player2BishopReference);
            if (player2BishopReference.transform.localScale.y != -.8)
            {
                player2BishopTile.hasPlayer2Piece = true;
            }
            else
            {
                player2BishopTile.hasPlayer1Piece = true;
            }
        }
        player2RookPosition = player2RookReference.transform.position;
        Tile player2RookTile = GetTileAtPosition(player2RookPosition);
        if (player2RookTile != null)
        {
            player2RookTile.UpdateCurrentPieceUnder(player2RookReference);
            if (player2RookReference.transform.localScale.y != -.8)
            {
                player2RookTile.hasPlayer2Piece = true;
            }
            else
            {
                player2RookTile.hasPlayer1Piece = true;
            }
        }
    }

    public void PromotePiece(string piece)
    {
        if (piece == "player1Pawn")
        {
            player1PawnPromoted = true;
            player1PawnReference.GetComponent<SpriteRenderer>().sprite = player1PawnPromotedSprite;
        }
        if (piece == "player1Silver")
        {
            player1SilverPromoted = true;
            player1SilverReference.GetComponent<SpriteRenderer>().sprite = player1SilverPromotedSprite;
        }
        if (piece == "player1Bishop")
        {
            player1BishopPromoted = true;
            player1BishopReference.GetComponent<SpriteRenderer>().sprite = player1BishopPromotedSprite;
        }
        if (piece == "player1Rook")
        {
            player1RookPromoted = true;
            player1RookReference.GetComponent<SpriteRenderer>().sprite = player1RookPromotedSprite;
        }
        if (piece == "player2Pawn")
        {
            player2PawnPromoted = true;
            player2PawnReference.GetComponent<SpriteRenderer>().sprite = player2PawnPromotedSprite;
        }
        if (piece == "player2Silver")
        {
            player2SilverPromoted = true;
            player2SilverReference.GetComponent<SpriteRenderer>().sprite = player2SilverPromotedSprite;
        }
        if (piece == "player2Bishop")
        {
            player2BishopPromoted = true;
            player2BishopReference.GetComponent<SpriteRenderer>().sprite = player2BishopPromotedSprite;
        }
        if (piece == "player2Rook")
        {
            player2RookPromoted = true;
            player2RookReference.GetComponent<SpriteRenderer>().sprite = player2RookPromotedSprite;
        }
        promoteQuestion.SetActive(false);
        yesOption.SetActive(false);
        noOption.SetActive(false);
    }
}
