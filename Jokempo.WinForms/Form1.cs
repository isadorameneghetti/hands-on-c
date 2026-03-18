using Jokempo.Lib;

namespace Jokempo.WinForms;

// Formulário principal do jogo (parcial porque tem o designer separado)
public partial class Form1 : Form
{
    // Instância do jogo (vinda da biblioteca Jokempo.Lib)
    private readonly Jogo _jogo = new();

    // Construtor do formulário
    public Form1()
    {
        InitializeComponent();
        
        // Adiciona evento para capturar a tecla Enter no campo de nome
        txtNomeJogador.KeyDown += TxtNomeJogador_KeyDown;
    }

    /// <summary>
    /// Evento disparado quando uma tecla é pressionada no campo de nome
    /// Permite que o usuário pressione Enter para confirmar o nome
    /// </summary>
    private void TxtNomeJogador_KeyDown(object? sender, KeyEventArgs e)
    {
        // Verifica se a tecla pressionada foi Enter
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true; // Impede o som de "bip" do Enter
            BtnEntrar_Click(sender, e); // Aciona o clique do botão Entrar
        }
    }

    /// <summary>
    /// Evento do botão Entrar - valida nome e carrega jogador
    /// </summary>
    private void BtnEntrar_Click(object? sender, EventArgs e)
    {
        // Pega o texto do campo e remove espaços extras
        var nome = txtNomeJogador.Text.Trim();

        // Validação: nome não pode ser vazio
        if (string.IsNullOrWhiteSpace(nome))
        {
            // Mostra mensagem de erro para o usuário
            MessageBox.Show("Por favor, digite um nome válido.", "Nome inválido",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Troca para o jogador (cria novo ou carrega existente)
        _jogo.TrocarJogador(nome);
        
        // Habilita os botões de jogada
        pnlJogadas.Enabled = true;
        
        // Esconde o painel de resultado (se estiver visível)
        pnlResultado.Visible = false;
        
        // Atualiza as estatísticas na tela
        AtualizarEstatisticas();

        // Muda o comportamento do botão
        txtNomeJogador.Enabled = false; // Bloqueia edição do nome
        btnEntrar.Text = "Trocar"; // Botão agora vira "Trocar"
        
        // Troca o evento do clique (remove Entrar, adiciona Trocar)
        btnEntrar.Click -= BtnEntrar_Click;
        btnEntrar.Click += BtnTrocar_Click;
    }

    /// <summary>
    /// Evento do botão Trocar - permite digitar novo nome
    /// </summary>
    private void BtnTrocar_Click(object? sender, EventArgs e)
    {
        // Habilita o campo de nome para edição
        txtNomeJogador.Enabled = true;
        txtNomeJogador.Text = ""; // Limpa o campo
        txtNomeJogador.Focus(); // Coloca o cursor no campo
        
        // Desabilita os botões de jogada até novo login
        pnlJogadas.Enabled = false;
        pnlResultado.Visible = false;

        // Volta o botão para "Entrar"
        btnEntrar.Text = "Entrar";
        
        // Troca o evento do clique (remove Trocar, adiciona Entrar)
        btnEntrar.Click -= BtnTrocar_Click;
        btnEntrar.Click += BtnEntrar_Click;
    }

    /// <summary>
    /// Evento dos botões de jogada (Pedra, Papel, Tesoura)
    /// </summary>
    private void BtnJogada_Click(object? sender, EventArgs e)
    {
        // Verifica se o botão clicado tem a Tag com a jogada
        // sender é o objeto que disparou o evento (o botão)
        if (sender is not Button btn || btn.Tag is not Jogada jogada)
            return;

        // Executa a jogada (cria uma rodada e registra resultado)
        var rodada = _jogo.Jogar(jogada);
        
        // Atualiza a interface com os resultados
        ExibirResultado(rodada);
        AtualizarEstatisticas();
        AdicionarHistorico(rodada);
    }

    /// <summary>
    /// Exibe o resultado da rodada no painel de resultado
    /// </summary>
    private void ExibirResultado(Rodada rodada)
    {
        var nomeJogador = _jogo.JogadorAtual!.Nome;

        // Mostra as escolhas do jogador e do computador
        lblJogadorEscolheu.Text = $"{nomeJogador} escolheu: {Rodada.ObterNomeJogada(rodada.JogadaJogador)}";
        lblComputadorEscolheu.Text = $"Computador escolheu: {Rodada.ObterNomeJogada(rodada.JogadaComputador)}";

        // Define mensagem e cor conforme o resultado
        switch (rodada.Resultado)
        {
            case ResultadoRodada.Vitoria:
                lblResultado.Text = $"🎉 Parabéns, {nomeJogador}! Você venceu!";
                lblResultado.ForeColor = Color.FromArgb(34, 197, 94); // Verde
                break;
            case ResultadoRodada.Derrota:
                lblResultado.Text = $"😢 Não foi dessa vez, {nomeJogador}!";
                lblResultado.ForeColor = Color.FromArgb(239, 68, 68); // Vermelho
                break;
            case ResultadoRodada.Empate:
                lblResultado.Text = "🤝 Empate!";
                lblResultado.ForeColor = Color.FromArgb(168, 85, 247); // Roxo
                break;
        }

        // Mostra o painel de resultado
        pnlResultado.Visible = true;
    }

    /// <summary>
    /// Atualiza os labels de estatísticas com os dados do jogador atual
    /// </summary>
    private void AtualizarEstatisticas()
    {
        // Se não há jogador atual, não faz nada
        if (_jogo.JogadorAtual == null) return;

        // Pega as estatísticas do jogador atual
        var stats = _jogo.JogadorAtual.Estatisticas;
        
        // Atualiza os labels
        lblVitorias.Text = $"Vitórias: {stats.Vitorias}";
        lblDerrotas.Text = $"Derrotas: {stats.Derrotas}";
        lblEmpates.Text = $"Empates: {stats.Empates}";
        lblTotal.Text = $"Total: {stats.Total}";
    }

    /// <summary>
    /// Adiciona a jogada ao histórico (lista)
    /// </summary>
    private void AdicionarHistorico(Rodada rodada)
    {
        // Escolhe o ícone conforme o resultado
        var simbolo = rodada.Resultado switch
        {
            ResultadoRodada.Vitoria => "✅",
            ResultadoRodada.Derrota => "❌",
            ResultadoRodada.Empate => "➖",
            _ => ""
        };

        // Formata o texto da jogada
        var texto = $"{simbolo} {Rodada.ObterNomeJogada(rodada.JogadaJogador)} vs {Rodada.ObterNomeJogada(rodada.JogadaComputador)}";
        
        // Insere no início da lista (mais recente primeiro)
        lstHistorico.Items.Insert(0, texto);
    }
}