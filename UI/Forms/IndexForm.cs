// Archivo: UI/Forms/IndexForm.cs
using Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class IndexForm : Form
    {
        public IndexForm(List<IndexInfo> indexes, string tableName)
        {
            InitializeComponent();
            this.Text = "Índices de la tabla: " + tableName;
            dataGridViewIndexes.DataSource = indexes;
            dataGridViewIndexes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {

        }
    }
}
