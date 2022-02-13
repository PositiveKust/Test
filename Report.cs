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
    public partial class Report : Form
    {
        private MySqlConnection m_dbConn;
        private MySqlCommand m_sqlCmd;
        private int flagreport = -1;
        private String idWarehouseOrOrder = "";
        private String nameMaterial = "";
        private bool flagreportmaterial = false;
        
        public Report(MySqlConnection m_dbConn, MySqlCommand m_sqlCmd, int flagreport, String idWarehouseOrOrder)
        {
            this.m_dbConn = m_dbConn;
            this.m_sqlCmd = m_sqlCmd;
            this.flagreport = flagreport;
            this.idWarehouseOrOrder += idWarehouseOrOrder;
            InitializeComponent();
            Read_Data("");
        }

        private void Read_Data(String sqlQuery)
        {
            DataTable dTable = new DataTable();

            MainTable.Columns.Clear();
            MainTable.Rows.Clear();
            //Проверка подключения к базе
            if (m_dbConn.State != System.Data.ConnectionState.Open) return;

            try
            {
                MySqlDataAdapter adapter;
                if (sqlQuery == "")
                {
                    flagreportmaterial = false;
                    if (flagreport == 1)
                    {
                        this.Text = "Отчет о складе для материалов/полуфабрикатов с id = "+idWarehouseOrOrder;
                        sqlQuery = "SELECT materials.name AS \'Название материала/полуфабриката\',  ";
                        sqlQuery += "finding_materials.quantity_material AS \'Количество на складе\'\n";
                        sqlQuery += "FROM materials INNER JOIN finding_materials ON material_id = materials.id\n";
                        sqlQuery += " INNER JOIN warehouses ON warehous_id = warehouses.id\n";
                        sqlQuery += " WHERE warehous_id = \'" + idWarehouseOrOrder + "\';";
                    }
                    else if (flagreport == 2)
                    {
                        /*sqlQuery = "SELECT warehouses.name FROM warehouses WHERE warehouses.id = \'"+idWarehouseOrOrder+"\'";
                        adapter = new MySqlDataAdapter(sqlQuery, m_dbConn);
                        adapter.Fill(dTable);*/
                        this.Text = "Отчет о складе для готовой продукции c id = " + idWarehouseOrOrder;
                        sqlQuery = "SELECT final_products.name AS \'Название готового продукта\', COUNT(final_products.name) AS \'Количество на складе\', statuses_product.name AS \'Состояние продукта\'";
                        sqlQuery += " FROM final_products INNER JOIN warehouses ON final_products.warehouses_id = warehouses.id INNER JOIN statuses_product ON final_products.statuses_Product_id = statuses_product.id";
                        sqlQuery += " WHERE warehouses.id = \'" + idWarehouseOrOrder + "\' AND (final_products.order_Composition_id='3' OR final_products.order_Composition_id='4') GROUP BY final_products.statuses_Product_id, final_products.name;";
                    }
                    else if(flagreport == 0)
                    {
                        sqlQuery = "SELECT final_products.name AS \'Название готового продукта\', order_composition.final_quantity AS \'Планируемое количество изготавливаемой продукции\', COUNT( final_products.name) AS \'Всего изготовлено продукции\'";
                        this.Text = "Отчет о завершенном заказе с id = " + idWarehouseOrOrder;
                        //sqlQuery = "SELECT final_products.name AS \'Название готовой продукции\', statuses_product.name AS \'Статус готовой продукции\', COUNT(final_products.name) AS \'Общее количество\' FROM final_products";
                        //sqlQuery += " INNER JOIN statuses_product ON final_products.statuses_Product_id = statuses_product.id INNER JOIN order_composition";
                        sqlQuery += " FROM final_products INNER JOIN order_composition ON order_composition.id = final_products.order_Composition_id WHERE order_composition.orders_id = \'" + idWarehouseOrOrder + "\' GROUP BY final_products.name;";
                    }
                }
                adapter = new MySqlDataAdapter(sqlQuery, m_dbConn);
                adapter.Fill(dTable);
                //Вывод столбцов
                for (int i = 0; i < dTable.Columns.Count; i++)
                {
                    MainTable.Columns.Add(new DataGridViewTextBoxColumn() { Name = dTable.Columns[i].Caption });
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

        private void MainTable_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((MainTable.CurrentCellAddress.Y < MainTable.Rows.Count - 1) && (flagreportmaterial == false) && (flagreport == 0))
            {
                nameMaterial = MainTable.Rows[MainTable.CurrentCellAddress.Y].Cells[0].Value.ToString();
                buttonnextorback.Visible = true;
                buttonnextorback.Text = "Подробнее о " + nameMaterial;
                buttonnextorback.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tempstr = ""; int allprice = 0;
            if (!flagreportmaterial && nameMaterial != "")
            {
                flagreportmaterial = true;
                tempstr = "SELECT materials.name AS \'Название готового продукта\', (COUNT( final_products.name)*resources_used.quantity_resources_used) AS \'Всего затрачено\', ((COUNT( final_products.name)-order_composition.final_quantity)*resources_used.quantity_resources_used) AS \'Дополнительно затраченный материал из-за брака\', (materials.price*(COUNT( final_products.name)-order_composition.final_quantity)*resources_used.quantity_resources_used) AS \'Дополнительная цена материала\'\n";
                tempstr += "FROM materials INNER JOIN specification_composition ON specification_composition.materials_id = materials.id INNER JOIN specifications ON specifications.id = specification_composition.specifications_id INNER JOIN production_stages ON production_stages.specifications_id = specifications.id INNER JOIN order_composition ON order_composition.specifications_id = specifications.id INNER JOIN final_products ON final_products.specifications_id = specifications.id AND final_products.order_Composition_id = order_composition.id INNER JOIN resources_used ON resources_used.specification_Composition_id = specification_composition.id AND resources_used.production_Stages_id = production_stages.id\n";
                tempstr += " WHERE order_composition.orders_id = \'" + idWarehouseOrOrder + "\' AND final_products.name = \'"+nameMaterial+ "\' GROUP BY materials.name, production_stages.id, specification_composition.id";
                Read_Data(tempstr);
                buttonnextorback.Text = "Назад";
                labelWarehous1.Visible = true;
                for (int i = 0; i < MainTable.Rows.Count-1; i++)
                {
                    allprice += Int32.Parse(MainTable.Rows[i].Cells[3].Value.ToString());
                }
                if (allprice > 0)
                    labelWarehous1.Text = "При работе с \n\'" + nameMaterial + "\'\nОбщая цена\nдополнительно\nзатраченный ресурсов \n" + (allprice / 100.0) + " руб.";
                else
                    labelWarehous1.Text = "При работе с \n\'"+nameMaterial+"\'\nне было дополнительного\nиспользования ресурсов.";
            }
            else
            {
                flagreportmaterial = false;
                buttonnextorback.Text = "Подробнее о " + nameMaterial;
                Read_Data("");
            }
        }
    }
}
