using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QnAmazing
{
    public class WebService
    {
        public WebService()
        {
        }

		//string responseString = string.Empty;

        public static async Task<QnAMakerResult> Query(string query)
        {
			//var query = "hi"; //User Query
			var knowledgebaseId = "54625cfa-f8f1-4b0b-8a1f-1557785b22eb"; // Use knowledge base id created.
			var qnamakerSubscriptionKey = "08d31c549cca4bcc9d1fc8a8400fbd32"; //Use subscription key assigned to you.

			//Build the URI
			Uri qnamakerUriBase = new Uri("https://westus.api.cognitive.microsoft.com/qnamaker/v1.0");
			var builder = new UriBuilder($"{qnamakerUriBase}/knowledgebases/{knowledgebaseId}/generateAnswer");

			//Add the question as part of the body
			var postBody = $"{{\"question\": \"{query}\"}}";

			//Send the POST request
			using (HttpClient client = new HttpClient())
			{
				//Set the encoding to UTF8
                client.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("UTF8"));

				//Add the subscription key header
				client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", qnamakerSubscriptionKey);
                var repsonse = await client.PostAsync(builder.Uri.ToString(), new StringContent(postBody, Encoding.UTF8, "application/json"));
                if (repsonse.IsSuccessStatusCode) {

                    var responseString = await repsonse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<QnAMakerResult>(responseString);
                }
			}
            return null;
        }
    }


}


