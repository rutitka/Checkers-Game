using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using GameLogic;

namespace GameInterface
{
    public partial class CheckersGameUI : Form
    {
        public delegate bool SingleStepEnteredEventHandler(SingleStep i_MoveToCheck);

        public delegate void GameOverEventHandler();

        public enum eGameBoardSize
        {
            Size6x6 = 6,
            Size8X8 = 8,
            Size10x10 = 10
        }

        private readonly Login r_LoginWindow;
        private GameBoardUI m_GameBoardUI;
        private bool m_IsANewBoard = true;
        private BoardButton m_FirstButtonChoice = null;
        private bool m_GameOver = false;

        public event SingleStepEnteredEventHandler SingleStepEntered;

        public event GameOverEventHandler CalculateSingleMatchScore;

        public CheckersGameUI()
        {
            SingleStepEntered += CheckersGameControl.CheckIfPlayerMoveFoundInList;
            CalculateSingleMatchScore += CheckersGameControl.CalculateGameScore;
            r_LoginWindow = new Login();
            InitializeComponent();
            ShowDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            if (r_LoginWindow.DialogResult == DialogResult.OK)
            {
                initializeGameSpecification(r_LoginWindow.Player1Name, r_LoginWindow.Player2Name, r_LoginWindow.GameBoardSize, r_LoginWindow.PlayerVsPlayer);
                m_GameBoardUI.DrawGameBoard();
                base.OnShown(e);
            }
        }

        private void initializeGameSpecification(string i_Player1Name, string i_Player2Name, eGameBoardSize i_GameBoardSize, bool i_PlayerVsPlayer)
        {
            CheckersGameControl.InitielizeGameProperties((int)i_GameBoardSize);
            CheckersGameControl.GameBoard.InitializeGameBoard((int)i_GameBoardSize);
            CheckersGameControl.Player1.PlayerName = i_Player1Name;
            CheckersGameControl.Player2.PlayerName = i_Player2Name;
            this.labelPlayer1Score.Text = string.Format(@"{0}: ", i_Player1Name);
            this.labelPlayer2Score.Text = string.Format(@"{0}: ", i_Player2Name);
            m_GameBoardUI = new GameBoardUI((int)i_GameBoardSize);
            m_GameBoardUI.SetBoardSize((int)i_GameBoardSize);
            m_GameBoardUI.InitializeGameBoard(this, CheckersGameControl.Player1, CheckersGameControl.Player2, CheckersGameControl.GameBoard, m_IsANewBoard);
            m_IsANewBoard = false;
        }

        internal void AddButtonToForm(Button i_NewButton)
        {
            this.Controls.Add(i_NewButton);
            i_NewButton.Click += new EventHandler(boardButton_Click);
        }

        private void GameBoardUI_Load(object sender, EventArgs e)
        {
            r_LoginWindow.ShowDialog();
        }

        private void boardButton_Click(object sender, EventArgs e)
        {
            BoardButton nextSquare = sender as BoardButton;
            bool isValidMove = false;
            if (m_FirstButtonChoice != null)
            {
                isValidMove = checkButtonValidity(nextSquare);
                resetButtons(m_FirstButtonChoice, nextSquare);
                if (!isValidMove)
                {
                    showErrorWindow();
                }

                if (CheckersGameControl.ActivePlayer == CheckersGameControl.Player2 && r_LoginWindow.PlayerVsPlayer == false && !m_GameOver)
                {
                    runComputerTurn();
                }
            }
            else
            {
                if (CheckersGameControl.IsAnActivePlayerSoldier(nextSquare.GetY, nextSquare.GetX, CheckersGameControl.ActivePlayer))
                {
                    m_FirstButtonChoice = nextSquare;
                    m_FirstButtonChoice.BackColor = Color.LightBlue;
                }
            }

            if (m_GameOver)
            {
                endOfMatchProcedure();
            }
        }

        private void runComputerTurn()
        {
            CheckersGameControl.CheckPlayersMovingOptions();
            CheckersGameControl.GetComputerMove();
            CheckersGameControl.MakeUsersMove();
            Thread.Sleep(700);
            m_GameBoardUI.InitializeGameBoard(this, CheckersGameControl.Player1, CheckersGameControl.Player2, CheckersGameControl.GameBoard, m_IsANewBoard);
            runComputerMultipleEatingProcess();
            CheckersGameControl.ChangeTurn();
        }

