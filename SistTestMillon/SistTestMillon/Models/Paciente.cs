using Model;
using Repository;
using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Paciente : Pacientes
    {

        public string actualizar(Usuario usuario, Paciente paciente)
        {
            string strMensaje = "Error";
            IRepository repository = new Model.Repository();
            Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
            string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
            Pacientes objUsuID = repository.FindEntity<Pacientes>(c => c.IdUsuario == UpdatePaciente.IdUsuario);

            if (objUsuID != null)
            {
                UpdatePaciente.NombreUsuario = usuario.NombreUsuario;
                UpdatePaciente.Contraseña = strPass;
                UpdatePaciente.Correo = usuario.Correo;
                repository.Update(UpdatePaciente);

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

                repository.Update(objUsuID);
                strMensaje = "Se actualizaron sus datos";

            }

            return strMensaje;

        }

        public string crear(Usuario usuario, Paciente paciente)
        {

            string strMensaje = "Se agrego el paciente correctamente";
            IRepository repository = new Model.Repository();
            
            try
            {
                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                var objUsuarios = repository.Create(new Usuarios
                {
                    TipoUsuario = "Paciente",
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = strPass,
                    Correo = usuario.Correo

                });


                var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == objUsuarios.NombreUsuario).IdUsuario;
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
                    IdUsuario = objUsuID
                });
            }
            catch (Exception e)
            {

                strMensaje = e.Message;
            }

            return strMensaje;

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
            };

            objetos.Add(Paciente);
            var fecha = Paciente.FechaNacimiento.ToString("dd/MM/yyyy");
            objetos.Add(fecha);
            Usuario usuario = new Usuario
            {
                IdUsuario= objUsuario.IdUsuario,
                NombreUsuario = objUsuario.NombreUsuario,
                Contraseña = objUsuario.Contraseña,
                TipoUsuario = objUsuario.TipoUsuario,
                Correo=objUsuario.Correo

            };
            objetos.Add(usuario);
            return  objetos;
        }
    }
}