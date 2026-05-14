# 🎮 PROJETOS C# - JOKEMPO & BLACKJACK & AGENDA & GCLAB & ASYNCLAB

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
- **Programação Assíncrona e Paralelismo**

---

## 📁 ESTRUTURA DO REPOSITÓRIO (BRANCHES)

```
main                    # Branch principal (documentação)
│
├── hands-on-01         # Jokempo v1 - Pedra, Papel e Tesoura
├── hands-on-02         # Jokempo v2 - Com estatísticas e histórico
├── hands-on-03         # Blackjack - Jogo de cartas 21
├── hands-on-05         # AgendaConsole - Com fusos horários
├── hands-on-05.2       # GCLab - Laboratório de Garbage Collection
└── hands-on-06         # AsyncLab - Laboratório de Programação Assíncrona
```

---

## 📊 STATUS DAS BRANCHES

| Branch | Projeto | Descrição | Status |
|--------|---------|-----------|--------|
| `main` | Documentação | README principal do repositório | ✅ Ativo |
| `hands-on-01` | Jokempo v1 | Pedra, Papel e Tesoura (básico) | ✅ Concluído |
| `hands-on-02` | Jokempo v2 | Com estatísticas e histórico de jogadores | ✅ Concluído |
| `hands-on-03` | Blackjack 21 | Jogo de cartas Blackjack | ✅ Concluído |
| `hands-on-05` | AgendaConsole | Sistema de agenda com fusos horários | ✅ Concluído |
| `hands-on-05.2` | **GCLab** | Laboratório de Garbage Collection | ✅ Concluído |
| `hands-on-06` | **AsyncLab** | Laboratório de Programação Assíncrona | ✅ Concluído |

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
Laboratório de Programação Assíncrona em C# - Comparação de performance entre código síncrono e assíncrono/paralelo.

### Funcionalidades
- ✅ Download do CSV de municípios (Receita Federal)
- ✅ Processamento PBKDF2 com 50.000 iterações por município
- ✅ Agrupamento por UF (27 estados)
- ✅ Geração de arquivos CSV e JSON por UF

### Transformações Assíncronas Aplicadas

| Operação Original (Síncrona) | Operação Assíncrona | Benefício |
|------------------------------|---------------------|------------|
| `WebClient.DownloadFile` | `HttpClient.GetStringAsync` | Libera thread durante download |
| `File.ReadAllLines` | `File.ReadAllLinesAsync` | I/O não-bloqueante |
| Processamento serial por UF | `Task.WhenAll` + paralelismo | Múltiplas UFs simultâneas |
| `File.WriteAllLines` | `File.WriteAllLinesAsync` | Escrita não-bloqueante |

### Resultados de Performance

| Métrica | Valor |
|---------|-------|
| **Municípios processados** | 5.571 |
| **Total de UFs** | 27 |
| **Iterações PBKDF2** | 50.000 por município |
| **Tempo total (assíncrono)** | **1min 00s (60.9s)** |
| **Ganho de performance** | **~42%** |

### Como Executar
```bash
git checkout hands-on-06
cd AsyncLab
dotnet run
```

### Saída esperada:
```
Baixando CSV de municípios (Receita Federal) - ASSÍNCRONO...
Registros lidos: 5571
Processando UF: AC (22 municípios) - INICIADO
Processando UF: AL (102 municípios) - INICIADO
...
===== RESUMO =====
UFs geradas: 27
Tempo total: 1m 0s 922ms
```

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Jokempo V1 | Jokempo V2 | Blackjack | Agenda | GCLab | AsyncLab |
|----------|:----------:|:----------:|:---------:|:------:|:-----:|:--------:|
| **Classes e Objetos** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Métodos** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **If/Else** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Switch/Case** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **While/For** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Listas/Tipos Genéricos** | ❌ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Enumerações** | ✅ | ✅ | ✅ | ❌ | ❌ | ❌ |
| **Encapsulamento** | ✅ | ✅ | ✅ | ✅ | ✅ | ✅ |
| **Tratamento de Exceções** | ❌ | ✅ | ❌ | ✅ | ✅ | ✅ |
| **LINQ** | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ |
| **TimeZoneInfo** | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ |
| **Garbage Collection** | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ |
| **WeakReference** | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ |
| **IDisposable Pattern** | ❌ | ❌ | ❌ | ❌ | ✅ | ❌ |
| **async/await** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ |
| **Task.WhenAll** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ |
| **Paralelismo** | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ |

---

## 🚀 COMO CLONAR E ACESSAR CADA PROJETO

```bash
# Clonar o repositório
git clone https://github.com/isadorameneghetti/hands-on-c/

# Acessar cada branch
git checkout hands-on-01  # Jokempo v1
git checkout hands-on-02  # Jokempo v2
git checkout hands-on-03  # Blackjack
git checkout hands-on-05  # AgendaConsole
git checkout hands-on-05.2 # GCLab
git checkout hands-on-06  # AsyncLab
```

---

## ▶️ REQUISITOS PARA EXECUTAR

- .NET SDK 6.0 ou superior
- Windows / Linux / macOS
- Git (para clonar o repositório)
- Conexão com internet (AsyncLab apenas)

---

## 📈 APRENDIZADOS

Durante o desenvolvimento dos projetos, foram trabalhados:

1. **Organização de código** - Divisão em métodos e classes
2. **Validações** - Tratamento de entradas do usuário
3. **POO** - Encapsulamento, construtores, propriedades
4. **Coleções** - Uso de List, Dictionary, Queue, Stack
5. **Fusos horários** - Conversão com TimeZoneInfo
6. **Gerenciamento de Memória** - Garbage Collection, WeakReference, IDisposable
7. **Programação Assíncrona** - async/await, Task.WhenAll, paralelismo

---

## 🔗 LINKS ÚTEIS

- [Documentação C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [.NET Download](https://dotnet.microsoft.com/download)
- [Git Download](https://git-scm.com/downloads)
- [Garbage Collection no .NET](https://learn.microsoft.com/pt-br/dotnet/standard/garbage-collection/)
- [Programação Assíncrona](https://learn.microsoft.com/pt-br/dotnet/csharp/asynchronous-programming/)

---

<p align="center">
  <b>FIAP - Faculdade de Informática e Administração Paulista</b><br>
  Desenvolvido com ❤️ por Isadora Meneghetti, Gustavo Ikeda, Henrique Azevedo, Renato Alvarenga e Victoria Moura<br>
  © 2026 - Todos os direitos reservados
</p>
