# 📅 GCLab - Laboratório de Garbage Collection em C#

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![GC](https://img.shields.io/badge/GC-Laboratório-4EAA25?style=for-the-badge)

## 👤 INTEGRANTE

| Nome | RM |
|------|-----|
| **Isadora Meneghetti** | RM556326 |

---

## 📚 DISCIPLINA

**Garbage Collection em C# - Identificação e Correção de Memory Leaks**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O PROJETO

Este é um **Laboratório de Garbage Collection (GCLab)** desenvolvido em C#.

O projeto contém **problemas propositais de gerenciamento de memória**, onde os alunos devem identificar más práticas, analisar o comportamento do GC e aplicar correções para que o programa finalize com o "GC limpo" (nenhuma referência indesejada permanecendo viva).

---

## 🐛 PROBLEMAS PROPOSITAIS

| # | Problema | Descrição |
|---|----------|-----------|
| **1** | **Event Leak** | Subscriber inscrito em evento sem nunca desinscrever |
| **2** | **LOH + Cache Estático** | Buffer grande (200KB) no LOH armazenado em cache estático sem expiração |
| **3** | **Pinned Buffer** | Buffer fixado (pinned) por longo período, impedindo movimentação do GC |
| **4** | **String Concatenação** | 50.000 concatenações gerando resíduo no Gen0/Gen1 |
| **5** | **Recurso externo sem Dispose** | StreamWriter sem liberação adequada, dependendo apenas do finalizador |

---

## ✅ CORREÇÕES APLICADAS

| Problema | Solução |
|----------|---------|
| **Event Leak** | Implementar `IDisposable` e remover evento no `Dispose()` |
| **LOH + Cache** | Usar `WeakReference` + política FIFO de remoção |
| **Pinned Buffer** | Implementar `IDisposable` para desfixar via `GCHandle.Free()` |
| **String Concat** | Substituir por `StringBuilder` |
| **Recurso externo** | Implementar `IDisposable` padrão com `Dispose()` do StreamWriter |

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Aplicação no Projeto |
|----------|----------------------|
| **Garbage Collection** | Coleta forçada com `GC.Collect()` e `GC.WaitForPendingFinalizers()` |
| **Gerações (Gen0/Gen1/Gen2)** | Monitoramento via `GC.CollectionCount()` |
| **LOH (Large Object Heap)** | Objetos ≥85KB alocados no LOH |
| **Pinning** | `GCHandle.Alloc()` com `GCHandleType.Pinned` |
| **WeakReference** | Referência fraca que não impede coleta |
| **Event Leak** | Assinatura de eventos sem remoção |
| **IDisposable Pattern** | Liberação determinística de recursos |
| **Finalizadores** | Rede de segurança (~destrutor) |
| **StringBuilder** | Evitar concatenações repetitivas |

---

## 🎮 COMO USAR

1. Executar o programa com problemas
2. Observar o relatório de sobreviventes
3. Aplicar correções propostas
4. Reexecutar e verificar a mensagem **"✅ GC limpo"**

### Exemplo de saída esperada (antes da correção):

```
--- Verificação de sobreviventes (WeakReference) ---
subscriber: vivo
lohBuffer: vivo
pinnedBuffer: vivo
logger: vivo
-----------------------------------------------
Gen0: 0 | Gen1: 0 | Gen2: 1

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

## 📊 ESTRUTURA DO CÓDIGO

```
GCLab/
├── Program.cs              # Fluxo principal
├── IssueTracker.cs         # Monitoramento via WeakReference
├── GCHelpers.cs            # Helpers de coleta forçada
├── LeakySubscriber.cs      # ❌ Event Leak → ✅ IDisposable
├── Publisher.cs            # Publicador do evento
├── GlobalCache.cs          # ❌ Cache estático → ✅ WeakReference + FIFO
├── BigBufferHolder.cs      # Buffer LOH
├── Pinner.cs               # ❌ Pinned leak → ✅ IDisposable
├── ConcatWork.cs           # ❌ String concat → ✅ StringBuilder
├── Logger.cs               # ❌ Sem Dispose → ✅ IDisposable
└── GCLab.csproj            # .NET 8.0
```

---

## 🔬 MÉTRICAS DE ANÁLISE

```csharp
// Coletas por geração
GC.CollectionCount(0)  // Gen0 - objetos de curta vida
GC.CollectionCount(1)  // Gen1 - objetos promovidos
GC.CollectionCount(2)  // Gen2 + LOH - objetos de longa vida

// Forçar coleta completa (apenas para diagnóstico)
GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();
```

---

## 📦 REQUISITOS

- .NET SDK 8.0 ou superior
- Windows / Linux / macOS

---

<p align="center">
  Desenvolvido com ❤️ por Isadora Meneghetti - FIAP
</p>
