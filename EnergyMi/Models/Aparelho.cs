using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EnergyMi.Models
{
    [Table("tb_aparelho")]
    public class Aparelho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdAparelho { get; set; }


        [Required]
        [StringLength(100)]
        public string DsNomeAparelho { get; set; }
        [Required]
        [StringLength(200)]
        public string DsTipoAparelho { get; set; }

        [Required]
        [Column(TypeName = "NUMBER(5)")]
        public int NrWatts { get; set; }

        [ForeignKey("CdAparelho")]
        public int? CdUsuario { get; set; }

        public Usuario? Usuario { get; set; }

        public Aparelho()
        {
        }

        public Aparelho(int cdAparelho, string dsNomeAparelho, string dsTipoAparelho, int nrWatts, int cdUsuario)
        {
            CdAparelho = cdAparelho;
            DsNomeAparelho = dsNomeAparelho;
            DsTipoAparelho = dsTipoAparelho;
            NrWatts = nrWatts;
            CdUsuario = cdUsuario;
        }
    }
}