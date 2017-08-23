using System;
using AVFoundation;
using QnAmazing.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace QnAmazing.iOS
{
    public class TextToSpeechImplementation : QnAmazing.ISpeechService
	{
		public TextToSpeechImplementation() { }

		public void Speak(string text)
		{
			var speechSynthesizer = new AVSpeechSynthesizer();

			var speechUtterance = new AVSpeechUtterance(text)
			{
				Rate = AVSpeechUtterance.MaximumSpeechRate / 2,
				Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
				Volume = 0.5f,
				PitchMultiplier = 1.0f
			};

			speechSynthesizer.SpeakUtterance(speechUtterance);
		}
	}
}
