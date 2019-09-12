using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Paciente : Pacientes
    {

        public void actualizar(Usuario usuario, Paciente paciente)
        {

            IRepository repository = new Model.Repository();
            Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
            Pacientes objUsuID = repository.FindEntity<Pacientes>(c => c.IdUsuario == UpdatePaciente.IdUsuario);

            if (objUsuID != null)
            {
                objUsuID.Dni = paciente.Dni;
                objUsuID.Nombres = paciente.Nombres;
                objUsuID.ApellidoPaterno = paciente.ApellidoPaterno;
                objUsuID.ApellidoMaterno = paciente.ApellidoMaterno;
                objUsuID.Direccion = paciente.Direccion;
                objUsuID.Edad = paciente.Edad;
                objUsuID.Sexo = paciente.Sexo;
                objUsuID.Profesion = paciente.Profesion;
                objUsuID.FechaNacimiento = Convert.ToDateTime(paciente.FechaNacimiento);
                objUsuID.Telefono = paciente.Telefono;
                objUsuID.Correo = paciente.Correo;

            }
            repository.Update(objUsuID);
        }

        public void crear(Usuario usuario, Paciente paciente) {

            IRepository repository = new Model.Repository();
            var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == usuario.NombreUsuario).IdUsuario;
            var objUsuNew = repository.Create(new Pacientes
            {
                Dni = paciente.Dni,
                Nombres = paciente.Nombres,
                ApellidoPaterno = paciente.ApellidoPaterno,
                ApellidoMaterno = paciente.ApellidoMaterno,
                Direccion = paciente.Direccion,
                Edad = paciente.Edad,
                Sexo = paciente.Sexo,
                Profesion = paciente.Profesion,
                FechaNacimiento = Convert.ToDateTime(paciente.FechaNacimiento),
                Telefono = paciente.Telefono,
                Correo = paciente.Correo,
                IdUsuario = objUsuID
            });

        }

        public List<object> Obtener(Pacientes objPaciente, Usuarios objUsuario) {

            List<object> objetos = new List<object>();
            Paciente Paciente = new Paciente
            {
                IdPaciente = objPaciente.IdPaciente,
                Dni = objPaciente.Dni,
                Nombres = objPaciente.Nombres,
                ApellidoPaterno = objPaciente.ApellidoPaterno,
                ApellidoMaterno = objPaciente.ApellidoMaterno,
                Direccion = objPaciente.Direccion,
                Edad = objPaciente.Edad,
                Sexo = objPaciente.Sexo,
                Profesion = objPaciente.Profesion,
                FechaNacimiento = objPaciente.FechaNacimiento,
                Telefono = objPaciente.Telefono,
                Correo = objPaciente.Correo,
            };

            objetos.Add(Paciente);
            var fecha = Paciente.FechaNacimiento.ToString("dd/MM/yyyy");
            objetos.Add(fecha);
            Usuario usuario = new Usuario
            {
                NombreUsuario = objUsuario.NombreUsuario,
                Contraseña = objUsuario.Contraseña,
                TipoUsuario = objUsuario.TipoUsuario

            };
            objetos.Add(usuario);
            return  objetos;
        }
    }
}