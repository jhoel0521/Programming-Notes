using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Presiones
{
    public partial class Form1 : Form
    {
        // variables

        // promedio diario
        Dictionary<string, double>? promedioDiario;
        // promedio por hora
         Dictionary<string, Dictionary<string, double>>? promedioDiarioPorHora;
        public Form1()
        {
            InitializeComponent();
            promedioDiario = null;
            promedioDiarioPorHora = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de texto (*.txt)|*.txt",
                Title = "Selecciona un archivo para abrir"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    ReadData(filePath);

                    MessageBox.Show("Datos cargados exitosamente", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private  void ReadData(string filePath)
        {
            var groupedData = new Dictionary<string, Dictionary<string, List<double>>>();
            var lines = File.ReadAllLines(filePath);

            // recorremos linea por linea
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 3
                    && DateTime.TryParseExact(parts[0] + " " + parts[1], "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime)
                    && double.TryParse(parts[2], out var value))
                {

                    string dateKey = dateTime.ToString("dd-MM-yyyy");
                    string hourKey = dateTime.ToString("HH:") + "00";

                    if (!groupedData.ContainsKey(dateKey))
                    {
                        groupedData[dateKey] = new Dictionary<string, List<double>>();
                    }

                    if (!groupedData[dateKey].ContainsKey(hourKey))
                    {
                        groupedData[dateKey][hourKey] = new List<double>();
                    }

                    groupedData[dateKey][hourKey].Add(value);
                }
            }
            promedioDiario = new Dictionary<string, double>();
            promedioDiarioPorHora = new Dictionary<string, Dictionary<string, double>>();
            foreach (var dateKey in groupedData.Keys)
            {
             
                double acumulativoDia= 0;
                int contador = 0;
                promedioDiarioPorHora.Add(dateKey, new Dictionary<string, double>());
                foreach (var hourKey in groupedData[dateKey].Keys)
                {
                    double acumulativoHora = 0;
                    int contadorHora = 0;

                    foreach (var value in groupedData[dateKey][hourKey])
                    {
                        acumulativoHora += value;
                        acumulativoDia += value;
                        contador++;
                        contadorHora++;
                    }
                    promedioDiarioPorHora[dateKey].Add(hourKey, acumulativoHora / contadorHora);
                }
                promedioDiario.Add(dateKey, acumulativoDia / contador);
            }

        }




        private void button2_Click(object sender, EventArgs e)
        {
            if (this.promedioDiario != null)
            {
                var promediosOrdenados = this.promedioDiario.OrderBy(x => DateTime.ParseExact(x.Key, "dd-MM-yyyy", CultureInfo.InvariantCulture));
                textBox1.Text = string.Join(Environment.NewLine, promediosOrdenados.Select(x => $"{x.Key}: {x.Value}"));
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea cargar los datos?", "Cargar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    button1_Click(sender, e);
                    button2_Click(sender, e);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.promedioDiarioPorHora != null)
            {
                string view = "";
                foreach (var dateKey in this.promedioDiarioPorHora.Keys)
                {
                    view += $"{dateKey}:{Environment.NewLine}";
                    foreach (var hourKey in this.promedioDiarioPorHora[dateKey].Keys)
                    {
                       view += $"\t{hourKey}: {this.promedioDiarioPorHora[dateKey][hourKey]}{Environment.NewLine}";
                    }
                    view += Environment.NewLine;
                }
                textBox1.Text = view;
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea cargar los datos?", "Cargar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    button1_Click(sender, e);
                    button3_Click(sender, e);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.promedioDiario != null)
            {
                var promediosOrdenados = this.promedioDiario.OrderBy(x => DateTime.ParseExact(x.Key, "dd-MM-yyyy", CultureInfo.InvariantCulture));
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos de texto (*.txt)|*.txt",
                    Title = "Guardar archivo"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    File.WriteAllLines(filePath, promediosOrdenados.Select(x => $"{x.Key}: {x.Value}"));
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un nombre para guardar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea cargar los datos?", "Cargar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    button1_Click(sender, e);
                    button4_Click(sender, e);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.promedioDiarioPorHora != null)
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivos de texto (*.txt)|*.txt",
                    Title = "Guardar archivo"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    string salidaText = "";
                    foreach (var dateKey in this.promedioDiarioPorHora.Keys)
                    {
                        salidaText += $"{dateKey}:{Environment.NewLine}";
                        foreach (var hourKey in this.promedioDiarioPorHora[dateKey].Keys)
                        {
                            salidaText += $"\t{hourKey}: {this.promedioDiarioPorHora[dateKey][hourKey]}{Environment.NewLine}";
                        }
                        salidaText += Environment.NewLine;
                    }
                    File.WriteAllText(filePath, salidaText);
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado un nombre para guardar el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("¿Desea cargar los datos?", "Cargar datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    button1_Click(sender, e);
                    button5_Click(sender, e);
                }
            }
        }
    }
}
