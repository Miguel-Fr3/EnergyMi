using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyMi.Models
{
    [Table("tb_log_consumo")]
    public class LogConsumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdLogConsumo { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DtInicio { get; set; }
        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DtFim { get; set; }
        [Required]
        [Column(TypeName = "NUMBER(5)")]
        public int NrConsumoPrevisto { get; set; }

        [ForeignKey("CdAparelho")]
        public int? CdAparelho { get; set; }
        public Aparelho? Aparelho { get; set; }

        public LogConsumo()
        {
        }

        public LogConsumo(int cdLogConsumo, DateTime dtInicio, DateTime dtFim, int nrConsumoPrevisto, int? cdAparelho)
        {
            CdLogConsumo = cdLogConsumo;
            DtInicio = dtInicio;
            DtFim = dtFim;
            NrConsumoPrevisto = nrConsumoPrevisto;
            CdAparelho = cdAparelho;
        }
    }
}
