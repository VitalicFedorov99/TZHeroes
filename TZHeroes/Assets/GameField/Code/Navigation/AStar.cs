using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class AStar
{
    private static List<Hex> _toSearch;
    private static List<Hex> _processed;
    public static void FindPath(Hex startPoint, Hex endPoint, out List<Hex> listResult)
    {
        _toSearch = new List<Hex> { startPoint };
        _processed = new List<Hex>();
        listResult = new List<Hex>();
        int count = 0;
        var currentHex = _toSearch[0];
        while (currentHex != endPoint)
        {
            if (_toSearch.Count == 0)
            {
                break;
            }
            currentHex = _toSearch[0];

            foreach (var t in _toSearch)
            {
                bool flag1 = Vector2.Distance(new Vector2(currentHex.transform.position.x, currentHex.transform.position.y), new Vector2(endPoint.transform.position.x, endPoint.transform.position.y))
                    > Vector2.Distance(new Vector2(t.transform.position.x, t.transform.position.y), new Vector2(endPoint.transform.position.x, endPoint.transform.position.y));
                if (flag1)
                {
                    currentHex = t;
                }
            }

            _processed.Add(currentHex);
            _toSearch.Remove(currentHex);

            foreach (var neighbor in currentHex.NeighbourArray.Where(t => t.CheckHexWalkable() == true && !_processed.Contains(t)))
            {
                var inSearch = _toSearch.Contains(neighbor);

                var costToNeighbor = Vector2.Distance(new Vector2(neighbor.transform.position.x, neighbor.transform.position.y),
                    new Vector2(endPoint.transform.position.x, endPoint.transform.position.y));

                var cost = Vector2.Distance(new Vector2(currentHex.transform.position.x, currentHex.transform.position.y),
                    new Vector2(endPoint.transform.position.x, endPoint.transform.position.y));

                if (!inSearch || costToNeighbor < cost)
                {
                    _toSearch.Add(neighbor);
                    count = 0;
                }
            }
            count++;
            if (count >= 5)
            {
                break;
            }
        }
        foreach (var node in _processed)
        {
            listResult.Add(node);
        }

    }

    public static void FindNearestHex(Hex startPoint, Hex endPoint, out Hex nearEndPoint)
    {
        float dist = 100000000000;
        nearEndPoint = null;
        Debug.Log(endPoint);
        foreach (var hex in endPoint.NeighbourArray)
        {
            if (hex.CheckHexWalkable())
            {
                if (dist > Vector2.Distance(startPoint.transform.position, hex.transform.position))
                {
                    dist = Vector2.Distance(startPoint.transform.position, hex.transform.position);
                    nearEndPoint = hex;
                }
            }
        }
    }
}
