using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticaConsultorio
{

    public partial class MainWindow : Window
    {
        DateTime fechaInicioConsulta;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGuardarNuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            Paciente nuevoPaciente = new Paciente();
            nuevoPaciente.Nombre = txtNombre.Text;
            nuevoPaciente.Dirrecion = txtDirrecion.Text;
            nuevoPaciente.Edad = int.Parse(txtEdad.Text);
            nuevoPaciente.Altura = float.Parse(txtAltura.Text);
            nuevoPaciente.Peso = float.Parse(txtPeso.Text);
            nuevoPaciente.EnfermedadesCronicas = txtEnfermedadesCronicas.Text;
            Datos.pacientes.Add(nuevoPaciente);
            actualizarListaPacientes();

            txtNombre.Text = string.Empty;
            txtDirrecion.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtAltura.Text = string.Empty;
            txtEnfermedadesCronicas.Text = string.Empty;
            gridNuevoPaciente.Visibility = Visibility.Collapsed;
        }
        private void actualizarListaPacientes()
        {
            lstPacientes.Items.Clear();
            foreach(Paciente paciente in Datos.pacientes)
            {
                lstPacientes.Items.Add(new ListBoxItem()
                {
                    Content = paciente.Nombre
                }
                );
            }
        }

        private void btnNuevoPaciente_Click(object sender, RoutedEventArgs e)
        {
            gridNuevoPaciente.Visibility = Visibility.Visible;
            btnGuardarNuevoPaciente.Visibility = Visibility.Visible;
            gridFormularioConsulta.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridFormularioConsulta.Visibility = Visibility.Visible;
            btnGuardarNuevoPaciente.Visibility = Visibility.Collapsed;
            Paciente paciente = Datos.pacientes[lstPacientes.SelectedIndex];

            txtNombrePaciente.Text = paciente.Nombre;

            txtEdadPaciente.Text = paciente.Edad.ToString();

            txtAlturaPaciente.Text = paciente.Altura.ToString();

            txtEnfermedadesCronicasPaciente.Text = paciente.EnfermedadesCronicas;

            txtPesoPaciente.Text = paciente.Peso.ToString();

            fechaInicioConsulta = DateTime.Now;

            txtFechaConsulta.Text = DateTime.Now.ToString();
        }

        private void lstPacientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lstPacientes.SelectedIndex != -1)
            {
                btnNuevaConsulta.IsEnabled = true;
            }
            else
            {
                btnNuevaConsulta.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Consulta nuevaConsulta = new Consulta();
            nuevaConsulta.PacienteActual = Datos.pacientes[lstPacientes.SelectedIndex];
            nuevaConsulta.Sintomas = txtSintomasConsulta.Text;
            nuevaConsulta.Diagnostico = txtDiagnosticoConsulta.Text;
            nuevaConsulta.Receta = txtRecetaConsulta.Text;
            nuevaConsulta.fecha = fechaInicioConsulta;

            Datos.consultas.Add(nuevaConsulta);
            txtNombrePaciente.Text = "";
            txtEdadPaciente.Text = "";
            txtAlturaPaciente.Text = "";
            txtPesoPaciente.Text = "";
            txtEnfermedadesCronicasPaciente.Text = "";

            txtSintomasConsulta.Text = "";
            txtDiagnosticoConsulta.Text = "";
            txtRecetaConsulta.Text = "";
            txtFechaConsulta.Text = "";

            gridFormularioConsulta.Visibility = Visibility.Collapsed;
        }
    }
}
