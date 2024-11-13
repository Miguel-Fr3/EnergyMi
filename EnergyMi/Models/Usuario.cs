using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyMi.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string DsNome { get; set; }

        [Required]
        [StringLength(100)]
        public string DsEmail { get; set; }
        [Required]
        [StringLength(100)]
        public string DsSenha { get; set; }
        [Required]
        [StringLength(250)]
        public string DsEndereco { get; set; }
        [Required]
        [StringLength(100)]
        public string DsAmbiente { get; set; }



        public ICollection<Aparelho>? Aparelho { get; set; }



        public Usuario()
        {
        }


        public Usuario(int cdUsuario, string dsNome, string dsEmail, string dsSenha, string dsEndereco, string dsAmbiente)
        {
            CdUsuario = cdUsuario;
            DsNome = dsNome;
            DsEmail = dsEmail;
            DsSenha = dsSenha;
            DsEndereco = dsEndereco;
            DsAmbiente = dsAmbiente;

        }
    }
}