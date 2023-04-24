using System.Collections.Generic;
using UnityEngine;

public class GameBoardManager : MonoBehaviour
{
    public GameObject boardSquarePrefab;

    public Material whiteMaterial;
    public Material blackMaterial;

    private const int BOARD_SIZE = 8;
    private const float SQUARE_SIZE = 1f;

    private List<GameObject> boardSquares = new List<GameObject>();

    private void Awake()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        // Loop through each row and column of the board
        for (int row = 0; row < BOARD_SIZE; row++)
        {
            for (int col = 0; col < BOARD_SIZE; col++)
            {
                // Calculate the position of the square
                float xPos = col * SQUARE_SIZE;
                float zPos = row * SQUARE_SIZE;

                // Instantiate a new square object and set its position
                GameObject square = Instantiate(boardSquarePrefab, transform);
                square.transform.localPosition = new Vector3(xPos, 0, zPos);

                // Set the square's material based on its position
                MeshRenderer renderer = square.GetComponent<MeshRenderer>();
                if ((row + col) % 2 == 0)
                {
                    renderer.material = whiteMaterial;
                }
                else
                {
                    renderer.material = blackMaterial;
                }

                // Add the square object to the list of board squares
                boardSquares.Add(square);
            }
        }
    }
}