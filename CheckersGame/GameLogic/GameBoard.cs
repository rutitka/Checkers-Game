using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class GameBoard
    {
        private readonly GameBoardSquare[,] r_GameBoard;
        private int m_BoardSize;

        public GameBoard(int i_GameBoardSize) ////ctor
        {
            m_BoardSize = i_GameBoardSize;
            r_GameBoard = new GameBoardSquare[m_BoardSize, m_BoardSize];
        }

        public GameBoardSquare[,] Square
        {
            get { return r_GameBoard; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
        }

        public void InitializeGameBoard(int i_BoardSize)
        {
            int boardSize = i_BoardSize;
            for (int line = 0; line < (boardSize / 2) - 1; line++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (IsEvenNum(line))
                    {
                        if (!IsEvenNum(col))
                        {
                            r_GameBoard[line, col] = new GameBoardSquare(GameBoardSquare.eSquareType.WhiteRegularSoldier, Player.ePlayerColor.White, line, col);
                        }
                    }
                    else
                    {
                        if (IsEvenNum(col))
                        {
                            r_GameBoard[line, col] = new GameBoardSquare(GameBoardSquare.eSquareType.WhiteRegularSoldier, Player.ePlayerColor.White, line, col);
                        }
                    }
                }
            }

            for (int line = (boardSize / 2) + 1; line < boardSize; line++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (IsEvenNum(line))
                    {
                        if (!IsEvenNum(col))
                        {
                            r_GameBoard[line, col] = new GameBoardSquare(GameBoardSquare.eSquareType.BlackRegularSoldier, Player.ePlayerColor.Black, line, col);
                        }
                    }
                    else
                    {
                        if (IsEvenNum(col))
                        {
                            r_GameBoard[line, col] = new GameBoardSquare(GameBoardSquare.eSquareType.BlackRegularSoldier, Player.ePlayerColor.Black, line, col);
                        }
                    }
                }
            }
        }

        public bool IsEvenNum(int i_index)
        {
            bool isEven = i_index % 2 == 0;
            return isEven;
        }

        public void BurnTheSquareAndUpdateScore(int i_EatableLine, int i_EatableCol, Player i_ActivePlayer)
        {
            GameBoardSquare.eSquareType squareShape = r_GameBoard[i_EatableLine, i_EatableCol].SquareShape;
            r_GameBoard[i_EatableLine, i_EatableCol] = null;
        }

        public void UpdateMoveInBoard(SingleStep i_UserMove)
        {
            GameBoardSquare.eSquareType squareType = r_GameBoard[i_UserMove.CurrentLine, i_UserMove.CurrentCol].SquareShape;
            Player.ePlayerColor squareColor = r_GameBoard[i_UserMove.CurrentLine, i_UserMove.CurrentCol].SquareColor;
            r_GameBoard[i_UserMove.NextLine, i_UserMove.NextCol] = new GameBoardSquare(squareType, squareColor, i_UserMove.NextLine, i_UserMove.NextCol);
            r_GameBoard[i_UserMove.CurrentLine, i_UserMove.CurrentCol] = null;
            CheckIfSoldierBecomeAKing(i_UserMove.NextLine, i_UserMove.NextCol);
        }

        public void CheckIfSoldierBecomeAKing(int i_Line, int i_Col)
        {
            if ((r_GameBoard[i_Line, i_Col].SquareColor == Player.ePlayerColor.Black) && (i_Line == 0))
            {
                r_GameBoard[i_Line, i_Col].SquareShape = GameBoardSquare.eSquareType.BlackKing;
            }
            else if ((r_GameBoard[i_Line, i_Col].SquareColor == Player.ePlayerColor.White) && (i_Line == m_BoardSize - 1)) 
            {
                r_GameBoard[i_Line, i_Col].SquareShape = GameBoardSquare.eSquareType.WhiteKing;
            }
        }

        public bool CheckIfSquareBelongsToActivePlayer(int i_Col, int i_Line, Player i_ActivePlayer)
        {
            bool isAnActivePlayerSquare = false;
            if (r_GameBoard[i_Line, i_Col] != null)
            {
                isAnActivePlayerSquare = r_GameBoard[i_Line, i_Col].SquareColor == i_ActivePlayer.PlayerColor;
            }

            return isAnActivePlayerSquare;
        }

        public int CheckWhoWon()
        {
            int player1Score = 0, player2Score = 0, finalScore = 0;

            for (int line = 0; line < m_BoardSize; line++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    GameBoardSquare checkedSquare = r_GameBoard[line, col];

                    if (checkedSquare != null)
                    {   ////Here i'm finding Active player Squares and check their next steps
                        if (checkedSquare.SquareColor == CheckersGameControl.Player1.PlayerColor)
                        {
                            player1Score += checkedSquare.CalculateSquareValue();
                        }
                        else if (checkedSquare.SquareColor == CheckersGameControl.Player2.PlayerColor) 
                        {
                            player2Score += checkedSquare.CalculateSquareValue();
                        }
                    }
                }
            }

            finalScore = player1Score - player2Score;
            return finalScore;
        }
    }
}