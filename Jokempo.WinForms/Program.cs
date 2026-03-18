namespace Jokempo.WinForms;

// Classe estática que contém o ponto de entrada da aplicação
static class Program
{
    /// <summary>
    /// Ponto de entrada principal da aplicação Windows Forms
    /// O atributo [STAThread] é obrigatório para aplicações Windows Forms
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Inicializa as configurações da aplicação Windows Forms
        // Isso inclui configurações de visualização, fontes, etc.
        // Veja mais em: https://aka.ms/applicationconfiguration
        ApplicationConfiguration.Initialize();
        
        // Inicia a aplicação executando o Form1 (janela principal)
        // Isso bloqueia a execução até que o formulário seja fechado
        Application.Run(new Form1());
    }    
}