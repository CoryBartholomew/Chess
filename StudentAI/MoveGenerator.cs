using System.Collections.Generic;
using UvsChess;

namespace StudentAI
{
    public class MoveGenerator
    {
        public List<ChessMove> Moves { get; set; }

        public void GenerateMoves(ChessBoard board, ChessColor color)
        {
            Moves = new List<ChessMove>();
            for (int y = 0; y < ChessBoard.NumberOfRows; y++)
            {
                for (int x = 0; x < ChessBoard.NumberOfColumns; x++)
                {
                    if (color == ChessColor.White) // if play is white
                    {
                        if (board[x, y] > ChessPiece.Empty)
                        {
                            switch (board[x, y])
                            {
                                case ChessPiece.WhiteBishop:
                                    BishopMoves(board, x, y, color);
                                    break;
                                case ChessPiece.WhiteQueen:
                                    QueenMoves(board, x, y, color);
                                    break;
                                case ChessPiece.WhiteKing:
                                    break;
                                case ChessPiece.WhiteKnight:
                                    KnightMoves(board, x, y, color);
                                    break;
                                case ChessPiece.WhitePawn:
                                    PawnMoves(board, x, y, color);
                                    break;
                                case ChessPiece.WhiteRook:
                                    RookMoves(board, x, y, color);
                                    break;
                            }
                        }
                    }
                    else if ( color == ChessColor.Black)
                    {
                        switch (board[x, y])
                        {
                            case ChessPiece.BlackBishop:
                                BishopMoves(board, x, y, color);
                                break;
                            case ChessPiece.BlackQueen:
                                QueenMoves(board, x, y, color);
                                break;
                            case ChessPiece.BlackKing:
                                break;
                            case ChessPiece.BlackKnight:
                                KnightMoves(board, x, y, color);
                                break;
                            case ChessPiece.BlackPawn:
                                PawnMoves(board, x, y, color);
                                break;
                            case ChessPiece.BlackRook:
                                RookMoves(board, x, y, color);
                                break;
                        }
                    }
                }
            }
        }

