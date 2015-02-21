using System;
namespace Game
{
    using System.Speech.Synthesis;

    public class PlayAudio
    {
        public static void YouLuckyBastard()
        {
            // Initialize a new instance of the SpeechSynthesizer.
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string.
            synth.Speak("You lucky bastard.");
        }
    }
}