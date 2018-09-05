using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;

namespace ConsoleApp1
{
    /// <summary>
    ///     Class Program Speech Bing
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Recognizes the speech asynchronous.
        /// </summary>
        /// <returns></returns>
        public static async Task RecognizeSpeechAsync()
        {
            var factory = SpeechFactory.FromSubscription("", "global");

            // Creates a speech recognizer.
            using (var recognizer = factory.CreateSpeechRecognizer())
            {
                Console.WriteLine("Say something...");

                var result = await recognizer.RecognizeAsync();

                // Checks result.
                if (result.RecognitionStatus != RecognitionStatus.Recognized)
                {
                    Console.WriteLine($"Recognition status: {result.RecognitionStatus.ToString()}");
                    Console.WriteLine(result.RecognitionStatus == RecognitionStatus.Canceled
                        ? $"There was an error, reason: {result.RecognitionFailureReason}"
                        : "No speech could be recognized.\n");
                }
                else
                {
                    Console.WriteLine($"We recognized: {result.Text}");
                }
            }
        }

        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        private static void Main()
        {
            RecognizeSpeechAsync().Wait();
            Console.WriteLine("Please press a key to continue.");
            Console.ReadLine();
        }
    }
}