using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setuper : MonoBehaviour
{
    [SerializeField] private UnitPlacer unitPlacer;
    [SerializeField] private GameGrid grid;
    [SerializeField] private QueueFight queueFight;
    private void Start()
    {
        Setup();
    }

    private void Setup() 
    {
        grid.Setup();
        unitPlacer.Setup();
        queueFight.Setup();
    }
}
