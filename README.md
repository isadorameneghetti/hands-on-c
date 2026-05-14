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

O projeto processa dados de **municípios brasileiros** (CSV da Receita Federal) com os seguintes objetivos:

- Aplicar hash **PBKDF2** em cada registro
- Gerenciar versões de arquivos (backup, modificações, comparação)
- Salvar dados em **múltiplos formatos** (CSV, JSON e BINÁRIO)
- Implementar **sistema de pesquisa** interativo

---

## 🚀 FUNCIONALIDADES

| # | Funcionalidade | Descrição |
|---|----------------|-----------|
| **1** | **Verificação de arquivo** | Verifica se o CSV local existe antes de baixar |
| **2** | **Backup automático** | Cria backup do arquivo antes de modificações |
| **3** | **Modificações aleatórias** | Altera ~30% dos registros para simular dados corrompidos |
| **4** | **Download atualizado** | Baixa nova versão do CSV da Receita Federal |
| **5** | **Comparação de arquivos** | Compara versão local com oficial e gera relatório de diferenças |
| **6** | **Processamento PBKDF2** | Aplica 50.000 iterações de SHA-256 por município |
| **7** | **Exportação multi-formato** | Salva por UF em CSV, JSON e formato binário |
| **8** | **Pesquisa interativa** | Busca por UF, parte do nome ou código IBGE |

---

## 🔄 FLUXO DE EXECUÇÃO

```
┌─────────────────────────────────────────────────────────────┐
│                    ASYNCLAB - FLUXO COMPLETO                 │
└─────────────────────────────────────────────────────────────┘

1. Verificar existência do arquivo municipios.csv
   │
   ├── SIM → Fazer backup → Aplicar modificações aleatórias
   │
   └── NÃO → Seguir para download

2. Baixar nova versão (municipios_receita.csv)

3. Comparar arquivos
   │
   └── Salvar diferenças em diferencas_municipios.csv

4. Processar hashes PBKDF2 (50.000 iterações)

5. Salvar por UF em 3 formatos:
   │
   ├── CSV  (municipios_hash_UF.csv)
   ├── JSON (municipios_hash_UF.json)
   └── BIN  (municipios_UF.bin) + TXT para debug

6. Menu interativo de pesquisa:
   │
   ├── Pesquisar por UF
   ├── Pesquisar por nome (parcial)
   └── Pesquisar por código IBGE
```

---

## 📁 ESTRUTURA DO PROJETO

```
AsyncLab/
├── Program.cs              # Fluxo principal (todos os requisitos)
├── Municipio.cs            # Modelo de dados do município
├── Util.cs                 # Helpers (PBKDF2, salt, sanitização)
├── DataModifier.cs         # Modificações aleatórias no CSV
├── FileComparer.cs         # Comparação entre arquivos
├── BinaryStorage.cs        # Serialização binária por UF
├── SearchEngine.cs         # Sistema de pesquisa de municípios
├── AsyncLab.csproj         # .NET 8.0
│
├── backup/                 # Backups automáticos
│   └── municipios_backup_YYYYMMDD_HHmmss.csv
│
├── mun_hash_por_uf/        # CSV e JSON por UF
│   ├── municipios_hash_AC.csv
│   ├── municipios_hash_AC.json
│   └── ...
│
├── binario_por_uf/         # Formato binário por UF
│   ├── municipios_AC.bin
│   ├── municipios_AC.txt   # Debug
│   └── ...
│
└── diferencas_municipios.csv  # Relatório de diferenças
```

---

## 🔬 TECNOLOGIAS UTILIZADAS

| Tecnologia | Aplicação |
|------------|-----------|
| **async/await** | Operações I/O não-bloqueantes |
| **HttpClient** | Download assíncrono do CSV |
| **BinaryFormatter** | Serialização binária dos dados |
| **Rfc2898DeriveBytes** | PBKDF2 com SHA-256 |
| **FileStream async** | Leitura/escrita assíncrona |
| **LINQ** | Consultas e agrupamentos |
| **Random** | Modificações aleatórias |

---

## 💻 CÓDIGOS IMPLEMENTADOS

### DataModifier.cs - Modificações Aleatórias
```csharp
// Aplica modificações em ~30% dos registros
if (_random.NextDouble() < 0.3)
{
    parts[2] = parts[2] + " [MODIFICADO]";
    parts[3] = parts[3] + " [MODIFICADO]";
}
```

### FileComparer.cs - Comparação de Arquivos
```csharp
// Compara linha por linha e identifica diferenças
if (linhaLocal != linhaReceita)
{
    diferencas.Add($"Linha {i+1} | Local: {nomeLocal} | Receita: {nomeReceita}");
}
```

### BinaryStorage.cs - Armazenamento Binário
```csharp
// Serializa dados em formato binário
var formatter = new BinaryFormatter();
formatter.Serialize(fs, data);
```

### SearchEngine.cs - Sistema de Pesquisa
```csharp
// Pesquisa por UF, nome ou código IBGE
public static List<Municipio> SearchByUf(List<Municipio> municipios, string uf)
public static List<Municipio> SearchByName(List<Municipio> municipios, string termo)
public static Municipio? SearchByIbge(List<Municipio> municipios, string ibge)
```

---

## 📊 MÉTRICAS DE DESEMPENHO

