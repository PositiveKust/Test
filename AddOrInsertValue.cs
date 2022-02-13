using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProgrammBaseData
{
    public partial class AddOrInsertValue : Form
    {
        private int flagAddOrInsert=-1;
        private String[] newvaluerow = new String[8];
        private String[] dbtablecomposition = new String[8];
        WorkwithBaseData workwith;
        private bool flagerror = false;
        public AddOrInsertValue(WorkwithBaseData workwith, String[] dbtablecomposition, String[] newvaluerow)
        {
            this.workwith = workwith;
            this.dbtablecomposition = dbtablecomposition;
            this.newvaluerow = newvaluerow;
            InitializeComponent();
        }
        public void FlagAddOrInsert(int flagAddOrInsert) { 
            this.flagAddOrInsert = flagAddOrInsert;
            MainTable.Columns.Clear();
            for (int i = 1; i < Int32.Parse(dbtablecomposition[0]) + 1; i++)
                MainTable.Columns.Add(new DataGridViewTextBoxColumn() { Name = dbtablecomposition[i] });
            if (flagAddOrInsert==0)
            {
                this.Text = "Добавить";
                mainbutton.Text = "Добавить";
                labelError.Text = "Введите нужные значения для добавления новой строки и нажмите \'Сохранить\'";
            }
            else if (flagAddOrInsert == 1)
            {
                for (int i = 0; i < Int32.Parse(dbtablecomposition[0]); i++)
                    MainTable.Rows[0].Cells[i].Value = newvaluerow[i+1];
                this.Text = "Изменить";
                mainbutton.Text = "Изменить";
                labelError.Text = "Измените нужные значения в строке и нажмите \'Изменить\'";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String presqlQuery=""; String sqlQuery="";
            if (flagAddOrInsert == 0)
            {
                presqlQuery = "INSERT INTO";
                sqlQuery = "("+dbtablecomposition[1]+"";
                for (int i = 1; i < Int32.Parse(dbtablecomposition[0]); i++)
                {
                    sqlQuery += ","+dbtablecomposition[i + 1]+"";
                }
                sqlQuery += ") values (\'"+ MainTable.Rows[0].Cells[0].Value.ToString()+"\'";
                for (int i = 1; i < Int32.Parse(dbtablecomposition[0]); i++)
                {
                    if (MainTable.Rows[0].Cells[i].Value == null)
                        MainTable.Rows[0].Cells[i].Value = " ";
                    sqlQuery += ",\'" + MainTable.Rows[0].Cells[i].Value.ToString() + "\'";
                }
                sqlQuery += ");";
                flagerror = workwith.UseSQLCode(presqlQuery, sqlQuery);
            }
            else if (flagAddOrInsert == 1)
            {
                presqlQuery = "UPDATE"; sqlQuery = "SET ";
                for (int i = 1; i < Int32.Parse(dbtablecomposition[0]) + 1; i++)
                {
                    if (i == 1)
                    {
                        if (MainTable.Rows[0].Cells[i-1].Value == null)
                            MainTable.Rows[0].Cells[i-1].Value = " ";
                        sqlQuery += dbtablecomposition[i] + "=\'" + MainTable.Rows[0].Cells[i - 1].Value.ToString() + "\'";
                    }
                    else
                        sqlQuery += " , " + dbtablecomposition[i] + "=\'" + MainTable.Rows[0].Cells[i - 1].Value.ToString() + "\'";
                }
                sqlQuery += " WHERE ";
                for (int i = 1; i < Int32.Parse(dbtablecomposition[0]) + 1; i++)
                {
                    if (i == 1)
                        sqlQuery += dbtablecomposition[i] + "=\'" + newvaluerow[i] + "\'";
                    else
                        sqlQuery += " AND " + dbtablecomposition[i] + "=\'" + newvaluerow[i] + "\'";
                }
                sqlQuery += ";";
                flagerror = workwith.UseSQLCode(presqlQuery, sqlQuery);
            }
            if (!flagerror)
            {

                workwith.setnumberoftable(-1);
                workwith.Read_Data();
                this.Close();
            }
            else
                labelError.Text += "\n Значения Введены неверно";
        }
    }
}
