using System.Collections.Generic;
using UnityEngine;

public class SingleBoardTicTacToe 
{
    public int[,] board;
    private const int ROWS = 3, COLS = 3;

    public int player;

    public SingleBoardTicTacToe()
    {
        player = 1;
        board = new int[ROWS, COLS];
    }

    public List<SingleMove> GetMoves()
    {
        var moves = new List<SingleMove>();

        for (int i = 0; i < ROWS; i++)
        {
            for (int j = 0; j < COLS; j++)
            {
                if(board[i, j] == 0)
                    moves.Add(new SingleMove(i, j ,player));
            }
        }
        
        return moves;
    }

    public void MakeMove(SingleMove move)
    {
        if(board[move.x, move.y] != 0) return;
        board[move.x, move.y] = move.player;
        
        this.player = move.player == 1 ? 2 : 1;
    }

    /// <summary>
    /// 승자 확인
    /// </summary>
    /// <returns>0: 게임 진행 중 , 1: 1플레이어 승
    /// 2: 2플레이어 승, 3: 무승부</returns>
    public int CheckWinner()
    {
        // 가로 확인
        for (int i = 0; i < ROWS; i++)
        {
            if (board[i,0]!=0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return board[i, 0];
        }
        // 세로 확인
        for (int j = 0; j < COLS; j++)
        {
            if (board[0,j]!=0 && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                return board[0, j];
        }
        
        //대각
        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }

        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        if (GetMoves().Count == 0)
            return 3;
        return 0;

    }

    public bool IsGameOver()
    {
        return CheckWinner() != 0;
    }
}
