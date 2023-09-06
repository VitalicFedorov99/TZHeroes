using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacer : MonoBehaviour
{
    [SerializeField] private List<Vector2Int> positionFirstPlayer;
    [SerializeField] private List<Vector2Int> positionSecondPlayer;

    [SerializeField] private List<Squad> squadsFirstPlayer;
    [SerializeField] private List<Squad> squadsSecondPlayer;


    private Hex hex;
    public void Setup()
    {
        for (int i = 0; i < squadsFirstPlayer.Count; i++)
        {
            GameGrid.GetHex(positionFirstPlayer[i], out hex);
            Debug.Log(hex);
            squadsFirstPlayer[i].PutOnHex(hex);
        }
        for (int i = 0; i < squadsSecondPlayer.Count; i++)
        {
            GameGrid.GetHex(positionSecondPlayer[i], out hex);
            Debug.Log(hex);
            squadsSecondPlayer[i].PutOnHex(hex);
        }
    }


}
