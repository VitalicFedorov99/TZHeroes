using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGridGeneration : MonoBehaviour
{
    public int gridSizeX = 5; // Количество гексагонов по горизонтали
    public int gridSizeY = 5; // Количество гексагонов по вертикали
    public float hexagonSize = 1.0f; // Размер гексагона
    public float gap = 0.1f; // Промежуток между гексагонами
    public GameObject prefab;
    private void Start()
    {
        GenerateHexGrid();
    }

    private void GenerateHexGrid()
    {
        for (int q = -gridSizeX / 2; q <= gridSizeX / 2; q++)
        {
            for (int r = -gridSizeY / 2; r <= gridSizeY / 2; r++)
            {
                // Рассчитываем позицию для каждого гексагона
                float xOffset = q * (hexagonSize * 1.5f + gap);
                float yOffset = (q % 2 == 0) ? r * (hexagonSize * Mathf.Sqrt(3) + gap) : r * (hexagonSize * Mathf.Sqrt(3) + gap) + 0.5f * (hexagonSize * Mathf.Sqrt(3) + gap);

                // Создаем гексагон и устанавливаем его позицию
                CreateHexagon(new Vector3(xOffset, yOffset, 0f));
            }
        }
    }

    private void CreateHexagon(Vector3 position)
    {
        // Создание гексагона и его настройка
        GameObject hexagon = Instantiate(prefab);
        hexagon.transform.position = position;

        // Добавьте компоненты и настройки гексагона по вашему выбору.
    }
}
