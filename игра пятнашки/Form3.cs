using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace игра_пятнашки
{
    public partial class Form3 : Form
    {
        Game g;
        public Form3()
        {
            InitializeComponent();
            g = new Game(3);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            g.shift(position);
            refresh();
        }
        private Button button(int position)
        {
            switch (position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button4;
                case 4: return button5;
                case 5: return button6;
                case 6: return button8;
                case 7: return button9;
                case 8: return button10;
                default: return null;


            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            start_game();
        }

        private void начатьИгруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start_game();
        }
        private void start_game()
        {
            g.start();
            for (int j = 0; j < 100; j++)
                g.shift_random();
            refresh();
        }
        private void refresh()
        {
            for (int position = 0; position < 16; position++)
            {
                int nr = g.get_number(position);
                button(position).Text = nr.ToString();
                button(position).Visible = (nr > 0);

            }
            if (g.the_end() == true)
            {
                MessageBox.Show("ура победа!!", "ИГРА ОКОНЧЕНА");
            }
        }
    }
}
