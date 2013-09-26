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
                    if (color == ChessColor.White) // if player is white
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
                if (y - 1 > 0 && board[x , y - 1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x , y - 1)));
                }
                if (y  - 1 > 0 && x - 1 > 0 && board[x - 1, y - 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y - 1)));
                }
                if (y - 1  < ChessBoard.NumberOfColumns && x + 1 < ChessBoard.NumberOfRows && board[x + 1, y - 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y - 1)));
                }
                if (y == 6 && board[x, y - 1] == ChessPiece.Empty && board[x , y - 2] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, y - 2)));
                }
            }
            else
            {
                if (y + 1 < ChessBoard.NumberOfRows && board[x , y + 1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, y + 1)));
                }
                if (y + 1 < ChessBoard.NumberOfRows && x + 1 < ChessBoard.NumberOfColumns && board[x + 1, y + 1] > ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y + 1)));
                }
                if (y < ChessBoard.NumberOfColumns && x + 1 < ChessBoard.NumberOfRows && board[x + 1, y + 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x + 1, y + 1)));
                }
                if (y == 2 && board[x , y + 1] == ChessPiece.Empty && board[x , y + 2] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, y + 2)));
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

            for (int i = y + 1; i < ChessBoard.NumberOfRows; i++) // direction down
            {
                if (board[x, i] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, i)));
                }
                else
                {
                    if ((board[x, i] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, i] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, i)));
                    }
                    break;
                }

            }
            for (int i = y - 1; i >= 0; i--) // direction up
            {
                if (board[x, i] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, i)));
                }
                else
                {
                    if ((board[x, i] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x, i] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, i)));
                    }
                    break;
                }

            }
            for (int j = x - 1; j > 0; j--) // direction left
            {
                if (board[j, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(j, y)));
                }
                else
                {
                    if ((board[j, y] > ChessPiece.Empty && killColor == ChessColor.White) || (board[j, y] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(j, y)));
                    }
                    break;
                }

            }
            for (int j = x + 1; j < ChessBoard.NumberOfColumns; j++) // direction right
            {
                if (board[j, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(j,y)));
                }
                else
                {
                    if ((board[j, y] > ChessPiece.Empty && killColor == ChessColor.White) || (board[j, y] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(j, y)));
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
            int x1 = x - 1;
            int y1 = y - 2;
            //up left direction
            if ((x1 >= 0 && y1 >= 0 ))
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
                
            }
            // up right direction
            x1 = x + 1;
            if ((x1 < ChessBoard.NumberOfColumns && y1 >= 0 )  )
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
            }
            // right up direction
            y1 = y - 1;
            x1 = x + 2;
            if (x1 < ChessBoard.NumberOfColumns && y1 >= 0)
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
            }
            // right down direction
            y1 = y + 1;
            if (x1 < ChessBoard.NumberOfRows && y1 < ChessBoard.NumberOfColumns)
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
            }
            // down left direction
            x1 = x - 1;
            y1 = y + 2;
            if (x1 >= 0  && y1 < ChessBoard.NumberOfRows)
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
            }
            //down right direction
            x1 = x + 1;
            if (x1 < ChessBoard.NumberOfRows && y1 < ChessBoard.NumberOfColumns )
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
            }
            // left up direction
            x1 = x - 2;
            y1 = y - 1;
            if (x1 >= 0 && y1 >= 0 )
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
            }
            // left down direction
            y1 = y + 1;
            if (x1 >= 0 && y1 < ChessBoard.NumberOfColumns )
            {
                if ((board[x1, y1] > ChessPiece.Empty && killColor == ChessColor.White) || (board[x1, y1] < ChessPiece.Empty && killColor == ChessColor.Black) || board[x1, y1] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x1, y1)));
                }
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
                    if ((board[i, j] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, j] < ChessPiece.Empty && killColor == ChessColor.Black) )
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x, j)));
                    }
                    break;
                }
                i--;
                j--;
            }
            while (i > 0 && j < ChessBoard.NumberOfColumns) // up right direction
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
                i--;
                j++;
            }
            while (i < ChessBoard.NumberOfRows && j < ChessBoard.NumberOfColumns) // down right direction
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

