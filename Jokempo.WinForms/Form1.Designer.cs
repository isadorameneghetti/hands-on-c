namespace Jokempo.WinForms;

// Arquivo gerado automaticamente pelo Visual Studio Designer
// Contém a declaração dos controles e o layout da interface
partial class Form1
{
    // Gerenciador de componentes (necessário para o designer)
    private System.ComponentModel.IContainer components = null;

    // Método de limpeza de recursos (chamado ao fechar o formulário)
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    // Método que inicializa todos os componentes da interface
    // Este código é gerado automaticamente pelo designer
    private void InitializeComponent()
    {
        // --- Painel do Jogador (parte superior) ---
        pnlJogador = new Panel();
        lblJogador = new Label();
        txtNomeJogador = new TextBox();
        btnEntrar = new Button();

        // --- Painel de Jogadas (botões coloridos) ---
        pnlJogadas = new Panel();
        lblEscolha = new Label();
        btnPedra = new Button();
        btnPapel = new Button();
        btnTesoura = new Button();

        // --- Painel de Resultado (mostra quem ganhou) ---
        pnlResultado = new Panel();
        lblJogadorEscolheu = new Label();
        lblComputadorEscolheu = new Label();
        lblResultado = new Label();

        // --- Painel de Estatísticas (lado direito) ---
        pnlEstatisticas = new Panel();
        lblEstatisticasTitulo = new Label();
        lblVitorias = new Label();
        lblDerrotas = new Label();
        lblEmpates = new Label();
        lblTotal = new Label();

        // --- Histórico de jogadas (lista) ---
        lblHistoricoTitulo = new Label();
        lstHistorico = new ListBox();

        // Suspende a lógica de layout enquanto configura os controles
        SuspendLayout();

        // ------------------- CONFIGURAÇÃO DO PAINEL JOGADOR -------------------
        pnlJogador.Location = new Point(20, 15);      // Posição X, Y
        pnlJogador.Size = new Size(540, 50);          // Largura, Altura

        // Label "Jogador:"
        lblJogador.Text = "Jogador:";
        lblJogador.Location = new Point(0, 8);
        lblJogador.AutoSize = true;
        lblJogador.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

        // Campo de texto para digitar o nome
        txtNomeJogador.Location = new Point(85, 5);
        txtNomeJogador.Size = new Size(300, 30);
        txtNomeJogador.Font = new Font("Segoe UI", 11F);
        txtNomeJogador.PlaceholderText = "Digite seu nome...";

        // Botão Entrar (azul)
        btnEntrar.Text = "Entrar";
        btnEntrar.Location = new Point(400, 3);
        btnEntrar.Size = new Size(130, 35);
        btnEntrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnEntrar.BackColor = Color.FromArgb(59, 130, 246); // Azul
        btnEntrar.ForeColor = Color.White;
        btnEntrar.FlatStyle = FlatStyle.Flat;
        btnEntrar.FlatAppearance.BorderSize = 0;
        btnEntrar.Cursor = Cursors.Hand;

        // Adiciona os controles ao painel do jogador
        pnlJogador.Controls.Add(lblJogador);
        pnlJogador.Controls.Add(txtNomeJogador);
        pnlJogador.Controls.Add(btnEntrar);

        // ------------------- CONFIGURAÇÃO DO PAINEL JOGADAS -------------------
        pnlJogadas.Location = new Point(20, 80);
        pnlJogadas.Size = new Size(540, 140);
        pnlJogadas.Enabled = false; // Começa desabilitado (só habilita após login)

        // Label "Escolha sua jogada:"
        lblEscolha.Text = "Escolha sua jogada:";
        lblEscolha.Location = new Point(0, 0);
        lblEscolha.AutoSize = true;
        lblEscolha.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

        // Botão Pedra (vermelho)
        btnPedra.Text = "✊\nPedra";
        btnPedra.Location = new Point(0, 35);
        btnPedra.Size = new Size(165, 90);
        btnPedra.Font = new Font("Segoe UI", 14F);
        btnPedra.BackColor = Color.FromArgb(239, 68, 68); // Vermelho
        btnPedra.ForeColor = Color.White;
        btnPedra.FlatStyle = FlatStyle.Flat;
        btnPedra.FlatAppearance.BorderSize = 0;
        btnPedra.Cursor = Cursors.Hand;
        btnPedra.Tag = Jokempo.Lib.Jogada.Pedra; // Tag identifica a jogada

        // Botão Papel (verde)
        btnPapel.Text = "✋\nPapel";
        btnPapel.Location = new Point(180, 35);
        btnPapel.Size = new Size(165, 90);
        btnPapel.Font = new Font("Segoe UI", 14F);
        btnPapel.BackColor = Color.FromArgb(34, 197, 94); // Verde
        btnPapel.ForeColor = Color.White;
        btnPapel.FlatStyle = FlatStyle.Flat;
        btnPapel.FlatAppearance.BorderSize = 0;
        btnPapel.Cursor = Cursors.Hand;
        btnPapel.Tag = Jokempo.Lib.Jogada.Papel;

        // Botão Tesoura (roxo)
        btnTesoura.Text = "✌️\nTesoura";
        btnTesoura.Location = new Point(360, 35);
        btnTesoura.Size = new Size(165, 90);
        btnTesoura.Font = new Font("Segoe UI", 14F);
        btnTesoura.BackColor = Color.FromArgb(168, 85, 247); // Roxo
        btnTesoura.ForeColor = Color.White;
        btnTesoura.FlatStyle = FlatStyle.Flat;
        btnTesoura.FlatAppearance.BorderSize = 0;
        btnTesoura.Cursor = Cursors.Hand;
        btnTesoura.Tag = Jokempo.Lib.Jogada.Tesoura;

        // Adiciona os botões ao painel de jogadas
        pnlJogadas.Controls.Add(lblEscolha);
        pnlJogadas.Controls.Add(btnPedra);
        pnlJogadas.Controls.Add(btnPapel);
        pnlJogadas.Controls.Add(btnTesoura);

        // ------------------- CONFIGURAÇÃO DO PAINEL RESULTADO -------------------
        pnlResultado.Location = new Point(20, 235);
        pnlResultado.Size = new Size(540, 110);
        pnlResultado.BackColor = Color.FromArgb(241, 245, 249); // Cinza claro
        pnlResultado.Padding = new Padding(15);
        pnlResultado.Visible = false; // Começa invisível (só aparece após jogar)

        // Label que mostra a escolha do jogador
        lblJogadorEscolheu.Text = "";
        lblJogadorEscolheu.Location = new Point(15, 10);
        lblJogadorEscolheu.AutoSize = true;
        lblJogadorEscolheu.Font = new Font("Segoe UI", 11F);

        // Label que mostra a escolha do computador
        lblComputadorEscolheu.Text = "";
        lblComputadorEscolheu.Location = new Point(15, 35);
        lblComputadorEscolheu.AutoSize = true;
        lblComputadorEscolheu.Font = new Font("Segoe UI", 11F);

        // Label que mostra o resultado (Vitória/Derrota/Empate)
        lblResultado.Text = "";
        lblResultado.Location = new Point(15, 68);
        lblResultado.AutoSize = true;
        lblResultado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);

