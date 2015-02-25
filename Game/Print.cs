namespace Game
{
    using System;
    using System.Threading;
    using System.Speech.Synthesis;

    public static class Print
    {
        public static void PrintMessage(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < text.Length; i++)
            {
                Thread.Sleep(30);
                Console.Write(text[i]);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PrintMessageWithAudio(string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.SpeakAsync(text);
            for (int i = 0; i < text.Length; i++)
            {
                Thread.Sleep(30);
                Console.Write(text[i]);
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}