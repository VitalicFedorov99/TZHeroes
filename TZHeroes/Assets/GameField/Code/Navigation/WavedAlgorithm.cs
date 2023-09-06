using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavedAlgorithm
{
    public static List<Hex> SearchHexesWithoutNotWalkalbe(Hex start, int radius)
    {
        if (radius <= 1)
        {
            return start.NeighbourArray;
        }
        int iterationRange = 1;
        List<Hex> neigbourArray = new List<Hex>();
        neigbourArray.AddRange(start.NeighbourArray);
        while (iterationRange != radius)
        {
            List<Hex> temp = new List<Hex>();
            foreach (Hex hex in neigbourArray)
            {
                foreach (Hex neigbour in hex.NeighbourArray)
                {
                    if (!neigbourArray.Contains(neigbour) && neigbour != start && neigbour.CheckHexWalkable() && !temp.Contains(neigbour))
                        temp.Add(neigbour);
                }
            }
            neigbourArray.AddRange(temp);
            iterationRange++;
        }

        return neigbourArray;
    }

    

}
