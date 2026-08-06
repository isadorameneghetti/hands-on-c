## 🗄️ ADOLab - Laboratório de ADO.NET em C#

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

## 👥 INTEGRANTES

| Nome | RM |
|------|-----|
| **Isadora Meneghetti** | RM556326 |

---

## 📚 DISCIPLINA

**Acesso a Bancos de Dados com ADO.NET - CRUD em C#**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O PROJETO

Este é um **Laboratório de ADO.NET (ADOLab)** desenvolvido em C#.

O projeto implementa um **CRUD completo** (Create, Read, Update, Delete) para a entidade **Aluno**, demonstrando os principais conceitos de acesso a dados em .NET com SQL Server.

---

## 🚀 FUNCIONALIDADES

| # | Funcionalidade | Descrição |
|---|----------------|-----------|
| **1** | **CREATE (Inserir)** | Insere um novo aluno no banco de dados |
| **2** | **READ (Listar todos)** | Lista todos os alunos usando modo conectado |
| **3** | **READ (Por ID)** | Busca um aluno específico pelo ID |
| **4** | **READ (Busca por nome)** | Busca alunos por parte do nome (LIKE) |
| **5** | **READ (Total)** | Obtém o total de alunos cadastrados |
| **6** | **UPDATE (Atualizar)** | Atualiza os dados de um aluno existente |
| **7** | **DELETE (Deletar)** | Remove um aluno do banco de dados |
| **8** | **READ (Desconectado)** | Lista alunos usando modo desconectado (DataTable) |

---

## 🔄 FLUXO DE EXECUÇÃO

```
┌─────────────────────────────────────────────────────────────┐
│                    ADOLAB - FLUXO COMPLETO                  │
└─────────────────────────────────────────────────────────────┘

1. Inicializar banco de dados
   │
   └── Verificar se tabela Alunos existe → Criar se necessário

2. CRUD - Create (Inserir)
   │
   └── Inserir 3 alunos: Ana, Carlos, Mariana

3. CRUD - Read (Consultar)
   │
   ├── Listar todos os alunos (modo conectado)
   ├── Buscar por ID
   ├── Buscar por nome (LIKE)
   └── Obter total de alunos (COUNT)

4. CRUD - Update (Atualizar)
   │
   └── Atualizar idade e email da Ana

5. CRUD - Read (Verificar atualização)
   │
   └── Buscar Ana novamente para confirmar

6. CRUD - Read (Modo desconectado)
   │
   └── Listar alunos usando DataTable

7. CRUD - Delete (Deletar)
   │
   └── Remover Mariana do banco

8. CRUD - Read (Total final)
   │
   └── Verificar que restaram 2 alunos
```

---

## 📁 ESTRUTURA DO PROJETO

```
ADOLab/
├── ADOLab.sln                      # Solução do Visual Studio
├── .gitignore                      # Arquivos ignorados pelo Git
├── README.md                       # Documentação do projeto
│
├── ADOLab.Console/                 # Camada de apresentação (Console App)
│   ├── ADOLab.Console.csproj       # Arquivo do projeto
│   ├── Program.cs                  # Ponto de entrada e testes
│   └── appsettings.json            # Configurações (connection string)
│
└── ADOLab.Data/                    # Camada de acesso a dados
    ├── ADOLab.Data.csproj          # Arquivo do projeto
    ├── Database/
    │   └── DatabaseInitializer.cs  # Inicialização do banco
    ├── Models/
    │   └── Aluno.cs                # Entidade Aluno
    └── Repositories/
        └── AlunoRepository.cs      # CRUD completo
```

---

## 🔬 TECNOLOGIAS UTILIZADAS

| Tecnologia | Aplicação |
|------------|-----------|
| **ADO.NET** | Acesso a dados com SQL Server |
| **SqlConnection** | Gerenciamento de conexão com o banco |
| **SqlCommand** | Execução de comandos SQL |
| **SqlParameter** | Prevenção de SQL Injection |
| **SqlDataReader** | Leitura forward-only (modo conectado) |
| **SqlDataAdapter** | Preenche DataTable (modo desconectado) |
| **Repository Pattern** | Encapsulamento da lógica de acesso a dados |

---

## 💻 CÓDIGOS IMPLEMENTADOS

