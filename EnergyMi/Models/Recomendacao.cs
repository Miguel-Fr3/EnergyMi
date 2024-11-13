using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyMi.Models
{
    [Table("tb_recomendacao")]
    public class Recomendacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdRecomendacao { get; set; }

        [Required]
        [StringLength(250)]
        public string? DsObservacao { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DtRecomendacao { get; set; }

        [Required]
        [StringLength(50)]
        public string? StRecomendacao { get; set; }

        [Required]
        [ForeignKey("CdAparelho")]
        public int? CdAparelho { get; set; }
        public Aparelho? Aparelho { get; set; }

        public Recomendacao()
        {
        }

        public Recomendacao(int cdRecomendacao, string dsObservacao, DateTime dtRecomendacao, string stRecomendacao, int cdAparelho)
        {
            CdRecomendacao = cdRecomendacao;
            DsObservacao = dsObservacao;
            DtRecomendacao = dtRecomendacao;
            StRecomendacao = stRecomendacao;
            CdAparelho = cdAparelho;
        }
    }
}
