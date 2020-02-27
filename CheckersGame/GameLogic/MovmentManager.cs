using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class MovmentManager
    {
        public enum eMovementDirection
        {
            Upleft = 1,
            UpRight,
            DownLeft,
            DownRight
        }

        private readonly List<SingleStep> r_AvailableMoves = new List<SingleStep>();
        private bool m_IsReadyToEat = false;

        public bool IsReadyToEat
        {
            get { return m_IsReadyToEat; }
            set { m_IsReadyToEat = value; }
        }

        public List<SingleStep> MovesList
        {
            get { return r_AvailableMoves; }
        }

        public void CheckForAvailableMoves(Player i_ActivePlayer, Player i_SecondPlayer)
        {
            for (int line = 0; line < CheckersGameControl.BoardSize; line++)
            {
                for (int col = 0; col < CheckersGameControl.BoardSize; col++)
                {
                    if (CheckersGameControl.GameBoard.Square[line, col] != null)
                    {   ////Here i'm finding Active player Squares and check their next steps
                        if (CheckersGameControl.GameBoard.Square[line, col].SquareColor == i_ActivePlayer.PlayerColor)
                        {
                            CheckActivePlayerNextMove(CheckersGameControl.GameBoard.Square[line, col], i_SecondPlayer);
                        }
                    }
                }
            }
        }

        public void CheckActivePlayerNextMove(GameBoardSquare i_CurrentSquare, Player i_SecondPlayer)
        {
            SingleStep nextStepForChecking = new SingleStep();
            if (i_CurrentSquare.SquareShape == GameBoardSquare.eSquareType.WhiteRegularSoldier)
            {
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.DownLeft);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.DownLeft);
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.DownRight);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.DownRight);
            }
            else if (i_CurrentSquare.SquareShape == GameBoardSquare.eSquareType.BlackRegularSoldier)
            {
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.Upleft);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.Upleft);
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.UpRight);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.UpRight);
            }
            else if (i_CurrentSquare.SquareShape == GameBoardSquare.eSquareType.WhiteKing || i_CurrentSquare.SquareShape == GameBoardSquare.eSquareType.BlackKing)
            {
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.DownLeft);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.DownLeft);
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.DownRight);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.DownRight);
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.Upleft);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.Upleft);
                nextStepForChecking.CreateSingleStep(i_CurrentSquare.Line, i_CurrentSquare.Col, eMovementDirection.UpRight);
                CheckDirectionAndUpdateInList(nextStepForChecking, i_CurrentSquare, eMovementDirection.UpRight);
            }
        }

        public void CheckDirectionAndUpdateInList(SingleStep i_NextStep, GameBoardSquare i_CurrentSquare, eMovementDirection i_LastMoveDirection)
        {
            int nextStepLine = i_NextStep.NextLine;
            int nextStepCol = i_NextStep.NextCol;

            if (IsInTheBoardLimits(nextStepLine, nextStepCol))
            {
                GameBoardSquare nextSquare = CheckersGameControl.GameBoard.Square[nextStepLine, nextStepCol];

                if (nextSquare != null)
                {
                    if (nextSquare.SquareColor != i_CurrentSquare.SquareColor)
                    {
                        CheckIfSoldierCanEat(i_NextStep, i_LastMoveDirection, i_CurrentSquare);
                    }
                }
                else if (nextSquare == null && !m_IsReadyToEat && !CheckersGameControl.CheckForAnotherEating)
                {
                    SingleStep nextAvailableStep = new SingleStep();
                    nextAvailableStep.CopySingleStep(i_NextStep);
                    r_AvailableMoves.Add(nextAvailableStep);
                }
                else
                {
                    CheckersGameControl.CheckForAnotherEating = false;
                }
            }
            else
            {
                CheckersGameControl.CheckForAnotherEating = false;
            }
        }

        public void CheckIfSoldierCanEat(SingleStep i_LastStep, eMovementDirection i_LastMoveDirection, GameBoardSquare i_CurrentSquare)
        {
            int nextStepLine = i_LastStep.NextLine;
            int nextStepCol = i_LastStep.NextCol;
            SingleStep nextAvailableStep = new SingleStep();
            nextAvailableStep.CreateSingleStep(nextStepLine, nextStepCol, i_LastMoveDirection);

            if (IsInTheBoardLimits(nextAvailableStep.NextLine, nextAvailableStep.NextCol))
            {
                GameBoardSquare nextSquare = CheckersGameControl.GameBoard.Square[nextAvailableStep.NextLine, nextAvailableStep.NextCol];

                if (nextSquare == null)
                {
                    if (IsInTheBoardLimits(nextAvailableStep.NextLine, nextAvailableStep.NextCol))
                    {
                        nextAvailableStep.CurrentLine = i_LastStep.CurrentLine;
                        nextAvailableStep.CurrentCol = i_LastStep.CurrentCol;

                        if (!m_IsReadyToEat)
                        {
                            m_IsReadyToEat = true;
                            r_AvailableMoves.Clear();
                            r_AvailableMoves.Add(nextAvailableStep);
                        }
                        else
                        {
                            r_AvailableMoves.Add(nextAvailableStep);
                        }
                    }
                }
                else
                {
                    CheckersGameControl.CheckForAnotherEating = false;
                }
            }
        }

        public bool IsInTheBoardLimits(int i_Line, int i_Col)
        {
            bool isInTheBoardLimit = true;
            if (i_Line < 0 || i_Line >= CheckersGameControl.BoardSize || i_Col < 0 || i_Col >= CheckersGameControl.BoardSize)
            {
                isInTheBoardLimit = false;
            }

            return isInTheBoardLimit;
        }

        public bool CheckIfPlayerMoveAppearsInList(SingleStep i_userStep)
        {
            bool appearsInList = false;
            foreach (SingleStep index in r_AvailableMoves)
            {
                appearsInList = i_userStep.CompareBetweenTwoSteps(index);
                if (appearsInList)
                {
                    break;
                }
            }

            return appearsInList;
        }

        public void GetEatableSquarePos(SingleStep i_UserMove, Player i_ActivePlayer, out int o_EatableLineSquare, out int o_EatableColSquare) // ToDo: split functions
        {
            int currLine = i_UserMove.CurrentLine;
            int currCol = i_UserMove.CurrentCol;
            int nextLine = i_UserMove.NextLine;
            int nextCol = i_UserMove.NextCol;

            if (nextCol - currCol == 2)
            {
                o_EatableColSquare = currCol + 1;
            }
            else
            {
                o_EatableColSquare = currCol - 1;
            }

            if (nextLine - currLine == 2)
            {
                o_EatableLineSquare = currLine + 1;
            }
            else
            {
                o_EatableLineSquare = currLine - 1;
            }
            
            m_IsReadyToEat = false;
            CheckersGameControl.CheckForAnotherEating = true;
        }

        public SingleStep GetRandomizeMove()
        {
            SingleStep computerStep = new SingleStep();
            Random movingListIndex = new Random();
            int ListLength = r_AvailableMoves.Count;
            int randomMoveIndex = movingListIndex.Next(ListLength);
            if (r_AvailableMoves.Count > 0)
            {
                computerStep = r_AvailableMoves[randomMoveIndex];
            }

            return computerStep;
        }
    }
}
