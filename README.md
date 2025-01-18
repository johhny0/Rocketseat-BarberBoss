# Rocketseat - BarberBoss
## Desafio Pr�tico - M�dulo 05
### Descri��o do desafio

Ser� criado uma API para gerenciar uma barbearia e, ao final, gerar relat�rios em PDF e Excel com o faturamento total da semana!

A aplica��o deve conter as seguintes funcionalidades:

#### Parte 1: Faturamento

- [x]  Deve ser poss�vel criar um faturamento;
- [x]  Deve ser poss�vel visualizar um faturamento;
- [x]  Deve ser poss�vel editar um faturamento;
- [x]  Deve ser poss�vel excluir um faturamento;
- [x]  Deve ser poss�vel exportar um relat�rio em PDF com os dados do faturamento;
- [x]  Deve ser poss�vel exportar um relat�rio em Excel com os dados do faturamento;
- [x]  Crie tratativas de erros e filtros de exce��es para a sua aplica��o;
- [ ]  Crie testes de unidade para a sua aplica��o!

#### Parte 2: Autentica��o

- [ ] Deve ser poss�vel criar um usu�rio
- [ ] Deve ser poss�vel visualizar os dados de um usu�rio;
- [ ] Deve ser poss�vel editar um usu�rio;
- [ ] Deve ser poss�vel excluir um usu�rio;
- [ ] As senhas devem ser criptografadas;
- [ ] O usu�rio deve estar autenticado para entrar na aplica��o;
- [ ] Crie testes de unidade para as regras de neg�cio;
- [ ] Crie testes de integra��o.

### Futuro
- [ ] Code Coverage
- [ ] Increase test coverage to 20%
- [ ] Increase test coverage to 40%
- [ ] Increase test coverage to 60%
- [ ] Increase test coverage to 80%
- [ ] Increase test coverage to 90%

#### Outras Informa��es
dotnet tool install --global dotnet-ef
dotnet ef migrations add MigrationName --project Infraestructure --startup-project RocketseatBarberBoss
dotnet ef database update --project Infraestructure --startup-project RocketseatBarberBoss