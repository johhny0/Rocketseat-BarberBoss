# Rocketseat - BarberBoss
## Desafio Prático - Módulo 05
### Descrição do desafio

Será criado uma API para gerenciar uma barbearia e, ao final, gerar relatórios em PDF e Excel com o faturamento total da semana!

A aplicação deve conter as seguintes funcionalidades:

#### Parte 1: Faturamento

- [x]  Deve ser possível criar um faturamento;
- [x]  Deve ser possível visualizar um faturamento;
- [x]  Deve ser possível editar um faturamento;
- [x]  Deve ser possível excluir um faturamento;
- [x]  Deve ser possível exportar um relatório em PDF com os dados do faturamento;
- [x]  Deve ser possível exportar um relatório em Excel com os dados do faturamento;
- [x]  Crie tratativas de erros e filtros de exceções para a sua aplicação;
- [ ]  Crie testes de unidade para a sua aplicação!

#### Parte 2: Autenticação

- [ ] Deve ser possível criar um usuário
- [ ] Deve ser possível visualizar os dados de um usuário;
- [ ] Deve ser possível editar um usuário;
- [ ] Deve ser possível excluir um usuário;
- [ ] As senhas devem ser criptografadas;
- [ ] O usuário deve estar autenticado para entrar na aplicação;
- [ ] Crie testes de unidade para as regras de negócio;
- [ ] Crie testes de integração.

### Futuro
- [ ] Code Coverage
- [ ] Increase test coverage to 20%
- [ ] Increase test coverage to 40%
- [ ] Increase test coverage to 60%
- [ ] Increase test coverage to 80%
- [ ] Increase test coverage to 90%

#### Outras Informações
dotnet tool install --global dotnet-ef
dotnet ef migrations add MigrationName --project Infraestructure --startup-project RocketseatBarberBoss
dotnet ef database update --project Infraestructure --startup-project RocketseatBarberBoss