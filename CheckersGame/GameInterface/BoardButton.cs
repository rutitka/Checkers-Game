using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GameInterface.Properties;
using GameLogic;

namespace GameInterface
{
    public sealed class BoardButton : Button
    {
        private const int k_ButtonImageSize = 40;
        private readonly int r_XPos;
        private readonly int r_YPos;
        private bool m_IsClicked = false;

        public BoardButton(int i_YPos, int i_XPos)
        {
            r_XPos = i_XPos;
            r_YPos = i_YPos;
        }

        internal bool IsClicked
        {
            get { return m_IsClicked; }
            set { m_IsClicked = value; }
        }

        internal int GetX
        {
            get { return r_XPos; }
        }

        internal int GetY
        {
            get { return r_YPos; }
        }

        internal void EnableButtonAndInsertShape(GameBoardSquare.eSquareType i_ButtonShape, bool i_IsNewBoard)
        {
            if (i_ButtonShape == GameBoardSquare.eSquareType.BlackKing)
            {
                this.Image = (Image)(new Bitmap(Properties.Resources.black_king, new Size(k_ButtonImageSize, k_ButtonImageSize)));
            }
            else if (i_ButtonShape == GameBoardSquare.eSquareType.WhiteKing)
            {
                this.Image = (Image)(new Bitmap(Properties.Resources.red_queen, new Size(k_ButtonImageSize, k_ButtonImageSize)));
            }
            else if (i_ButtonShape == GameBoardSquare.eSquareType.BlackRegularSoldier)
            {
                this.Image = (Image)(new Bitmap(Properties.Resources.black_soldier, new Size(k_ButtonImageSize, k_ButtonImageSize)));
            }
            else
            {
                this.Image = (Image)(new Bitmap(Properties.Resources.red_soldier, new Size(k_ButtonImageSize, k_ButtonImageSize)));
            }

            this.Enabled = true;
            if (i_IsNewBoard)
            {
                this.BackgroundImage = (Image)(new Bitmap(Properties.Resources.ActiveCheckersSquare, new Size(k_ButtonImageSize, k_ButtonImageSize)));
            }
        }

        internal void EraseSoldier()
        {
            this.Image = null;
            this.BackgroundImage = (Image)(new Bitmap(Properties.Resources.ActiveCheckersSquare, new Size(k_ButtonImageSize, k_ButtonImageSize)));
            this.Enabled = true;
        }
    }
}
