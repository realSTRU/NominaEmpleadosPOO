using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina
{
    public class Empleado
    {
        const float AFP = 2.87f/100;
        const float SFS = 3.04f/100;
        public string nombre = "";
        public string apellido = "";
        public string cedula = "";
        public string telefono = "";
        public string direccion = "";
        public string departamento = "";
        public string puesto = "";
        public float sueldo = 0;
        public float sueldoNeto = 0;

        public Empleado(string nombre, string apellido, string cedula, string telefono, string direccion,
            string departamento, string puesto, float sueldo)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.cedula = cedula;
            this.telefono = telefono;
            this.direccion = direccion;
            this.departamento = departamento;
            this.puesto = puesto;
            this.sueldo = sueldo;
        }

        public string GetCedula()
        {
            return this.cedula;
        }

        public float GetAFP()
        {
            return sueldo * AFP;
        }

        public float GetSFS()
        {
            return sueldo * SFS;
        }

        public float GetSIR()
        {
            float anual = sueldo*12;
            if(anual<=416220){
                return 0;
            }
            if(anual>416220 && anual <=624329){
                return (((anual-416220.01f)*0.15f)/12);
            }
            if(anual>624329 && anual <=867123){
                return (((((anual-624329.01f)*0.2f))+31216)/12);
            }
            if(anual>867123){
                return (((((anual-867123.01f)*0.25f))+79776)/12);
            }

            return 1;
        }

        public float GetSueldoNeto()
        {
            return sueldoNeto = sueldo-(GetAFP() + GetSFS() + GetSIR());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Nombre: {0}\nApellido: {1}\nCedula: {2}\nTelefono: {3}"
                +"\nDireccion: {4}\nDepartemento: {5}\nPuesto: {6}\nSueldo: {7}\nAFP: {8}\nSFS: {9}\nISR: {10}"
                +"\nSueldo Neto: {11}",nombre,apellido,cedula,telefono,direccion,departamento,puesto,sueldo,GetAFP(),GetSFS(),GetSIR(),sueldoNeto);
            return (sb.ToString());
        }
    }
}
