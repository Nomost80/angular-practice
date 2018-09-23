namespace WebApp.Core
{
	public class ServerResponse<T>
	{
		public string Message { get; set; }
		public T Data { get; set; }
	}
}