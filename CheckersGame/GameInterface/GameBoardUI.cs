using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameLogic;

namespace GameInterface
{
    public class GameBoardUI
    {
        private const int k_BoardButtonSize = 40;
        private readonly BoardButton[,] r_GameBoard;
        private int m_BoardSize;

        public GameBoardUI(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
            r_GameBoard = new BoardButton[m_BoardSize, m_BoardSize];
        }

        internal int BoardSize
        {
            get { return m_BoardSize; }
        }

        internal void SetBoardSize(int i_BoardSize)
        {
            m_BoardSize = i_BoardSize;
        }

        internal void InitializeGameBoard(CheckersGameUI i_GameForm, Player i_Player1, Player i_Player2, GameBoard i_LogicGameBoard, bool i_NewBoard)
        {
            for (int line = 0; line < m_BoardSize; line++)
            {
                for (int col = 0; col < m_BoardSize; col++)
                {
                    if (i_NewBoard)
                    {
                        r_GameBoard[line, col] = new BoardButton(line, col);
                        r_GameBoard[line, col].Height = k_BoardButtonSize;
                        r_GameBoard[line, col].Width = k_BoardButtonSize;
                        r_GameBoard[line, col].BackgroundImage = (Image)(new Bitmap(Properties.Resources.inActiveSquare, new Size(k_BoardButtonSize, k_BoardButtonSize)));
                    }

                    r_GameBoard[line, col].Enabled = false;
                    r_GameBoard[line, col].Image = null;

                    if (CheckersGameControl.IsAnActivePlayerSoldier(line, col, i_Player1) || CheckersGameControl.IsAnActivePlayerSoldier(line, col, i_Player2))
                    {
                        r_GameBoard[line, col].EnableButtonAndInsertShape(i_LogicGameBoard.Square[line, col].SquareShape, i_NewBoard);
                    }
                    else if ((line + col) % 2 != 0)
                    {
                        r_GameBoard[line, col].EraseSoldier();
                    }

                    if (i_NewBoard)
                    {
                        i_GameForm.AddButtonToForm(r_GameBoard[line, col]);
                    }
                }
            }

            if (i_NewBoard)
            {
                setButtonsLocation();
            }
        }

        private void setButtonsLocation()
        {
            int xPos = 10;
            int yPos = 70;

            for (int i = 0; i < m_BoardSize; i++)
            {
                for (int j = 0; j < m_BoardSize; j++)
                {
                    r_GameBoard[i, j].Location = new Point(xPos, yPos);
                    xPos = r_GameBoard[i, j].Right;
                }

                xPos = 10;
                yPos += k_BoardButtonSize;
            }
        }

        internal void DrawGameBoard()
        {
            for(int i = 0; i < this.m_BoardSize; i++)
            {
                for(int j = 0; j < this.m_BoardSize; j++)
                {
                    r_GameBoard[i, j].Show();
                }
            }
        }
    }
}
