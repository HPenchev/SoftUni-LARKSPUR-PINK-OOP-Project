namespace Game
{
    using System.Speech.Synthesis;

    public class PlayAudio
    {
        public static void YouLuckyBastard()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("You lucky bastard.");
        }

        public static void YouAreFucked()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("You are fucked.");
        }

        public static void Laugh()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("ha ha ha ha.");
        }

        public static void YouPussy()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("You are a pussy.");
        }

        public static void WelcomeToTheShop()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("Hello stranger, welcome to my humble shop.");
        }

        public static void NoMoney()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SetOutputToDefaultAudioDevice();
            synth.Speak("No money, no funny.");
        }
    }
}