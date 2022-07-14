namespace CRR.Web.Controllers
{
	public class HttpAgent
	{
		public HttpClient HttpClient { get; set; }
		
		public HttpAgent()
		{
			HttpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7140/api/") };
		}
		
		public static implicit operator HttpClient(HttpAgent agent) => agent.HttpClient;
	}
}
