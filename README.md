# 📅 DominoPontaDeQuina - Sistema de Gerenciamento de Jogos de Dominó com EF Core

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)
![Console](https://img.shields.io/badge/Console-4EAA25?style=for-the-badge&logo=windows-terminal&logoColor=white)

## 👤 INTEGRANTE

| Nome | RM |
|------|-----|
| **Isadora Meneghetti** | RM556326 |

---

## 📚 DISCIPLINA

**Entity Framework Core - Acesso a Dados com ORM**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O PROJETO

Este projeto implementa o modelo de dados do jogo de dominó **"Ponta de Quina"** utilizando **Entity Framework Core** como ORM (Object-Relational Mapper).

O sistema gerencia:
- 👤 **Usuários** - Cadastro de usuários do sistema
- 🎮 **Jogadores** - Perfis de jogadores associados a usuários
- 🏆 **Jogos** - Partidas de dominó registradas
- 📊 **Participações** - Registro de jogadores em cada partida

---

## 🎯 OBJETIVO DO LABORATÓRIO

Evoluir o modelo de dados do jogo de dominó utilizando EF Core, aplicando diferentes abordagens de configuração:

| Entidade | Configuração | Descrição |
|----------|--------------|-----------|
| **Usuario** | Fluent API | Configurado via `OnModelCreating()` no DbContext |
| **Jogador** | Data Annotations | Configurado com atributos nas propriedades |
| **Jogo** | Convenções | Apenas propriedades, sem anotações ou Fluent API |

---

## 🗄️ ESTRUTURA DO BANCO DE DADOS

### Diagrama de Entidades

```
┌─────────────┐          ┌─────────────┐          ┌─────────────┐
│   Usuario   │ 1      N │   Jogador   │ 1      N │  Jogo       │
├─────────────┤──────────├─────────────┤──────────├─────────────┤
│ Id (PK)     │          │ Id (PK)     │          │ Id (PK)     │
│ Nome        │          │ NomeExibicao│          │ IniciadoEm  │
│ Email       │          │ UsuarioId   │          │ FinalizadoEm│
│ HashSenha   │          │ Usuario (FK)│          │ Status      │
│ CriadoEm    │          └─────────────┘          └─────────────┘
└─────────────┘                    ↑                        ↑
                                   │ N                      │ 1
                                   │                        │
                                   └────────────────────────┘
                                   │ N           1          │
                                   ▼                        ▼
                          ┌─────────────────────────────────────┐
                          │      ParticipacaoJogo               │
                          ├─────────────────────────────────────┤
                          │ Id (PK)                             │
                          │ JogoId (FK)                         │
                          │ JogadorId (FK)                      │
                          │ Posicao                             │
                          │ Pontuacao                           │
                          │ Vencedor                            │
                          └─────────────────────────────────────┘
```

---

## ⚙️ TECNOLOGIAS UTILIZADAS

| Tecnologia | Versão | Descrição |
|------------|--------|-----------|
| **.NET** | 8.0 | Plataforma de desenvolvimento |
| **C#** | 12.0 | Linguagem de programação |
| **Entity Framework Core** | 8.0.15 | ORM para acesso a dados |
| **SQLite** | 8.0.15 | Banco de dados leve embarcado |
| **Microsoft.EntityFrameworkCore.Design** | 8.0.15 | Ferramentas de design para migrações |
| **Microsoft.EntityFrameworkCore.Tools** | 8.0.15 | Ferramentas CLI para migrações |

---

## 📁 ESTRUTURA DO PROJETO

```
DominoPontaDeQuina-main/
│
├── DominoPontaDeQuina.Domain/              # Camada de Domínio
│   ├── Entities/
│   │   ├── Usuario.cs                      # ✅ Fluent API
│   │   ├── Jogador.cs                      # ✅ Data Annotations
│   │   ├── Jogo.cs                         # ✅ Convenções
│   │   ├── ParticipacaoJogo.cs             # ✅ Data Annotations
│   │   └── StatusJogo.cs                   # Enum
│   └── DominoPontaDeQuina.Domain.csproj
│
├── DominoPontaDeQuina.Repository/          # Camada de Repositório
│   ├── Context/
│   │   └── DominoDbContext.cs              # ✅ Fluent API + DbSets
│   ├── Repositories/
│   │   └── UsuarioRepository.cs
│   └── DominoPontaDeQuina.Repository.csproj
│
├── DominoPontaDeQuina.Migrations/          # Projeto de Migrações
│   ├── DominoDbContextFactory.cs
│   ├── Program.cs
│   ├── SeedData.cs
│   ├── domino.db                           # Banco de dados SQLite
│   ├── Migrations/                         # Pasta gerada pelo EF Core
│   │   └── 20260813123517_InitialCreate.cs
│   └── DominoPontaDeQuina.Migrations.csproj
│
└── DominoPontaDeQuina.Tests/               # Testes Unitários
    ├── JogoTests.cs
    ├── MaoJogadorGapTests.cs
    ├── PartidaFluxoTests.cs
    ├── PartidaGapTests.cs
    ├── RodadaExcecaoTests.cs
    ├── RodadaFinalizacaoGapTests.cs
    ├── RodadaGapTests.cs
    ├── TabuleiroGapTests.cs
    └── DominoPontaDeQuina.Tests.csproj
```

---

## 🏗️ CONFIGURAÇÃO DAS ENTIDADES

### 1. Usuario - Fluent API ✅

```csharp
// DominoDbContext.cs
private void ConfigureUsuario(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Usuario>(entity =>
    {
        entity.ToTable("Usuarios");
        entity.HasKey(u => u.Id);
        entity.Property(u => u.Nome)
            .IsRequired()
            .HasMaxLength(100);
        entity.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);
        entity.HasIndex(u => u.Email).IsUnique();
        entity.Property(u => u.HashSenha)
            .IsRequired()
            .HasMaxLength(255);
        entity.Property(u => u.CriadoEm)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        entity.HasMany(u => u.Jogadores)
            .WithOne(j => j.Usuario)
            .HasForeignKey(j => j.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);
    });
}
```

### 2. Jogador - Data Annotations ✅

```csharp
// Jogador.cs
[Table("Jogadores")]
public class Jogador
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    [Column("NomeExibicao")]
    public string NomeExibicao { get; set; } = string.Empty;

    [Required]
    [Column("UsuarioId")]
    public Guid UsuarioId { get; set; }

    [ForeignKey(nameof(UsuarioId))]
    public Usuario Usuario { get; set; } = null!;

    public ICollection<ParticipacaoJogo> Participacoes { get; set; } = new List<ParticipacaoJogo>();
}
```

### 3. Jogo - Convenções ✅

```csharp
// Jogo.cs - SEM anotações, apenas propriedades
public class Jogo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime IniciadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? FinalizadoEm { get; set; }
    public StatusJogo Status { get; set; } = StatusJogo.Aguardando;
    public ICollection<ParticipacaoJogo> Participacoes { get; set; } = new List<ParticipacaoJogo>();
}
```

---

## 🔧 COMANDOS DE MIGRAÇÃO

### Instalar a ferramenta globalmente

```bash
dotnet tool install --global dotnet-ef
```

### Criar a migração inicial

```bash
cd DominoPontaDeQuina.Migrations
dotnet ef migrations add InitialCreate --context DominoDbContext --startup-project .
```

### Aplicar a migração ao banco

```bash
dotnet ef database update --context DominoDbContext --startup-project .
```

### Remover a última migração (não aplicada)

```bash
dotnet ef migrations remove --context DominoDbContext --startup-project .
```

### Gerar script SQL da migração

```bash
dotnet ef migrations script --context DominoDbContext --startup-project .
```

---

## 🚀 COMO EXECUTAR

### Pré-requisitos

- .NET SDK 8.0 ou superior
- Git (para clonar o repositório)

### Passos

```bash
# 1. Restaurar pacotes
dotnet restore

# 2. Entrar na pasta de migrações
cd DominoPontaDeQuina.Migrations

# 3. Criar a migration
dotnet ef migrations add InitialCreate --context DominoDbContext --startup-project .

# 4. Aplicar a migration
dotnet ef database update --context DominoDbContext --startup-project .

# 5. Executar o programa
dotnet run
```

---

## 📊 SAÍDA ESPERADA

```
=== DOMINO PONTA DE QUINA - HANDS ON AULA 14 ===

--- Verificando Banco de Dados ---
✓ Banco existe: True
✓ Migrações aplicadas: 20260813123517_InitialCreate

--- Executando Seed ---
Inserindo dados iniciais...
✓ 3 usuários criados
✓ 4 jogadores criados
✓ Jogo criado com 4 participantes
✅ Seed concluído com sucesso!

--- Dados no Banco ---

📋 Usuários (3):
  - João Silva (joao@email.com)
    * Jogador: Joãozinho (ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
    * Jogador: Joãozinho2 (ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
  - Maria Oliveira (maria@email.com)
    * Jogador: Mariazinha (ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
  - Pedro Santos (pedro@email.com)
    * Jogador: Pedrinho (ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)

📋 Jogos (1):
  - Jogo ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Status: EmAndamento | Iniciado: 13/08/2026 09:35

✅ Verificação concluída com sucesso!

📋 RESUMO DO HANDS ON:
   ✅ Usuario configurado com Fluent API
   ✅ Jogador configurado com Data Annotations
   ✅ Jogo configurado por convenções
   ✅ DominoDbContext com DbSets necessários
   ✅ Conexão SQLite configurada
   ✅ Migration aplicada ao banco
```

---

## 📈 APRENDIZADOS

### Primeiro Semestre
1. **Organização de código** - Separação em camadas (Domain, Repository, Migrations)
2. **Entity Framework Core** - ORM para mapeamento objeto-relacional
3. **Fluent API** - Configuração programática de entidades
4. **Data Annotations** - Configuração declarativa com atributos
5. **Convenções do EF Core** - Comportamento padrão do ORM
6. **Migrations** - Versionamento e evolução do esquema do banco
7. **SQLite** - Banco de dados leve embarcado

### Segundo Semestre
8. **Repository Pattern** - Encapsulamento da lógica de acesso a dados
9. **DbSet** - Coleção de entidades no contexto
10. **DbContext** - Sessão de trabalho com o banco de dados
11. **OnModelCreating** - Configuração centralizada do modelo
12. **Relacionamentos** - 1:N, N:N e 1:1 com EF Core
13. **Seed Data** - População inicial do banco de dados

---

## 🔗 LINKS ÚTEIS

- [Documentação EF Core](https://learn.microsoft.com/pt-br/ef/core/)
- [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [SQLite](https://www.sqlite.org/index.html)
- [.NET Download](https://dotnet.microsoft.com/download)

---

<p align="center">
  <b>FIAP - Faculdade de Informática e Administração Paulista</b><br>
  Desenvolvido com ❤️ por <b>Isadora Meneghetti</b><br>
  © 2026 - Todos os direitos reservados
</p>