        private bool checkButtonValidity(BoardButton i_NextSquare)
        {
            bool isValidMove = false;
            if (i_NextSquare != m_FirstButtonChoice)
            {
                if (!CheckersGameControl.IsAnActivePlayerSoldier(i_NextSquare.GetY, i_NextSquare.GetX, CheckersGameControl.ActivePlayer))
                {
                    i_NextSquare.BackColor = Color.LightBlue;
                    if (CheckersGameControl.AnotherEatingMoveFound == false)
                    {
                        CheckersGameControl.CheckPlayersMovingOptions();
                        if (CheckersGameControl.ThereAreAvailableMoves == false)
                        {
                            m_GameOver = true;
                        }
                    }

                    if (SingleStepEntered.Invoke(createSingleStep(m_FirstButtonChoice.GetY, m_FirstButtonChoice.GetX, i_NextSquare.GetY, i_NextSquare.GetX)))
                    {
                        isValidMove = true;
                        legalMoveProcedure();
                    }
                }
            }

            return isValidMove; 
        }

        private void legalMoveProcedure()
        {
            CheckersGameControl.MakeUsersMove();
            m_GameBoardUI.InitializeGameBoard(this, CheckersGameControl.Player1, CheckersGameControl.Player2, CheckersGameControl.GameBoard, m_IsANewBoard);
            if (CheckersGameControl.CheckForAnotherEating == true)
            {
                CheckersGameControl.CheckForAnotherEatingOption();
            }

            if (CheckersGameControl.AnotherEatingMoveFound == false)
            {
                m_GameOver = CheckersGameControl.CheckIfGameIsOver();
                CheckersGameControl.ChangeTurn();
            }
        }

        private void runComputerMultipleEatingProcess()
        {
            while (CheckersGameControl.CheckForAnotherEating)
            {
                CheckersGameControl.CheckForAnotherEatingOption();

                if (CheckersGameControl.AnotherEatingMoveFound)
                {
                    Thread.Sleep(700);
                    CheckersGameControl.GetComputerMove();
                    CheckersGameControl.MakeUsersMove();
                    m_GameBoardUI.InitializeGameBoard(this, CheckersGameControl.Player1, CheckersGameControl.Player2, CheckersGameControl.GameBoard, m_IsANewBoard);
                }
                else
                {
                    m_GameOver = CheckersGameControl.CheckIfGameIsOver();
                }
            }
        }

        private void resetButtons(Button i_FirstButton, Button i_SecondButton)
        {
            i_FirstButton.BackColor = Color.White;
            i_SecondButton.BackColor = Color.White;
            m_FirstButtonChoice = null;
        }

        private SingleStep createSingleStep(int i_FromLine, int i_FromCol, int i_ToLine, int i_ToCol)
        {
            SingleStep nextMove = new SingleStep();
            nextMove.ConvertToSingleStep(i_FromLine, i_FromCol, i_ToLine, i_ToCol);
            return nextMove;
        }

        private void showErrorWindow()
        {
            const string ErrorMessage = "Invalid Move!";
            MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void endOfMatchProcedure()
        {
            CalculateSingleMatchScore.Invoke();
            string endOfMatchResults = createEndOfMatchMsg();
            DialogResult userChoice = MessageBox.Show(endOfMatchResults, "Game Over", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if (userChoice == DialogResult.OK)
            {
                startNewGame();
            }
            else if (userChoice == DialogResult.Cancel)
            {
                this.Close();
            }
        }

        private string createEndOfMatchMsg()
        {
            string endOfMatchResults = null;
            if (CheckersGameControl.Winner != null)
            {
                endOfMatchResults = string.Format(                      
                                        @"{0} Won!
                                        Another Round?", 
                                        CheckersGameControl.Winner.PlayerName);
            }
            else
            {
                endOfMatchResults = string.Format(@"Tie!
Another Round?");
            }

            return endOfMatchResults;
        }

        private void startNewGame()
        {
            CheckersGameControl.InitielizeGameProperties(m_GameBoardUI.BoardSize);
            CheckersGameControl.GameBoard.InitializeGameBoard(m_GameBoardUI.BoardSize);
            m_GameOver = false;
            m_FirstButtonChoice = null;
            this.labelPlayer1Score.Text = string.Empty;
            this.labelPlayer2Score.Text = string.Empty;
            this.labelPlayer1Score.Text = string.Format(@"{0}: {1}", CheckersGameControl.Player1.PlayerName, CheckersGameControl.Player1.PlayerGameScore);
            this.labelPlayer2Score.Text = string.Format(@"{0}: {1}", CheckersGameControl.Player2.PlayerName, CheckersGameControl.Player2.PlayerGameScore);
            m_GameBoardUI.InitializeGameBoard(this, CheckersGameControl.Player1, CheckersGameControl.Player2, CheckersGameControl.GameBoard, m_IsANewBoard);
            m_GameBoardUI.DrawGameBoard();
        }
    }
}