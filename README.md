# 📅 DominoPontaDeQuina - Sistema de Gerenciamento de Jogos de Dominó com EF Core

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-5E2B97?style=for-the-badge&logo=xunit&logoColor=white)

---

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

Este projeto implementa o modelo de dados do jogo de dominó **"Ponta de Quina"** utilizando **Entity Framework Core** como ORM (Object-Relational Mapper), com uma arquitetura completa em camadas.

O sistema gerencia:
- 👤 **Usuários** - Cadastro de usuários do sistema
- 🎮 **Jogadores** - Perfis de jogadores associados a usuários
- 🏆 **Partidas** - Jogos de dominó registrados
- 📊 **Participações** - Registro de jogadores em cada partida

---

## 🎯 OBJETIVO DO LABORATÓRIO

Evoluir o modelo de dados do jogo de dominó utilizando EF Core, aplicando diferentes abordagens de configuração:

| Entidade | Configuração | Descrição |
|----------|--------------|-----------|
| **Usuario** | Fluent API | Configurado via `OnModelCreating()` no DbContext |
| **Jogador** | Fluent API | Configurado via `OnModelCreating()` no DbContext |
| **Partida** | Fluent API | Configurado via `OnModelCreating()` no DbContext |
| **ParticipacaoPartida** | Fluent API | Configurado via `OnModelCreating()` no DbContext |

---

## 🗄️ ESTRUTURA DO BANCO DE DADOS

### Diagrama de Entidades

```
┌─────────────┐          ┌─────────────┐          ┌─────────────┐
│   Usuario   │ 1      N │   Jogador   │ 1      N │   Partida   │
├─────────────┤──────────├─────────────┤──────────├─────────────┤
│ Id (PK)     │          │ Id (PK)     │          │ Id (PK)     │
│ Nome        │          │ NomeExibicao│          │ IniciadoEm  │
│ Email       │          │ UsuarioId   │          │ FinalizadoEm│
│ HashSenha   │          │ Usuario (FK)│          │ Status      │
│ CriadoEm    │          └─────────────┘          │ PontuacaoAlvo│
└─────────────┘                    ↑              └─────────────┘
                                   │ N                        ↑
                                   │                          │ 1
                                   │                          │
                                   └──────────────────────────┘
                                   │ N             1          │
                                   ▼                          │
                          ┌─────────────────────────────────────┐
                          │    ParticipacaoPartida              │
                          ├─────────────────────────────────────┤
                          │ Id (PK)                             │
                          │ PartidaId (FK)                      │
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
| **xUnit** | 2.9.2 | Framework de testes unitários |
| **coverlet.collector** | 6.0.2 | Cobertura de testes |
| **Microsoft.EntityFrameworkCore.Design** | 8.0.15 | Ferramentas de design para migrações |
| **Microsoft.EntityFrameworkCore.Tools** | 8.0.15 | Ferramentas CLI para migrações |

---

## 📁 ESTRUTURA DO PROJETO

```
DominoPontaDeQuina-main/
│
├── DominoPontaDeQuina.Core/                # 🧠 Núcleo do Domínio
│   ├── Enums/
│   │   ├── LadoTabuleiro.cs
│   │   ├── StatusJogada.cs
│   │   ├── StatusPartida.cs
│   │   ├── StatusRodada.cs
│   │   └── TipoFinalizacaoRodada.cs
│   ├── Exceptions/
│   │   ├── DominoException.cs
│   │   ├── JogadaInvalidaException.cs
│   │   ├── PartidaException.cs
│   │   └── RodadaException.cs
│   ├── Interfaces/
│   │   ├── IJogada.cs
│   │   ├── IMaoJogador.cs
│   │   ├── IPartida.cs
│   │   └── IRodada.cs
│   ├── Models/
│   │   ├── Jogada.cs
│   │   ├── Jogador.cs
│   │   ├── MaoJogador.cs
│   │   ├── Partida.cs
│   │   ├── Peca.cs
│   │   ├── Rodada.cs
│   │   ├── Tabuleiro.cs
│   │   └── Time.cs
│   ├── Services/
│   │   ├── DistribuicaoService.cs
│   │   ├── ITabuleiroService.cs
│   │   └── TabuleiroService.cs
│   ├── Validators/
│   │   ├── JogadaValidator.cs
│   │   └── PartidaValidator.cs
│   └── Jogo.cs
│
├── DominoPontaDeQuina.Domain/              # 📦 Entidades para Persistência
│   └── Entities/
│       ├── Jogador.cs
│       ├── Partida.cs
│       ├── ParticipacaoPartida.cs
│       ├── StatusPartida.cs
│       └── Usuario.cs
│
├── DominoPontaDeQuina.Repository/          # 🗄️ Camada de Dados
│   ├── Context/
│   │   └── DominoDbContext.cs              # ✅ Fluent API
│   ├── Extensions/
│   │   └── ServiceCollectionExtensions.cs
│   ├── Interfaces/
│   │   ├── IJogadorRepository.cs
│   │   ├── IPartidaRepository.cs
│   │   ├── IParticipacaoPartidaRepository.cs
│   │   ├── IRepository.cs
│   │   ├── IUnitOfWork.cs
│   │   └── IUsuarioRepository.cs
│   ├── Repositories/
│   │   ├── BaseRepository.cs
│   │   ├── JogadorRepository.cs
│   │   ├── PartidaRepository.cs
│   │   ├── ParticipacaoPartidaRepository.cs
│   │   └── UsuarioRepository.cs
│   └── UnitOfWork/
│       └── UnitOfWork.cs
│
├── DominoPontaDeQuina.Migrations/          # 🔄 Migrações EF Core
│   ├── DominoDbContextFactory.cs
│   ├── Program.cs
│   ├── domino.db                           # Banco de dados SQLite
│   └── Migrations/                         # Pasta gerada pelo EF Core
│       └── 20260825121106_InitialCreate.cs
│
└── DominoPontaDeQuina.Tests/               # 🧪 Testes Unitários
    ├── Models/
    │   ├── MaoJogadorTests.cs
    │   ├── PartidaTests.cs
    │   ├── PecaTests.cs
    │   └── TabuleiroTests.cs
    ├── JogoTests.cs
    ├── MaoJogadorGapTests.cs
    ├── PartidaFluxoTests.cs
    ├── PartidaGapTests.cs
    ├── RodadaExcecaoTests.cs
    ├── RodadaFinalizacaoGapTests.cs
    ├── RodadaGapTests.cs
    └── TabuleiroGapTests.cs
