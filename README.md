# 🛒 | Commerce API.

## 💻 | Projeto: Construindo uma API Commerce simples.

Seja bem vindo, esse projeito foi feito no intuido de ajudar um amigo um pouco com o C#, aqui busco ser bem rudimentar possível.

- Colocando em prática alguns conceitos e utilizando o EF.
- Gerando seeds para ter o que consumir quando iniciar a aplicação.
- Utilizando a linguagem C#.
- Utilizando o PostgreSQL (Minha preferência).

## ⚙ | Projeto API.

### ✔ | Tecnologias:
- .NET 6
- EntityFrameworkCore 7.0.2
- EntityFrameworkCore.Design 7.0.2
- Npgsql.EntityFrameworkCore.PostgreSQL 7.0.0

### 📁 | Uma breve visão do projeto:
Minha aplicação em si é bem simples e com poucas entidades sendo elas:
- Sale (Venda).
- Saller (Vendedor).
- Product (Produtos).

Assim como um enum, que me serve para ter o status do processo das vendas sendo eles:

- AWAITING_PAYMENT (Aguardando pagamento) = 0.
- APPROVED_PAYMENT (Pagamento aprovado) = 1.
- SHIPPED_TO_CARRIER (Enviado ao transportador) = 2.
- DELIVERED (Entregue) = 3.
- CANCELED (Cancelado) = 4.

Os enumerados tem uma tratativa especial na hora de sua atualização:

    De: AWAITING_PAYMENT    Para: APPROVED_PAYMENT
    De: AWAITING_PAYMENT    Para: CANCELED
    De: APPROVED_PAYMENT    Para: SHIPPED_TO_CARRIER
    De: APPROVED_PAYMENT    Para: CANCELED
    De: SHIPPED_TO_CARRIER  Para: DELIVERED


Aqui temos a relação das minhas tabelas:

![preview1 img](/docs/img/preview01.png)

Fiz questão de adicinar seeds no código para que se pudesse ter o melhor aproveitamento do cadastro de uma venda (sale) dados esses que serão já implementado ao gerar a primeira migration.

<details><summary>Exemplos seeds</summary>
<p>

Ex 01:
```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Carne Bovina",
                    Description = "Carne Bovina para Churrasco",
                    Value = 12
                }
        }
```
</p>
<p>

Ex: 02
```cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Saller>().HasData(
                new Saller
                {
                    SallerId = 1,
                    NameSaller = "Person",
                    Cpf = "000.000.000-00",
                    Email = "string",
                    Active = true,
                    Telephone = "0000000-0000",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
        }

```
</p>
</details>

<details><summary>Retorno dos Dados</summary>
<p>

Ex 01:
```json
{
  "productId": 1,
  "name": "Carne Bovina",
  "description": "Carne Bovina para Churrasco",
  "value": 12
}
```
</p>

<p>

Ex: 02
```json
{
  "sallerId": 1,
  "nameSaller": "Person",
  "cpf": "000.000.000-00",
  "email": "string",
  "active": true,
  "telephone": "0000000-0000",
  "createdAt": "2023-01-19T23:36:10.623175Z",
  "updatedAt": "2023-01-19T23:36:10.623175Z"
}
```
</p>
</details>
<br>

### 🌐 | EndPoints:
Os endpoint esperados estão funcinando perfeitamente como o esperado.

<details><summary>Endpoints de Product</summary>
<p>

| Verbo  | Endpoint                | Parâmetro | Body           |
|--------|-------------------------|-----------|----------------|
| POST   | /Product/post/          | N/A       | Schema Product |
| GET    | /Product/get-all/       | N/A       | N/A            |
| GET    | /Product/get-by/{id}    | id        | N/A            |
| PUT    | /Product/update/{id}    | id        | Schema Product |
| DELETE | /Product/delete/{id}    | id        | N/A            |

</p>
</details>

<details><summary>Endpoints de Sale</summary>
<p>

| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| POST   | /Sale/post/             | N/A       | Schema Sale   |
| GET    | /Sale/get-all/          | N/A       | N/A           |
| GET    | /Sale/get-by/{id}       | id        | N/A           |
| PUT    | /Sale/update/{id}       | id        | N/A           |
| DELETE | /Sale/delete/{id}       | id        | N/A           |

</p>
</details>

<details><summary>Endpoints de Saller</summary>
<p>

| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| POST   | /Saller/post/           | N/A       | Schema Saller |
| GET    | /Saller/get-all/        | N/A       | N/A           |
| GET    | /Saller/get-by/{id}     | id        | N/A           |
| PUT    | /Saller/update/{id}     | id        | Schema Saller |
| DELETE | /Saller/delete/{id}     | id        | N/A           |

</p>
</details>
<br>

O schema (model) dos endpoitns, são utilizado para passar os campados exigidos, como no verbo POST e PUT.

Todas solicitações como GET, POST, PUT e DELETE que correspondem como CREATE, READ, UPDATE e DELETE (CRUD) estão funcionando.

Utilizando no Swagger:

![preview1 img](/docs/img/preview02.png)

## ⌨ | Comandos

| **Comandos**                                   |                                              **Descrição**|
|------------------------------------------------|------------------------------------------------------------|
|                                  `dotnet build`|                Constroi o projeto e todas suas dependências|
|                                    `dotnet run`|                                            Inicia o projeto|
|                     `dotnet ef database update`| Comando para criar ou atualizar o esquema do banco de dados|
|   `dotnet ef migrations add NomeDaMigraçãoAqui`| Crianção de suas migrations, servindo para criar, atualizar ou excluir suas tabelas ou campos de determinada tabela.|

<b>Segue a lista de commits para verificar o que foi implementado e alterado!</b>

## 👩‍💻 Meus Links:

- Github: [Victor Hugo.](https://github.com/torugo99)
- LinkedIn: [Victor Hugo.](https://www.linkedin.com/in/victor-hugo99/)
- Meu Site: [Victor99dev.](http://victor99dev.site/)

### 😀 | Créditos e Agradecimentos:
- Todas as informações do .Net, sendo comandos ou qualquer outra informação foi retirada da documentação oficial.
- Documentações: 
    - [.Net](https://learn.microsoft.com/pt-br/dotnet/)
    - [Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-7.0)
- Onde fiz a modelagem do banco?: [Link](https://app.sqldbm.com/#)
