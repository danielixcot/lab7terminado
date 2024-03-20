using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laboratorio7
{
    public partial class Form1 : Form
    {
        List<Propiedad> propiedads = new List<Propiedad>();
        List<Propietario> propietarios = new List<Propietario>();
        List<Dato> datos = new List<Dato>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Cargarpropiedades()
        {
            string fileName = "Propiedades.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propiedad propiedad = new Propiedad();
                propiedad.Casa = reader.ReadLine();
                propiedad.Dpi = Convert.ToInt64(reader.ReadLine());
                propiedad.Cuota = Convert.ToInt32(reader.ReadLine());

                propiedads.Add(propiedad);
            }
            reader.Close();
        }
        private void Cargarpropietarios()
        {
            string fileName = "Propietarios.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propietario propietario = new Propietario();
                propietario.Dpi = Convert.ToInt64(reader.ReadLine());
                propietario.Nombre = reader.ReadLine();
                propietario.Apellido = reader.ReadLine();

                propietarios.Add(propietario);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cargarpropiedades();
            Cargarpropietarios();
            if (datos.Count == 0)
            {
                datos.Clear();
                foreach (Propietario propietario in propietarios)
                {
                    List<Propiedad> propiedadesDelPropietario = propiedads.Where(p => p.Dpi == propietario.Dpi).ToList();
                    int contador = 0;
                    foreach (Propiedad propiedad in propiedadesDelPropietario)
                    {
                        if (contador < 3)
                        {
                            Dato dato = new Dato();
                            dato.Nombre = propietario.Nombre;
                            dato.Apellido = propietario.Apellido;
                            dato.Casa = propiedad.Casa;
                            dato.Cuota = propiedad.Cuota;
                            datos.Add(dato);
                            contador++;
                        }
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = datos;
                dataGridView1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (datos.Count > 0)
            {
                datos = datos.OrderByDescending(d => d.Cuota).ToList();
                List<Dato> cuotasAltas = datos.OrderByDescending(d => d.Cuota).Take(3).ToList();
                List<Dato> cuotasBajas = datos.OrderBy(d => d.Cuota).Take(3).ToList();
                dataGridView3.DataSource = cuotasAltas;
                dataGridView3.Refresh();
                dataGridView4.DataSource = cuotasBajas;
                dataGridView4.Refresh();
                dataGridView2.DataSource = datos;
                dataGridView2.Refresh();

                Dato propietarioCuotaAlta = datos.OrderByDescending(d => d.Cuota).FirstOrDefault();
                if (propietarioCuotaAlta != null)
                {
                    label2.Text = $"El propietario {propietarioCuotaAlta.Nombre} {propietarioCuotaAlta.Apellido} tiene la cuota total más alta: {propietarioCuotaAlta.Cuota}";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
