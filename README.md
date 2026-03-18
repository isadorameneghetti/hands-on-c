# 🎮 JOKEMPO - Pedra, Papel e Tesoura

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Console Application](https://img.shields.io/badge/Console_Application-FF8800?style=for-the-badge&logo=windows-terminal&logoColor=white)
![Multi-framework](https://img.shields.io/badge/.NET-8.0%20|%209.0%20|%2010.0-blue)

## 👥 INTEGRANTES DO GRUPO

| Nome | RM |
|------|-----|
| **Isadora Meneghetti** | RM556326 |
| **Gustavo Ikeda** | RM554718 |
| **Henrique Azevedo** | RM556707 |
| **Renato Alvarenga** | RM556403 |
| **Victoria Moura** | RM555474 |

---

## 📋 SOBRE O PROJETO

Este é um jogo de **Jokempo (Pedra, Papel e Tesoura)** desenvolvido em C# como parte das atividades da disciplina de **Estruturas de Controle de Fluxo e Métodos**. O jogo permite que o usuário jogue contra o computador, com funcionalidades completas de menu, estatísticas e gerenciamento de jogadores.

### ✨ Funcionalidades

- Jogar contra o computador (modo aleatório)
- Gravar nome do jogador
- Sistema de pontuação (vitórias, derrotas e empates)
- Estatísticas completas por jogador
- Trocar de jogador a qualquer momento
- Validação de entrada de dados
- Menu interativo com opções
- Emojis para melhor experiência visual
- Suporte a múltiplas versões do .NET (8.0, 9.0 e 10.0)

---

## 🎯 CONCEITOS DE C# UTILIZADOS

| Conceito | Onde foi aplicado |
|----------|-------------------|
| **Métodos** | Divisão do código em blocos reutilizáveis (Jogar, ExibirMenu, etc.) |
| **Estruturas Condicionais (if/else)** | Verificação de jogadas e resultados |
| **Estruturas Condicionais (switch)** | Menu principal e processamento de jogadas |
| **Laços de Repetição (while)** | Loop principal do jogo |
| **Laços de Repetição (do-while)** | Validação de entrada do usuário |
| **Laços de Repetição (foreach)** | Exibição das estatísticas |
| **Instruções de Controle (break)** | Interromper cases do switch |
| **Instruções de Controle (return)** | Retornar valores dos métodos |
| **Parâmetros** | Passagem de dados entre métodos |
| **Coleções (Dictionary)** | Armazenamento de estatísticas por jogador |
| **Tuplas** | Agrupamento de vitórias, derrotas e empates |
| **Validação de dados** | Prevenção contra entradas inválidas |

---

## 🚀 COMO EXECUTAR

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (8.0, 9.0 ou 10.0)
- Visual Studio Code / Visual Studio 2022
- Terminal ou Prompt de Comando

### Passos para execução

1. **Clone o repositório**
```bash
git clone https://github.com/isadorameneghetti/jokempo.git
```

2. **Acesse a pasta do projeto**
```bash
cd jokempo
```

3. **Execute o programa**
```bash
dotnet run
```

Ou abra o arquivo `.csproj` no Visual Studio e pressione `F5`.

---

## 🎮 COMO JOGAR

### Fluxo do jogo:

1. **Ao iniciar**, digite seu nome
2. **No menu principal**, escolha uma opção:
   - **1 - Jogar**: Inicia uma partida
   - **2 - Trocar Jogador**: Troca de usuário
   - **3 - Estatísticas**: Visualiza seu desempenho
   - **0 - Sair**: Encerra o programa

3. **Durante o jogo**, escolha:
   - **0 - Pedra ✊**
   - **1 - Papel ✋**
   - **2 - Tesoura ✌**

4. O computador fará uma jogada aleatória
5. O resultado é exibido e as estatísticas são atualizadas

### 📊 Regras do Jogo

| Jogada | Ganha de | Perde para |
|--------|----------|------------|
| ✊ Pedra | ✌ Tesoura | ✋ Papel |
| ✋ Papel | ✊ Pedra | ✌ Tesoura |
| ✌ Tesoura | ✋ Papel | ✊ Pedra |

**Jogadas iguais resultam em empate**

---

## 📱 EXEMPLO DE EXECUÇÃO

```text
😀 Olá! Vamos jogar Jokempo?

Digite o nome do jogador: João
Bem-vindo(a), João!

--- Menu (João) ---
1 - Jogar
2 - Trocar Jogador
3 - Estatísticas
0 - Sair
Escolha uma opção: 1

Escolha: 0 - Pedra ✊, 1 - Papel ✋ ou 2 - Tesoura ✌
João, sua jogada: 0
João escolheu Pedra ✊!
Eu escolhi Tesoura ✌!

😀 Parabéns, João! Você venceu!
```

### 📈 Estatísticas

```text
--- Estatísticas ---
Jogador: João
  Vitórias: 5
  Derrotas: 3
  Empates:  2
  Total:    10

Jogador: Maria
  Vitórias: 3
  Derrotas: 4
  Empates:  1
  Total:    8
```

---

## 📁 ESTRUTURA DO PROJETO

```
Jokempo/
├── Program.cs              # Código fonte principal
├── Jokempo.csproj          # Configuração do projeto
├── README.md               # Documentação
└── .gitignore              # Arquivos ignorados pelo Git
```

### ⚙️ Configuração do Projeto

O projeto está configurado para suportar múltiplas versões do .NET:

```xml
<TargetFrameworks>net8.0;net9.0;net10.0</TargetFrameworks>
```

Isso garante compatibilidade com diferentes ambientes de execução.

---

## 🧪 TESTANDO O PROJETO

### Cenários de teste sugeridos:

1. **Jogador novo** - Verificar se as estatísticas começam em zero
2. **Trocar jogador** - Confirmar que as estatísticas são mantidas por jogador
3. **Entradas inválidas** - Testar letras, números fora do intervalo e vazio
4. **Múltiplas partidas** - Verificar se os contadores atualizam corretamente
5. **Sair do jogo** - Confirmar se a mensagem de despedida aparece

---

## 📚 DISCIPLINA

**Estruturas de Controle de Fluxo e Métodos em C#**

**Professor:** Vinícius Costa Santos

**Instituição:** FACULDADE FIAP

**Ano:** 2026

---

## 📄 LICENÇA

Este projeto foi desenvolvido para fins educacionais. Todos os direitos reservados aos autores.

---

## ✨ AGRADECIMENTOS

Agradecimentos especiais ao professor **Vinícius Costa Santos** pelos ensinamentos e à equipe pelo empenho no desenvolvimento deste projeto.

---

<p align="center">
  Desenvolvido com ❤️ pelos alunos da FIAP
</p>

<p align="center">
  <img src="https://media.giphy.com/media/3o7abB06u9bNzA8LC8/giphy.gif" width="200">
</p>