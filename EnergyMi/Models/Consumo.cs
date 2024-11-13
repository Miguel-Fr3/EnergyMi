using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EnergyMi.Models
{
    [Table("tb_consumo")]
    public class Consumo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdConsumo { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DtConsumo { get; set; }
        [Required]
        [Column(TypeName = "NUMBER(5)")]
        public int NrConsumoEnergia { get; set; }
        [Required]
        [Column(TypeName = "NUMBER(5)")]
        public int NrCusto { get; set; }

        [StringLength(250)]
        public string? DsObservacoes { get; set; }

        [ForeignKey("CdAparelho")]
        public int? CdAparelho { get; set; }
        public Aparelho? Aparelho { get; set; }


        public Consumo()
        {
        }

        public Consumo(int cdConsumo, DateTime dtConsumo, int nrConsumoEnergia, int nrCusto, string? dsObservacoes, int? cdAparelho)
        {
            CdConsumo = cdConsumo;
            DtConsumo = dtConsumo;
            NrConsumoEnergia = nrConsumoEnergia;
            NrCusto = nrCusto;
            DsObservacoes = dsObservacoes;
            CdAparelho = cdAparelho;
        }
    }
}
