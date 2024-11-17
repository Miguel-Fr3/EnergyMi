using EnergyMi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyMi.DTO
{
    public class UsuarioDTO
    {

        public string DsEmail { get; set; }
        public string DsSenha { get; set; }



        public UsuarioDTO()
        {
        }


        public UsuarioDTO( string dsEmail, string dsSenha)
        {
            DsEmail = dsEmail;
            DsSenha = dsSenha;

        }
    }
}