using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyMi.Models
{
    [Table("tb_previsao_consumo")]
    public class PrevisaoConsumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdPrevisao { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DtPrevisao { get; set; }
        [Required]
        [Column(TypeName = "NUMBER(5)")]
        public int NrConsumoPrevisto { get; set; }

        [Required]
        [StringLength(250)]
        public string? DsMetodoPrevisao { get; set; }

        [ForeignKey("CdAparelho")]
        public int? CdAparelho { get; set; }
        public Aparelho? Aparelho { get; set; }

        public PrevisaoConsumo()
        {
        }

        public PrevisaoConsumo(int cdPrevisao, DateTime dtPrevisao, int nrConsumoPrevisto, string? dsMetodoPrevisao, int? cdAparelho)
        {
            CdPrevisao = cdPrevisao;
            DtPrevisao = dtPrevisao;
            NrConsumoPrevisto = nrConsumoPrevisto;
            DsMetodoPrevisao = dsMetodoPrevisao;
            CdAparelho = cdAparelho;
        }
    }
}
