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
        // all data
        Dictionary<string, Dictionary<string, List<double>>>? data;
        // promedio diario
        Dictionary<string, double>? promedioDiario;
        // promedio por hora
        Dictionary<string, double>? promedioHora;
        public Form1()
        {
            InitializeComponent();
            data = null;
            this.promedioDiario = null;
            this.promedioHora = null;
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
                    this.data = ReadData(filePath);
                    this.promedioDiario = PromedioDiario(this.data);
                    this.promedioHora = PromedioHora(this.data);
                    MessageBox.Show("Datos cargados exitosamente", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private static Dictionary<string, Dictionary<string, List<double>>> ReadData(string filePath)
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

            return groupedData;
        }



        private static Dictionary<string, double> PromedioDiario(Dictionary<string, Dictionary<string, List<double>>> data)
        {
            var PromedioDiario = new Dictionary<string, double>();

            foreach (var DatosDiario in data)
            {
                List<double> valoresDelDia = new List<double>();
                foreach (var DatosHora in DatosDiario.Value)
                {
                    valoresDelDia.AddRange(DatosHora.Value);
                }
                PromedioDiario[DatosDiario.Key] = valoresDelDia.Average();
            }

            return PromedioDiario;
        }


        private static Dictionary<string, double> PromedioHora(Dictionary<string, Dictionary<string, List<double>>> data)
        {
            var DatosPorHora = new Dictionary<string, List<double>>();

            foreach (var DatosDiario in data)
            {
                foreach (var DatosPorHoraDeUnDia in DatosDiario.Value)
                {
                    if (!DatosPorHora.ContainsKey(DatosPorHoraDeUnDia.Key))
                    {
                        DatosPorHora[DatosPorHoraDeUnDia.Key] = new List<double>();
                    }

                    foreach (var valor in DatosPorHoraDeUnDia.Value)
                    {
                        DatosPorHora[DatosPorHoraDeUnDia.Key].Add(valor);
                    }
                }
            }

            Dictionary<string, double> PromedioPorHora = new Dictionary<string, double>();
            foreach (var DatosPorHoraDeUnDia in DatosPorHora)
            {
                PromedioPorHora[DatosPorHoraDeUnDia.Key] = DatosPorHoraDeUnDia.Value.Average();
            }
            return PromedioPorHora;
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
            if (this.promedioHora != null)
            {
                var promediosOrdenados = this.promedioHora.OrderBy(x => DateTime.ParseExact(x.Key, "HH:mm", CultureInfo.InvariantCulture));
                textBox1.Text = string.Join(Environment.NewLine, promediosOrdenados.Select(x => $"{x.Key}: {x.Value}"));
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
            if (this.promedioHora != null)
            {
                var promediosOrdenados = this.promedioHora.OrderBy(x => DateTime.ParseExact(x.Key, "HH:mm", CultureInfo.InvariantCulture));
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
                    button5_Click(sender, e);
                }
            }
        }
    }
}
