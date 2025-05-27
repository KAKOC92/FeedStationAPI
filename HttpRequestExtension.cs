//namespace FSAPIHelpers
//{
//	public static class HttpRequestExtension


//	{

//		public static string GetIpAddress(this HttpRequest request)

//		{

//			var ipAddress = request?.Headers?["X-Real-IP"].ToString();

//			if (!string.IsNullOrEmpty(ipAddress))

//			{

//				return ipAddress;

//			}

//			ipAddress = request?.Headers?["X-Forwarded-For"].ToString();

//			if (!string.IsNullOrEmpty(ipAddress))

//			{

//				var parts = ipAddress.Split(',');

//				if (parts.Count() > 0)

//				{

//					ipAddress = parts[0];

//				}

//				return ipAddress;

//			}

//			ipAddress = request?.HttpContext?.Connection?.RemoteIpAddress?.ToString();

//			if (!string.IsNullOrEmpty(ipAddress))

//			{

//				return ipAddress;

//			}

//			return string.Empty;

//		}

//	}
//}