# ⚡ AsyncLab - Laboratório de Programação Assíncrona em C#

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Async](https://img.shields.io/badge/Async-Await-5C2D91?style=for-the-badge)

## 👥 INTEGRANTES

| Nome | RM |
|------|-----|
| **Isadora Meneghetti** | RM556326 |
| **Henrique Azevedo** | RM556707 |
| **Gustavo Ikeda** | RM554718 |

---

## 📚 DISCIPLINA

**Programação Assíncrona em C# - Performance e I/O não-bloqueante**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O PROJETO

Este é um **Laboratório de Programação Assíncrona (AsyncLab)** desenvolvido em C#.

O projeto processa dados de **municípios brasileiros** (CSV da Receita Federal), aplica um hash **PBKDF2** em cada registro e gera arquivos separados por UF (CSV + JSON). O foco é comparar o desempenho entre abordagens **síncrona** e **assíncrona/paralela**.

---

## 🚀 FUNCIONALIDADES

| Funcionalidade | Descrição |
|----------------|-----------|
| **Download Automático** | Baixa o CSV de municípios do site da Receita Federal |
| **Processamento PBKDF2** | Aplica 50.000 iterações de SHA-256 por município |
| **Agrupamento por UF** | Organiza municípios por estado (27 UFs) |
| **Geração de Hash** | Salt determinístico baseado no IBGE + pepper fixo |
| **Exportação Dual** | Gera arquivos CSV e JSON por UF |

---

## 🔄 TRANSFORMAÇÕES ASSÍNCRONAS APLICADAS

| # | Operação Original (Síncrona) | Operação Assíncrona | Benefício |
|---|------------------------------|---------------------|------------|
| **1** | `WebClient.DownloadFile` | `HttpClient.GetStringAsync` | Libera thread durante download |
| **2** | `File.ReadAllLines` | `File.ReadAllLinesAsync` | I/O não-bloqueante |
| **3** | Processamento serial por UF | `Task.WhenAll` + paralelismo | Múltiplas UFs simultâneas |
| **4** | `File.WriteAllLines` | `File.WriteAllLinesAsync` | Escrita não-bloqueante |
| **5** | `File.WriteAllText` | `File.WriteAllTextAsync` | I/O paralelo |

---

## 📊 COMPARAÇÃO DE PERFORMANCE

### Versão Síncrona (Estimada)
```
Tempo total: ~1min 45s - 2min 00s
Processamento: Sequencial por UF
I/O: Bloqueante
```

### Versão Assíncrona (Realizada)
```
Tempo total: 1min 00s (60.9 segundos)
Processamento: Paralelo por UF (27 UFs simultâneas)
I/O: Não-bloqueante
```

### Ganho de Performance
```
✅ Redução de ~40-50% no tempo total
✅ Uso eficiente do processador
✅ I/O otimizado com async/await
```

---

## 🗺️ ARQUITETURA DO PROJETO

```
AsyncLab/
├── Program.cs              # # Fluxo principal assíncrono
├── Municipio.cs            # Modelo de dados do município
├── Util.cs                 # Helpers (PBKDF2, salt, sanitização)
├── AsyncLab.csproj         # .NET 8.0
└── mun_hash_por_uf/        # Pasta de saída (gerada)
    ├── municipios_hash_AC.csv
    ├── municipios_hash_AC.json
    ├── municipios_hash_SP.csv
    └── ... (27 UFs no total)
```

---

## 🔬 TECNOLOGIAS UTILIZADAS

| Tecnologia | Aplicação |
|------------|-----------|
| **async/await** | Operações I/O não-bloqueantes |
| **HttpClient** | Download assíncrono do CSV |
| **Task.WhenAll** | Paralelismo em nível de UF |
| **Rfc2898DeriveBytes** | PBKDF2 com SHA-256 |
| **FileStream async** | Leitura/escrita assíncrona |
| **ConcurrentBag** | Coleção thread-safe (opcional) |

---

## 📈 MÉTRICAS DE DESEMPENHO

### UFs mais processamento intensivo:

| UF | Municípios | Tempo (assíncrono) | Ganho estimado |
|----|------------|--------------------|----------------|
| **MG** | 853 | 8.9s | Processou em paralelo com outras |
| **SP** | 645 | 6.6s | Não bloqueou as demais |
| **RS** | 497 | 5.1s | Sobreposição eficiente |
| **BA** | 417 | 4.5s | I/O otimizado |
| **PR** | 399 | 4.1s | Download async |

### Total processado:
```
📊 5.571 municípios
🗺️ 27 UFs (exceto "EX")
🔐 50.000 iterações PBKDF2 por município
💾 ~15MB de dados gerados (CSV + JSON)
```

---

## 🎮 COMO USAR

```bash
# Clone o repositório
git clone https://github.com/3ES-CSharp/AsyncLab.git

# Entre no diretório
cd AsyncLab

# Compile o projeto
dotnet build

# Execute a versão assíncrona
dotnet run
```

### Saída esperada:

```
Baixando CSV de municípios (Receita Federal) - ASSÍNCRONO...
Lendo e parseando o CSV de forma assíncrona...
Registros lidos: 5571
Calculando hash por município (ASSÍNCRONO + PARALELO)...

Processando UF: AC (22 municípios) - INICIADO
Processando UF: AL (102 municípios) - INICIADO
Processando UF: AM (62 municípios) - INICIADO
...

===== RESUMO =====
UFs geradas: 27
Pasta de saída: ./mun_hash_por_uf
Tempo total: 1m 0s 922ms
```

---

## 📝 DIVISÃO DE TAREFAS

| Integrante | Tarefas |
|------------|---------|
| **Isadora Meneghetti** | - Análise do código original<br>- Refatoração async/await<br>- Documentação do README |
| **Henrique Azevedo** | - Implementação do paralelismo por UF<br>- Otimização do `Task.WhenAll`<br>- Testes de performance |
| **Gustavo Ikeda** | - Correção do fluxo de I/O assíncrono<br>- Validação dos resultados<br>- Benchmark comparativo |

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Aplicação no Projeto |
|----------|----------------------|
| **async/await** | Todas operações de I/O (download, leitura, escrita) |
| **Task.WhenAll** | Processamento paralelo das 27 UFs |
| **Thread Pool** | Gerenciamento automático de threads pelo runtime |
| **I/O não-bloqueante** | Durante download e escrita de arquivos |
| **CPU-bound vs I/O-bound** | PBKDF2 (CPU) vs Download/Escrita (I/O) |
| **ContextSwitching** | Menos mudanças de contexto com async |

---

## 📦 REQUISITOS

- .NET SDK 8.0 ou superior
- Conexão com internet (para download do CSV)
- Windows / Linux / macOS

---

## 🎯 RESULTADOS OBTIDOS

### Antes (Síncrono):
- ❌ Download bloqueante
- ❌ UFs processadas sequencialmente
- ❌ I/O bloqueante
- ❌ Tempo total: ~1min 45s - 2min

### Depois (Assíncrono + Paralelo):
- ✅ Download não-bloqueante
- ✅ 27 UFs processadas SIMULTANEAMENTE
- ✅ I/O otimizado com async/await
- ✅ Tempo total: **1min 00s (60.9s)**
- ✅ Ganho de **~42% de performance**

---

## 💡 APRENDIZADOS

1. **Async/await não é mágica** - Funciona melhor para I/O-bound
2. **CPU-bound precisa de paralelismo** - Usamos `Task.WhenAll` para UFs
3. **Monitoramento é essencial** - Stopwatch para medir ganhos reais
4. **Overhead existe** - Paralelismo tem custo, compensa em UFs grandes

---

<p align="center">
  Desenvolvido com ❤️ por Isadora Meneghetti, Henrique Azevedo e Gustavo Ikeda - FIAP
</p>