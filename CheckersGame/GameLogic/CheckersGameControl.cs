using System;
using System.Collections.Generic;

namespace GameLogic
{
    public static class CheckersGameControl
    {
        public enum eGameType
        {
            PlayerVsPlayer = 1,
            PlayerVsComputer = 2
        }
        
        private static Player s_Player1 = new Player(Player.ePlayerColor.Black);
        private static Player s_Player2 = new Player(Player.ePlayerColor.White);
        private static MovmentManager s_MovementManager = new MovmentManager();
        private static int s_BoardSize;
        private static GameBoard s_MyGameBoard;
        private static Player s_ActivePlayer;
        private static Player s_SecondPlayer;
        private static Player s_Winner = null;
        private static SingleStep s_userNextStep = new SingleStep();
        private static eGameType s_GameType;
        private static bool s_CheckForAnotherEating = false;
        private static bool s_ThereAreAvailbleMoves = true;
        private static bool s_AnotherEatingMoveFound = false;

        public static Player Player1
        {
            get { return s_Player1; }
        }

        public static Player Player2
        {
            get { return s_Player2; }
        }

        public static Player SecondPlayer
        {
            get { return s_SecondPlayer; }
        }

        public static Player ActivePlayer
        {
            get { return s_ActivePlayer; }
        }

        public static Player Winner
        {
            get { return s_Winner; }
        }

        public static bool ThereAreAvailableMoves
        {
            get { return s_ThereAreAvailbleMoves; }
        }

        public static bool AnotherEatingMoveFound
        {
            get { return s_AnotherEatingMoveFound; }
        }

        public static int BoardSize
        {
            get { return s_BoardSize; }
        }

        public static eGameType GameType
        {
            get { return s_GameType; }
            set { s_GameType = value; }
        }

        public static GameBoard GameBoard
        {
            get { return s_MyGameBoard; }
        }

        public static SingleStep UserNextStep
        {
            get { return s_userNextStep; }
        }

        public static bool CheckForAnotherEating
        {
            get { return s_CheckForAnotherEating; }
            set { s_CheckForAnotherEating = value; }
        }

        public static void InitielizeGameProperties(int i_BoardSize)
        {
            s_BoardSize = i_BoardSize;
            s_ActivePlayer = s_Player1;
            s_SecondPlayer = s_Player2;
            s_MyGameBoard = new GameBoard(s_BoardSize);
            s_Winner = null;
            s_CheckForAnotherEating = false;
            s_ThereAreAvailbleMoves = true;
            s_AnotherEatingMoveFound = false;
            s_MovementManager.IsReadyToEat = false;
        }

        public static void CheckPlayersMovingOptions()
        {
            s_MovementManager.CheckForAvailableMoves(s_ActivePlayer, s_SecondPlayer);

            if (s_MovementManager.MovesList.Count <= 0)
            {
                s_ThereAreAvailbleMoves = false;
            }
        }

        public static bool PlayerMoveFoundInList(string i_userInput)
        {
            bool stepAppearsInList = true;
            s_userNextStep.ConvertFromStringToStep(i_userInput);
            stepAppearsInList = s_MovementManager.CheckIfPlayerMoveAppearsInList(s_userNextStep);
            return stepAppearsInList;
        }

        public static bool CheckIfPlayerMoveFoundInList(SingleStep i_NextMoveToCheck)
        {
            bool stepAppearsInList = true;
            s_userNextStep = i_NextMoveToCheck;
            stepAppearsInList = s_MovementManager.CheckIfPlayerMoveAppearsInList(s_userNextStep);
            return stepAppearsInList;
        }

        public static void MakeUsersMove()
        {
            if (s_MovementManager.IsReadyToEat)
            {
                MakeEatingMove(s_ActivePlayer);
            }
            else
            {
                s_MyGameBoard.UpdateMoveInBoard(s_userNextStep);
            }

            s_MovementManager.MovesList.Clear();
        }

        public static void MakeEatingMove(Player i_ActivePlayer)
        {
            int eatableLineSquare = 0;
            int eatableColSquare = 0;
            s_MovementManager.GetEatableSquarePos(s_userNextStep, i_ActivePlayer, out eatableLineSquare, out eatableColSquare);
            s_MyGameBoard.BurnTheSquareAndUpdateScore(eatableLineSquare, eatableColSquare, i_ActivePlayer);
            s_MyGameBoard.UpdateMoveInBoard(s_userNextStep);
        }

        public static void CheckForAnotherEatingOption()
        {
            GameBoardSquare CheckingSquare = s_MyGameBoard.Square[s_userNextStep.NextLine, s_userNextStep.NextCol];
            s_MovementManager.CheckActivePlayerNextMove(CheckingSquare, s_ActivePlayer);
            s_AnotherEatingMoveFound = s_MovementManager.IsReadyToEat;
            if (s_AnotherEatingMoveFound == false)
            {
                s_CheckForAnotherEating = false;
            }
        }
        
        public static void GetComputerMove()
        {
            s_userNextStep = s_MovementManager.GetRandomizeMove();
        }

        public static bool CheckIfGameIsOver()
        {
            s_MovementManager.MovesList.Clear();
            ChangeTurn();
            s_MovementManager.CheckForAvailableMoves(s_ActivePlayer, s_SecondPlayer);
            bool gameOver = s_MovementManager.MovesList.Count <= 0;
            s_MovementManager.MovesList.Clear();
            ChangeTurn();
            return gameOver;
        }

        public static void ChangeTurn()
        {
            Player temp = s_ActivePlayer;
            s_ActivePlayer = s_SecondPlayer;
            s_SecondPlayer = temp;
        }

        public static bool IsAnActivePlayerSoldier(int i_Y, int i_X, Player i_ActivePlayer)
        {
            bool isAnActivePlayerSquare = s_MyGameBoard.CheckIfSquareBelongsToActivePlayer(i_X, i_Y, i_ActivePlayer);
            return isAnActivePlayerSquare;
        }

        public static void CalculateGameScore()
        {
            int totalScore = s_MyGameBoard.CheckWhoWon();
            if (totalScore > 0)
            {
                s_Winner = Player1;
                Player1.PlayerGameScore += totalScore;
            }
            else if (totalScore < 0)
            {
                s_Winner = Player2;
                Player2.PlayerGameScore += totalScore * (-1);
            }
            else
            {
                s_Winner = null;
            }
        } 
    }
}