        // Adiciona as labels ao painel de resultado
        pnlResultado.Controls.Add(lblJogadorEscolheu);
        pnlResultado.Controls.Add(lblComputadorEscolheu);
        pnlResultado.Controls.Add(lblResultado);

        // ------------------- CONFIGURAÇÃO DO PAINEL ESTATÍSTICAS -------------------
        pnlEstatisticas.Location = new Point(580, 15); // Lado direito
        pnlEstatisticas.Size = new Size(200, 170);
        pnlEstatisticas.BackColor = Color.FromArgb(241, 245, 249);
        pnlEstatisticas.Padding = new Padding(12);

        // Título "Estatísticas"
        lblEstatisticasTitulo.Text = "Estatísticas";
        lblEstatisticasTitulo.Location = new Point(12, 8);
        lblEstatisticasTitulo.AutoSize = true;
        lblEstatisticasTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

        // Label de Vitórias (verde)
        lblVitorias.Text = "Vitórias: 0";
        lblVitorias.Location = new Point(12, 42);
        lblVitorias.AutoSize = true;
        lblVitorias.Font = new Font("Segoe UI", 10F);
        lblVitorias.ForeColor = Color.FromArgb(34, 197, 94); // Verde

        // Label de Derrotas (vermelho)
        lblDerrotas.Text = "Derrotas: 0";
        lblDerrotas.Location = new Point(12, 68);
        lblDerrotas.AutoSize = true;
        lblDerrotas.Font = new Font("Segoe UI", 10F);
        lblDerrotas.ForeColor = Color.FromArgb(239, 68, 68); // Vermelho

