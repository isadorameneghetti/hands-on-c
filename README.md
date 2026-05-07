# 🎮 PROJETOS C# - JOKEMPO & BLACKJACK & AGENDA & GCLAB

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Console](https://img.shields.io/badge/Console-4EAA25?style=for-the-badge&logo=windows-terminal&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)

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

**Estruturas de Controle de Fluxo e Métodos em C#**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O REPOSITÓRIO

Este repositório contém os projetos desenvolvidos durante a disciplina, abordando conceitos fundamentais de programação em C#:

- Estruturas de controle de fluxo (`if/else`, `switch`, `while`, `for`, `foreach`)
- Métodos e funções
- Programação Orientada a Objetos
- Coleções e Listas
- Tratamento de exceções
- Trabalho com datas e fusos horários
- **Garbage Collection e gerenciamento de memória**

---

## 📁 ESTRUTURA DO REPOSITÓRIO

```
├── main/                          # Branch principal (documentação)
│
├── hands-on-01/                   # Primeira versão do Jokempo
│   └── Jokempo/                   # Pedra, Papel e Tesoura (básico)
│
├── hands-on-02/                   # Segunda versão do Jokempo
│   └── Jokempo/                   # Com estatísticas e histórico
│
├── hands-on-03/                   # Projeto Blackjack
│   └── Blackjack/                 # Jogo de cartas 21
│
├── hands-on-05/                   # Projeto Agenda
│   └── AgendaConsole/             # Agenda com fusos horários
│
└── hands-on-06/                   # Projeto GCLab
    └── GCLab/                     # Laboratório de Garbage Collection
```

| Branch | Projeto | Descrição | Status |
|--------|---------|-----------|--------|
| `hands-on-01` | Jokempo | Versão inicial do Pedra, Papel e Tesoura | ✅ Concluído |
| `hands-on-02` | Jokempo | Versão aprimorada com estatísticas e histórico | ✅ Concluído |
| `hands-on-03` | Blackjack 21 | Jogo de cartas Blackjack | ✅ Concluído |
| `hands-on-05` | AgendaConsole | Sistema de agenda com fusos horários | ✅ Concluído |
| `hands-on-06` | GCLab | Laboratório de Garbage Collection | ✅ Concluído |

---

## 🎮 PROJETO 1: JOKEMPO (hands-on-01)

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
cd hands-on-01/Jokempo
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
cd hands-on-03/Blackjack
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
cd hands-on-05/AgendaConsole
dotnet run
```

---

## 🗑️ PROJETO 5: GCLAB (hands-on-06)

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
cd hands-on-06/GCLab
dotnet run
```

### Exemplo de saída esperada (antes da correção):
```
--- Verificação de sobreviventes (WeakReference) ---
subscriber: vivo
lohBuffer: vivo
pinnedBuffer: vivo
logger: vivo
-----------------------------------------------
❌ Existem sobreviventes indesejados.
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

## 🧠 CONCEITOS APLICADOS

| Conceito | Jokempo V1 | Jokempo V2 | Blackjack | Agenda | GCLab |
|----------|:----------:|:----------:|:---------:|:------:|:-----:|
| **Classes e Objetos** | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Métodos** | ✅ | ✅ | ✅ | ✅ | ✅ |
| **If/Else** | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Switch/Case** | ✅ | ✅ | ✅ | ✅ | ✅ |
| **While/For** | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Listas/Tipos Genéricos** | ❌ | ✅ | ✅ | ✅ | ✅ |
| **Enumerações** | ✅ | ✅ | ✅ | ❌ | ❌ |
| **Encapsulamento** | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Tratamento de Exceções** | ❌ | ✅ | ❌ | ✅ | ✅ |
| **LINQ** | ❌ | ❌ | ❌ | ✅ | ❌ |
| **TimeZoneInfo** | ❌ | ❌ | ❌ | ✅ | ❌ |
| **Garbage Collection** | ❌ | ❌ | ❌ | ❌ | ✅ |
| **WeakReference** | ❌ | ❌ | ❌ | ❌ | ✅ |
| **IDisposable Pattern** | ❌ | ❌ | ❌ | ❌ | ✅ |

---

## 🚀 COMO CLONAR O REPOSITÓRIO

```bash
# Clonar todas as branches
git clone https://github.com/seu-usuario/projetos-csharp.git

# Acessar uma branch específica
git checkout hands-on-01  # Jokempo versão 1
git checkout hands-on-02  # Jokempo versão 2
git checkout hands-on-03  # Blackjack
git checkout hands-on-05  # AgendaConsole
git checkout hands-on-06  # GCLab
```

---

## 📊 STATUS DAS ENTREGAS

| Projeto | Branch | Data de Entrega | Status |
|---------|--------|-----------------|--------|
| Jokempo (Básico) | `hands-on-01` | 15/10/2026 | ✅ Concluído |
| Jokempo (Avançado) | `hands-on-02` | 29/10/2026 | ✅ Concluído |
| Blackjack | `hands-on-03` | 12/11/2026 | ✅ Concluído |
| AgendaConsole | `hands-on-05` | 26/11/2026 | ✅ Concluído |
| GCLab | `hands-on-06` | 10/12/2026 | ✅ Concluído |

---

## 🛠️ TECNOLOGIAS UTILIZADAS

- **C#** - Linguagem de programação
- **.NET 6/8** - Framework
- **Git** - Controle de versão
- **GitHub** - Repositório remoto

---

## ▶️ REQUISITOS PARA EXECUTAR

- .NET SDK 6.0 ou superior
- Windows / Linux / macOS
- Git (para clonar o repositório)

---

## 📈 APRENDIZADOS

Durante o desenvolvimento dos projetos, foram trabalhados:

1. **Organização de código** - Divisão em métodos e classes
2. **Validações** - Tratamento de entradas do usuário
3. **POO** - Encapsulamento, construtores, propriedades
4. **Coleções** - Uso de List, Dictionary, Queue, Stack
5. **Fusos horários** - Conversão com TimeZoneInfo
6. **Gerenciamento de Memória** - Garbage Collection, WeakReference, IDisposable

---

## 🔗 LINKS ÚTEIS

- [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [.NET Download](https://dotnet.microsoft.com/download)
- [Git Download](https://git-scm.com/downloads)
- [Garbage Collection no .NET](https://learn.microsoft.com/pt-br/dotnet/standard/garbage-collection/)

---

<p align="center">
  <b>FIAP - Faculdade de Informática e Administração Paulista</b><br>
  Desenvolvido com ❤️ pelos alunos da turma 3ESA<br>
  © 2026 - Todos os direitos reservados
</p>
