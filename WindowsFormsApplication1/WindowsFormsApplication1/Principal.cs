using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //lectura y escritura
using System.Text.RegularExpressions; //libreria de expresiones regulares

namespace WindowsFormsApplication1
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    myRichTextBox.Text = ofd.ToString(); 
                    string[] s = File.ReadAllLines(ofd.FileName);

                    foreach (string col in s[0].Split(','))
                        dataGridView1.Columns.Add(col, col);

                    for (int i = 1; i < s.GetLength(0); i++)
                        dataGridView1.Rows.Add(s[i].Split(','));

                    //############################
                    //     reglas de tipo
                    //############################
                    string cadenaParaAnalizar;
                    float num;
                    cadenaParaAnalizar = "123"; //asignamos un valor Temp
                    bool esDigito = cadenaParaAnalizar.All(char.IsDigit);//enteros
                    bool esChar = cadenaParaAnalizar.All(char.IsLetter);//letras
                    bool esFlotante = float.TryParse(cadenaParaAnalizar, out num);//es flotante
                    string.IsNullOrEmpty(cadenaParaAnalizar); //Cadena vacia
                    //Entero usando regex
                    
                        //reglas de los colores
                        foreach (DataGridViewRow row1 in dataGridView1.Rows)
                    {
                        if (row1.Cells.Cast<DataGridViewCell>().Any(c => c.Value == null || string.IsNullOrWhiteSpace(c.Value.ToString())))
                        {
                            bool booleano = false;
                            Analizador variableTmp = new Analizador(cadenaParaAnalizar,booleano);
                            row1.DefaultCellStyle.BackColor = Color.White;

                        }
                        else
                        {
                            row1.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                    //
                    //segunda pasada de reglas

                    /*foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        string comparame = Convert.ToString(r.Cells[0].Value);//falta establecer una variable para cada celda
                        bool valor = false;
                        Analizador temporal = new Analizador(comparame,valor);
                        
                        temporal.SoyEntero();

                        if () { }
                        r.DefaultCellStyle.BackColor = Color.Red;//cambia el color de celda
                    }*/
                    //
                    Regex EsEntero = new Regex("^[0-9]+$");


                    if (EsEntero.IsMatch(cadenaParaAnalizar))
                    {
                        foreach (DataGridViewRow r in dataGridView1.Rows)
                        {
                            int indiceDeCabecera = 0;// variable para asignar
                            string comparame = Convert.ToString(r.Cells[indiceDeCabecera].Value);//falta establecer una variable para cada celda
                            bool valor = false;
                            Analizador temporal = new Analizador(comparame,valor);
                            
                            //checa enteros
                            temporal.SoyEntero();
                            if (temporal.Verdadero() != true) //Cuando es difenete de entero
                            {
                                //cambia el color de celda
                                r.Cells[0].Style.BackColor = Color.Red;
                            }
                            //fin checa enteros


                        }

                    }
                }
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void cerrarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere cerrar el archivo?", "Cerrar archivo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // MessageBox.Show("The application has been closed successfully.", "Application Closed!", MessageBoxButtons.OK);
                //System.Windows.Forms.Application.Exit();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                myRichTextBox.Clear();
            }

           
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.ShowDialog();//muestra la ventana
            guardar.Filter = "Data Files (*.arff)|*.arff";//filtro de extensiones validas
            guardar.DefaultExt = "arff";//extension predeterminada
            guardar.AddExtension = true;

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