### Processamento Realizado:
```
📊 5.571 municípios processados
🗺️ 27 UFs (exceto "EX")
🔐 50.000 iterações PBKDF2 por município
💾 3 formatos de saída por UF (CSV, JSON, BIN)
📁 ~20MB de dados gerados no total
```

### UFs mais processamento intensivo:

| UF | Municípios | Tempo estimado |
|----|------------|----------------|
| **MG** | 853 | ~9s |
| **SP** | 645 | ~7s |
| **RS** | 497 | ~5s |
| **BA** | 417 | ~5s |
| **PR** | 399 | ~4s |

---

## 🎮 COMO USAR

```bash
# Entre no diretório
cd AsyncLab

# Compile o projeto
dotnet build

# Execute o programa
dotnet run
```

### Saída esperada:

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

    Primeiras diferenças:
      Linha 15 | IBGE: 1200013 | Local: Rio Branco [MODIFICADO] | Receita: Rio Branco
      Linha 32 | IBGE: 1200104 | Local: Xapuri [MODIFICADO] | Receita: Xapuri
      ...

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

Escolha uma opção:
```

### Exemplo de Pesquisa:

```
Escolha uma opção: 1
Digite a UF (ex: SP, RJ, MG): SP

============================================================
📋 Municípios da UF SP
============================================================
Total encontrado: 645

  3500105 | SP | Adamantina
  3500204 | SP | Adolfo
  3500303 | SP | Aguaí
  ...

============================================================
===== RESUMO FINAL =====
UFs processadas: 27
Total de municípios: 5571
Pasta de saída (CSV/JSON): ./mun_hash_por_uf
Pasta de saída (Binário): ./binario_por_uf
Arquivo de diferenças: ./diferencas_municipios.csv

✅ Laboratório concluído com sucesso!
```

---

## ✅ VALIDAÇÃO DOS REQUISITOS

| # | Requisito | Status | Implementação |
|---|-----------|--------|----------------|
| 1 | Verificar existência do arquivo base | ✅ | `File.Exists()` |
| 2 | Backup antes de modificar | ✅ | `File.Copy()` com timestamp |
| 3 | Alterações aleatórias | ✅ | `DataModifier.cs` (30% dos registros) |
| 4 | Baixar nova versão da Receita | ✅ | `HttpClient.GetStringAsync()` |
| 5 | Comparar arquivos | ✅ | `FileComparer.cs` |
| 6 | Salvar diferenças | ✅ | `diferencas_municipios.csv` |
| 7 | Salvar por UF em formato binário | ✅ | `BinaryStorage.cs` |
| 8 | Pesquisa por UF | ✅ | `SearchEngine.SearchByUf()` |
| 9 | Pesquisa por parte do nome | ✅ | `SearchEngine.SearchByName()` |
| 10 | Pesquisa por código IBGE | ✅ | `SearchEngine.SearchByIbge()` |

---

## 📝 DIVISÃO DE TAREFAS

| Integrante | Tarefas |
|------------|---------|
| **Isadora Meneghetti** | - Análise dos requisitos<br>- Implementação do fluxo principal<br>- Sistema de pesquisa<br>- Documentação do README |
| **Henrique Azevedo** | - Implementação do `DataModifier`<br>- Implementação do `FileComparer`<br>- Testes de comparação de arquivos |
| **Gustavo Ikeda** | - Implementação do `BinaryStorage`<br>- Serialização binária<br>- Validação dos resultados |

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Aplicação no Projeto |
|----------|----------------------|
| **async/await** | Download, leitura e escrita de arquivos |
| **I/O não-bloqueante** | Durante todas operações de arquivo |
| **Serialização binária** | `BinaryFormatter` para salvar dados por UF |
| **Comparação de arquivos** | Detecção de mudanças linha a linha |
| **Backup e versão** | Timestamp nos arquivos de backup |
| **Modificação controlada** | `Random` para simular dados corrompidos |
| **LINQ** | Agrupamentos, ordenações e buscas |
| **PBKDF2** | Derivação de hash com 50k iterações |

---

## 📦 REQUISITOS

- .NET SDK 8.0 ou superior
- Conexão com internet (para download do CSV)
- Windows / Linux / macOS

---

## 🎯 RESULTADOS OBTIDOS

### Funcionalidades Implementadas:
- ✅ Backup automático antes de modificações
- ✅ Modificações aleatórias para simular corrupção
- ✅ Download da versão oficial
- ✅ Comparação detalhada entre versões
- ✅ Exportação em 3 formatos diferentes (CSV, JSON, BIN)
- ✅ Pesquisa interativa com 3 critérios diferentes

### Qualidade do Código:
- ✅ Código assíncrono em todas operações de I/O
- ✅ Separação de responsabilidades em classes específicas
- ✅ Tratamento de exceções implícito
- ✅ Logging informativo para o usuário

---

## 💡 APRENDIZADOS

1. **Gerenciamento de versões** - Backup e comparação são essenciais para integridade de dados
2. **Múltiplos formatos** - Cada formato tem sua utilidade (CSV para planilhas, JSON para APIs, BIN para performance)
3. **Serialização binária** - Mais rápida e compacta, mas menos interoperável
4. **Pesquisa eficiente** - LINQ proporciona consultas flexíveis e performáticas
5. **Async em todo I/O** - Melhora responsividade mesmo em operações locais

---

<p align="center">
  Desenvolvido com ❤️ por Isadora Meneghetti, Henrique Azevedo e Gustavo Ikeda - FIAP
</p>