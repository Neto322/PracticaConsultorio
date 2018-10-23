using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaConsultorio
{
    class Paciente
    {
        public string Nombre { get; set; }
        public string Dirrecion { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public float Altura { get; set; }
        public string EnfermedadesCronicas { get; set; }

        public Paciente()
        {
            Nombre = "Nuevo Paciente";
            Dirrecion = "Nueva Dirrecion";
            Telefono = "Nuevo Telefono";
            Edad = 00;
            Altura = 00;
            EnfermedadesCronicas = "Nueva Enfermedad";
        }
        public Paciente(string nombre, string dirrecion, string telefono, int edad, float altura, string enfermedadescronicas)
        {
            Nombre = nombre;
            Dirrecion = dirrecion;
            Telefono = telefono;
            Edad = edad;
            Altura = altura;
            EnfermedadesCronicas = enfermedadescronicas;
        }
    }
}