### DatabaseInitializer.cs - Inicialização do Banco
```csharp
// Verifica e cria a tabela Alunos se não existir
const string createTableSql = @"
    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Alunos' AND xtype='U')
    BEGIN
        CREATE TABLE Alunos (
            Id INT IDENTITY(1,1) PRIMARY KEY,
            Nome NVARCHAR(100) NOT NULL,
            Idade INT NOT NULL,
            Email NVARCHAR(200) NULL,
            DataMatricula DATETIME NOT NULL DEFAULT GETDATE()
        );
    END";
```

### AlunoRepository.cs - Operações CRUD
```csharp
// CREATE - Inserir aluno (retorna ID gerado)
public int Inserir(Aluno aluno)
{
    const string sql = @"
        INSERT INTO Alunos (Nome, Idade, Email, DataMatricula) 
        VALUES (@Nome, @Idade, @Email, @DataMatricula);
        SELECT CAST(SCOPE_IDENTITY() AS INT);";
    
    // Usa parâmetros para prevenir SQL Injection
    cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 100).Value = aluno.Nome;
    // ...
    return (int)cmd.ExecuteScalar();
}

// READ - Listar todos (modo conectado)
public List<Aluno> ObterTodos()
{
    const string sql = "SELECT * FROM Alunos ORDER BY Nome";
    // SqlDataReader - leitura forward-only
    while (reader.Read())
    {
        alunos.Add(new Aluno { ... });
    }
    return alunos;
}

// UPDATE - Atualizar aluno
public bool Atualizar(Aluno aluno)
{
    const string sql = "UPDATE Alunos SET Nome=@Nome, Idade=@Idade, Email=@Email WHERE Id=@Id";
    int linhasAfetadas = cmd.ExecuteNonQuery();
    return linhasAfetadas > 0;
}

// DELETE - Remover aluno
public bool Deletar(int id)
{
    const string sql = "DELETE FROM Alunos WHERE Id=@Id";
    int linhasAfetadas = cmd.ExecuteNonQuery();
    return linhasAfetadas > 0;
}
```

---

## 📊 MÉTRICAS DE DESEMPENHO

### Operações Realizadas:
```
📊 3 alunos inseridos
🔍 4 tipos de consulta realizadas (todos, ID, nome, total)
📝 1 atualização realizada
🗑️ 1 deleção realizada
💾 2 modos de leitura testados (conectado e desconectado)
```

### Modos de Conexão:

| Modo | Características | Uso no Projeto |
|------|-----------------|----------------|
| **Conectado** | Conexão aberta, forward-only, baixa memória | `ObterTodos()`, `ObterPorId()`, `BuscarPorNome()` |
| **Desconectado** | Dados em memória, conexão fechada, editável | `ObterTodosDesconectado()` (DataTable) |

---

## 🎮 COMO USAR

```bash
# Clone o repositório
git clone https://github.com/isadorameneghetti/hands-on-c.git

# Entre na branch hands-on-08
git checkout hands-on-08

# Entre no diretório
cd ADOLab

# Restaure os pacotes
dotnet restore

# Compile o projeto
dotnet build

# Execute o programa
dotnet run --project ADOLab.Console\ADOLab.Console.csproj
```

### Saída esperada:

```
Banco de dados inicializado com sucesso.
=== ADO.NET CRUD - AlunoRepository ===

--- Inserindo alunos ---
Aluno inserido com ID: 1
Aluno inserido com ID: 2
Aluno inserido com ID: 3

Total de alunos: 3

--- Lista de alunos (modo conectado) ---
#1 - Ana Silva (22 anos) - ana@email.com
#2 - Carlos Santos (25 anos) - carlos@email.com
#3 - Mariana Oliveira (19 anos) - mariana@email.com

--- Buscando alunos com 'ana' ---
#1 - Ana Silva (22 anos)
#3 - Mariana Oliveira (19 anos)

--- Obter aluno por ID ---
ID 1: Ana Silva - ana@email.com

--- Atualizando aluno ---
Atualização bem-sucedida: True
Após atualização: Ana Silva - 23 anos - ana.silva@email.com

--- Modo desconectado (DataTable) ---
#1 - Ana Silva (23 anos)
#2 - Carlos Santos (25 anos)
#3 - Mariana Oliveira (19 anos)

--- Deletando aluno ---
Deleção bem-sucedida: True

Total final de alunos: 2

Pressione qualquer tecla para sair...
```

