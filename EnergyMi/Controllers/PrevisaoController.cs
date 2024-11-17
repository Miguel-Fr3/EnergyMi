using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.Data;
using Microsoft.ML;
using Microsoft.AspNetCore.Authorization;

namespace EnergyMi.Controllers
{
    // Classe de Dados para Treinamento e Previsão
    public class PrevisaoEnergiaDTO
    {
        [LoadColumn(0)] public string dtConsumo { get; set; }
        [LoadColumn(1)] public float cdAparelho { get; set; }
        [LoadColumn(2)] public string dsTipoAparelho { get; set; }
        [LoadColumn(3)] public float nrWatts { get; set; }
        [LoadColumn(4)] public float nrConsumoEnergia { get; set; } 
        [LoadColumn(5)] public float nrCusto { get; set; }
    }

    public class PrevisaoEnergiaPrediction
    {
        [ColumnName("Score")]
        public float ConsumoPrevisto { get; set; }
    }
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoEnergiaController : ControllerBase
    {
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloEnergia.zip");
        private readonly string caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "energy_training.csv");
        private readonly MLContext mlContext;

        public PrevisaoEnergiaController()
        {
            mlContext = new MLContext();

            if (!System.IO.File.Exists(caminhoModelo))
            {
                TreinarModelo();
            }
        }

        private void TreinarModelo()
        {
            var pastaModelo = Path.GetDirectoryName(caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
            }


            IDataView dadosTreinamento = mlContext.Data.LoadFromTextFile<PrevisaoEnergiaDTO>(
                path: caminhoTreinamento, hasHeader: true, separatorChar: ',');


            var pipeline = mlContext.Transforms.Concatenate("Features",
                                nameof(PrevisaoEnergiaDTO.cdAparelho),
                                nameof(PrevisaoEnergiaDTO.nrWatts),
                                nameof(PrevisaoEnergiaDTO.nrCusto))
                            .Append(mlContext.Transforms.NormalizeMinMax("Features")) 
                            .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "nrConsumoEnergia", featureColumnName: "Features"));

            var modelo = pipeline.Fit(dadosTreinamento);


            mlContext.Model.Save(modelo, dadosTreinamento.Schema, caminhoModelo);
        }

        [HttpPost("prever")]
        public ActionResult<PrevisaoEnergiaPrediction> PreverConsumo([FromBody] PrevisaoEnergiaDTO dadosPrevisao)
        {
            if (!System.IO.File.Exists(caminhoModelo))
            {
                return BadRequest("O modelo ainda não foi treinado.");
            }

            ITransformer modelo;
            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                modelo = mlContext.Model.Load(stream, out var modeloSchema);
            }

            var enginePrevisao = mlContext.Model.CreatePredictionEngine<PrevisaoEnergiaDTO, PrevisaoEnergiaPrediction>(modelo);

            var previsao = enginePrevisao.Predict(dadosPrevisao);

            return Ok(previsao);
        }
    }
}