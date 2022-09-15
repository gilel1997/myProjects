namespace ChassForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayBoardForm playBoardForm = new PlayBoardForm();
            playBoardForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TipsForm learnForm = new TipsForm();
            learnForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this project created by gil elazar");
            
        }
    }
}