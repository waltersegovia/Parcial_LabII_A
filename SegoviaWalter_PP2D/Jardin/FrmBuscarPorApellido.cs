using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Jardin
{
    public partial class FrmBuscarPorApellido : Form
    {
        private List<Alumno> listaPorApellidos;
        private List<Alumno> lista2;
        string apellido;

        public FrmBuscarPorApellido(List<Alumno> listaAlumnos)
        {
            InitializeComponent();

            this.listaPorApellidos = listaAlumnos;
        }

        //public List<Alumno> ListaPorApellidos { get { return this.listaPorApellidos; } }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            apellido = txtApellido.Text;
            int cont = 0;
            foreach (Alumno item in listaPorApellidos)
            {
                if (item.Apellido == apellido)
                {
                    cont++;
                    lista2.Add(item);
                }
            }

            if (cont == 0)
                MessageBox.Show("No se encontraron resultados");
            else
            {
                foreach (Alumno item in listaPorApellidos)
                {
                    ListViewItem lista = new ListViewItem(item.Apellido);
                    lista.SubItems.Add(item.Nombre);
                    lista.SubItems.Add(item.Legajo.ToString());
                    lista.SubItems.Add(item.ColorSala.ToString());
                    lista.SubItems.Add("$" + item.PrecioCuota.ToString());

                    lstApellidos.Items.Add(lista);
                }
            }
        }

        private void FrmBuscarPorApellido_Load(object sender, EventArgs e)
        {
            lista2 = new List<Alumno>();
        }
    }
}