```

---

## 🏗️ CONFIGURAÇÃO DAS ENTIDADES

### 1. Usuario - Fluent API ✅

```csharp
// DominoDbContext.cs
private static void ConfigureUsuario(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Usuario>(entity =>
    {
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
            .OnDelete(DeleteBehavior.Restrict);
    });
}
```

### 2. Jogador - Fluent API ✅

```csharp
// DominoDbContext.cs
private static void ConfigureJogador(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Jogador>(entity =>
    {
        entity.HasKey(j => j.Id);
        entity.Property(j => j.NomeExibicao)
            .IsRequired()
            .HasMaxLength(100);
        entity.Property(j => j.UsuarioId)
            .IsRequired();
        entity.HasMany(j => j.Participacoes)
            .WithOne(p => p.Jogador)
            .HasForeignKey(p => p.JogadorId)
            .OnDelete(DeleteBehavior.Cascade);
    });
}
```

### 3. Partida - Fluent API ✅

```csharp
// DominoDbContext.cs
private static void ConfigurePartida(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Partida>(entity =>
    {
        entity.HasKey(p => p.Id);
        entity.Property(p => p.IniciadoEm)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        entity.Property(p => p.Status)
            .IsRequired()
            .HasConversion<int>();
        entity.Property(p => p.PontuacaoAlvo)
            .IsRequired()
            .HasDefaultValue(50);
        entity.HasMany(p => p.Participacoes)
            .WithOne(pp => pp.Partida)
            .HasForeignKey(pp => pp.PartidaId)
            .OnDelete(DeleteBehavior.Cascade);
    });
}
```

### 4. ParticipacaoPartida - Fluent API ✅

```csharp
// DominoDbContext.cs
private static void ConfigureParticipacaoPartida(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<ParticipacaoPartida>(entity =>
    {
        entity.HasKey(pp => pp.Id);
        entity.Property(pp => pp.PartidaId).IsRequired();
        entity.Property(pp => pp.JogadorId).IsRequired();
        entity.Property(pp => pp.Posicao).IsRequired();
        entity.Property(pp => pp.Pontuacao)
            .IsRequired()
            .HasDefaultValue(0);
        entity.Property(pp => pp.Vencedor)
            .IsRequired()
            .HasDefaultValue(false);
        entity.HasIndex(pp => new { pp.PartidaId, pp.JogadorId })
            .IsUnique();
    });
}
```

---

## 📦 REPOSITORIES COM LINQ

### Exemplo de Consultas LINQ no Repository

```csharp
// PartidaRepository.cs
public async Task<IEnumerable<Partida>> GetByJogadorAsync(Guid jogadorId)
{
    return await _dbSet
        .Where(p => p.Participacoes.Any(pp => pp.JogadorId == jogadorId))
        .Include(p => p.Participacoes)
            .ThenInclude(pp => pp.Jogador)
        .OrderByDescending(p => p.IniciadoEm)
        .ToListAsync();
}

