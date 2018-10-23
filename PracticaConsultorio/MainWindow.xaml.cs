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
            nuevoPaciente.altura = float.Parse(txtAltura.Text);
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
        }
    }
}
