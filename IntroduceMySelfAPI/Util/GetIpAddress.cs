namespace IntroduceMySelf.API.Util;
public class GetIpAddress
{
	/// <summary>
	/// Client Ip 꺼낼때 사용.
	/// Forwarded-For를 Web에서 긁어서 API 서버에 전달
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	public static string GetClientIp(HttpRequest request)
	{
		var ip = string.Empty;
		if (request.Headers["X-Forwarded-For"].Count > 0)
		{
			var ips = request.Headers["X-Forwarded-For"].ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(e => e.Trim()).ToArray();
			ip = ips[0].Trim();
		}
		else
		{
			ip = request.HttpContext.Connection.RemoteIpAddress.ToString();
		}

		//IPV6
		ip = ip.Replace("::ffff:", "");

		return ip;
	}
}
