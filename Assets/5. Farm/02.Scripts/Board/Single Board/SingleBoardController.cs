using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleBoardController : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private Transform cellGroup;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Button restartButton;

    private SingleBoardTicTacToe gameBoard;
    private SingleCell[,] cells = new SingleCell[3, 3];

    public static Action startAction;
    
    private void Awake()
    {
        restartButton.onClick.AddListener(StartGame);
        startAction += StartGame;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameBoard = new SingleBoardTicTacToe();
        statusText.text = "X Turn";
        restartButton.gameObject.SetActive(false);

        for (int i = 0; i < cellGroup.childCount; i++)
        {
            Destroy(cellGroup.GetChild(i).gameObject);
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject cellObj = Instantiate(cellPrefab, cellGroup);
                SingleCell cell = cellObj.GetComponent<SingleCell>();
                cell.SetButton(i,j,OnCellClicked);
                cells[i, j] = cell;
            }
        }
        
        UpdateBoardVisual();
        
    }

    private void OnCellClicked(int x, int y)
    {
        if (gameBoard.IsGameOver() || gameBoard.board[x, y] != 0) return;
        
        SingleMove move = new SingleMove(x, y, gameBoard.player);
        gameBoard.MakeMove(move);
        UpdateBoardVisual();
        CheckForGameOver();
    }

    private void CheckForGameOver()
    {
        int winner = gameBoard.CheckWinner();
        if (winner == 0)
        {
            string nextPlayer = gameBoard.player == 1 ? "X" : "O";
            statusText.text = $"{nextPlayer} turn";
            return;
        }

        if (winner == 3)
        {
            statusText.text = "Draw";
        }

        else
        {
            string result = winner == 1 ? "X" : "O";
            statusText.text = $"{result} win";
        }
        
        restartButton.gameObject.SetActive(true);
    }

    private void UpdateBoardVisual()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string str = "";
                if(gameBoard.board[i, j] == 1)
                    str = "X";
                else if(gameBoard.board[i, j] == 2)
                    str = "O";
                cells[i,j].SetText(str);
            }
        }
    }
}