        // Label de Empates (roxo)
        lblEmpates.Text = "Empates: 0";
        lblEmpates.Location = new Point(12, 94);
        lblEmpates.AutoSize = true;
        lblEmpates.Font = new Font("Segoe UI", 10F);
        lblEmpates.ForeColor = Color.FromArgb(168, 85, 247); // Roxo

        // Label de Total (negrito)
        lblTotal.Text = "Total: 0";
        lblTotal.Location = new Point(12, 126);
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        // Adiciona as labels ao painel de estatísticas
        pnlEstatisticas.Controls.Add(lblEstatisticasTitulo);
        pnlEstatisticas.Controls.Add(lblVitorias);
        pnlEstatisticas.Controls.Add(lblDerrotas);
        pnlEstatisticas.Controls.Add(lblEmpates);
        pnlEstatisticas.Controls.Add(lblTotal);

        // ------------------- CONFIGURAÇÃO DO HISTÓRICO -------------------
        lblHistoricoTitulo.Text = "Histórico";
        lblHistoricoTitulo.Location = new Point(580, 195);
        lblHistoricoTitulo.AutoSize = true;
        lblHistoricoTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

        // ListBox que mostra as últimas jogadas
        lstHistorico.Location = new Point(580, 222);
        lstHistorico.Size = new Size(200, 133);
        lstHistorico.Font = new Font("Segoe UI", 9F);
        lstHistorico.BorderStyle = BorderStyle.FixedSingle;

        // ------------------- CONFIGURAÇÃO DO FORMULÁRIO -------------------
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 370); // Tamanho da janela
        Text = "Jokempo - Pedra, Papel e Tesoura"; // Título da janela
        FormBorderStyle = FormBorderStyle.FixedSingle; // Não redimensionável
        MaximizeBox = false; // Remove botão maximizar
        StartPosition = FormStartPosition.CenterScreen; // Centraliza na tela
        BackColor = Color.White; // Fundo branco

        // Adiciona todos os controles ao formulário
        Controls.Add(pnlJogador);
        Controls.Add(pnlJogadas);
        Controls.Add(pnlResultado);
        Controls.Add(pnlEstatisticas);
        Controls.Add(lblHistoricoTitulo);
        Controls.Add(lstHistorico);

        // Retoma a lógica de layout
        ResumeLayout(false);
    }

    #endregion

    // ------------------- DECLARAÇÃO DOS CONTROLES -------------------
    // Painel e controles do jogador
    private Panel pnlJogador;
    private Label lblJogador;
    private TextBox txtNomeJogador;
    private Button btnEntrar;

    // Painel e botões de jogadas
    private Panel pnlJogadas;
    private Label lblEscolha;
    private Button btnPedra;
    private Button btnPapel;
    private Button btnTesoura;

    // Painel e labels de resultado
    private Panel pnlResultado;
    private Label lblJogadorEscolheu;
    private Label lblComputadorEscolheu;
    private Label lblResultado;

    // Painel e labels de estatísticas
    private Panel pnlEstatisticas;
    private Label lblEstatisticasTitulo;
    private Label lblVitorias;
    private Label lblDerrotas;
    private Label lblEmpates;
    private Label lblTotal;

    // Histórico
    private Label lblHistoricoTitulo;
    private ListBox lstHistorico;
}