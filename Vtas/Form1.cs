using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vtas
{
    public partial class Form1 : Form
    {
        DocenteContext db;
        public Form1()
        {
            InitializeComponent();
            db = new DocenteContext();
            LoadTablet();
        }

        private void LoadTablet()
        {
            dataGridView1.DataSource = db.ConsultarDocentes().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ConsultarDocentes().Where(p => p.Nombres.Contains(textBox1.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Visible = true;
        }
    }
}
