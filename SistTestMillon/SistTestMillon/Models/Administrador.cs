using Model;
using Repository;
using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Administrador:Administradores
    {
        public string Actualizar(Usuario usuario, Administrador admin)
        {
            string strMensaje = "Error";
            IRepository repository = new Model.Repository();
            Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
            string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
            Administradores objUsuID = repository.FindEntity<Administradores>(c => c.IdUsuario == UpdatePaciente.IdUsuario);
            if (objUsuID != null)
            {

                UpdatePaciente.NombreUsuario = usuario.NombreUsuario;
                UpdatePaciente.Contraseña = strPass;
                UpdatePaciente.Correo = usuario.Correo;
                repository.Update(UpdatePaciente);

                objUsuID.Dni = admin.Dni;
                objUsuID.Nombres = admin.Nombres;
                objUsuID.ApellidoPaterno = admin.ApellidoPaterno;
                objUsuID.ApellidoMaterno = admin.ApellidoMaterno;
                objUsuID.Direccion = admin.Direccion;
                objUsuID.Edad = admin.Edad;
                objUsuID.Sexo = admin.Sexo;
                objUsuID.Profesion = admin.Profesion;
                objUsuID.FechaNacimiento = Convert.ToDateTime(admin.FechaNacimiento);
                objUsuID.Telefono = admin.Telefono;
                repository.Update(objUsuID);

                strMensaje = "Se actualizo sus datos";

            }
            return strMensaje;
            
        }

        public string crear(Usuario usuario, Administrador admin)
        {
            string strMensaje = "Se agrego el administrador correctamente";
            IRepository repository = new Model.Repository();
            try
            {
                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                var objUsuarios = repository.Create(new Usuarios
                {
                    TipoUsuario = "Administrador",
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = strPass,
                    Correo = usuario.Correo

                });
                var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == objUsuarios.NombreUsuario).IdUsuario;
                var objUsuNew = repository.Create(new Administradores
                {
                    Dni = admin.Dni,
                    Nombres = admin.Nombres,
                    ApellidoPaterno = admin.ApellidoPaterno,
                    ApellidoMaterno = admin.ApellidoMaterno,
                    Direccion = admin.Direccion,
                    Edad = admin.Edad,
                    Sexo = admin.Sexo,
                    Profesion = admin.Profesion,
                    FechaNacimiento = Convert.ToDateTime(admin.FechaNacimiento),
                    Telefono = admin.Telefono,
                    IdUsuario = objUsuID
                });
            }
            catch (Exception e)
            {

                
                strMensaje = e.Message;

            }

            return strMensaje;

        }

        public List<object> Obtener(Administradores admin, Usuarios objUsuario)
        {

            List<object> objetos = new List<object>();
            Administrador adminst = new Administrador
            {
                IdAdministrador = admin.IdAdministrador,
                Dni = admin.Dni,
                Nombres = admin.Nombres,
                ApellidoPaterno = admin.ApellidoPaterno,
                ApellidoMaterno = admin.ApellidoMaterno,
                Direccion = admin.Direccion,
                Edad = admin.Edad,
                Sexo = admin.Sexo,
                Profesion = admin.Profesion,
                FechaNacimiento = admin.FechaNacimiento,
                Telefono = admin.Telefono,
            };

            objetos.Add(adminst);
            var fecha = adminst.FechaNacimiento.ToString("dd/MM/yyyy");
            objetos.Add(fecha);
            Usuario usuario = new Usuario
            {
                IdUsuario=objUsuario.IdUsuario,
                NombreUsuario = objUsuario.NombreUsuario,
                Contraseña = objUsuario.Contraseña,
                TipoUsuario = objUsuario.TipoUsuario,
                Correo=objUsuario.Correo

            };
            objetos.Add(usuario);
            return objetos;
        }

    }


}