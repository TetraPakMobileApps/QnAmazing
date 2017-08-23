using System;
using Newtonsoft.Json;

namespace QnAmazing
{
    public class QnAMakerResult
	{
		/// <summary>
		/// The top answer found in the QnA Service.
		/// </summary>
		[JsonProperty(PropertyName = "answer")]
		public string Answer { get; set; }

		/// <summary>
		/// The score in range [0, 100] corresponding to the top answer found in the QnA    Service.
		/// </summary>
		[JsonProperty(PropertyName = "score")]
		public double Score { get; set; }

        [JsonIgnore]
        public string Emoji {
            get {
                if (Score < 30) return "BAD";
                if (Score < 60) return "NJEA";
                return "GOOD";
            }
        }

		[JsonIgnore]
		public string Question { get; set; }

        public override string ToString()
        {
            return string.Format("[QnAMakerResult: Answer={0}, Score={1}]", Answer, Score);
        }
	}
}