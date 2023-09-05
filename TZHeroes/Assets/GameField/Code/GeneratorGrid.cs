using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorGrid : MonoBehaviour
{
    private static GameObject _hexPrefab = null;
    private static GameObject _gridObject;
    private static Vector2 _hexSize;
    private static Vector2Int _gridSize = Vector2Int.zero;
    private static float _gridOffset = 0;

    public static Hex[,] GenerateGrid(GameObject gridObject, GridSettings settings)
    {
        SetSettings(settings, gridObject);
        Hex[,] grid = new Hex[settings.Size.x, settings.Size.y];
        grid = HexMatrixGenerate(grid);
        SetupIdGrid(grid);
        return grid;
    }

    public static Vector2Int ConvertPosToIndex(Vector2 pos)
    {
        int y = (int)(pos.y / (_hexSize.y * 0.75f + _gridOffset) + 0.5f);
        int x = (int)(pos.x / (_hexSize.x + _gridOffset) - (y % 2 == 0 ? 0.5f : 0.0f) + 0.5f);
        return new Vector2Int(x, y);
    }

    public static Vector2 ConvertIndexToPos(Vector2Int index)
    {
        return new Vector2(
            (index.x + (index.y % 2 == 0 ? 0.5f : 0.0f)) * (_hexSize.x + _gridOffset),
            index.y * (_hexSize.y * 0.75f + _gridOffset)
        );
    }

    private static void SetSettings(GridSettings settings, GameObject gridObject)
    {
        _gridSize = settings.Size;
        _gridOffset = settings.Ñlearance;
        _hexPrefab = settings.HexPrefab;
        _gridObject = gridObject;
        var boundSize = _hexPrefab.GetComponent<Renderer>().bounds.size;
        _hexSize = new Vector2(boundSize.x, boundSize.y);
    }

    private static void SetupIdGrid(Hex[,] grid)
    {
        int id = 0;
        bool flag = false;
        List<Hex> listTemp = new List<Hex>();
        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                listTemp.Add(grid[x, y]);


                grid[x,y].name = id.ToString();
                id++;
            }
        }
        id = 0;
        int tempx;
        int tempId = 0;
        float flagNumber = listTemp.Count / (_gridSize.x * 2);
        if(listTemp.Count % (_gridSize.x * 2) != 0) 
        {
            flagNumber++;
        }
        int k = 0;
        while (k <= flagNumber) 
        {
            if(id == _gridSize.x * 2) 
            {
               tempId = tempId + 1;
               id = 0;
               k++;
            }
            if (!flag)
            {
                if (id != 0)
                    tempId = tempId - 6;
                if (tempId >= listTemp.Count)
                {
                    flag = true;
                    id++;
                    continue;
                }
                listTemp[tempId].name = $"({id}, {listTemp[tempId].PositionInGrid.y})";
                listTemp[tempId].PositionInGrid = new Vector2Int(id, listTemp[tempId].PositionInGrid.y);
                id++;
                flag = true;
                continue;
            }
            else
            {
                
                tempId = tempId + 7;
                if (tempId >= listTemp.Count) 
                {
                    flag = false;
                    id++;
                    continue;
                }
                listTemp[tempId].name = $"({id}, {listTemp[tempId].PositionInGrid.y})";
                listTemp[tempId].PositionInGrid = new Vector2Int(id, listTemp[tempId].PositionInGrid.y);
                id++;
                flag = false;
                continue;
            }
            
        }     
    }

    private static Hex[,] HexMatrixGenerate(Hex[,] grid)
    {
        bool offset = false;
        Vector3 horizon = new Vector3(-5, -4, 0);
        for (int y = 0; y < _gridSize.y; y++)
        {
            Vector3 current = new Vector3(horizon.x, horizon.y, horizon.z);
            for (int x = 0; x < _gridSize.x; x++)
            {
                var gameObject = Instantiate(_hexPrefab, _gridObject.transform);
                var hex = gameObject.GetComponent<Hex>();

                hex.name = $"({x}, {y})";
                hex.transform.position = current;
                hex.PositionInGrid = new Vector2Int(x, y);

                grid[x, y] = hex;
                if (x > 0)
                {
                    Hex t = grid[x - 1, y];
                    t.NeighbourArray.Add(hex);
                    hex.NeighbourArray.Add(t);
                }
                if (y > 0)
                {
                    Hex h = grid[x, y - 1];
                    h.NeighbourArray.Add(hex);
                    hex.NeighbourArray.Add(h);

                    int tx = x + (offset ? 1 : -1);
                    if (tx >= 0 && tx < _gridSize.x)
                    {
                        Hex t = grid[tx, y - 1];
                        t.NeighbourArray.Add(hex);
                        hex.NeighbourArray.Add(t);
                    }
                }

                current = GameGrid.MoveRC(current);
            }
            horizon = offset ? GameGrid.MoveLU(horizon) : GameGrid.MoveRU(horizon);
            offset = !offset;
        }

        offset = false;
        return grid;
    }

}
