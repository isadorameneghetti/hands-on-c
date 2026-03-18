# 🎮 JOKEMPO - Pedra, Papel e Tesoura

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0088CC?style=for-the-badge&logo=microsoft&logoColor=white)
![Multi-framework](https://img.shields.io/badge/.NET-8.0%20|%209.0-blue)

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

Este é um jogo de **Jokempo (Pedra, Papel e Tesoura)** desenvolvido em C# como parte das atividades da disciplina de **Estruturas de Controle de Fluxo e Métodos**. O projeto foi estruturado em **duas camadas**:

- 📚 **Jokempo.Lib**: Biblioteca de classes com a lógica do jogo
- 🎨 **Jokempo.WinForms**: Interface gráfica utilizando Windows Forms

---

## 📁 ESTRUTURA DO PROJETO

```
Jokempo/
├── Jokempo.csproj                    # Projeto principal (console)
├── Program.cs                         # Código da versão console
├── Jokempo.Lib/                       # Biblioteca de classes
│   ├── Estatisticas.cs                 # Gerencia pontuação do jogador
│   ├── Jogada.cs                        # Enum: Pedra, Papel, Tesoura
│   ├── Jogador.cs                        # Representa um jogador
│   ├── Jogo.cs                            # Classe principal com lógica do jogo
│   ├── Jokempo.Lib.csproj                 # Configuração da biblioteca
│   ├── ResultadoRodada.cs                  # Enum: Vitoria, Derrota, Empate
│   └── Rodada.cs                             # Representa uma jogada
│
└── Jokempo.WinForms/                    # Interface gráfica
    ├── Form1.cs                           # Lógica da interface
    ├── Form1.Designer.cs                   # Layout gerado pelo designer
    ├── Jokempo.WinForms.csproj              # Configuração do projeto
    └── Program.cs                             # Ponto de entrada da aplicação
```

---

## ✨ FUNCIONALIDADES

- Jogar contra o computador (modo aleatório)
- Gravar nome do jogador
- Sistema de pontuação (vitórias, derrotas e empates)
- Estatísticas completas por jogador
- Trocar de jogador a qualquer momento
- Validação de entrada de dados
- Histórico de jogadas
- Interface colorida e intuitiva
- Atalho de teclado (Enter para confirmar nome)
- Suporte a múltiplas versões do .NET (8.0 e 9.0)

---

## 🎯 CONCEITOS DE C# UTILIZADOS

| Conceito | Onde foi aplicado |
|----------|-------------------|
| **Classes e Objetos** | `Jogador.cs`, `Estatisticas.cs`, `Rodada.cs`, `Jogo.cs` |
| **Métodos** | Organização da lógica em métodos reutilizáveis |
| **Propriedades** | `get; private set;` para encapsulamento |
| **Construtores** | Inicialização de objetos com validação |
| **Enumerações** | `Jogada.cs` (Pedra, Papel, Tesoura) e `ResultadoRodada.cs` |
| **Estruturas Condicionais (if/else)** | Validações e regras de negócio |
| **Estruturas Condicionais (switch)** | Processamento de resultados |
| **Laços de Repetição (foreach)** | Exibição de estatísticas |
| **Instruções de Controle (break/return)** | Controle de fluxo |
| **Coleções (List<>)** | Armazenamento de jogadores em `Jogo.cs` |
| **Tratamento de Exceções** | Validação de entrada com `throw` |
| **Eventos** | Clique de botões em `Form1.cs` |
| **LINQ** | Busca de jogadores existentes com `FirstOrDefault` |
| **Programação Orientada a Objetos** | Separação em camadas e responsabilidades |
| **Windows Forms** | Interface gráfica com `Form1.cs` e `Form1.Designer.cs` |

---

## 🚀 COMO EXECUTAR

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (8.0 ou 9.0)
- Visual Studio 2022 (recomendado) ou VS Code
- Windows (para versão Windows Forms)

### Passos para execução

1. **Clone o repositório**
```bash
git clone https://github.com/isadorameneghetti/jokempo.git
```

2. **Acesse a pasta do projeto**
```bash
cd jokempo
```

3. **Execute a versão desejada**

#### Versão Console:
```bash
dotnet run
```

#### Versão Windows Forms:
```bash
cd Jokempo.WinForms
dotnet run
```

Ou abra o arquivo `Jokempo.sln` no Visual Studio e pressione `F5`.

---

## 🎨 INTERFACE GRÁFICA (WINDOWS FORMS)

### Componentes da Interface:

| Componente | Função |
|------------|--------|
| **Campo de texto** | Digitar nome do jogador |
| **Botão Entrar/Trocar** | Login e troca de jogador |
| **Botão Pedra (vermelho)** | Jogar Pedra ✊ |
| **Botão Papel (verde)** | Jogar Papel ✋ |
| **Botão Tesoura (roxo)** | Jogar Tesoura ✌️ |
| **Painel de resultado** | Mostra jogadas e resultado da rodada |
| **Painel de estatísticas** | Vitórias (verde), Derrotas (vermelho), Empates (roxo) e Total |
| **Lista de histórico** | Últimas jogadas com ícones (❌ ➖) |

### Funcionalidades da Interface:

- **Enter** no campo de nome para confirmar
- Botão "Entrar" vira "Trocar" após login
- Cores diferentes para cada resultado
- Histórico com ícones visuais
- Estatísticas atualizadas em tempo real
- Validação de nome vazio com mensagem de erro

---

## 🖥️ VERSÃO CONSOLE

### Como jogar:

1. Digite seu nome
2. Escolha uma opção no menu:
   - **1 - Jogar**: Inicia uma partida
   - **2 - Trocar Jogador**: Troca de usuário
   - **3 - Estatísticas**: Visualiza desempenho
   - **0 - Sair**: Encerra o programa
3. Escolha: **0 - Pedra ✊**, **1 - Papel ✋** ou **2 - Tesoura ✌**

### Exemplo de execução:

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

---

## 🔍 DETALHAMENTO DAS CLASSES

### 📁 **Jokempo.Lib/**

#### `Jogada.cs`
```csharp
public enum Jogada
{
    Pedra = 0,    // ✊
    Papel = 1,    // ✋
    Tesoura = 2   // ✌️
}
```

#### `ResultadoRodada.cs`
```csharp
public enum ResultadoRodada
{
    Vitoria,  // Jogador ganhou
    Derrota,  // Computador ganhou
    Empate    // Jogadas iguais
}
```

#### `Estatisticas.cs`
- Gerencia vitórias, derrotas e empates
- Propriedade calculada `Total`
- Método `RegistrarResultado()`

#### `Jogador.cs`
- Nome do jogador (imutável)
- Objeto de estatísticas
- Validação no construtor

#### `Rodada.cs`
- Gera jogada aleatória do computador
- Determina resultado pelas regras
- Métodos estáticos para nomes formatados

#### `Jogo.cs`
- Gerencia lista de jogadores
- Controla jogador atual
- Cria rodadas e registra resultados

### 📁 **Jokempo.WinForms/**

#### `Program.cs`
- Ponto de entrada da aplicação
- Inicialização do Windows Forms

#### `Form1.Designer.cs`
- Layout gerado automaticamente
- Posicionamento dos controles
- Configurações visuais

#### `Form1.cs`
- Lógica principal da interface
- Eventos de clique dos botões
- Atualização de estatísticas e histórico

---

## 🧪 TESTANDO O PROJETO

### Cenários de teste sugeridos:

1. **Jogador novo** - Verificar se as estatísticas começam em zero
2. **Trocar jogador** - Confirmar que as estatísticas são mantidas por jogador
3. **Entradas inválidas** - Testar nome vazio (deve mostrar mensagem)
4. **Múltiplas partidas** - Verificar se os contadores atualizam corretamente
5. **Histórico** - Confirmar se as jogadas aparecem na lista com ícones
6. **Atalho Enter** - Pressionar Enter no campo de nome deve confirmar

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

<p align="center">
  <strong>Versão Console</strong> + <strong>Versão Windows Forms</strong>
</p>

<p align="center">
  Desenvolvido com ❤️ pelos alunos da FIAP
</p>

<p align="center">
  <img src="https://media.giphy.com/media/3o7abB06u9bNzA8LC8/giphy.gif" width="200">
</p>