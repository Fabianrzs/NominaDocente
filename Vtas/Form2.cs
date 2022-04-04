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
    public partial class Form2 : Form
    {
        DocenteContext db;
        public Form2()
        {
            InitializeComponent();
            db = new DocenteContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var docente = new Docente()
            {
                Identificacion = textBox1.Text,
                Nombres = textBox2.Text,
                TipoDocente = comboBox1.Text,
                AreaDesempenio = comboBox2.Text,
                Categoria = comboBox3.Text 

            };

            docente.CalcularSalario();
            docente.CalcularNomina();

            textBox3.Text = docente.Salario.ToString();


            MessageBox.Show($"Su nomina esta determinada por {docente.Nomina}");

            db.GuardarDocente(docente);

            
        }
    }
}
