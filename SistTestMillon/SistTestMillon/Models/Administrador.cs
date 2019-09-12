using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Administrador:Administradores
    {
        public void insertar(Usuario usuario, Administrador admin)
        {
            IRepository repository = new Model.Repository();
            Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
            Administradores objUsuID = repository.FindEntity<Administradores>(c => c.IdUsuario == UpdatePaciente.IdUsuario);
            if (objUsuID != null)
            {
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
                objUsuID.Correo = admin.Correo;

            }
            repository.Update(objUsuID);
        }

        public void crear(Usuario usuario, Administrador admin)
        {

            IRepository repository = new Model.Repository();
            var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == usuario.NombreUsuario).IdUsuario;
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
                Correo = admin.Correo,
                IdUsuario = objUsuID
            });

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
                Correo = admin.Correo,
            };

            objetos.Add(adminst);
            var fecha = adminst.FechaNacimiento;
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