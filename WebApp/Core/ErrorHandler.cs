using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApp.Core
{
	public class ErrorHandler
	{
		private readonly RequestDelegate _next;

		public ErrorHandler(RequestDelegate next)
		{
			_next = next;
		}
		
		public async Task Invoke(HttpContext context, IHostingEnvironment env)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex, env);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception ex, IHostingEnvironment env)
		{
			var response = new ServerResponse<string>();
			if (env.IsProduction())
				response.Message = "Something bad happened. Please try again later.";
			response.Message = ex.Message;

			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";
			var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});
			return context.Response.WriteAsync(json);
		}
	}
}