using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutomataForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        Automata automata = new Automata();

        private void btnAbrirArchivos_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrirExploradorArchivos = new OpenFileDialog();

            abrirExploradorArchivos.Title = "Seleccionar archivo";
            abrirExploradorArchivos.Filter = "Archivos de TXT (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            abrirExploradorArchivos.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            if (abrirExploradorArchivos.ShowDialog() == DialogResult.OK)
            {
                string ruta = abrirExploradorArchivos.FileName;
                string contenido = System.IO.File.ReadAllText(ruta);
                try
                {
                    automata = CrearAutomata(contenido);
                    MessageBox.Show("Creado Exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected Automata CrearAutomata(String input)
        {
            String[] lineasLectura = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Automata automata = new Automata
            {
                estadoInicial = lineasLectura[2],
                estadoFinal = lineasLectura[3],
            };
            List<Estados> estados = new List<Estados>();
            String[] alfabeto = lineasLectura[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < int.Parse(lineasLectura[0]); i++)
            {
                Estados estado = new Estados
                {
                    Alfabeto = alfabeto,
                    Ruta = lineasLectura[4 + i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries)
                };
                estados.Add(estado);
            }
            automata.estados = estados;

            txtInicio.Text = automata.estadoInicial;
            txtFinal.Text = automata.estadoFinal;

            return automata;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            txtCamino.Clear();
            if (automata == null)
            {
                MessageBox.Show("Asegurese de que esta configurado un automata");
                return;
            }
            bool valido = automata.evaluar(txtEntrada.Text);

            txtCamino.Text = automata.camino;
            if (valido)
            {
                MessageBox.Show("Es una cadena valida");
            }
            else
            {
                MessageBox.Show("Es una cadena invalida");
            }
        }
    }
}
