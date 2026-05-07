namespace GCLab;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== GCLab - Versão Corrigida ===");
        Console.WriteLine($"GC Server Mode: {System.Runtime.GCSettings.IsServerGC}\n");

        var tracker = new IssueTracker();

        // 1) Vazamento por evento - USANDO USING
        var publisher = new Publisher();
        using (var subscriber = new LeakySubscriber(publisher))
        {
            tracker.Track("subscriber", subscriber);
            
            // 2) LOH + cache (agora com WeakReference)
            var lohBuffer = BigBufferHolder.Run();
            tracker.Track("lohBuffer", lohBuffer);

            // 3) Pinned buffer - USANDO USING
            using (var pinner = new Pinner())
            {
                var pinned = pinner.PinLongTime();
                tracker.Track("pinnedBuffer", pinned);

                // 4) Concatenação (já corrigida)
                var payload = ConcatWork.Bad();
                Console.WriteLine($"Payload length: {payload.Length}");

                // 5) Logger - USANDO USING
                using (var logger = new Logger("log.txt"))
                {
                    logger.WriteLines(10);
                    tracker.Track("logger", logger);
                    
                    // Dispara evento
                    publisher.Raise();
                } // Logger.Dispose() chamado aqui
                
            } // Pinner.Dispose() chamado aqui
            
        } // LeakySubscriber.Dispose() chamado aqui (remove evento)

        // Todas as referências locais já saíram de escopo
        publisher = null;

        // Força coletas
        GCHelpers.FullCollect();
        tracker.Report();

        Console.WriteLine(tracker.HasSurvivors
            ? "\n❌ Existem sobreviventes indesejados. Sua missão: corrigir o código e rodar novamente."
            : "\n✅ GC limpo: nenhuma referência indesejada permaneceu viva.");
    }
}