using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammBaseData
{
    public partial class EntryMenu : Form
    {
        public EntryMenu()
        {
            InitializeComponent();
            this.Text = "Вход";
        }

        private void checkPasswordBox_CheckedChanged(object sender, EventArgs e)
        {
            if(checkPasswordBox.Checked == true)
            {
                PasswordBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordBox.UseSystemPasswordChar = true;
            }
        }

        private void Enterbutton_Click(object sender, EventArgs e)
        {
            TableSelection tableSelection = new TableSelection(this);
            switch (EntryWorkerBox.Text)
            {
                case "Оператор базы":
                    if(PasswordBox.Text == "777")
                    {
                        tableSelection.enty(1);
                        tableSelection.Show();
                        this.Visible = false;
                    }
                    break;
                case "Менеджер":
                    if (PasswordBox.Text == "333")
                    {
                        tableSelection.enty(2);
                        tableSelection.Show();
                        this.Visible = false;
                    }
                    break;
                case "Инженер":
                    if (PasswordBox.Text == "555")
                    {
                        tableSelection.enty(3);
                        tableSelection.Show();
                        this.Visible = false;
                    }
                    break;
                case "Сотрудник отдела снабжения":
                    if (PasswordBox.Text == "111")
                    {
                        tableSelection.enty(4);
                        tableSelection.Show();
                        this.Visible = false;
                    }
                    break;
                case "Сотрудник отдела сбыта":
                    if (PasswordBox.Text == "1212")
                    {
                        tableSelection.enty(5);
                        tableSelection.Show();
                        this.Visible = false;
                    }
                    break;
            }
        }
    }
}
