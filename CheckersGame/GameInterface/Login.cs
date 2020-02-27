using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace GameInterface
{
    public partial class Login : Form
    {
        private bool m_secondPlayerIsHuman = false;
        private CheckersGameUI.eGameBoardSize m_BoardSize;
        
        public Login()
        {
            InitializeComponent();
        }

        public string Player1Name
        {
            get { return textBoxPlayer1.Text; }
        }

        public string Player2Name
        {
            get { return textBoxPlayer2.Text; }
        }

        public CheckersGameUI.eGameBoardSize GameBoardSize
        {
            get { return m_BoardSize; }
        }

        public bool PlayerVsPlayer
        {
            get { return m_secondPlayerIsHuman; }
        }

        private void GameSettings_Load(object sender, EventArgs e)
        {
        }

        private void radioButtonSize6x6_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = CheckersGameUI.eGameBoardSize.Size6x6;
        }

        private void radioButtonSize8x8_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = CheckersGameUI.eGameBoardSize.Size8X8;
        }

        private void radioButtonSize10x10_CheckedChanged(object sender, EventArgs e)
        {
            m_BoardSize = CheckersGameUI.eGameBoardSize.Size10x10;
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxPlayer2.Checked)
            {
                this.textBoxPlayer2.Enabled = true;
                this.textBoxPlayer2.ReadOnly = false;
                this.textBoxPlayer2.Text = string.Empty;
                this.textBoxPlayer2.BackColor = System.Drawing.SystemColors.Window;
                this.m_secondPlayerIsHuman = true;
            }
            else
            {
                this.textBoxPlayer2.Enabled = false;
                this.textBoxPlayer2.ReadOnly = false;
                this.textBoxPlayer2.Text = "Computer";
                this.textBoxPlayer2.BackColor = System.Drawing.SystemColors.Control;
                this.m_secondPlayerIsHuman = false;
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (this.textBoxPlayer1.Text.Length == 0 || this.textBoxPlayer1.Text.Contains(" ") || this.textBoxPlayer2.Text.Length == 0 || this.textBoxPlayer2.Text.Contains(" "))
            {
                const string ErrorMessage = "Error! Player names can not be empty or contain spaces.";
                MessageBox.Show(ErrorMessage, "Checkers Game", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
