using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Mine_sweeper
{
    public partial class Form1 : Form
    {
        private const string noBombs = "0";
        private const string wingdings = "Wingdings 2";
        private const string calibri = "Calibri";
        private const string bomb = "8";
        private const string flag = "U";
        public bool DisableButtons;
        List<Coordinate> bombs = new List<Coordinate>();
        List<Button> buttons = new List<Button>();
        int row;
        int column;

        public Form1()
        {
            InitializeComponent();
            button_placement();
            bomb_placement();
            numberplacement();
        }
        void button_placement()
        {

            var toppad = 145;
            var pad = 2;
            var s = 30;
            for (int i = 0; i < 20; i++)
            {
                var x = (s + pad) * i;

                for (int j = 0; j < 20; j++)
                {
                    var y = (s + pad) * j + toppad;

                    var button = new Button();
                    button.Location = new Point(x, y);
                    button.Size = new Size(s, s);
                    button.Text = "";
                    button.BackColor = Color.CornflowerBlue;
                    button.Font = new Font(wingdings, 12F);
                    button.TextAlign = ContentAlignment.MiddleCenter;
                    button.MouseDown += Button_MouseDown;
                    button.FlatStyle = FlatStyle.Popup;

                    button.Tag = new Coordinate()
                    {
                        X = i,
                        Y = j,
                    };
                    Controls.Add(button);
                    buttons.Add(button);
                }
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (DisableButtons)
            {
                return;
            }
            if (!(sender is Button button))
            {
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                if (button.Text == flag)
                {
                    button.Text = (button.Tag as Coordinate).OriginalText;
                    button.Font = new Font(calibri, 12F);
                    button.ForeColor = button.BackColor;
                    if (button.Text == bomb)
                    {
                        button.Font = new Font(wingdings, 12F);
                    }
                }
                else if (button.BackColor == Color.Gray)
                {
                    return;
                }
                else
                {
                    (button.Tag as Coordinate).OriginalText = button.Text;
                    button.Font = new Font(wingdings, 12F);
                    button.ForeColor = Color.Black;
                    button.Text = flag;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (button.Text == flag)
                {
                    return;
                }
                else
                {
                    var buttons = sender as Button;
                    if (buttons != null)
                    {
                        var coord = buttons.Tag as Coordinate;
                        if (coord != null)
                        {
                            row = coord.X;
                            column = coord.Y;
                        }
                    }
                    if (button.Text == flag && (button.Tag as Coordinate).OriginalText == noBombs)
                    {
                        
                    }
                    button.ForeColor = Color.Black;
                    button.BackColor = Color.Gray;
                    numberis0();
                }
                if (button.Text == bomb)
                {
                    HitaBomb();
                }
            }
        }

        void bomb_placement()
        {
            var rand = new Random();
            for (int i = 0; i < 70; i++)
            {
                while (true)
                {
                    var newCoord = new Coordinate()
                    {
                        X = rand.Next(20),
                        Y = rand.Next(20)
                    };

                    bool invalid = bombs.Any(c => c.X == newCoord.X && c.Y == newCoord.Y);
                    if (invalid)
                    {
                        continue;
                    }
                    else
                    {
                        Debug.WriteLine($"Bomb {i + 1}: X = {newCoord.X}, Y = {newCoord.Y}");
                        bombs.Add(newCoord);
                        break;
                    }
                }
            }
            for (int i = 0; i < 70; i++)
            {
                foreach (var button in buttons)
                {
                    if (button.Tag is Coordinate p)
                    {
                        if (p.X == bombs[i].X && p.Y == bombs[i].Y)
                        {
                            p.OriginalText = button.Text = bomb;
                            button.ForeColor = button.BackColor;
                        }
                    }
                }
            }
        }
        private void numberplacement()
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (IsBombAt(x, y))
                    {
                        continue;
                    }

                    var button = GetButton(x, y);
                    int bombCount = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }

                            if (IsBombAt(x + i, y + j))
                            {
                                bombCount++;
                            }
                        }
                    }

                    button.Font = new Font(calibri, 12F);
                    button.Text = bombCount.ToString();
                    (button.Tag as Coordinate).OriginalText = button.Text;
                    button.ForeColor = button.BackColor;
                }
            }
        }
        private void numberis0()
        {
            var ButtonstoCheck = new List<Coordinate>();
            ButtonstoCheck.Add(new Coordinate() { X = row, Y = column });

            var ButtonsChecked = new List<Coordinate>();

            var index = 0;

            while (index < ButtonstoCheck.Count)
            {
                var coord = ButtonstoCheck[index];
                index++;

                var button = GetButton(coord.X, coord.Y);

                if (button.Text == noBombs)
                {

                    var focusX = (button.Tag as Coordinate).X;
                    var focusY = (button.Tag as Coordinate).Y;

                    button.Text = "";

                    ButtonsChecked.Add(button.Tag as Coordinate);
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            button.ForeColor = Color.Black;
                            button.BackColor = Color.Gray;
                            if (GetButton(focusX + x, focusY + y) is Button button2)
                            {
                                button2.ForeColor = Color.Black;
                                button2.BackColor = Color.Gray;
                                if (button2.Text == flag)
                                {
                                    button2.Text = (button2.Tag as Coordinate).OriginalText;
                                }

                                if (button2.Text == noBombs)
                                {
                                    AddtoCheck(ButtonstoCheck, button2.Tag as Coordinate);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void AddtoCheck(List<Coordinate> list, Coordinate coord)
        {
            bool contains = false;

            foreach (var existing in list)
            {
                if (existing.X == coord.X && existing.Y == coord.Y)
                {
                    contains = true;
                    break;
                }
            }
            if (!contains)
            {
                list.Add(coord);
            }
        }

        private bool IsBombAt(int x, int y)
        {
            foreach (var item in bombs)
            {
                if (item.X == x && item.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private Button GetButton(int x, int y)
        {

            foreach (var button in buttons)
            {
                if (button.Tag is Coordinate c && c.X == x && c.Y == y)
                {
                    return button;
                }
            }
            return null;
        }
        private void HitaBomb()
        {
            DisableButtons = true;
            foreach (var button in buttons)
            {
                if (button.Text == flag)
                {
                    if (button.Text == "" || button.BackColor == Color.Gray)
                    {
                        return;
                    }
                    button.Text = (button.Tag as Coordinate).OriginalText;
                    button.Font = new Font(calibri, 12F);
                    button.ForeColor = button.BackColor;
                }
                if ((button.Tag as Coordinate).OriginalText == bomb)
                {
                    button.Text = (button.Tag as Coordinate).OriginalText;
                    button.Font = new Font(wingdings, 12F);

                    button.ForeColor = Color.Black;
                    button.BackColor = Color.Red;
                }
            }
        }

        private void boxColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var buttoncolor = colorDialog1.Color;
                for (int x = 0; x < 20; x++)
                {
                    for (int y = 0; y < 20; y++)
                    {
                        var button = GetButton(x, y);
                        if (button.BackColor != Color.Gray || button.ForeColor != Color.Black)
                        {
                            button.ForeColor = colorDialog1.Color;
                            button.BackColor = colorDialog1.Color;
                        }
                    }
                }
            }

        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                
            }
        }
    }
}