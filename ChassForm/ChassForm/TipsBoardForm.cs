using ChassForm.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChassForm
{
    public partial class TipsBoardForm : Form
    {
        TipsForm tipsForm;
        int cube = 55;
        int whichButton;
        int offset = 30;
        public TipsBoardForm(int num)
        {
            whichButton = num;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tipsForm = new TipsForm();
            tipsForm.Show();
            this.Hide();
        }

        private void TipsBoardForm_Load(object sender, EventArgs e)
        {
            List<Peace> peaces = new List<Peace>();
            DBHender dBHender = new DBHender();
            peaces = dBHender.GetPeaces(whichButton);
            DrawPeaces(peaces);

        }

        private void DrawPeaces(List<Peace> peaces)
        {
            foreach (Peace peace in peaces)
            {
                if (peace.locationX != -1 && peace.locationY != -1)
                {
                    PictureBox picture = new PictureBox();
                    picture.Image = Image.FromFile(peace.picture);
                    if (peace.locationX == 0)
                    {
                        picture.Location = new Point(cube - 10, (peace.locationY + 1) * cube - 10);
                    }
                    else if (peace.locationY == 0)
                    {
                        picture.Location = new Point((peace.locationX + 1) * cube - 10, cube - 10);

                    }
                    else
                    {
                        picture.Location = new Point((peace.locationX + 1) * cube - 10, (peace.locationY + 1) * cube - 10);
                    }
                    picture.Bounds = new Rectangle(picture.Location.X, picture.Location.Y, cube - 10, picture.Height - 10);
                    picture.BackColor = Color.Transparent;
                    pictureBox1.Controls.Add(picture);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (whichButton)
            {
                case 1:
                    {
                        string text = "בתור פתיחה הדרך הכי טובה זה להביא כמה שיותר כלים למרכז למשל החייל שמול המלך יילך בהצלחה שני צעדים פנימה, אחרי זה להביא את הפרשים למרכז והצד הבא יהיה לשחרר את הרצים";
                        MessageBox.Show(text);
                    }
                    break;
                case 2:
                    {
                        string text = "מט סנדלרים(מט ב-4מהלכים) קודם כל להזיז את החייל של המלך שני צעדים קדימה לאחר מכן להזיז את הרץ עד שהוא מאיים על החייל שליד המלך ואז להזיז את המלכה שמאייימת על אותו החייל ואז את המלכה פנימה ואז הוא תקוע בלי אפשרות לזוז";
                        MessageBox.Show(text);
                    }
                    break;
                case 3:
                    {
                        string text = "גמביט הוא מושג בשחמט, המתאר הקרבת חומר (כלומר כלים) בפתיחת המשחק (לרוב על ידי הלבן), במטרה להשיג יתרון עמדתי על לוח המשחק, בדרך כלל על ידי עיכוב פיתוח הכלים של היריב או שליטה חזקה במרכז";
                        MessageBox.Show(text);
                    }
                    break;
                case 4:
                    {
                        string text = "מט טיפשים (המט השחור) הוא המט המהיר ביותר האפשרי במשחק שחמט. במט הטיפש קיים מט במסע השני. המט יכול להיות מושג בעקבות טעות חמורה של השחקן הלבן או בעקבות שיתוף פעולה בין השחקנים במטרה לתת מט ללבן";
                        MessageBox.Show(text);
                    }
                    break;
                case 5:
                    {
                        string text = "בשחמט, מט חנק הוא סוג של מט שבו המלך אינו יכול לברוח כי הוא מוקף על ידי כלים מהצבע שלו, ועליו מאיים פרש ואי אפשר להכות את הפרש. מט חנק מבוצע על ידי פרש בלבד, כי הוא היחיד שיכול לדלג מעל הכלים שחוסמים את המלך";
                        MessageBox.Show(text);
                    }
                    break;
                case 6:
                    {
                        string text = "מט לגל או מלכודת בלקברן היא מלכודת בשלב הפתיחה של משחק השחמט, ידועה בגלל הקרבת מלכה וביצוע מט עם כלים קלים אם השחור מקבל את ההקרבה";
                        MessageBox.Show(text);
                    }
                    break;
            }

        }
    }
}
