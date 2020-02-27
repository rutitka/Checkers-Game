using System;

namespace GameLogic
{
    public class GameBoardSquare
    {
        public enum eSquareType
        {
            BlackRegularSoldier = 'X',
            BlackKing = 'K',
            WhiteRegularSoldier = 'O',
            WhiteKing = 'U'
        }

        private int m_CurrentLine;
        private int m_CurrentCol;
        private eSquareType m_SoldierShape;
        private Player.ePlayerColor m_SoldierColor;

        public GameBoardSquare(eSquareType i_SoldierShape, Player.ePlayerColor i_SoldierColor, int i_Line, int i_Col)
        {
            m_CurrentLine = i_Line;
            m_CurrentCol = i_Col;
            m_SoldierColor = i_SoldierColor;
            m_SoldierShape = i_SoldierShape;
        }

        public eSquareType SquareShape
        {
            get { return m_SoldierShape; }
            set { m_SoldierShape = value; }
        }

        public Player.ePlayerColor SquareColor
        {
            get { return m_SoldierColor; }
            set { m_SoldierColor = value; }
        }

        public int Line
        {
            get { return m_CurrentLine; }
        }

        public int Col
        {
            get { return m_CurrentCol; }
        }

        public int CalculateSquareValue()
        {
            int score = 0;
            if (m_SoldierShape == eSquareType.BlackKing || m_SoldierShape == eSquareType.WhiteKing) 
            {
                score = 4;
            }
            else if (m_SoldierShape == eSquareType.BlackRegularSoldier || m_SoldierShape == eSquareType.WhiteRegularSoldier) 
            {
                score = 1;
            }

            return score;
        }
    }
}
