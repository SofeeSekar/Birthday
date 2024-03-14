using System;
using System.Text;
namespace BithdayB.CommonUtils
{
	/// <summary>
	/// 
	/// </summary>
	public class BdayUtils
	{
		public BdayUtils()
		{

		}
		/// <summary>
		/// Method to get the serialized data
		/// </summary>
		/// <param name="_data"></param>
		/// <returns></returns>
		public static HttpContent GetSerializedData(LoginModel _data)
		{
            var json = System.Text.Json.JsonSerializer.Serialize(_data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
			return content;

        }
	}
}

