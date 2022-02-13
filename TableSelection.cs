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
    public partial class TableSelection : Form
    {
        private int flaguser = -1;
        private EntryMenu entryMenu = new EntryMenu();
        public TableSelection(EntryMenu entryMenu)
        {
            InitializeComponent();
            this.entryMenu = entryMenu;
            this.Text = "Выбор таблицы";
        }
        public int getflaguser() { return flaguser; }
        public void enty(int flaguser)
        {
            this.flaguser = flaguser;
            switch (this.flaguser)
            {
                case -1:
                    buttonfinishproduct.Enabled = false;
                    buttonClients.Enabled = false;
                    buttonordercomposition.Enabled = false;
                    buttonequipment.Enabled = false;
                    buttonfindingmaterial.Enabled = false;
                    buttonstatusfinishedproduct.Enabled = false;
                    buttonmaterial.Enabled = false;
                    buttonorders.Enabled = false;
                    buttonspecification.Enabled = false;
                    buttonusingmaterial.Enabled = false;
                    buttonwarehouse.Enabled = false;
                    buttonspecificationcomposition.Enabled = false;
                    buttonproductionstage.Enabled = false;
                    break;
                case 1:
                    buttonfinishproduct.Enabled = false;
                    buttonClients.Enabled = false;
                    buttonordercomposition.Enabled = false;
                    buttonequipment.Enabled = true;
                    buttonfindingmaterial.Enabled = false;
                    buttonstatusfinishedproduct.Enabled = false;
                    buttonmaterial.Enabled = true;
                    buttonorders.Enabled = true;
                    buttonspecification.Enabled = false;
                    buttonusingmaterial.Enabled = false;
                    buttonwarehouse.Enabled = true;
                    buttonspecificationcomposition.Enabled = false;
                    buttonproductionstage.Enabled = false;
                    break;
                case 2:
                    buttonfinishproduct.Enabled = true;
                    buttonClients.Enabled = true;
                    buttonordercomposition.Enabled = true;
                    buttonequipment.Enabled = false;
                    buttonfindingmaterial.Enabled = false;
                    buttonstatusfinishedproduct.Enabled = false;
                    buttonmaterial.Enabled = false;
                    buttonorders.Enabled = true;
                    buttonspecification.Enabled = true;
                    buttonusingmaterial.Enabled = false;
                    buttonwarehouse.Enabled = false;
                    buttonspecificationcomposition.Enabled = true;
                    buttonproductionstage.Enabled = false;
                    break;
                case 3:
                    buttonfinishproduct.Enabled = true;
                    buttonClients.Enabled = false;
                    buttonordercomposition.Enabled = true;
                    buttonequipment.Enabled = true;
                    buttonfindingmaterial.Enabled = true;
                    buttonstatusfinishedproduct.Enabled = true;
                    buttonmaterial.Enabled = true;
                    buttonorders.Enabled = true;
                    buttonspecification.Enabled = true;
                    buttonusingmaterial.Enabled = true;
                    buttonwarehouse.Enabled = true;
                    buttonspecificationcomposition.Enabled = true;
                    buttonproductionstage.Enabled = true;
                    break;
                case 4:
                    buttonfinishproduct.Enabled = false;
                    buttonClients.Enabled = false;
                    buttonordercomposition.Enabled = false;
                    buttonequipment.Enabled = false;
                    buttonfindingmaterial.Enabled = true;
                    buttonstatusfinishedproduct.Enabled = false;
                    buttonmaterial.Enabled = true;
                    buttonorders.Enabled = false;
                    buttonspecification.Enabled = false;
                    buttonusingmaterial.Enabled = false;
                    buttonwarehouse.Enabled = true;
                    buttonspecificationcomposition.Enabled = false;
                    buttonproductionstage.Enabled = false;
                    break;
                case 5:
                    buttonfinishproduct.Enabled = true;
                    buttonClients.Enabled = true;
                    buttonordercomposition.Enabled = false;
                    buttonequipment.Enabled = false;
                    buttonfindingmaterial.Enabled = false;
                    buttonstatusfinishedproduct.Enabled = false;
                    buttonmaterial.Enabled = false;
                    buttonorders.Enabled = true;
                    buttonspecification.Enabled = false;
                    buttonusingmaterial.Enabled = false;
                    buttonwarehouse.Enabled = true;
                    buttonspecificationcomposition.Enabled = false;
                    buttonproductionstage.Enabled = false;
                    break;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entryMenu.Visible = true;
            enty(-1);
            this.Close();
        }

        private void buttonmaterial_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(1);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonusingmaterial_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(2);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonfindingmaterial_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(3);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttomfinishproduct_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(4);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonwarehouse_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(5);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonfindingthefinishedproduct_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(6);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttondesign_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(10);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonproductionline_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(8);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonequipment_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(9);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonorders_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(7);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonClients_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(11);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonproductionstage_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(12);
            workwithBaseData.Show();
            this.Visible = false;
        }

        private void buttonspecificationcomposition_Click(object sender, EventArgs e)
        {
            WorkwithBaseData workwithBaseData = new WorkwithBaseData(entryMenu, this);
            workwithBaseData.setflaguser(getflaguser());
            workwithBaseData.setnumberoftable(13);
            workwithBaseData.Show();
            this.Visible = false;
        }
    }
}
