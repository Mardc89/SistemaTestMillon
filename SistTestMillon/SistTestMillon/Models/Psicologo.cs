using Model;
using Repository;
using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Psicologo : Psicologos
    {
        public string actualizar(Usuario usuario, Psicologo psicologo)
        {
            string strMensaje = "Error";
            IRepository repository = new Model.Repository();
            Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
            string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
            Psicologos objUsuID = repository.FindEntity<Psicologos>(c => c.IdUsuario == UpdatePaciente.IdUsuario);
            if (objUsuID != null)
            {
                UpdatePaciente.NombreUsuario = usuario.NombreUsuario;
                UpdatePaciente.Contraseña = strPass;
                UpdatePaciente.Correo = usuario.Correo;
                repository.Update(UpdatePaciente);

                objUsuID.Dni = psicologo.Dni;
                objUsuID.Nombres = psicologo.Nombres;
                objUsuID.ApellidoPaterno = psicologo.ApellidoPaterno;
                objUsuID.ApellidoMaterno = psicologo.ApellidoMaterno;
                objUsuID.Direccion = psicologo.Direccion;
                objUsuID.Edad = psicologo.Edad;
                objUsuID.Sexo = psicologo.Sexo;
                objUsuID.Profesion = psicologo.Profesion;
                objUsuID.FechaNacimiento = Convert.ToDateTime(psicologo.FechaNacimiento);
                objUsuID.Telefono = psicologo.Telefono;
                repository.Update(objUsuID);

                strMensaje = "Se actualizaron sus datos";
            }

            return strMensaje;
            
        }

        public string crear(Usuario usuario, Psicologo psicologo)
        {
            string strMensaje = "Se agrego el psicologo correctamente";
            IRepository repository = new Model.Repository();           
            try
            {
                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                var objUsuarios = repository.Create(new Usuarios
                {
                    TipoUsuario = "Psicologo",
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = strPass,
                    Correo = usuario.Correo

                });

                var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == objUsuarios.NombreUsuario).IdUsuario;

                var objUsuNew = repository.Create(new Psicologos
                {
                    Dni = psicologo.Dni,
                    Nombres = psicologo.Nombres,
                    ApellidoPaterno = psicologo.ApellidoPaterno,
                    ApellidoMaterno = psicologo.ApellidoMaterno,
                    Direccion = psicologo.Direccion,
                    Edad = psicologo.Edad,
                    Sexo = psicologo.Sexo,
                    Profesion = psicologo.Profesion,
                    FechaNacimiento = Convert.ToDateTime(psicologo.FechaNacimiento),
                    Telefono = psicologo.Telefono,
                    IdUsuario = objUsuID
                });
            }
            catch (Exception e)
            {

                strMensaje = e.Message;
            }
            return strMensaje;

        }

        public List<object> Obtener(Psicologos psicologo, Usuarios objUsuario)
        {

            List<object> objetos = new List<object>();
            Psicologo Psico = new Psicologo
            {
                IdPsicologo = psicologo.IdPsicologo,
                Dni = psicologo.Dni,
                Nombres = psicologo.Nombres,
                ApellidoPaterno = psicologo.ApellidoPaterno,
                ApellidoMaterno = psicologo.ApellidoMaterno,
                Direccion = psicologo.Direccion,
                Edad = psicologo.Edad,
                Sexo = psicologo.Sexo,
                Profesion = psicologo.Profesion,
                FechaNacimiento = Convert.ToDateTime(psicologo.FechaNacimiento),
                Telefono = psicologo.Telefono,
            };

            objetos.Add(Psico);
            string fecha = Psico.FechaNacimiento.Value.ToString("dd/MM/yyyy");
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