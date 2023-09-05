using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private static GameObject _instance;
    private static Hex[,] _grid;
    private static Vector2 _hexSize;
    private static Vector2 _gridSize;
    private static Dictionary<Vector2Int, Hex> dictionaryHexs = new Dictionary<Vector2Int, Hex>();
    public static Hex[,] Grid
    {
        get => _grid;
        set => _grid = value;
    }
    private void Awake()
    {
        _instance = this.gameObject;

    }
    private void Start()
    {
        GridCreate(GetComponent<GridSettings>());
        
    }

    public void GridCreate(GridSettings settings)
    {
        var boundSize = settings.HexPrefab.GetComponent<Renderer>().bounds.size;
        _hexSize = new Vector2(boundSize.x, boundSize.y);
        _grid = GeneratorGrid.GenerateGrid(_instance, settings);
        _gridSize = new Vector2(
            _grid[_grid.GetLength(0) - 1, 0].transform.position.x - _grid[0, 0].transform.position.x,
            _grid[0, _grid.GetLength(1) - 1].transform.position.y - _grid[0, 0].transform.position.y);
        foreach(var hex in _grid) 
        {
            dictionaryHexs.Add(hex.PositionInGrid, hex);
        }
    }
    public static Vector2 GridSize => _gridSize;
    public static Vector2 HexSize => _hexSize;

    public static void Colorize(List<Vector2Int> indexs, Vector2Int currentPosition) 
    {
        Vector2Int index = Vector2Int.zero;
        Hex hex;
        foreach (var ind in indexs) 
        {
                index = currentPosition + ind;
                dictionaryHexs.TryGetValue(index, out hex);
                if(hex!=null)
                hex.OnColorize();
        }

        dictionaryHexs.TryGetValue(currentPosition,out hex);
        hex.OnColorize();
       // _grid[currentPosition.x, currentPosition.y].OnColorize();
    }
    public static void OffColorize()
    {
        foreach (var gr in _grid)
        {
            gr.OffColorize();
        }
    }

    public bool CheckGrid()
    {
        if (_grid != null) return true;
        else return false;

    }

    public static void SetGrid(Hex[,] grid)
    {
        if (_grid.GetLength(0) < 10 && _grid.GetLength(1) < 10) return;
        _grid = grid;
    }

    public static Hex GetGridHex(Vector2 pos)
    {
        Debug.LogError(pos.x + " x " + pos.y + " y ");
        Vector2Int index = GeneratorGrid.ConvertPosToIndex(pos);
        return _grid[index.x, index.y];
    }

    private static float padding = 0.04f;
    private static float magicx = (Mathf.Cos(Mathf.PI / 6)) / 2 + padding;
    private static float magicy = (Mathf.Sin(Mathf.PI / 6) + 1) * (padding + 0.5f);
    public static Vector3 MoveLU(Vector3 hex)
    {
        return new Vector3(hex.x - magicx, hex.y + magicy, 15);
    }
    public static Vector3 MoveRU(Vector3 hex)
    {
        return new Vector3(hex.x + magicx, hex.y + magicy, 15);
    }
    public static Vector3 MoveLC(Vector3 hex)
    {
        return new Vector3(hex.x - magicx * 2, hex.y, 15);
    }
    public static Vector3 MoveRC(Vector3 hex)
    {
        return new Vector3(hex.x + magicx * 2, hex.y, 15);
    }
    public static Vector3 MoveLD(Vector3 hex)
    {
        return new Vector3(hex.x - magicx, hex.y - magicy, 15);
    }
    public static Vector3 MoveRD(Vector3 hex)
    {
        return new Vector3(hex.x + magicx, hex.y - magicy, 15);
    }
}
