# 🎮 PROJETOS C# - JOKEMPO & BLACKJACK & AGENDA & GCLAB & ASYNCLAB & ADOLAB & DOMINOPONTADEQUINA

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Console](https://img.shields.io/badge/Console-4EAA25?style=for-the-badge&logo=windows-terminal&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)

---

## 👥 INTEGRANTES DO GRUPO

| Nome | RM |
|------|-----|
| **Isadora Meneghetti** | RM556326 |
| **Gustavo Ikeda** | RM554718 |
| **Henrique Azevedo** | RM556707 |
| **Renato Alvarenga** | RM556403 |
| **Victoria Moura** | RM555474 |

---

## 📚 DISCIPLINA

### Primeiro Semestre
**Estruturas de Controle de Fluxo e Métodos em C#**

### Segundo Semestre
**Acesso a Bancos de Dados com ADO.NET**  
**Entity Framework Core - ORM para .NET**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O REPOSITÓRIO

Este repositório contém os projetos desenvolvidos durante a disciplina, abordando conceitos fundamentais de programação em C#:

### Primeiro Semestre
- Estruturas de controle de fluxo (`if/else`, `switch`, `while`, `for`, `foreach`)
- Métodos e funções
- Programação Orientada a Objetos
- Coleções e Listas
- Tratamento de exceções
- Trabalho com datas e fusos horários
- **Garbage Collection e gerenciamento de memória**
- **Programação Assíncrona e Paralelismo**

### Segundo Semestre
- **ADO.NET** - Acesso a bancos de dados relacionais
- **CRUD completo** (Create, Read, Update, Delete)
- **SQL Server** - Conexão e execução de comandos
- **Prevenção de SQL Injection** com `SqlParameter`
- **Modo Conectado vs Desconectado**
- **Repository Pattern**
- **Entity Framework Core** - ORM para acesso a dados
- **Fluent API** - Configuração programática de entidades
- **Data Annotations** - Configuração declarativa com atributos
- **Migrations** - Versionamento do esquema do banco
- **LINQ** - Consultas avançadas com LINQ

---

## 📁 ESTRUTURA DO REPOSITÓRIO (BRANCHES)

```
main                    # Branch principal (documentação)
│
├── [PRIMEIRO SEMESTRE]
│   ├── hands-on-01         # Jokempo v1 - Pedra, Papel e Tesoura
│   ├── hands-on-02         # Jokempo v2 - Com estatísticas e histórico
│   ├── hands-on-03         # Blackjack - Jogo de cartas 21
│   ├── hands-on-05         # AgendaConsole - Com fusos horários
│   ├── hands-on-05.2       # GCLab - Laboratório de Garbage Collection
│   └── hands-on-06         # AsyncLab - Laboratório de Programação Assíncrona
│
└── [SEGUNDO SEMESTRE]
    ├── hands-on-08         # ADOLab - CRUD com ADO.NET
    ├── hands-on-09         # DominoPontaDeQuina - EF Core (v1)
    └── hands-on-10         # DominoPontaDeQuina - EF Core + LINQ (v2)
```

---

## 📊 STATUS DAS BRANCHES

| Branch | Projeto | Descrição | Semestre | Status |
|--------|---------|-----------|----------|--------|
| `main` | Documentação | README principal do repositório | - | ✅ Ativo |
| `hands-on-01` | Jokempo v1 | Pedra, Papel e Tesoura (básico) | 1º | ✅ Concluído |
| `hands-on-02` | Jokempo v2 | Com estatísticas e histórico de jogadores | 1º | ✅ Concluído |
| `hands-on-03` | Blackjack 21 | Jogo de cartas Blackjack | 1º | ✅ Concluído |
| `hands-on-05` | AgendaConsole | Sistema de agenda com fusos horários | 1º | ✅ Concluído |
| `hands-on-05.2` | **GCLab** | Laboratório de Garbage Collection | 1º | ✅ Concluído |
| `hands-on-06` | **AsyncLab** | Laboratório de Programação Assíncrona | 1º | ✅ Concluído |
| `hands-on-08` | **ADOLab** | CRUD com ADO.NET e SQL Server | 2º | ✅ Concluído |
| `hands-on-09` | **DominoPontaDeQuina** | Modelo de dados com EF Core (v1) | 2º | ✅ Concluído |
| `hands-on-10` | **DominoPontaDeQuina** | EF Core + LINQ (v2) | 2º | ✅ Concluído |

---

## 🎮 PROJETO 1: JOKEMPO V1 (hands-on-01)

### Sobre o Projeto
Jogo de Pedra, Papel e Tesoura onde o usuário joga contra o computador.

### Regras do Jogo
| Escolha | Ganha de | Perde para |
|---------|----------|------------|
| 🪨 Pedra | ✂️ Tesoura | 📄 Papel |
| 📄 Papel | 🪨 Pedra | ✂️ Tesoura |
| ✂️ Tesoura | 📄 Papel | 🪨 Pedra |

### Como Jogar
```bash
git checkout hands-on-01
cd Jokempo
dotnet run
```

1. Digite seu nome
2. Escolha sua jogada:
   - **[1] Pedra** 🪨
   - **[2] Papel** 📄
   - **[3] Tesoura** ✂️
3. Veja o resultado e acumule pontos

---

## 🎮 PROJETO 2: JOKEMPO V2 (hands-on-02)

### Novidades da Versão 2
- ✅ Modularização do código com métodos
- ✅ Validação de entrada de dados
- ✅ Gravação do nome do jogador
- ✅ Permite mudar de jogador
- ✅ Estatísticas completas dos jogadores

### Estatísticas Exibidas
- Total de partidas jogadas
- Vitórias
- Derrotas
- Empates
- Taxa de aproveitamento

### Como Jogar
```bash
git checkout hands-on-02
cd Jokempo
dotnet run
```

---

## 🃏 PROJETO 3: BLACKJACK 21 (hands-on-03)

### Sobre o Projeto
Jogo de cartas Blackjack (21) desenvolvido com Programação Orientada a Objetos.

### Valores das Cartas
| Carta | Valor |
|-------|-------|
| 2, 3, 4, 5, 6, 7, 8, 9, 10 | Valor nominal |
| Valete (J), Dama (Q), Rei (K) | 10 |
| Ás (A) | 11 ou 1 |

### Regras do Jogo
- Jogador começa com 2 cartas
- Pode **comprar** (Hit) ou **parar** (Stand)
- Computador compra até atingir 17 pontos
- Quem chegar mais perto de 21 (sem estourar) vence

### Como Jogar
```bash
git checkout hands-on-03
cd Blackjack
dotnet run
```

### Sistema de Pontuação
| Resultado | Pontos |
|-----------|--------|
| 🏆 Vitória | +100 |
| ❌ Derrota | 0 |
| 🤝 Empate | 0 |

---

## 📅 PROJETO 4: AGENDACONSOLE (hands-on-05)

### Sobre o Projeto
Sistema de agenda com suporte a múltiplos fusos horários.

### Funcionalidades
- ✅ Adicionar compromissos com data, hora e fuso horário
- ✅ Exibir compromissos do dia atual
- ✅ Exibir compromissos por data específica
- ✅ Conversão automática entre fusos UTC

### Fusos Horários Suportados
| Fuso | TimeZone ID (Windows) |
|------|----------------------|
| UTC-5 | `SA Pacific Standard Time` |
| UTC-4 | `SA Western Standard Time` |
| UTC-3 | `E. South America Standard Time` |
| UTC-5 | `Eastern Standard Time` |
| UTC-8 | `Pacific Standard Time` |
| UTC+0 | `GMT Standard Time` |
| UTC+5 | `Pakistan Standard Time` |
| UTC+9 | `Tokyo Standard Time` |

### Como Executar
```bash
git checkout hands-on-05
cd AgendaConsole
dotnet run
```

---

## 🗑️ PROJETO 5: GCLAB (hands-on-05.2)

### Sobre o Projeto
Laboratório de Garbage Collection em C# - Identificação e Correção de Memory Leaks.

### Problemas Propositais

| # | Problema | Descrição |
|---|----------|-----------|
| **1** | **Event Leak** | Subscriber inscrito em evento sem nunca desinscrever |
| **2** | **LOH + Cache Estático** | Buffer grande (200KB) no LOH armazenado em cache estático sem expiração |
| **3** | **Pinned Buffer** | Buffer fixado (pinned) por longo período, impedindo movimentação do GC |
| **4** | **String Concatenação** | 50.000 concatenações gerando resíduo no Gen0/Gen1 |
| **5** | **Recurso externo sem Dispose** | StreamWriter sem liberação adequada, dependendo apenas do finalizador |

### Correções Aplicadas

| Problema | Solução |
|----------|---------|
| **Event Leak** | Implementar `IDisposable` e remover evento no `Dispose()` |
| **LOH + Cache** | Usar `WeakReference` + política FIFO de remoção |
| **Pinned Buffer** | Implementar `IDisposable` para desfixar via `GCHandle.Free()` |
| **String Concat** | Substituir por `StringBuilder` |
| **Recurso externo** | Implementar `IDisposable` padrão com `Dispose()` do StreamWriter |

### Como Executar
```bash
git checkout hands-on-05.2
cd GCLab
dotnet run
```

### Exemplo de saída (após correção):
```
--- Verificação de sobreviventes (WeakReference) ---
subscriber: coletado
lohBuffer: coletado
pinnedBuffer: coletado
logger: coletado
-----------------------------------------------
✅ GC limpo: nenhuma referência indesejada permaneceu viva.
```

---

## ⚡ PROJETO 6: ASYNCLAB (hands-on-06)

### Sobre o Projeto
Laboratório de Programação Assíncrona em C# - Gerenciamento de arquivos, processamento paralelo e sistema de pesquisa.

### Funcionalidades Completas

| # | Funcionalidade | Descrição |
|---|----------------|-----------|
| **1** | **Verificação de arquivo** | Verifica se o CSV local existe antes de baixar |
| **2** | **Backup automático** | Cria backup do arquivo antes de modificações |
| **3** | **Modificações aleatórias** | Altera ~30% dos registros para simular dados corrompidos |
| **4** | **Download atualizado** | Baixa nova versão do CSV da Receita Federal |
| **5** | **Comparação de arquivos** | Compara versão local com oficial e gera relatório |
| **6** | **Processamento PBKDF2** | Aplica 50.000 iterações de SHA-256 por município |
| **7** | **Exportação multi-formato** | Salva por UF em CSV, JSON e formato binário |
| **8** | **Pesquisa interativa** | Busca por UF, parte do nome ou código IBGE |

### Fluxo de Execução

```
1. Verificar existência do arquivo municipios.csv
   ├── SIM → Backup → Modificações aleatórias (30% dos registros)
   └── NÃO → Segue para download

2. Baixar nova versão (municipios_receita.csv)

3. Comparar arquivos
   └── Salvar diferenças em diferencas_municipios.csv

4. Processar hashes PBKDF2 (50.000 iterações)

5. Salvar por UF em 3 formatos:
   ├── CSV  (municipios_hash_UF.csv)
   ├── JSON (municipios_hash_UF.json)
   └── BIN  (municipios_UF.bin) + TXT para debug

6. Menu interativo de pesquisa:
   ├── Pesquisar por UF
   ├── Pesquisar por nome (parcial)
   └── Pesquisar por código IBGE
```

### Estrutura de Arquivos Gerados

```
AsyncLab/
├── backup/                              # Backups automáticos
│   └── municipios_backup_YYYYMMDD_HHmmss.csv
│
├── mun_hash_por_uf/                     # CSV e JSON por UF
│   ├── municipios_hash_AC.csv
│   ├── municipios_hash_AC.json
│   └── ... (27 UFs)
│
├── binario_por_uf/                      # Formato binário por UF
│   ├── municipios_AC.bin
│   ├── municipios_AC.txt   # Debug
│   └── ...
│
└── diferencas_municipios.csv            # Relatório de diferenças
```

### Resultados de Performance

| Métrica | Valor |
|---------|-------|
| **Municípios processados** | 5.571 |
| **Total de UFs** | 27 |
| **Iterações PBKDF2** | 50.000 por município |
| **Formatos de saída** | 3 por UF (CSV, JSON, BIN) |
| **Tempo total** | ~1min 00s |
| **Ganho assíncrono** | ~42% vs versão síncrona |

### Como Executar

```bash
git checkout hands-on-06
cd AsyncLab
dotnet run
```

### Exemplo de Saída

```
=== ASYNCLAB - PROCESSAMENTO DE MUNICÍPIOS ===

[1] Arquivo local encontrado. Fazendo backup...
    Backup salvo em: backup/municipios_backup_20260514_143022.csv

[2] Aplicando modificações aleatórias no arquivo local...
    Modificações aplicadas com sucesso!

[3] Baixando arquivo atualizado da Receita Federal...
    Download concluído: municipios_receita.csv

[4] Comparando arquivo local com o da Receita...
    Diferenças encontradas: 1672
    Arquivo de diferenças salvo em: diferencas_municipios.csv

[5] Processando dados e gerando hashes...
    Registros lidos: 5571

[6] Salvando arquivos por UF em formato binário...
    UF AC: 22 municípios salvos (CSV, JSON e BIN)
    UF AL: 102 municípios salvos (CSV, JSON e BIN)
    ...

[7] Sistema de pesquisa de municípios
========================================

Opções de pesquisa:
  1 - Pesquisar por UF
  2 - Pesquisar por nome (parte do nome)
  3 - Pesquisar por código IBGE
  0 - Sair

Escolha uma opção: 1
Digite a UF (ex: SP, RJ, MG): SP

============================================================
📋 Municípios da UF SP
============================================================
Total encontrado: 645

  3500105 | SP | Adamantina
  3500204 | SP | Adolfo
  ...

===== RESUMO FINAL =====
UFs processadas: 27
Total de municípios: 5571
✅ Laboratório concluído com sucesso!
```

---

## 🗄️ PROJETO 7: ADOLAB (hands-on-08) - SEGUNDO SEMESTRE

### Sobre o Projeto
Laboratório de ADO.NET - Implementação de um CRUD completo com SQL Server.

### Funcionalidades

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

### Tecnologias Utilizadas
- ADO.NET
- SQL Server LocalDB
- Repository Pattern
- Microsoft.Data.SqlClient

### Estrutura do Projeto

```
ADOLab/
├── ADOLab.sln
├── ADOLab.Console/
│   ├── Program.cs
│   └── appsettings.json
└── ADOLab.Data/
    ├── Database/
    │   └── DatabaseInitializer.cs
    ├── Models/
    │   └── Aluno.cs
    └── Repositories/
        └── AlunoRepository.cs
```

### Como Executar

```bash
git checkout hands-on-08
cd ADOLab
dotnet restore
dotnet run --project ADOLab.Console\ADOLab.Console.csproj
```

### Exemplo de Saída

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
```

### Conceitos Aplicados no ADOLab
- **SqlConnection** - Gerenciamento de conexão com SQL Server
- **SqlCommand** - Execução de comandos SQL
- **SqlParameter** - Prevenção de SQL Injection
- **ExecuteNonQuery** - INSERT, UPDATE, DELETE
- **ExecuteScalar** - COUNT(*) e SCOPE_IDENTITY()
- **ExecuteReader** - SELECT com SqlDataReader
- **SqlDataReader** - Modo Conectado
- **SqlDataAdapter + DataTable** - Modo Desconectado
- **Repository Pattern** - Encapsulamento da lógica de acesso a dados
- **using** - Garantia de liberação de recursos

---

## 🗄️ PROJETO 8: DOMINOPONTADEQUINA (hands-on-09) - SEGUNDO SEMESTRE

### Sobre o Projeto
Sistema de gerenciamento do jogo de dominó **"Ponta de Quina"** utilizando **Entity Framework Core** como ORM.

### 🎯 Objetivo do Laboratório

Evoluir o modelo de dados do jogo de dominó utilizando EF Core, aplicando diferentes abordagens de configuração:

| Entidade | Configuração | Descrição |
|----------|--------------|-----------|
| **Usuario** | Fluent API | Configurado via `OnModelCreating()` no DbContext |
| **Jogador** | Data Annotations | Configurado com atributos nas propriedades |
| **Jogo** | Convenções | Apenas propriedades, sem anotações ou Fluent API |

### 🗄️ Estrutura do Banco de Dados

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

### ⚙️ Tecnologias Utilizadas

| Tecnologia | Versão | Descrição |
|------------|--------|-----------|
| **.NET** | 8.0 | Plataforma de desenvolvimento |
| **C#** | 12.0 | Linguagem de programação |
| **Entity Framework Core** | 8.0.15 | ORM para acesso a dados |
| **SQLite** | 8.0.15 | Banco de dados leve embarcado |
| **Microsoft.EntityFrameworkCore.Design** | 8.0.15 | Ferramentas de design para migrações |
| **Microsoft.EntityFrameworkCore.Tools** | 8.0.15 | Ferramentas CLI para migrações |

### 📁 Estrutura do Projeto

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

### 🔧 Comandos de Migração

```bash
# Instalar a ferramenta globalmente
dotnet tool install --global dotnet-ef

# Criar a migração inicial
cd DominoPontaDeQuina.Migrations
dotnet ef migrations add InitialCreate --context DominoDbContext --startup-project .

# Aplicar a migração ao banco
dotnet ef database update --context DominoDbContext --startup-project .

# Remover a última migração (não aplicada)
dotnet ef migrations remove --context DominoDbContext --startup-project .

# Gerar script SQL da migração
dotnet ef migrations script --context DominoDbContext --startup-project .
```

### 🚀 Como Executar

```bash
# 1. Clonar o repositório
git checkout hands-on-09

# 2. Restaurar pacotes
dotnet restore

# 3. Entrar na pasta de migrações
cd DominoPontaDeQuina.Migrations

# 4. Criar a migration
dotnet ef migrations add InitialCreate --context DominoDbContext --startup-project .

# 5. Aplicar a migration
dotnet ef database update --context DominoDbContext --startup-project .

# 6. Executar o programa
dotnet run
```

### 📊 Saída Esperada

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

## 🗄️ PROJETO 9: DOMINOPONTADEQUINA V2 (hands-on-10) - SEGUNDO SEMESTRE

### Sobre o Projeto
**Evolução do DominoPontaDeQuina** com implementação completa de **LINQ** nas consultas do repositório, **Unit of Work** e **Repository Pattern** aprimorados.

### 🆕 Novidades da Versão 2 (LINQ)

| # | Funcionalidade | Descrição |
|---|----------------|-----------|
| **1** | **Repository Pattern** | Implementação completa com LINQ |
| **2** | **Unit of Work** | Gerenciamento de transações e repositórios |
| **3** | **Consultas LINQ** | Filtros, includes, ordenações e agregações |
| **4** | **Fluent API** | Configuração completa de entidades |
| **5** | **78 Testes** | 100% de cobertura com xUnit |
| **6** | **Migrations** | Versionamento do banco de dados |

### 📁 Estrutura do Projeto V2

```
DominoPontaDeQuina-main/
│
├── DominoPontaDeQuina.Core/                # 🧠 Núcleo do Domínio
│   ├── Enums/
│   ├── Exceptions/
│   ├── Interfaces/
│   ├── Models/
│   ├── Services/
│   ├── Validators/
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
│   ├── domino.db
│   └── Migrations/
│       └── 20260825121106_InitialCreate.cs
│
└── DominoPontaDeQuina.Tests/               # 🧪 Testes Unitários (78 testes)
    ├── Models/
    ├── JogoTests.cs
    ├── MaoJogadorGapTests.cs
    ├── PartidaFluxoTests.cs
    ├── PartidaGapTests.cs
    ├── RodadaExcecaoTests.cs
    ├── RodadaFinalizacaoGapTests.cs
    ├── RodadaGapTests.cs
    └── TabuleiroGapTests.cs
```

### 🔍 Exemplos de Consultas LINQ no Repository V2

```csharp
// PartidaRepository.cs - Consultas com LINQ
public async Task<IEnumerable<Partida>> GetByJogadorAsync(Guid jogadorId)
{
    return await _dbSet
        .Where(p => p.Participacoes.Any(pp => pp.JogadorId == jogadorId))
        .Include(p => p.Participacoes)
            .ThenInclude(pp => pp.Jogador)
        .OrderByDescending(p => p.IniciadoEm)
        .ToListAsync();
}

// JogadorRepository.cs - Ranking com LINQ
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

### 🚀 Como Executar

```bash
# 1. Clonar o repositório
git checkout hands-on-10

# 2. Restaurar pacotes
dotnet restore

# 3. Entrar na pasta de migrações
cd DominoPontaDeQuina.Migrations

# 4. Aplicar as migrações
dotnet ef database update --context DominoDbContext

# 5. Voltar para a raiz e executar os testes
cd ..
dotnet test
```

### 📊 Resultado dos Testes

```
Test summary: total: 78, failed: 0, succeeded: 78, skipped: 0
✅ 100% dos testes passando!
```

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Jokempo V1 | Jokempo V2 | Blackjack | Agenda | GCLab | AsyncLab | ADOLab | Domino v1 | Domino v2 (LINQ) |
|----------|:----------:|:----------:|:---------:|:------:|:-----:|:--------:|:------:|:---------:|:----------------:|
| **Classes e Objetos** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Métodos** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **If/Else** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Switch/Case** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **While/For** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Listas/Tipos Genéricos** | ❌ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Enumerações** | ✅ | ✅ | ✅ | ❌ | ❌ | ❌ | ❌ | ✅ | ✅ |
| **Encapsulamento** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Tratamento de Exceções** | ❌ | ✅ | ❌ | ✅ | ✅ | ✅ | ❌ | ✅ | ✅ |
| **LINQ** | ❌ | ❌ | ❌ | ✅ | ❌ | ✅ | ❌ | ✅ | ✅ |
| **TimeZoneInfo** | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ | ❌ | ❌ |
| **Garbage Collection** | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ | ❌ |
| **WeakReference** | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ | ❌ |
| **IDisposable Pattern** | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ | ❌ |
| **async/await** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ |
| **Task.WhenAll** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ |
| **Paralelismo** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ |
| **Serialização Binária** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ |
| **Comparação de Arquivos** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ |
| **Backup e Versionamento** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ |
| **SqlConnection/SqlCommand** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ |
| **SqlParameter** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ |
| **Repository Pattern** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ✅ | ✅ |
| **Modo Conectado/Desconectado** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ |
| **Entity Framework Core** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ✅ |
| **Fluent API** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ✅ |
| **Data Annotations** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ✅ |
| **Migrations** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ | ✅ |
| **Unit of Work** | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ |

---

## 🚀 COMO CLONAR E ACESSAR CADA PROJETO

```bash
# Clonar o repositório
git clone https://github.com/isadorameneghetti/hands-on-c.git

# PRIMEIRO SEMESTRE
git checkout hands-on-01  # Jokempo v1
git checkout hands-on-02  # Jokempo v2
git checkout hands-on-03  # Blackjack
git checkout hands-on-05  # AgendaConsole
git checkout hands-on-05.2 # GCLab
git checkout hands-on-06  # AsyncLab

# SEGUNDO SEMESTRE
git checkout hands-on-08  # ADOLab - CRUD com ADO.NET
git checkout hands-on-09  # DominoPontaDeQuina - EF Core (v1)
git checkout hands-on-10  # DominoPontaDeQuina - EF Core + LINQ (v2)
```

---

## ▶️ REQUISITOS PARA EXECUTAR

- .NET SDK 8.0 ou superior
- Windows / Linux / macOS
- Git (para clonar o repositório)
- Conexão com internet (AsyncLab apenas)
- SQL Server LocalDB ou SQL Server Express (ADOLab apenas)

---

## 📈 APRENDIZADOS

### Primeiro Semestre
1. **Organização de código** - Divisão em métodos e classes
2. **Validações** - Tratamento de entradas do usuário
3. **POO** - Encapsulamento, construtores, propriedades
4. **Coleções** - Uso de List, Dictionary, Queue, Stack
5. **Fusos horários** - Conversão com TimeZoneInfo
6. **Gerenciamento de Memória** - Garbage Collection, WeakReference, IDisposable
7. **Programação Assíncrona** - async/await, Task.WhenAll, paralelismo
8. **Serialização** - Formatos CSV, JSON e Binário
9. **Versionamento** - Backup e comparação de versões de arquivos
10. **Sistemas de Busca** - Pesquisa com múltiplos critérios

### Segundo Semestre
11. **ADO.NET** - Biblioteca fundamental para acesso a dados em .NET
12. **SQL Injection** - Como prevenir com `SqlParameter`
13. **Modos de conexão** - Diferenças entre conectado e desconectado
14. **Repository Pattern** - Organização e manutenibilidade do código
15. **Boas práticas** - `using`, centralização de config, tratamento de null
16. **Execute vs Read** - Quando usar cada método do SqlCommand
17. **DataTable vs SqlDataReader** - Vantagens de cada abordagem
18. **Entity Framework Core** - ORM moderno para .NET
19. **Fluent API vs Data Annotations** - Diferentes abordagens de configuração
20. **Migrations** - Versionamento do esquema do banco de dados
21. **LINQ** - Consultas avançadas e expressões lambda
22. **Unit of Work** - Padrão para gerenciamento de transações

---

## 🔗 LINKS ÚTEIS

- [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [.NET Download](https://dotnet.microsoft.com/download)
- [Git Download](https://git-scm.com/downloads)
- [Garbage Collection no .NET](https://learn.microsoft.com/pt-br/dotnet/standard/garbage-collection/)
- [Programação Assíncrona](https://learn.microsoft.com/pt-br/dotnet/csharp/asynchronous-programming/)
- [ADO.NET Documentation](https://learn.microsoft.com/pt-br/dotnet/framework/data/adonet/)
- [Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/)
- [SQLite](https://www.sqlite.org/index.html)
- [LINQ Documentation](https://learn.microsoft.com/pt-br/dotnet/csharp/linq/)

---

<p align="center">
  <b>FIAP - Faculdade de Informática e Administração Paulista</b><br>
  Desenvolvido com ❤️ por <b>Isadora Meneghetti</b>, <b>Gustavo Ikeda</b>, <b>Henrique Azevedo</b>, <b>Renato Alvarenga</b> e <b>Victoria Moura</b><br>
  © 2026 - Todos os direitos reservados
</p>