        private void PawnMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            if (color == ChessColor.White)
            {
                if (x - 1 > 0 && board[x - 1, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y)));
                }
                if (y > 0 && x - 1 > 0 && board[x - 1, y - 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y - 1)));
                }
                if (y < ChessBoard.NumberOfColumns && x - 1 > 0 && board[x - 1, y + 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y + 1)));
                }
                if (x == 6 && board[x - 1, y] == ChessPiece.Empty && board[x - 2, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 2, y)));
                }
            }
            else
            {
                if (x < ChessBoard.NumberOfRows && board[x + 1, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y)));
                }
                if (y > 0 && x + 1 < ChessBoard.NumberOfRows && board[x + 1, y - 1] > ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y - 1)));
                }
                if (y < ChessBoard.NumberOfColumns && x + 1 < ChessBoard.NumberOfRows && board[x + 1, y + 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y + 1)));
                }
                if (x == 2 && board[x + 1, y] == ChessPiece.Empty && board[x + 2, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 2, y)));
                }
            }
        }

        private void RookMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            ChessColor killColor = ChessColor.White;
            if (color == ChessColor.White)
            {
                killColor = ChessColor.Black;
            }

            for (int i = x + 1; i < ChessBoard.NumberOfRows; i++) // direction down
            {
                if (board[i, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, y)));
                }
                else
                {
                    if ((board[i, y] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, y] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, y)));
                    }
                    break;
                }

            }
            for (int i = x - 1; i > 0; i--) // direction up
            {
                if (board[i, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, y)));
                }
                else
                {
                    if ((board[i, y] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, y] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, y)));
                    }
                    break;
                }

            }
            for (int j = y - 1; j > 0; j--) // direction left
            {
                if (board[x, j] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                }
                else
                {
                    if ((board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                    }
                    break;
                }

            }
            for (int j = y + 1; j < ChessBoard.NumberOfColumns; j++) // direction right
            {
                if (board[x, j] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                }
                else
                {
                    if ((board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                    }
                    break;
                }

            }

        }

        private void KnightMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            ChessColor killColor = ChessColor.White;
            if (color == ChessColor.White)
            {
                killColor = ChessColor.Black;
            }
            int i = x - 2;
            int j = y - 1;
            //up left direction
            if (i > 0 && j > 0 && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }
            // up right direction
            j = y + 1;
            if (i > 0 && j < ChessBoard.NumberOfColumns && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }
            // right up direction
            j = y + 2;
            i = x - 1;
            if (i > 0 && j < ChessBoard.NumberOfColumns && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }
            // right down direction
            i = x + 1;
            if (i < ChessBoard.NumberOfRows && j < ChessBoard.NumberOfColumns && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }
            // down left direction
            i = x + 2;
            j = y - 1;
            if (i < ChessBoard.NumberOfRows && j > 0 && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }
            //down right direction
            j = y + 1;
            if (i < ChessBoard.NumberOfRows && j < ChessBoard.NumberOfColumns && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }
            // left up direction
            i = x - 2;
            j = y - 1;
            if (i > 0 && j > 0 && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }
            // left down direction
            j = y + 1;
            if (i > 0 && j < ChessBoard.NumberOfColumns && (board[x, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, j] < ChessPiece.Empty && killColor == ChessColor.Black))
            {
                Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
            }


        }

        private void BishopMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            ChessColor killColor = ChessColor.White;
            if (color == ChessColor.White)
            {
                killColor = ChessColor.Black;
            }
            int i = x - 1;
            int j = y - 1;
            while (i > 0 && j > 0) // up left direction
            {
                if (board[i, j] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
                }
                else
                {
                    if ((board[i, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, j] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                    }
                    break;
                }
                i--;
                j--;
            }
            while (i > 0 && j < ChessBoard.NumberOfColumns) // up rifht direction
            {
                if (board[i, j] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
                }
                else
                {
                    if ((board[i, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, j] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                    }
                    break;
                }
                i--;
                j++;
            }
            while (i < ChessBoard.NumberOfRows && j > 0) // down left direction
            {
                if (board[i, j] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
                }
                else
                {
                    if ((board[i, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, j] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                    }
                    break;
                }
                i++;
                j--;
            }
            while (i < ChessBoard.NumberOfRows && j < ChessBoard.NumberOfColumns) // up left direction
            {
                if (board[i, j] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(i, j)));
                }
                else
                {
                    if ((board[i, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, j] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                    }
                    break;
                }
                i++;
                j++;
            }
        }

        private void QueenMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            RookMoves(board, x, y, color);
            BishopMoves(board, x, y, color);
        }

        private void KingMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            if (color == ChessColor.White)
            {
                //king moves up
                if (x > 0 && (board[x - 1, y] == ChessPiece.Empty || board[x - 1, y] < ChessPiece.Empty))
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y)));
                }
                // king moves up and left
                if (y > 0 && x > 0 && (board[x - 1, y - 1] == ChessPiece.Empty || board[x - 1, y - 1] < ChessPiece.Empty))
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y - 1)));
                }
                // king moves up and right
                if (y < ChessBoard.NumberOfColumns && x > 0 && (board[x - 1, y + 1] == ChessPiece.Empty || board[x - 1, y + 1] < ChessPiece.Empty))
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y + 1)));
                }
                //king right moves
                if (y < ChessBoard.NumberOfColumns && (board[x, y + 1] == ChessPiece.Empty || board[x, y + 1] == ChessPiece.Empty))
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, y + 1)));
                }
                //king moves left
                if (y > 0 && (board[x, y - 1] < ChessPiece.Empty || board[x, y - 1] < ChessPiece.Empty))
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, y - 1)));
                }
                //king moves down and left
                if (y > 0 && x < ChessBoard.NumberOfRows && board[x + 1, y - 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y - 1)));
                }
                //king moves down
                if (x < ChessBoard.NumberOfRows && (board[x + 1, y] == ChessPiece.Empty || board[x + 1, y] < ChessPiece.Empty))
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y)));
                }
                //king moves down and right
                if (y < ChessBoard.NumberOfColumns && x < ChessBoard.NumberOfRows && (board[x + 1, y + 1] == ChessPiece.Empty || board[x + 1, y + 1] < ChessPiece.Empty))
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y + 1)));
                }
            }
            else
            {
                if (board[x + 1, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y)));
                }
                if (y > 0 && board[x + 1, y - 1] > ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y - 1)));
                }
                if (y < ChessBoard.NumberOfColumns && board[x + 1, y + 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y + 1)));
                }
                if (x == 2 && board[x + 1, y] == ChessPiece.Empty && board[x + 2, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 2, y)));
                }
            }
        }
    }
}

