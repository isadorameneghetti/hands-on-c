# 📅 AgendaConsole - Sistema de Agendamento com Fusos Horários

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Console](https://img.shields.io/badge/Console-4EAA25?style=for-the-badge&logo=windows-terminal&logoColor=white)

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

**Data e Tempo em C# - Conversão de Fusos Horários**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📋 SOBRE O PROJETO

Este é um sistema de **Agenda com Conversor de Fusos Horários** desenvolvido em C#.

O sistema permite gerenciar compromissos com data/hora em diferentes fusos horários, convertendo automaticamente os horários para o fuso desejado.

---

## ⏰ FUNCIONALIDADES

- **Adicionar compromisso** com descrição, data, hora e fuso horário
- **Exibir compromissos do dia atual** baseado no fuso informado
- **Exibir compromissos de uma data específica** baseado no fuso informado
- Suporte a múltiplos fusos horários (UTC-3, UTC-4, UTC+5, etc.)
- Conversão automática entre fusos

---

## 🗺️ FUSOS HORÁRIOS SUPORTADOS

| Fuso | Horário | TimeZone ID (Windows) |
|------|---------|----------------------|
| **UTC-5** | Lima, Bogotá | `SA Pacific Standard Time` |
| **UTC-4** | Manaus, Caracas | `SA Western Standard Time` |
| **UTC-3** | São Paulo, Brasília | `E. South America Standard Time` |
| **UTC-5** | Nova York | `Eastern Standard Time` |
| **UTC-8** | Los Angeles | `Pacific Standard Time` |
| **UTC+0** | Londres | `GMT Standard Time` |
| **UTC+5** | Karachi | `Pakistan Standard Time` |
| **UTC+9** | Tóquio | `Tokyo Standard Time` |

---

## 🎮 COMO USAR

1. Execute o programa
2. Escolha uma opção no menu:
   - **[1] Adicionar compromisso** - Cadastre um novo compromisso
   - **[2] Exibir compromissos do dia atual** - Veja os compromissos de hoje
   - **[3] Exibir compromissos de uma data específica** - Consulte por data
   - **[4] Sair**

### Exemplo de cadastro:

```
Descrição: Reunião com cliente
Data (dd/MM/yyyy): 25/12/2026
Hora (HH:mm): 14:30
TimeZone: E. South America Standard Time
```

### TimeZone padrão:

Se pressionar **Enter**, o sistema usa o fuso horário do seu computador.

---

## 🧠 CONCEITOS APLICADOS

| Conceito | Aplicação no Projeto |
|----------|----------------------|
| **Classes e Objetos** | `Compromisso`, `Program` |
| **Métodos** | `AdicionarCompromisso()`, `ExibirCompromissosDoDiaAtual()`, `ExibirCompromissosPorData()` |
| **Estruturas de decisão** | `if/else`, `switch/case` para navegação do menu |
| **Estruturas de repetição** | `while` para manter o programa em execução |
| **Listas** | `List<Compromisso>` para armazenar os agendamentos |
| **LINQ** | `Where()` para filtrar compromissos por data |
| **TimeZoneInfo** | Conversão entre fusos horários com `ConvertTimeFromUtc()` |
| **Tratamento de exceções** | `try/catch` para validação de entradas |

---

## 📊 ESTRUTURA DO CÓDIGO

```
AgendaConsole/
├── Program.cs           # Código principal da aplicação
└── AgendaConsole.csproj # Configurações do projeto
```

### Classe Compromisso:
- `Descricao` - Texto do compromisso
- `DataHoraUtc` - Data/hora armazenada em UTC
- `TimeZoneId` - Fuso original do agendamento

---

## 📦 REQUISITOS

- .NET SDK 6.0 ou superior
- Windows / Linux / macOS

---

<p align="center">
  Desenvolvido com ❤️ pelos alunos da FIAP
</p>
```