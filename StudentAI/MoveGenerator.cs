using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    if(color == ChessColor.White) // if play is white
                    {
                        if(board[x,y] > ChessPiece.Empty)
                        {
                            switch (board[x,y])
                            {
                                    case ChessPiece.WhiteBishop:
                                    break;
                                    case ChessPiece.WhiteQueen:
                                    break;
                                    case ChessPiece.WhiteKing:
                                    break;
                                    case ChessPiece.WhitePawn:
                                    PawnMoves(board,x,y,color);
                                    break;
                                    case ChessPiece.WhiteKnight:
                                    break;
                                    case ChessPiece.WhiteRook:
                                    RookMoves(board,x,y,color);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        private void PawnMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            if (color == ChessColor.White)
            {
                if(board[x - 1, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x,y), new ChessLocation(x - 1, y)));
                }
                if(y > 0 && board[x - 1, y -1] < ChessPiece.Empty) 
                {
                    Moves.Add(new ChessMove(new ChessLocation(x,y), new ChessLocation(x - 1, y - 1)));
                }
                if (y < ChessBoard.NumberOfColumns && board[x - 1, y + 1] < ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x, y), new ChessLocation(x - 1, y + 1)));
                }
                if(x == 6 && board[x -1, y] == ChessPiece.Empty && board[x - 2, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x,y),new ChessLocation(x - 2, y) ));
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

        private void RookMoves(ChessBoard board, int x, int y, ChessColor color)
        {
            ChessColor killColor = ChessColor.White;
            if(color == ChessColor.White)
            {
                killColor = ChessColor.Black;
            }
            
            for (int i = x + 1; i < ChessBoard.NumberOfRows; i++) // direction down
            {
                if(board[i, y] == ChessPiece.Empty)
                {
                    Moves.Add(new ChessMove(new ChessLocation(x,y),new ChessLocation(i, y)) );
                }
                else
                {
                    if ((board[i, y] > ChessPiece.Empty && killColor == ChessColor.White) || (board[i, y] < ChessPiece.Empty && killColor == ChessColor.Black))
                    {
                        Moves.Add(new ChessMove(new ChessLocation(x,y),new ChessLocation(i,y) ));
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
                if (board[x,j] == ChessPiece.Empty)
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
            for (int j = y + 1; j > 0; j++) // direction right
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

        private void KnightMoves(ChessBoard board, int x, int y)
        {

        }

        private void BishopMoves(ChessBoard board, int x, int y)
        {

        }

        private void QueenMoves(ChessBoard board, int x, int y)
        {

        }

        private void KingMoves(ChessBoard board, int x, int y)
        {

        }
    }
}
