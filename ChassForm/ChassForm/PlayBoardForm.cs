using ChassForm.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colors = ChassForm.Objects.Colors;

namespace ChassForm
{
    public partial class PlayBoardForm : Form
    {
        public int sizeOfCube = 55;
        public int offset = 30;
        GameTool[,] board = new GameTool[8, 8];
        Graphics graphics;
        List<Point> points;
        object objectLastClicked;
        Colors turn;
        public PlayBoardForm()
        {
            int indexGameools = 0;
            int indexPawns = 0;
            InitializeComponent();
            graphics = pictureBox1.CreateGraphics();
            List<GameTool> lstOfPawns = new List<GameTool>()
            {
                new Pawn("picturePawn1Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn2Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn3Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn4Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn5Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn6Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn7Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn8Black",Colors.black,picturePawn1Black.Image),
                new Pawn("picturePawn1White",Colors.white,picturePawn1White.Image),
                new Pawn("picturePawn2White",Colors.white,picturePawn1White.Image),
                new Pawn("picturePawn3White",Colors.white,picturePawn1White.Image),
                new Pawn("picturePawn4White",Colors.white,picturePawn1White.Image),
                new Pawn("picturePawn5White",Colors.white,picturePawn1White.Image),
                new Pawn("picturePawn6White",Colors.white,picturePawn1White.Image),
                new Pawn("picturePawn7White",Colors.white,picturePawn1White.Image),
                new Pawn("picturePawn8White",Colors.white,picturePawn1White.Image)
            };
            List<GameTool> lstOfGameTools = new List<GameTool>()
            {
                new Rook("pictureRookBlack",Colors.black,pictureRookBlack.Image),
                new Knight("pictureKnightBlack",Colors.black,pictureKnightBlack.Image),
                new Bishop("pictureBishopBlack",Colors.black, pictureBishopBlack.Image),
                new Queen("pictureQueenBlack",Colors.black, pictureQueenBlack.Image),
                new King("pictureKingBlack",Colors.black,pictureKnightBlack.Image),
                new Bishop("pictureBishop2Black",Colors.black, pictureBishop2Black.Image),
                new Knight("pictureKnight2Black",Colors.black,pictureKnight2Black.Image),
                new Rook("pictureRook2Black",Colors.black,pictureRook2Black.Image),
                new Rook("pictureRookWhite",Colors.white,pictureRookWhite.Image),
                new Knight("pictureKnightWhite",Colors.white,pictureKnightWhite.Image),
                new Bishop("pictureBishopWhite",Colors.white, pictureBishopWhite.Image),
                new Queen("pictureQueenWhite",Colors.white, pictureQueenWhite.Image),
                new King("pictureKingWhite",Colors.white,pictureKnightWhite.Image),
                new Bishop("pictureBishop2White",Colors.white, pictureBishop2White.Image),
                new Knight("pictureKnight2White",Colors.white,pictureKnight2White.Image),
                new Rook("pictureRook2White",Colors.white,pictureRook2White.Image)
            };

            for (int rows = 0; rows < board.GetLength(0); rows++)
            {

                if (rows == 0 || rows == 1 || rows == 6 || rows == 7)
                {
                    for (int cols = 0; cols < board.GetLength(1); cols++)
                    {
                        if (rows == 1 || rows == 6)
                        {
                            board[rows, cols] = lstOfPawns[indexPawns];
                            indexPawns++;
                        }
                        else
                        {
                            board[rows, cols] = lstOfGameTools[indexGameools];
                            indexGameools++;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void pictureRookBlack_Click(object sender, EventArgs e)
        {
            Refresh();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            int index = 1;
            points = new List<Point>();
            Point xy = pictureRookBlack.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 0 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 0] != null && board[1, 0].color == board[0, 0].color)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 0].Move(board[0, 0].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        for (int i = 1; i < points.Count; i += 2)
                        {
                            if (index < 8)
                            {
                                if (board[index, 0] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    break;
                                }
                                index++;
                            }
                        }
                        index = 1;
                        for (int j = 0; j < points.Count; j += 2)
                        {
                            if (index < 8)
                            {
                                if (board[0, index] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }

                                index++;
                            }
                        }
                    }
                }
                else
                {
                    int i, j;
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    index = tempY + 1;
                    for (i = 0; i < points.Count; i++)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index < 8)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    i++;
                                    break;
                                }
                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (i <= 2)
                    {
                        i = (8 - (tempY + 1)) * 2;
                    }
                    index = tempY - 1;
                    while (i < points.Count)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index >= 0)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else if (board[index, tempX].color == board[tempY, tempX].color)
                                {
                                    break;
                                }
                                index--;
                            }
                        }
                        i++;
                    }
                    index = tempX + 1;
                    for (j = 0; j < points.Count; j++)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index < 8)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    j++;
                                    break;
                                }

                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (j < 2)
                    {
                        j = (8 - (tempX + 1)) * 2;
                    }
                    index = tempX - 1;
                    while (j < points.Count)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index >= 0)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }

                                index--;
                            }
                        }
                        j++;
                    }
                }
            }

            points = pointsNew;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            int indexRow = 1, indexCol = 3;
            objectLastClicked = sender;
            Point xy = pictureBishopBlack.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 2 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 1] != null && board[1, 3] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 2].Move(board[0, 2].name, xy.X, xy.Y, sizeOfCube, true, offset);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                }
                for (int i = 1; i < points.Count; i += 2)
                {
                    if (indexRow < 8 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null)
                        {
                            graphics.DrawImage(pictureBishopBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                        indexCol++;
                    }
                }
                indexRow = 1;
                indexCol = 1;
                for (int i = 0; i < points.Count; i += 2)
                {
                    if (indexRow < 8 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null && points[i].X > 0)
                        {
                            graphics.DrawImage(pictureBishopBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                        indexCol++;
                    }
                }
                points = pointsNew;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn4Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 3 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 3] != null && board[3, 3] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[1, 3].Move(board[1, 3].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }
        }

        private void PlayBoardForm_Load(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            Point xy = Cursor.Position;
            if (xy.X / sizeOfCube == 0 && xy.Y / sizeOfCube == 0)
            {
                if (board[1, 0] != null)
                {
                    MessageBox.Show("you can not move this peace");
                    return;
                }
                else
                {
                    board[0, 0].Move(board[0, 0].name, xy.X, xy.Y, sizeOfCube, true, offset);
                }
            }
        }

        private void pictureRookWhite_Click(object sender, EventArgs e)
        {
            Refresh();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            int index = 6;
            points = new List<Point>();
            Point xy = pictureRookWhite.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 0 && xy.Y / sizeOfCube == 7)
                {
                    if (board[6, 0] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[7, 0].Move(board[7, 0].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        for (int i = 1; i < points.Count; i += 2)
                        {
                            if (index >= 0)
                            {
                                if (board[index, 0] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    break;
                                }
                                index--;
                            }
                        }
                        index = 1;
                        for (int j = 0; j < points.Count; j += 2)
                        {
                            if (index < 8)
                            {
                                if (board[0, index] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }

                                index++;
                            }
                        }
                    }
                }
                else
                {
                    int i, j;
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    index = tempY + 1;
                    for (i = 0; i < points.Count; i++)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index < 8)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    i++;
                                    break;
                                }
                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (i <= 2)
                    {
                        i = (8 - (tempY + 1)) * 2;
                    }
                    index = tempY - 1;
                    while (i < points.Count)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index >= 0)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else if (board[index, tempX].color == board[tempY, tempX].color)
                                {
                                    break;
                                }
                                index--;
                            }
                        }
                        i++;
                    }
                    index = tempX + 1;
                    for (j = 0; j < points.Count; j++)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index < 8)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    j++;
                                    break;
                                }

                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (j < 2)
                    {
                        j = (8 - (tempX + 1)) * 2;
                    }
                    index = tempX - 1;
                    while (j < points.Count)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index >= 0)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }

                                index--;
                            }
                        }
                        j++;
                    }
                }
            }
            points = pointsNew;
        }

        private void pictureRook2Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            List<Point> pointsNew = new List<Point>();
            int index = 1;
            points = new List<Point>();
            Point xy = pictureRook2Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 7 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 7] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 7].Move(board[0, 7].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        for (int i = 0; i < points.Count; i++)
                        {
                            if (index < 8)
                            {
                                if (board[index, 7] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    break;
                                }
                                index++;
                            }
                        }
                        index = 6;
                        for (int j = 0; j < points.Count; j++)
                        {
                            if (index > -1)
                            {
                                if (board[0, index] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }
                                index--;
                            }
                        }
                    }
                }
                else
                {
                    int i, j;
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    index = tempY + 1;
                    for (i = 0; i < points.Count; i++)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index < 8)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    i++;
                                    break;
                                }
                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    //if (i <= 2)
                    //{
                    //    i = (8 - (tempY + 1)) * 2;
                    //}
                    index = tempY - 1;
                    while (i < points.Count)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index >= 0)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else if (board[index, tempX].color == board[tempY, tempX].color)
                                {
                                    break;
                                }
                                index--;
                            }
                        }
                        i++;
                    }
                    index = tempX + 1;
                    for (j = 0; j < points.Count; j++)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index < 8)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    j++;
                                    break;
                                }

                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (j < 2)
                    {
                        j = (8 - (tempX + 1)) * 2;
                    }
                    index = tempX - 1;
                    while (j < points.Count)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index >= 0)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookBlack.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }

                                index--;
                            }
                        }
                        j++;
                    }
                }
            }
            points = pointsNew;
        }


        private void pictureRook2White_Click(object sender, EventArgs e)
        {
            Refresh();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            int index = 6;
            points = new List<Point>();
            Point xy = pictureRook2White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 7 && xy.Y / sizeOfCube == 7)
                {
                    if (board[6, 7] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[7, 7].Move(board[7, 7].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        for (int i = 1; i < points.Count; i += 2)
                        {
                            if (index >= 0)
                            {
                                if (board[index, 7] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    break;
                                }
                                index--;
                            }
                        }
                        index = 1;
                        for (int j = 0; j < points.Count; j += 2)
                        {
                            if (index < 8)
                            {
                                if (board[0, index] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }

                                index++;
                            }
                        }
                    }
                }
                else
                {
                    int i, j;
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    index = tempY + 1;
                    for (i = 0; i < points.Count; i++)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index < 8)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else
                                {
                                    i++;
                                    break;
                                }
                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (i <= 2)
                    {
                        i = (8 - (tempY + 1)) * 2;
                    }
                    index = tempY - 1;
                    while (i < points.Count)
                    {
                        if (points[i].X / sizeOfCube == tempX)
                        {
                            if (index >= 0)
                            {
                                if (board[index, tempX] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[i]);
                                    pointsNew.Add(points[i]);
                                }
                                else if (board[index, tempX].color == board[tempY, tempX].color)
                                {
                                    break;
                                }
                                index--;
                            }
                        }
                        i++;
                    }
                    index = tempX + 1;
                    for (j = 0; j < points.Count; j++)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index < 8)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    j++;
                                    break;
                                }

                                index++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (j < 2)
                    {
                        j = (8 - (tempX + 1)) * 2;
                    }
                    index = tempX - 1;
                    while (j < points.Count)
                    {
                        if (points[j].Y / sizeOfCube == tempY)
                        {
                            if (index >= 0)
                            {
                                if (board[tempY, index] == null)
                                {
                                    graphics.DrawImage(pictureRookWhite.Image, points[j]);
                                    pointsNew.Add(points[j]);
                                }
                                else
                                {
                                    break;
                                }

                                index--;
                            }
                        }
                        j++;
                    }
                }
            }
            points = pointsNew;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Refresh();
            PictureBox temp = (PictureBox)objectLastClicked;
            MouseEventArgs mouse = (MouseEventArgs)e;
            int cubeMouseX, cubeMouseY, cubePointX, cubePointY;
            cubeMouseX = (mouse.X - offset) / sizeOfCube;
            cubeMouseY = (mouse.Y - offset) / sizeOfCube;
            if (points != null && temp != null)
            {
                foreach (Point point in points)
                {
                    cubePointX = (point.X - offset) / sizeOfCube;
                    cubePointY = (point.Y - offset) / sizeOfCube;
                    if (cubeMouseX == cubePointX && cubeMouseY == cubePointY)
                    {
                        temp.Location = new Point(point.X + offset, point.Y + offset);
                        for (int row = 0; row < board.GetLength(0); row++)
                        {
                            for (int col = 0; col < board.GetLength(1); col++)
                            {
                                if (board[row, col] != null)
                                {
                                    if (temp.Name == board[row, col].name)
                                    {
                                        board[cubeMouseY, cubeMouseX] = board[row, col];
                                        board[row, col] = null;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void PlayBoardForm_Load_1(object sender, EventArgs e)
        {
            Refresh();
            turn = Colors.black;
        }

        private void pictureKnightBlack_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            Point xy = pictureKnightBlack.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 1 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 3] != null && board[2, 2] != null && board[2, 0] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 1].Move(board[0, 1].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        if (board[1, 3] == null)
                        {
                            graphics.DrawImage(pictureKnightBlack.Image, points[3]);
                            pointsNew.Add(points[3]);
                        }
                        if (board[2, 2] == null)
                        {
                            graphics.DrawImage(pictureKnightBlack.Image, points[1]);
                            pointsNew.Add(points[1]);
                        }
                        if (board[2, 0] == null)
                        {
                            graphics.DrawImage(pictureKnightBlack.Image, points[2]);
                            pointsNew.Add(points[2]);
                        }
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    if (board[tempY + 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[0]);
                        pointsNew.Add(points[0]);
                    }
                    if (board[tempY + 2, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[1]);
                        pointsNew.Add(points[1]);
                    }
                    if (board[tempY + 2, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[2]);
                        pointsNew.Add(points[2]);
                    }
                    if (board[tempY + 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[3]);
                        pointsNew.Add(points[3]);
                    }
                    if (board[tempY - 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[4]);
                        pointsNew.Add(points[4]);
                    }
                    if (board[tempY - 1, tempX - 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[5]);
                        pointsNew.Add(points[5]);
                    }
                    if (board[tempY - 2, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[6]);
                        pointsNew.Add(points[6]);
                    }
                    if (board[tempY - 2, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[7]);
                        pointsNew.Add(points[7]);
                    }
                }
            }
            points = pointsNew;
        }

        private void pictureKnight2Black_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            Point xy = pictureKnight2Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 6 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 4] != null && board[2, 7] != null && board[2, 5] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 6].Move(board[0, 6].name, xy.X, xy.Y, sizeOfCube, true, offset);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                }
                if (board[1, 4] == null)
                {
                    graphics.DrawImage(pictureKingBlack.Image, points[0]);
                    pointsNew.Add(points[0]);
                }
                if (board[2, 7] == null)
                {
                    graphics.DrawImage(pictureKingBlack.Image, points[1]);
                    pointsNew.Add(points[1]);
                }
                if (board[2, 5] == null)
                {
                    graphics.DrawImage(pictureKingBlack.Image, points[2]);
                    pointsNew.Add(points[2]);
                }
            }
            points = pointsNew;
        }

        private void picturePawn1Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn1Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 0 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 0] != null && board[3, 0] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[1, 0].Move(board[1, 0].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }
        }

        private void pictureQueenBlack_Click(object sender, EventArgs e)
        {
            Refresh();
            List<Point> pointsNew = new List<Point>();
            points = new List<Point>();
            int indexRow = 1, indexCol = 4;
            objectLastClicked = sender;
            Point xy = pictureQueenBlack.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 3 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 2] != null && board[1, 4] != null && board[1, 3] != null && board[0, 2] != null && board[0, 4] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 3].Move(board[0, 3].name, xy.X, xy.Y, sizeOfCube, true, offset);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                }
                for (int i = 1; i < points.Count; i += 4)
                {
                    if (indexRow < 8)
                    {
                        if (board[indexRow, 3] == null)
                        {
                            graphics.DrawImage(pictureQueenBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                    }
                }
                indexRow = 1;
                for (int i = 3; i < points.Count; i += 4)
                {
                    if (indexRow < 8 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null)
                        {
                            graphics.DrawImage(pictureQueenBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                        indexCol++;
                    }
                }
                indexRow = 1;
                indexCol = 2;
                for (int i = 0; i < points.Count; i += 4)
                {
                    if (indexRow < 8)
                    {
                        if (board[0, indexRow] == null)
                        {
                            graphics.DrawImage(pictureQueenBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                    }
                }
                indexRow = 1;
                for (int i = 2; i < points.Count; i += 4)
                {
                    if (indexRow < 8 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null && points[i].X > 0)
                        {
                            graphics.DrawImage(pictureQueenBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                        indexCol++;
                    }
                }
            }
            points = pointsNew;
        }

        private void pictureKingBlack_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            Point xy = pictureKingBlack.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 4 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 4] != null && board[1, 3] != null && board[1, 5] != null && board[0, 5] != null && board[0, 3] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 4].Move(board[0, 4].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        if (board[1, 4] == null)
                        {
                            graphics.DrawImage(pictureKingBlack.Image, points[0]);
                            pointsNew.Add(points[0]);
                        }
                        if (board[1, 3] == null)
                        {
                            graphics.DrawImage(pictureKingBlack.Image, points[1]);
                            pointsNew.Add(points[1]);
                        }
                        if (board[1, 5] == null)
                        {
                            graphics.DrawImage(pictureKingBlack.Image, points[2]);
                            pointsNew.Add(points[2]);
                        }
                        if (board[0, 5] == null)
                        {
                            graphics.DrawImage(pictureKingBlack.Image, points[3]);
                            pointsNew.Add(points[3]);
                        }
                        if (board[0, 3] == null)
                        {
                            graphics.DrawImage(pictureKingBlack.Image, points[4]);
                            pointsNew.Add(points[4]);
                        }
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    if (board[tempY + 1, tempX] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[0]);
                        pointsNew.Add(points[0]);
                    }
                    if (board[tempY + 1, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[1]);
                        pointsNew.Add(points[1]);
                    }
                    if (board[tempY + 1, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[2]);
                        pointsNew.Add(points[2]);
                    }
                    if (board[tempY, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[3]);
                        pointsNew.Add(points[3]);
                    }
                    if (board[tempY, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[4]);
                        pointsNew.Add(points[4]);
                    }
                    if (board[tempY - 1, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[5]);
                        pointsNew.Add(points[5]);
                    }
                    if (board[tempY - 1, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[6]);
                        pointsNew.Add(points[6]);
                    }
                    if (board[tempY - 1, tempX] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[7]);
                        pointsNew.Add(points[7]);
                    }

                }
            }
            points = pointsNew;
        }

        private void pictureBishop2Black_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            int indexRow = 1, indexCol = 6;
            objectLastClicked = sender;
            Point xy = pictureBishop2Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 5 && xy.Y / sizeOfCube == 0)
                {
                    if (board[1, 6] != null && board[1, 4] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[0, 5].Move(board[0, 5].name, xy.X, xy.Y, sizeOfCube, true, offset);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                }
                for (int i = 1; i < points.Count; i += 2)
                {
                    if (indexRow < 8 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null)
                        {
                            graphics.DrawImage(pictureBishopBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                        indexCol++;
                    }
                }
                indexRow = 1;
                indexCol = 4;
                for (int i = 0; i < points.Count; i += 2)
                {
                    if (indexRow < 8 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null)
                        {
                            graphics.DrawImage(pictureBishopBlack.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow++;
                        indexCol++;
                    }
                    if (points[i].X > offset && points[i].X < sizeOfCube)
                    {
                        graphics.DrawImage(pictureBishopBlack.Image, points[i]);
                        pointsNew.Add(points[i]);
                        break;
                    }
                }
            }
            points = pointsNew;

        }

        private void picturePawn8Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn8Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 7 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 7] != null && board[3, 7] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[1, 7].Move(board[1, 7].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }
        }

        private void picturePawn7Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn7Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 6 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 6] != null && board[3, 6] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[1, 6].Move(board[1, 6].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void picturePawn2Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn2Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 1 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 1] != null && board[3, 1] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[1, 1].Move(board[1, 1].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }
        }

        private void picturePawn3Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn3Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 2 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 2] != null && board[3, 2] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[1, 2].Move(board[1, 2].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }
        }

        private void picturePawn5Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn5Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 4 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 4] != null && board[3, 4] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                    }
                    else
                    {
                        points = board[1, 4].Move(board[1, 4].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }
        }

        private void picturePawn6Black_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            this.Invalidate();
            Point xy = picturePawn6Black.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.white)
            {
                turn = Colors.black;
                if (xy.X / sizeOfCube == 5 && xy.Y / sizeOfCube == 1)
                {
                    if (board[2, 5] != null && board[3, 5] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[1, 5].Move(board[1, 5].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1Black.Image, points[0]);
                        graphics.DrawImage(picturePawn1Black.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1Black.Image, points[0]);
                }
            }


        }

        private void picturePawn1White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn1White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 0 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 0] != null && board[4, 0] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 0].Move(board[6, 0].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void picturePawn2White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn2White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 1 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 1] != null && board[4, 1] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 1].Move(board[6, 1].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void picturePawn3White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn3White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 2 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 2] != null && board[4, 2] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 2].Move(board[6, 2].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void picturePawn4White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn4White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 3 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 3] != null && board[4, 3] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 3].Move(board[6, 3].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void picturePawn5White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn5White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 4 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 4] != null && board[4, 4] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 4].Move(board[6, 4].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void picturePawn6White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn6White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 5 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 5] != null && board[4, 5] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 5].Move(board[6, 5].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void picturePawn7White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn7White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 6 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 6] != null && board[4, 6] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 6].Move(board[6, 6].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void picturePawn8White_Click(object sender, EventArgs e)
        {
            Refresh();
            objectLastClicked = sender;
            points = new List<Point>();
            Point xy = picturePawn8White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 7 && xy.Y / sizeOfCube == 6)
                {
                    if (board[5, 7] != null && board[4, 7] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[6, 7].Move(board[6, 7].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        graphics.DrawImage(picturePawn1White.Image, points[0]);
                        graphics.DrawImage(picturePawn1White.Image, points[1]);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    graphics.DrawImage(picturePawn1White.Image, points[0]);
                }
            }
        }

        private void pictureKnightWhite_Click(object sender, EventArgs e)
        {

            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            Point xy = pictureKnightWhite.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 1 && xy.Y / sizeOfCube == 7)
                {
                    if (board[5, 0] != null && board[5, 2] != null && board[6, 3] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }

                    else
                    {
                        points = board[7, 1].Move(board[7, 1].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        if (board[5, 0] == null)
                        {
                            graphics.DrawImage(pictureKnightWhite.Image, points[7]);
                            pointsNew.Add(points[7]);
                        }
                        if (board[5, 2] == null)
                        {
                            graphics.DrawImage(pictureKnightWhite.Image, points[6]);
                            pointsNew.Add(points[6]);
                        }
                        if (board[6, 3] == null)
                        {
                            graphics.DrawImage(pictureKnightWhite.Image, points[4]);
                            pointsNew.Add(points[4]);
                        }
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    if (board[tempY + 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[0]);
                        pointsNew.Add(points[0]);
                    }
                    if (board[tempY + 2, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[1]);
                        pointsNew.Add(points[1]);
                    }
                    if (board[tempY + 2, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[2]);
                        pointsNew.Add(points[2]);
                    }
                    if (board[tempY + 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[3]);
                        pointsNew.Add(points[3]);
                    }
                    if (board[tempY - 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[4]);
                        pointsNew.Add(points[4]);
                    }
                    if (board[tempY - 1, tempX - 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[5]);
                        pointsNew.Add(points[5]);
                    }
                    if (board[tempY - 2, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[6]);
                        pointsNew.Add(points[6]);
                    }
                    if (board[tempY - 2, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[7]);
                        pointsNew.Add(points[7]);
                    }
                }
            }
            points = pointsNew;
        }

        private void pictureKnight2White_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            Point xy = pictureKnight2White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 6 && xy.Y / sizeOfCube == 7)
                {
                    if (board[5, 7] != null && board[5, 5] != null && board[6, 4] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }

                    else
                    {
                        points = board[7, 1].Move(board[7, 1].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        if (board[5, 7] == null)
                        {
                            graphics.DrawImage(pictureKnightWhite.Image, points[7]);
                            pointsNew.Add(points[7]);
                        }
                        if (board[5, 5] == null)
                        {
                            graphics.DrawImage(pictureKnightWhite.Image, points[6]);
                            pointsNew.Add(points[6]);
                        }
                        if (board[6, 4] == null)
                        {
                            graphics.DrawImage(pictureKnightWhite.Image, points[5]);
                            pointsNew.Add(points[5]);
                        }
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    if (board[tempY + 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[0]);
                        pointsNew.Add(points[0]);
                    }
                    if (board[tempY + 2, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[1]);
                        pointsNew.Add(points[1]);
                    }
                    if (board[tempY + 2, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[2]);
                        pointsNew.Add(points[2]);
                    }
                    if (board[tempY + 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[3]);
                        pointsNew.Add(points[3]);
                    }
                    if (board[tempY - 1, tempX + 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[4]);
                        pointsNew.Add(points[4]);
                    }
                    if (board[tempY - 1, tempX - 2] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[5]);
                        pointsNew.Add(points[5]);
                    }
                    if (board[tempY - 2, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[6]);
                        pointsNew.Add(points[6]);
                    }
                    if (board[tempY - 2, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKnightBlack.Image, points[7]);
                        pointsNew.Add(points[7]);
                    }
                }
            }
            points = pointsNew;
        }

        private void pictureBishopWhite_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            int indexRow = 6, indexCol = 3;
            objectLastClicked = sender;
            Point xy = pictureBishopWhite.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 2 && xy.Y / sizeOfCube == 7)
                {
                    if (board[6, 1] != null && board[6, 3] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[7, 2].Move(board[7, 2].name, xy.X, xy.Y, sizeOfCube, true, offset);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                }
                for (int i = 1; i < points.Count; i += 2)
                {
                    if (indexRow >= 0 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null)
                        {
                            graphics.DrawImage(pictureBishopWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                        indexCol++;
                    }
                }
                indexRow = 6;
                indexCol = 1;
                for (int i = 0; i < points.Count; i += 2)
                {
                    if (indexRow >= 0 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null && points[i].X > 0)
                        {
                            graphics.DrawImage(pictureBishopWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                        indexCol++;
                    }
                }
            }
            points = pointsNew;
        }

        private void pictureBishop2White_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            int indexRow = 6, indexCol = 6;
            objectLastClicked = sender;
            Point xy = pictureBishop2White.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 5 && xy.Y / sizeOfCube == 7)
                {
                    if (board[6, 4] != null && board[6, 6] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[7, 2].Move(board[7, 2].name, xy.X, xy.Y, sizeOfCube, true, offset);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                }
                for (int i = 1; i < points.Count; i += 2)
                {
                    if (indexRow >= 0 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null)
                        {
                            graphics.DrawImage(pictureBishopWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                        indexCol++;
                    }
                }
                indexRow = 6;
                indexCol = 4;
                for (int i = 0; i < points.Count; i += 2)
                {
                    if (indexRow >= 0 && indexCol >= 0)
                    {
                        if (board[indexRow, indexCol] == null && points[i].X > 0)
                        {
                            graphics.DrawImage(pictureBishopWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                        indexCol--;
                    }
                    if (points[i].X > offset && points[i].X < sizeOfCube)
                    {
                        graphics.DrawImage(pictureBishopWhite.Image, points[i]);
                        pointsNew.Add(points[i]);
                        break;
                    }
                }
                points = pointsNew;
            }
        }

        private void pictureKingWhite_Click(object sender, EventArgs e)
        {
            Refresh();
            points = new List<Point>();
            List<Point> pointsNew = new List<Point>();
            objectLastClicked = sender;
            Point xy = pictureKingWhite.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 4 && xy.Y / sizeOfCube == 7)
                {
                    if (board[6, 4] != null && board[6, 3] != null && board[6, 5] != null && board[7, 5] != null && board[7, 3] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[7, 4].Move(board[7, 4].name, xy.X, xy.Y, sizeOfCube, true, offset);
                        if (board[6, 4] == null)
                        {
                            graphics.DrawImage(pictureKingWhite.Image, points[7]);
                            pointsNew.Add(points[7]);
                        }
                        if (board[6, 3] == null)
                        {
                            graphics.DrawImage(pictureKingWhite.Image, points[6]);
                            pointsNew.Add(points[6]);
                        }
                        if (board[6, 5] == null)
                        {
                            graphics.DrawImage(pictureKingWhite.Image, points[5]);
                            pointsNew.Add(points[5]);
                        }
                        if (board[7, 5] == null)
                        {
                            graphics.DrawImage(pictureKingWhite.Image, points[3]);
                            pointsNew.Add(points[3]);
                        }
                        if (board[7, 3] == null)
                        {
                            graphics.DrawImage(pictureKingWhite.Image, points[4]);
                            pointsNew.Add(points[4]);
                        }
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                    if (board[tempY + 1, tempX] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[0]);
                        pointsNew.Add(points[0]);
                    }
                    if (board[tempY + 1, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[1]);
                        pointsNew.Add(points[1]);
                    }
                    if (board[tempY + 1, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[2]);
                        pointsNew.Add(points[2]);
                    }
                    if (board[tempY, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[3]);
                        pointsNew.Add(points[3]);
                    }
                    if (board[tempY, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[4]);
                        pointsNew.Add(points[4]);
                    }
                    if (board[tempY - 1, tempX + 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[5]);
                        pointsNew.Add(points[5]);
                    }
                    if (board[tempY - 1, tempX - 1] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[6]);
                        pointsNew.Add(points[6]);
                    }
                    if (board[tempY - 1, tempX] == null)
                    {
                        graphics.DrawImage(pictureKingBlack.Image, points[7]);
                        pointsNew.Add(points[7]);
                    }

                }
            }
            points = pointsNew;
        }

        private void pictureQueenWhite_Click(object sender, EventArgs e)
        {
            Refresh();
            List<Point> pointsNew = new List<Point>();
            points = new List<Point>();
            int indexRow = 6, indexCol = 4;
            objectLastClicked = sender;
            Point xy = pictureQueenWhite.Location;
            xy.X -= offset;
            xy.Y -= offset;
            if (turn == Colors.black)
            {
                turn = Colors.white;
                if (xy.X / sizeOfCube == 3 && xy.Y / sizeOfCube == 7)
                {
                    if (board[6, 2] != null && board[6, 4] != null && board[6, 3] != null && board[6, 2] != null && board[6, 4] != null)
                    {
                        MessageBox.Show("you can not move this peace");
                        return;
                    }
                    else
                    {
                        points = board[7, 3].Move(board[7, 3].name, xy.X, xy.Y, sizeOfCube, true, offset);
                    }
                }
                else
                {
                    int tempX, tempY;
                    tempX = xy.X / sizeOfCube;
                    tempY = xy.Y / sizeOfCube;
                    points = board[tempY, tempX].Move(board[tempY, tempX].name, xy.X, xy.Y, sizeOfCube, false, offset);
                }
                for (int i = 1; i < points.Count; i += 4)
                {
                    if (indexRow >= 0)
                    {
                        if (board[indexRow, 3] == null)
                        {
                            graphics.DrawImage(pictureQueenWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                    }
                }
                indexRow = 6;
                for (int i = 3; i < points.Count; i += 4)
                {
                    if (indexRow >= 0 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null)
                        {
                            graphics.DrawImage(pictureQueenWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                        indexCol++;
                    }
                }
                indexRow = 6;
                indexCol = 2;
                for (int i = 0; i < points.Count; i += 4)
                {
                    if (indexRow >= 0)
                    {
                        if (board[0, indexRow] == null)
                        {
                            graphics.DrawImage(pictureQueenWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                    }
                }
                indexRow = 6;
                for (int i = 2; i < points.Count; i += 4)
                {
                    if (indexRow >= 0 && indexCol < 8)
                    {
                        if (board[indexRow, indexCol] == null && points[i].X > 0)
                        {
                            graphics.DrawImage(pictureQueenWhite.Image, points[i]);
                            pointsNew.Add(points[i]);
                        }
                        else
                        {
                            break;
                        }
                        indexRow--;
                        indexCol++;
                    }
                }
            }
            points = pointsNew;
        }
    }
}