public async Task<IEnumerable<Partida>> GetPartidasComPontuacaoAcimaAsync(int pontuacaoMinima)
{
    return await _dbSet
        .Where(p => p.Participacoes.Any(pp => pp.Pontuacao > pontuacaoMinima))
        .Include(p => p.Participacoes)
        .OrderByDescending(p => p.IniciadoEm)
        .ToListAsync();
}
```

```csharp
// JogadorRepository.cs
public async Task<IEnumerable<Jogador>> GetJogadoresRankingAsync()
{
    return await _dbSet
        .Include(j => j.Participacoes)
        .Select(j => new
        {
            Jogador = j,
            PontuacaoTotal = j.Participacoes.Sum(pp => pp.Pontuacao)
        })
        .OrderByDescending(x => x.PontuacaoTotal)
        .Select(x => x.Jogador)
        .ToListAsync();
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

### Listar migrações aplicadas

```bash
dotnet ef migrations list --context DominoDbContext --startup-project .
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

# 2. Construir a solução
dotnet build

# 3. Entrar na pasta de migrações
cd DominoPontaDeQuina.Migrations

# 4. Criar a migration
dotnet ef migrations add InitialCreate --context DominoDbContext --startup-project .

# 5. Aplicar a migration
dotnet ef database update --context DominoDbContext --startup-project .

# 6. Voltar para a raiz e executar os testes
cd ..
dotnet test
```

---

## 🧪 TESTES

### Executar todos os testes

```bash
dotnet test
```

### Executar testes por categoria

```bash
# Testes básicos
dotnet test --filter "Categoria=Basico"

# Testes de exceção
dotnet test --filter "Categoria=Excecao"

# Testes de gap
dotnet test --filter "Categoria=Gap"
```

### Resumo dos Testes

| Categoria | Testes | Status |
|-----------|--------|--------|
| Básicos | 44 | ✅ Passando |
| Exceção | 8 | ✅ Passando |
| Gap | 26 | ✅ Passando |
| **Total** | **78** | **✅ 100% Passando** |

---

## 🎮 EXEMPLO DE USO

### Usando o UnitOfWork

```csharp
using DominoPontaDeQuina.Domain.Entities;
using DominoPontaDeQuina.Repository.Context;
using DominoPontaDeQuina.Repository.UnitOfWork;

var optionsBuilder = new DbContextOptionsBuilder<DominoDbContext>();
optionsBuilder.UseSqlite("Data Source=../DominoPontaDeQuina.Migrations/domino.db");

using var context = new DominoDbContext(optionsBuilder.Options);
var unitOfWork = new UnitOfWork(context);

// 1. Criar um usuário
var usuario = new Usuario
{
    Nome = "João Silva",
    Email = "joao@email.com",
    HashSenha = "hash_123456"
};
await unitOfWork.Usuarios.AddAsync(usuario);
await unitOfWork.CompleteAsync();

// 2. Criar um jogador
var jogador = new Jogador
{
    NomeExibicao = "Joãozinho",
    UsuarioId = usuario.Id
};
await unitOfWork.Jogadores.AddAsync(jogador);
await unitOfWork.CompleteAsync();

// 3. Criar uma partida
var partida = new Partida
{
    PontuacaoAlvo = 50,
    Status = StatusPartida.EmAndamento
};
await unitOfWork.Partidas.AddAsync(partida);
await unitOfWork.CompleteAsync();

// 4. Adicionar participação
var participacao = new ParticipacaoPartida
{
    PartidaId = partida.Id,
    JogadorId = jogador.Id,
    Posicao = 1,
    Pontuacao = 25
};
await unitOfWork.ParticipacoesPartidas.AddAsync(participacao);
await unitOfWork.CompleteAsync();

// 5. Buscar partidas do jogador
var partidas = await unitOfWork.Partidas.GetByJogadorAsync(jogador.Id);
foreach (var p in partidas)
{
    Console.WriteLine($"Partida: {p.Id} - Status: {p.Status}");
}
```

---

## 📊 SAÍDA ESPERADA

```
=== DOMINO PONTA DE QUINA - LABORATÓRIO EF CORE ===

--- Verificando Banco de Dados ---
✓ Banco existe: True
✓ Migrações aplicadas: 20260825121106_InitialCreate

--- Executando Seed ---
Inserindo dados iniciais...
✓ 3 usuários criados
✓ 4 jogadores criados
✓ Partida criada com 4 participantes
✅ Seed concluído com sucesso!

--- Executando Testes ---
[xUnit.net] Total: 78, Failed: 0, Succeeded: 78, Skipped: 0
✅ Todos os testes passaram!

--- Dados no Banco ---

📋 Usuários (3):
  - João Silva (joao@email.com)
    * Jogador: Joãozinho (ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
  - Maria Oliveira (maria@email.com)
    * Jogador: Mariazinha (ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
  - Pedro Santos (pedro@email.com)
    * Jogador: Pedrinho (ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)

📋 Partidas (1):
  - Partida ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
    * Status: EmAndamento
    * Iniciado: 25/08/2026 09:11
    * Pontuação Alvo: 50

📋 Participações (4):
  - Joãozinho (Posição: 1 | Pontos: 25 | Vencedor: False)
  - Mariazinha (Posição: 2 | Pontos: 18 | Vencedor: False)
  - Pedrinho (Posição: 3 | Pontos: 30 | Vencedor: False)
  - Ana (Posição: 4 | Pontos: 22 | Vencedor: False)

✅ Verificação concluída com sucesso!

📋 RESUMO DO LABORATÓRIO:
   ✅ Usuario configurado com Fluent API
   ✅ Jogador configurado com Fluent API
   ✅ Partida configurada com Fluent API
   ✅ ParticipacaoPartida configurada com Fluent API
   ✅ Índices únicos configurados
   ✅ Relacionamentos 1:N configurados
   ✅ Repositories implementados com LINQ
   ✅ UnitOfWork implementado
   ✅ Migration aplicada ao banco
   ✅ 78 testes passando (100% de sucesso)
```

---

## 📈 APRENDIZADOS

### Primeiro Semestre
1. **Organização de código** - Separação em camadas (Core, Domain, Repository, Migrations)
2. **Entity Framework Core** - ORM para mapeamento objeto-relacional
3. **Fluent API** - Configuração programática de entidades
4. **Migrations** - Versionamento e evolução do esquema do banco
5. **SQLite** - Banco de dados leve embarcado
6. **Relacionamentos** - 1:N e N:1 com EF Core

### Segundo Semestre
7. **Repository Pattern** - Encapsulamento da lógica de acesso a dados
8. **Unit of Work** - Gerenciamento de transações e repositórios
9. **LINQ** - Consultas avançadas com Includes, Filters e Aggregations
10. **Testes Unitários** - xUnit para validação do domínio
11. **Arquitetura em Camadas** - Core, Domain, Repository, Migrations, Tests
12. **Injeção de Dependência** - ServiceCollectionExtensions

---

## 🔗 LINKS ÚTEIS

- [Documentação EF Core](https://learn.microsoft.com/pt-br/ef/core/)
- [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [SQLite](https://www.sqlite.org/index.html)
- [xUnit Documentation](https://xunit.net/)
- [.NET Download](https://dotnet.microsoft.com/download)

---

## 📊 CHANGELOG

| Versão | Data | Alterações |
|--------|------|------------|
| 1.0.0 | 25/08/2026 | Versão inicial com todas as funcionalidades |

---

<p align="center">
  <b>FIAP - Faculdade de Informática e Administração Paulista</b><br>
  Desenvolvido com ❤️ por <b>Isadora Meneghetti</b><br>
  © 2026 - Todos os direitos reservados
</p>