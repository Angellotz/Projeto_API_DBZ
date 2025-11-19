# 🐉 Projeto DBZ API – ASP.NET Core + Entity Framework

Uma API REST desenvolvida em **ASP.NET Core** para gerenciar personagens do universo **Dragon Ball Z**.  
O projeto utiliza **Entity Framework Core**, **SQL Server** e segue o padrão de CRUD completo (Create, Read, Update, Delete).

---

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core 7**
- **Entity Framework Core**
- **SQL Server**
- **Swagger / OpenAPI**
- **C#**

---

## 📌 Funcionalidades

✔ Cadastrar personagens  
✔ Listar todos os personagens  
✔ Buscar personagem por ID  
✔ Atualizar personagem  
✔ Excluir personagem  
✔ Banco de dados estruturado com EF Core  
✔ Documentação automática com Swagger  

---

## 🧱 Estrutura do Projeto

```
ProjetoDBZ/
│
├── Controllers/
│   └── PersonagensController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   └── Personagem.cs
│
├── Program.cs
└── ProjetoDBZ.csproj
```

---

## 🗃️ Modelo Personagem

```csharp
public class Personagem
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public int Poder { get; set; }
    public string? Raca { get; set; }
}
```

---

## 🔗 Endpoints

### POST – Criar Personagem
`/api/personagens`

### GET – Listar Todos
`/api/personagens`

### GET – Buscar por ID
`/api/personagens/{id}`

### PUT – Atualizar
`/api/personagens/{id}`

### DELETE – Excluir
`/api/personagens/{id}`

---

## 🛠️ Configuração do Banco de Dados

No arquivo `appsettings.json`, configure sua conexão:

```json
"ConnectionStrings": {
  "AppDbConnectionString": "Server=SEU_SERVIDOR;Database=DBZ;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## ▶️ Como rodar o projeto

1. Clone o repositório  
2. Configure o SQL Server  
3. Rode as migrations (se tiver)  
4. Execute a API:

```
dotnet run
```


