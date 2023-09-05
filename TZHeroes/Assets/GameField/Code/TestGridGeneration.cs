using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGridGeneration : MonoBehaviour
{
    public int gridSizeX = 5; // ���������� ���������� �� �����������
    public int gridSizeY = 5; // ���������� ���������� �� ���������
    public float hexagonSize = 1.0f; // ������ ���������
    public float gap = 0.1f; // ���������� ����� �����������
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
                // ������������ ������� ��� ������� ���������
                float xOffset = q * (hexagonSize * 1.5f + gap);
                float yOffset = (q % 2 == 0) ? r * (hexagonSize * Mathf.Sqrt(3) + gap) : r * (hexagonSize * Mathf.Sqrt(3) + gap) + 0.5f * (hexagonSize * Mathf.Sqrt(3) + gap);

                // ������� �������� � ������������� ��� �������
                CreateHexagon(new Vector3(xOffset, yOffset, 0f));
            }
        }
    }

    private void CreateHexagon(Vector3 position)
    {
        // �������� ��������� � ��� ���������
        GameObject hexagon = Instantiate(prefab);
        hexagon.transform.position = position;

        // �������� ���������� � ��������� ��������� �� ������ ������.
    }
}
