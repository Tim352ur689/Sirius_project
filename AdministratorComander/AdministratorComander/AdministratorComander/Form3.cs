using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdministratorComander
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            this.StartPosition = FormStartPosition.Manual;

            // Задаём координаты окна (например, X=100, Y=100)
            this.Location = new Point(100, 100);
            InitializeComponent();
        }

        private void enterbt_Click(object sender, EventArgs e)
        {

            
            if (chcb.SelectedItem != null && chcb.SelectedItem.ToString() == "Admin")
            {
                Form1 adm = new Form1();
                adm.Show();
                this.Hide();
            }
            else if(chcb.SelectedItem != null && chcb.SelectedItem.ToString() == "User")
            {
                Form4 adm = new Form4();
                adm.Show();
                this.Hide();
            }
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
