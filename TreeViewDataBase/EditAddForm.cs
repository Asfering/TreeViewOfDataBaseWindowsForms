using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewDataBase
{
    public partial class EditAddForm : Form
    {
        private DataSet dataSet;
        private SqlDataAdapter sqlAdapter;

        public EditAddForm(DataSet ds, SqlDataAdapter adapter, Form1.ActionType actionType)
        {
            InitializeComponent();
            dataGridView1.DataSource = ds.Tables[0];
            switch (actionType)
            {
                case Form1.ActionType.Edit:
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    break;
                case Form1.ActionType.Create:
                    dataGridView1.CellClick += dataGridView1_CellClick;
                    break;
            }
            dataSet = ds;
            sqlAdapter = adapter;
        }

        public EditAddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder local = new SqlCommandBuilder(sqlAdapter);
                local.ConflictOption = ConflictOption.OverwriteChanges;
                sqlAdapter.UpdateCommand = local.GetUpdateCommand();
                sqlAdapter.Update(dataSet.Tables[0]);
                dataSet.AcceptChanges();
                dataGridView1.DataSource = dataSet.Tables[0];
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при работе с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) != "")
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    }
                }
            }
        }
    }
}
