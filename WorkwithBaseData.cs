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
    public partial class WorkwithBaseData : Form
    {
        private String dbFileName;
        private MySqlConnection m_dbConn;
        private MySqlCommand m_sqlCmd;
        private String[] bdtable = new String[13] { 
        "materials", "resources_used", "finding_materials", "final_products", "warehouses", "statuses_product",
            "orders", "specifications", "printers", "order_composition", "clients", "production_stages", "specification_composition"};
        private String[] dbtablecomposition = new String[8];
        private String[] dbtablevaluerows = new String[8] { "0","", "", "", "", "", "", ""};
        private int numberoftable = -1;
        private int flaguser = -1;
        public int getflaguser() { return flaguser; }
        public void setflaguser(int flaguser) { this.flaguser = flaguser; }
        EntryMenu entryMenu;
        TableSelection tableSelection;
        AddOrInsertValue addOrInsertValue;
        Report report;
        public WorkwithBaseData(EntryMenu entryMenu, TableSelection tableSelection)
        {
            dbFileName = "mydb";
            this.entryMenu = entryMenu;
            this.tableSelection = tableSelection;
            InitializeComponent();
            this.Text = "Элементы таблицы";
            try
            {
                m_dbConn = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=" + dbFileName);
                m_sqlCmd = new MySqlCommand("USE `mydb` ;");
                m_dbConn.Open();
                m_sqlCmd.Connection = m_dbConn;
                m_sqlCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void Read_Data()
        {
            DataTable dTable = new DataTable();
            String sqlQuery;

            MainTable.Columns.Clear();
            MainTable.Rows.Clear();
            //Проверка подключения к базе
            if (m_dbConn.State != System.Data.ConnectionState.Open) return;

            try
            {
                sqlQuery = "SELECT * FROM "+bdtable[numberoftable-1]+"";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                //Вывод столбцов
                dbtablecomposition[0] = dTable.Columns.Count.ToString();
                for (int i = 0; i < dTable.Columns.Count; i++)
                {
                    MainTable.Columns.Add(new DataGridViewTextBoxColumn() { Name = dTable.Columns[i].Caption });
                    dbtablecomposition[i + 1] = dTable.Columns[i].Caption;
                }
                //Вывод строк
                if (dTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dTable.Rows.Count; i++)
                        MainTable.Rows.Add(dTable.Rows[i].ItemArray);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public int getnumberoftable() { return numberoftable; }
        public void setnumberoftable(int numberoftable)
        {
            NameVarString.Text = "-";
            dbtablevaluerows[0] = "0";
            for (int i = 1; i < 8; i++) dbtablevaluerows[i] = "";
            if (numberoftable == -1)
                numberoftable = this.numberoftable;
            this.numberoftable = numberoftable;
            buttonorderreport.Visible = false;
            buttonadd.Visible = false;
            buttonchange.Visible = false;
            buttondelete.Visible = false;
            buttonadd.Enabled = true;
            buttonchange.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            NameVarString.Visible = false;
            buttondelete.Enabled = false;
            buttonorderreport.Enabled = false;
            buttonorderreport.Text = "Отчет о заказе";
            switch (numberoftable)
            {
                case 1:
                    switch (getflaguser())
                    {
                        case 1:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                        case 3:
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            break;
                        case 4:
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            break;
                    }
                    break;
                case 2:
                    if(getflaguser() == 3)
                    {
                        buttonadd.Visible = true;
                        buttonchange.Visible = true;
                        buttondelete.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        NameVarString.Visible = true;
                    }
                    break;
                case 3:
                    switch (getflaguser())
                    {
                        case 3:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                    }
                    break;
                case 4:
                    switch (getflaguser())
                    {
                        case 3:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                    }
                    break;
                case 5:
                    switch (getflaguser())
                    {
                        case 1:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                        case 3:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                    }
                    buttonorderreport.Visible = true;
                    buttonorderreport.Text = "Отчет о складе";
                    break;
                case 6:
                    switch (getflaguser())
                    {
                        case 3:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                    }
                    break;
                case 7:
                    switch (getflaguser())
                    {
                        case 1:
                            buttonorderreport.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                        case 2:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            buttonorderreport.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                    }
                    break;
                case 8:
                    if (getflaguser() == 3)
                    {
                        buttonadd.Visible = true;
                        buttonchange.Visible = true;
                        buttondelete.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        NameVarString.Visible = true;
                    }
                    else if (getflaguser() == 2)
                    {
                        buttonadd.Visible = true;
                        buttonchange.Visible = true;
                        buttondelete.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        NameVarString.Visible = true;
                    }
                    break;
                case 9:
                    switch (getflaguser())
                    {
                        case 1:
                            buttonadd.Visible = true;
                            buttonchange.Visible = true;
                            buttondelete.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                        case 3:
                            buttonchange.Visible = true;
                            label1.Visible = true;
                            label2.Visible = true;
                            NameVarString.Visible = true;
                            break;
                    }
                    break;
                case 10:
                    if (getflaguser() == 2)
                    {
                        buttonadd.Visible = true;
                        buttonchange.Visible = true;
                        buttondelete.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        NameVarString.Visible = true;
                    }
                    break;
                case 11:
                    if (getflaguser() == 2)
                    {
                        buttonadd.Visible = true;
                        buttonchange.Visible = true;
                        buttondelete.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        NameVarString.Visible = true;
                    }
                    break;
                case 12:
                    if (getflaguser() == 3)
                    {
                        buttonadd.Visible = true;
                        buttonchange.Visible = true;
                        buttondelete.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        NameVarString.Visible = true;
                    }
                    break;
                case 13:
                    if (getflaguser() == 2)
                    {
                        buttonadd.Visible = true;
                        buttonchange.Visible = true;
                        buttondelete.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        NameVarString.Visible = true;
                    }
                    break;
            }
            if(numberoftable!=-1)
                Read_Data();
        }
        
        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableSelection.enty(getflaguser());
            tableSelection.Visible = true;
            setnumberoftable(-1);
            m_dbConn.Close();
            if (addOrInsertValue != null)
                addOrInsertValue.Close();
            if (report != null)
                report.Close();
            this.Close();
        }
        public bool UseSQLCode(String presqlQuery,String sqlQuery)
        {
            try
            {
                m_sqlCmd.CommandText = presqlQuery+" "+ bdtable[numberoftable - 1]+" " + sqlQuery;
                m_sqlCmd.ExecuteNonQuery();
                Read_Data();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return true;
            }
            return false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableSelection.Visible = true;
            setnumberoftable(-1);
            tableSelection.enty(-1);
            tableSelection.Close();
            entryMenu.Visible = true;
            if(addOrInsertValue!=null)
                addOrInsertValue.Close();
            if (report != null)
                report.Close();
            m_dbConn.Close();
            this.Close();
        }
        private void MainTable_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (MainTable.CurrentCellAddress.Y < MainTable.Rows.Count-1)
            {
                dbtablevaluerows[0] = MainTable.CurrentCellAddress.Y.ToString();
                NameVarString.Text = (MainTable.CurrentCellAddress.Y + 1).ToString();
                for (int i = 0; i < Int32.Parse(dbtablecomposition[0]); i++)
                {
                    dbtablevaluerows[i + 1] = MainTable.Rows[MainTable.CurrentCellAddress.Y].Cells[i].Value.ToString();
                }
                if (report != null)
                    report.Close();
                buttonchange.Enabled = true;
                buttondelete.Enabled = true;
                if ((getflaguser() == 1 || getflaguser() == 2) && ((dbtablevaluerows[4]!=" ") &&(dbtablevaluerows[4]!=" ")&&(dbtablevaluerows[4]!="")))
                    buttonorderreport.Enabled = true;
                else if(numberoftable == 5)
                    buttonorderreport.Enabled = true;
                else
                    buttonorderreport.Enabled = false;
            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            try
            {
                m_sqlCmd.CommandText = "DELETE FROM "+bdtable[numberoftable-1]+"  WHERE " ;
                for (int i = 1; i < Int32.Parse(dbtablecomposition[0])+1; i++)
                {
                    if(i==1)
                        m_sqlCmd.CommandText += dbtablecomposition[i] + "=\'" + dbtablevaluerows[i]+"\'";
                    else
                        m_sqlCmd.CommandText += " AND "+ dbtablecomposition[i] + "=\'" + dbtablevaluerows[i]+"\'";
                }
                m_sqlCmd.CommandText += ";";
                m_sqlCmd.ExecuteNonQuery();
                Read_Data();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            if (report != null)
                report.Close();
            NameVarString.Text = "-";
            buttonchange.Enabled = false;
            buttondelete.Enabled = false;
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setnumberoftable(numberoftable);
            Read_Data();
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            addOrInsertValue = new AddOrInsertValue(this, dbtablecomposition, dbtablevaluerows);
            addOrInsertValue.FlagAddOrInsert(0);
            if (report != null)
                report.Close();
            addOrInsertValue.Show();
            buttonadd.Enabled = false;
            buttonchange.Enabled = false;
            buttondelete.Enabled = false;
        }

        private void buttonchange_Click(object sender, EventArgs e)
        {
            addOrInsertValue = new AddOrInsertValue(this, dbtablecomposition, dbtablevaluerows);
            addOrInsertValue.FlagAddOrInsert(1);
            if (report != null)
                report.Close();
            addOrInsertValue.Show();
            buttonadd.Enabled = false;
            buttonchange.Enabled = false;
            buttondelete.Enabled = false;
        }

        private void buttonorderreport_Click(object sender, EventArgs e)
        {
            if(numberoftable == 5)
            {
                if (dbtablevaluerows[3] == "Полуфабрикаты" || dbtablevaluerows[3] == "Материалы")
                {
                    report = new Report(m_dbConn, m_sqlCmd, 1, dbtablevaluerows[1]);
                    report.Show();
                }
                else if(dbtablevaluerows[3] == "Готовая продукция")
                {
                    report = new Report(m_dbConn, m_sqlCmd, 2, dbtablevaluerows[1]);
                    report.Show();
                }
            }
            else
            {
                //MessageBox.Show(dbtablevaluerows[4]);
                report = new Report(m_dbConn, m_sqlCmd, 0, dbtablevaluerows[1]);
                report.Show();
            }
        }
    }
}
