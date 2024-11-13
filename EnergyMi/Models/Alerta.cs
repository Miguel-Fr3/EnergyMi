using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyMi.Models
{
    [Table("tb_alerta")]
    public class Alerta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdAlerta { get; set; }

        [Required]
        [StringLength(100)]
        public string? DsObservacao { get; set; }
        [Required]
        [StringLength(5)]
        public string? StNivelPrioridade { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DtAlerta { get; set; }

        [ForeignKey("CdAparelho")]
        public int? CdAparelho { get; set; }
        public Aparelho? Aparelho { get; set; }


        public Alerta()
        {
        }
        public Alerta(int cdAlerta, string dsObservacao, string stNivelPrioridade, DateTime dtAlerta, int cdAparelho)
        {
            CdAlerta = cdAlerta;
            DsObservacao = dsObservacao;
            StNivelPrioridade = stNivelPrioridade;
            DtAlerta = dtAlerta;
            CdAparelho = cdAparelho;
        }
    }
}
