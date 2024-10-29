namespace VoiceRecognition
 {
    using Microsoft.CognitiveServices.Speech;
    using System.Runtime.CompilerServices;

    public static class VoiceRecognition
    {
        public static async Task<string> VoiceRecognitionOnce()
        {
            string? apiKey = "";
            try
            {
                 apiKey = Environment.GetEnvironmentVariable("AZURE_API_KEY");
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!string.IsNullOrEmpty(apiKey))
            {
                var config = SpeechConfig.FromSubscription(apiKey, "brazilsouth");

                using (var recognizer = new SpeechRecognizer(config))
                {
                    var result = await recognizer.RecognizeOnceAsync();

                    if (result.Reason == ResultReason.RecognizedSpeech)
                    {
                        return result.Text;
                    }
                    else
                    {
                        return "Unrecognized";
                    }

                }
            }
            return null;

        }
    }
}
