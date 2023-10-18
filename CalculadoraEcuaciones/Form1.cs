using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraEcuaciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Analizador analizador = new Analizador();
            string ecuacion = textEcuacion.Text;

            try
            {
                if (analizador.ValidarParentesis(ecuacion))
                {
                    ecuacion = analizador.AgregarMultiplicacionImplicita(ecuacion); // Agregar multiplicación implícita
                    double resultado = analizador.EvaluarEcuacion(ecuacion);
                    MessageBox.Show("Resultado: " + resultado);
                }
                else
                {
                    MessageBox.Show("Error: Los paréntesis no están balanceados en la ecuación.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al evaluar la ecuación: " + ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            textEcuacion.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

