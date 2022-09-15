using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChassForm
{
    public partial class TipsForm : Form
    {
        public int whichButton { get; set; }
        public TipsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipsBoardForm tipsBoardForm= new TipsBoardForm(1);
            tipsBoardForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TipsBoardForm tipsBoardForm = new TipsBoardForm(4);
            tipsBoardForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TipsBoardForm tipsBoardForm = new TipsBoardForm(2);
            tipsBoardForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TipsBoardForm tipsBoardForm = new TipsBoardForm(3);
            tipsBoardForm.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            TipsBoardForm tipsBoardForm = new TipsBoardForm(5);
            tipsBoardForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TipsBoardForm tipsBoardForm = new TipsBoardForm(6);
            tipsBoardForm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
