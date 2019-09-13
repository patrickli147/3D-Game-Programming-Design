using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tictactoe : MonoBehaviour {
    private static int player;
    private static int count;
    private int winner;
    private int[,] chessBoard = new int[3, 3];

    void Start () {
        Restart();
    }

    void OnGUI() {
        GUI.Box(new Rect(225, 25, 200, 300), "");
        if (GUI.Button(new Rect(275, 250, 100, 50), "重新开始")) Restart();
        if (!GameOver()) {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (chessBoard[i, j] == 0 && GUI.Button(new Rect(250 + j * 50, 50 + i * 50, 50, 50), "")) {
                        chessBoard[i, j] = player;
                        player = 3 - player;
                        count++;
                    }
                    else if (chessBoard[i, j] == 1) 
                        GUI.Button(new Rect(250 + j * 50, 50 + i * 50, 50, 50), "O");
                    else if (chessBoard[i, j] == 2) 
                        GUI.Button(new Rect(250 + j * 50, 50 + i * 50, 50, 50), "X");
                }
            }
        }
    }

    void Restart() {
        player = 1;
        winner = 0;
        count = 0;
        for(int i = 0; i < 3; i++)
            for(int j = 0; j < 3; j++)
                chessBoard[i, j] = 0;
    }

    bool GameOver() {
        for(int i = 0; i < 3; i++) {
            if (chessBoard[i, 0] != 0 && chessBoard[i, 0] == chessBoard[i, 1] && chessBoard[i, 0] == chessBoard[i, 2]) 
                winner = chessBoard[i, 0];
            if (chessBoard[0, i] != 0 && chessBoard[0, i] == chessBoard[1, i] && chessBoard[0, i] == chessBoard[2, i]) 
                winner = chessBoard[0, i];
        }
        if (chessBoard[0, 0] != 0 && chessBoard[0, 0] == chessBoard[1, 1] && chessBoard[0, 0] == chessBoard[2, 2]) 
            winner = chessBoard[0, 0];
        if (chessBoard[0, 2] != 0 && chessBoard[0, 2] == chessBoard[1, 1] && chessBoard[0, 2] == chessBoard[2, 0]) 
            winner = chessBoard[0, 2];
        if (count < 9 && winner == 0) 
            return false;
        if (winner != 0)
            GUI.Box(new Rect(235, 35, 180, 200), "\n 玩家："+winner+"获胜\n请重新开始");
        else
            GUI.Box(new Rect(235, 35, 180, 200), "\n\n\n平局\n请重新开始");

        return true;
    }

}