# EnergyMi 🍃

**API de Consumo de Energia**

EnergyMi é uma API desenvolvida como parte de um projeto acadêmico, com o objetivo de oferecer uma solução integrada para gestão de consumo energético. A aplicação realiza operações CRUD e utiliza Machine Learning (ML.NET) para prever consumos de energia com base em dados fornecidos pelo usuário. A arquitetura monolítica da API é complementada por práticas de clean code e design patterns, garantindo robustez e escalabilidade.

## Principais Funcionalidades 📲

1. **Gestão de Recursos:**
   - CRUD completo para usuários, aparelhos e consumo energético.

2. **Previsão de Consumo com Machine Learning:**
   - Utilizando ML.NET, a API prevê o consumo aproximado de energia com base em dados enviados pelo usuário.
   - Dados fornecidos em formato JSON são analisados por uma máquina treinada, retornando previsões detalhadas.
   - Registros gerados automaticamente no banco de dados para cada previsão realizada.

3. **Documentação Interativa:**
   - Endpoints detalhados e testáveis via Swagger/OpenAPI.


## Arquitetura 📂

A API utiliza uma **arquitetura monolítica**, escolhida pela simplicidade e adequação ao escopo do projeto.

### Por que um monolítico?
- **Facilidade de Desenvolvimento:** Um único projeto centralizado simplifica o gerenciamento e a colaboração.
- **Desempenho Adequado:** Um monolito bem estruturado suporta as necessidades da aplicação sem overhead desnecessário.
- **Praticidade:** Evita a complexidade de comunicação entre serviços e múltiplos bancos de dados.

A organização do código segue o princípio da separação por camadas, facilitando a manutenção e extensibilidade.


## Implementação de Machine Learning 🤖

A API utiliza um modelo treinado em ML.NET para análise e previsão. O modelo é configurado para prever o consumo energético com base nos dados enviados pelos usuários, como:

- Informações sobre aparelhos (tipo, consumo médio, potência, etc.).
- Especificações do uso, como frequência e duração.

### Pipeline de Previsão

1. **Entrada de Dados:** O usuário submete um formulário por meio de uma aplicação mobile.
2. **Transformação:** Os dados são convertidos para JSON.
3. **Análise e Previsão:** A máquina treinada processa os dados e gera um consumo previsto.
4. **Registro no Banco:** As informações de consumo previsto são salvas no banco de dados junto com os dados do usuário e do aparelho.

### Exemplo de Uso 📋

Endpoint: `/PrevisaoEnergia`  
Método: **POST**

```json
{
  "dtConsumo": "2023-01-23",
  "cdAparelho": 5,
  "dsTipoAparelho": "geladeira",
  "nrWatts": 150,
  "nrConsumoEnergia": 0,
  "nrCusto": 0.13
}
```

## Endpoints CRUD

A API oferece endpoints para gerenciar recursos, com operações básicas de CRUD:

- **GET**: Recupera uma lista ou um item específico.
- **POST**: Cria um novo item.
- **PUT**: Atualiza um item existente.
- **DELETE**: Remove um item.

### Exemplos de endpoints:

- `GET /api/usuarios`
- `POST /api/usuarios`
- `PUT /api/usuarios/{id}`
- `DELETE /api/usuarios/{id}`

## Documentação da API 📄

A API é documentada com Swagger/OpenAPI, permitindo que os desenvolvedores explorem e testem os endpoints diretamente pela interface do Swagger. A documentação inclui descrições detalhadas dos endpoints e dos modelos de dados utilizados, facilitando o entendimento e a integração.

Para acessar a documentação, navegue até `https://localhost:7148/swagger/index.html`.

## Como executar a API

### Pré-requisitos:

- .NET 6.0+
- Oracle Database

### Passos para execução:

1. Clone o repositório:
   ```bash
   git clone https://github.com/Miguel-Fr3/EnergyMi.git

2. Configure as variáveis de ambiente com as credenciais de acesso ao banco Oracle:

3. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update

4. Inicie a aplicação:
   ```bash
   dotnet run


## Integrantes do Grupo 
- rm99977 - Alberto Seiji
- rm551997 - Matheus Rodrigues
- rm99997 - Miguel Fernandes
- rm552579 - Nicolly de Almeida Gonçalves
- rm551521 - Patrick Jaguski
