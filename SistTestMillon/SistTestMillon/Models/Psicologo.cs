using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Psicologo : Psicologos
    {
        public void insertar(Usuario usuario, Psicologo psicologo)
        {

            IRepository repository = new Model.Repository();
            Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
            Psicologos objUsuID = repository.FindEntity<Psicologos>(c => c.IdUsuario == UpdatePaciente.IdUsuario);
            if (objUsuID != null)
            {
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
                objUsuID.Correo = psicologo.Correo;

            }
            repository.Update(objUsuID);
        }

        public void crear(Usuario usuario, Psicologo psicologo)
        {

            IRepository repository = new Model.Repository();
            var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == usuario.NombreUsuario).IdUsuario;
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
                Correo = psicologo.Correo,
                IdUsuario = objUsuID
            });

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
                FechaNacimiento = psicologo.FechaNacimiento,
                Telefono = psicologo.Telefono,
                Correo = psicologo.Correo,
            };

            objetos.Add(Psico);
            var fecha = Psico.FechaNacimiento;
            objetos.Add(fecha);
            Usuario usuario = new Usuario
            {
                NombreUsuario = objUsuario.NombreUsuario,
                Contraseña = objUsuario.Contraseña,
                TipoUsuario = objUsuario.TipoUsuario

            };
            objetos.Add(usuario);
            return objetos;
        }

    }
}