### Exemplo de Pesquisa:

```
--- Buscando alunos com 'ana' ---
🔎 Busca por 'ana' encontrou 2 aluno(s):
   #1 - Ana Silva (22 anos)
   #3 - Mariana Oliveira (19 anos)
```

---

## ✅ VALIDAÇÃO DOS REQUISITOS

| # | Requisito | Status | Implementação |
|---|-----------|--------|----------------|
| 1 | Inserir aluno com retorno do ID | ✅ | `ExecuteScalar` + `SCOPE_IDENTITY()` |
| 2 | Listar todos os alunos | ✅ | `SqlDataReader` (modo conectado) |
| 3 | Buscar aluno por ID | ✅ | `SqlDataReader` com parâmetro |
| 4 | Buscar alunos por nome (LIKE) | ✅ | `LIKE @Termo` com parâmetro |
| 5 | Obter total de alunos | ✅ | `ExecuteScalar` com `COUNT(*)` |
| 6 | Atualizar dados do aluno | ✅ | `ExecuteNonQuery` com parâmetros |
| 7 | Deletar aluno por ID | ✅ | `ExecuteNonQuery` com parâmetro |
| 8 | Modo desconectado (DataTable) | ✅ | `SqlDataAdapter` + `DataTable` |
| 9 | Prevenção de SQL Injection | ✅ | `SqlParameter` em todos os comandos |
| 10 | Boas práticas com `using` | ✅ | Garantia de fechamento da conexão |
| 11 | Centralização da connection string | ✅ | `appsettings.json` |

---

## 📝 DIVISÃO DE TAREFAS

| Integrante | Tarefas |
|------------|---------|
| **Isadora Meneghetti** | - Análise dos requisitos<br>- Implementação do CRUD completo<br>- Criação do repositório<br>- Documentação do README |

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Aplicação no Projeto |
|----------|----------------------|
| **SqlConnection** | Gerenciamento de conexão com SQL Server |
| **SqlCommand** | Execução de comandos SQL |
| **SqlParameter** | Prevenção de SQL Injection |
| **ExecuteNonQuery** | INSERT, UPDATE, DELETE |
| **ExecuteScalar** | COUNT(*) e SCOPE_IDENTITY() |
| **ExecuteReader** | SELECT com SqlDataReader |
| **SqlDataReader** | Modo Conectado - leitura forward-only |
| **SqlDataAdapter + DataTable** | Modo Desconectado - dados em memória |
| **Repository Pattern** | Encapsulamento da lógica de acesso a dados |
| **using** | Garantia de liberação de recursos |
| **appsettings.json** | Centralização da connection string |

---

## 📦 REQUISITOS

- .NET SDK 8.0 ou superior
- SQL Server LocalDB ou SQL Server Express
- Windows / Linux / macOS

---

## 🎯 RESULTADOS OBTIDOS

### Funcionalidades Implementadas:
- ✅ CRUD completo (Create, Read, Update, Delete)
- ✅ Modo conectado com SqlDataReader
- ✅ Modo desconectado com DataTable
- ✅ Prevenção de SQL Injection com parâmetros
- ✅ Boas práticas com `using` e centralização de configuração
- ✅ Repository Pattern para organização do código

### Qualidade do Código:
- ✅ Separação de responsabilidades (Models, Repositories, Database)
- ✅ Uso consistente de parâmetros em todos os comandos
- ✅ Tratamento adequado de valores nulos (DBNull.Value)
- ✅ Código comentado para facilitar compreensão

---

## 💡 APRENDIZADOS

1. **ADO.NET** - Biblioteca fundamental para acesso a dados em .NET
2. **SQL Injection** - Como prevenir com `SqlParameter`
3. **Modos de conexão** - Diferenças entre conectado e desconectado
4. **Repository Pattern** - Organização e manutenibilidade do código
5. **Boas práticas** - `using`, centralização de config, tratamento de null
6. **Execute vs Read** - Quando usar cada método do SqlCommand
7. **DataTable vs SqlDataReader** - Vantagens de cada abordagem

---

<p align="center">
  Desenvolvido com ❤️ por Isadora Meneghetti - FIAP
</p>