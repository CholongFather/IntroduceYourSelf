using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroduceMySelf.API.Util
{
    public class GetIpAddress
    {
		/// <summary>
		/// Client Ip 꺼낼때 사용.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static string GetClientIp(HttpRequest request)
		{
			string ip = string.Empty;
			if (request.Headers["X-Forwarded-For"].Count > 0)
			{
				var ips = request.Headers["X-Forwarded-For"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();
				ip = ips[0].Trim();
			}
			else
				ip = request.HttpContext.Connection.RemoteIpAddress.ToString();

			ip = ip.Replace("::ffff:", "");

			return ip;
		}
	}
}
