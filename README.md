# _&nbsp;_ _&nbsp;_ Serviço de Cotações B3

#### _&nbsp;_ _&nbsp;_ Este repositório contem um serviço de consulta de ativos b3, onde é utiliza uma api (http://cotacoes.economia.uol.com.br) para buscar _&nbsp;_ _&nbsp;_ _&nbsp;_ as ultimas cotações.

#### _&nbsp;_ _&nbsp;_ Para a criação do projeto foram utilizadas as seguintes tecnologias:

- .Net Core (C# / ConsoleApp)
- .Nunit (Framework para a criação de testes de unidade) - https://nunit.org/
- Refit (Bilioteca para realizar requisições http de forma mais simples em projetos .NET) - https://github.com/reactiveui/refit
- Autofac (Container para utializar os princípios da inversão de controle) - https://autofac.org/
- System.Net.Mail (Bilioteca para realizar o envio de e-mail em projetos .NET)
- Topshelf (Framework que facilita o desenvolvimento de serviços windows)
- TDD (Test Driven Development)

#### _&nbsp;_ _&nbsp;_ Para executar a aplicação é necessário seguir os passo a passo seguinte:
  
1. Abrir o projeto no visual studio (de preferência vs2019).
2. Abrir o arquivo "appsettings.json" dentro do projeto "Cotacao.Service" e preencher as informações de e-mail.
3. Compilar o projeto.
4. Executar o servico "Cotacao.Service.exe" por linha de comando informando os parametros da consulta. (Exemplo: -ativo: "PETR4" -maximo:"22.67" - minimo:"22.59")
5. Os ativos disponíveis para consulta atualmente são: PETR4, FLRY3, ELET3, CIEL3, HYPE3, SUZB3, CSAN3, KLBN11, BTOW3, GOAU4, USIM5, COGN3, VVAR3.
  




