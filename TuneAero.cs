using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BreakFreeAudioKeyMaker
{
	public class TuneAero
	{
		public string Generate()
		{
			var combinedKey = "";

			try
			{
				var publicRsasp = new RSACryptoServiceProvider();

				publicRsasp.FromXmlString("<RSAKeyValue><Modulus>l76/Hhom3YQdJOSMkzfpPi3x08r+FF3UBc1HxttOnBBFeilrN67kYeFYeyA7czYKG+Sk26wX82JqO70yKWll1ufhFTVoKj84OqmcJSDsqFcOBJJSkWE3/8XiB89YY1ZgCsx+Hg+6Cd30Km7Sf7Uds0HdXFDYVPLdr9LFVhLNVhU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
				combinedKey = Regex.Replace(combinedKey, "\\t|\\n|\\r", "");

				var licenseId = GetLicenseIdFromCombinedKey(combinedKey);
				var licenseKey = GetKeyFromCombinedKey(combinedKey);
				
				if (IsKeyValid(licenseId, licenseKey, publicRsasp))
				{
					var keyEmailId = GetEmailIdFromLicenseId(licenseId);
				}

			}
			catch (Exception ex)
			{
				combinedKey = ex.Message;
			}

			return combinedKey;
		}

		private static bool IsKeyValid(string licenseId, string key, RSACryptoServiceProvider publicRsasp)
		{
			licenseId = licenseId.ToUpper().Trim();
			var bytes = new ASCIIEncoding().GetBytes(licenseId);
			var signature = Convert.FromBase64String(key);

			return publicRsasp.VerifyData(bytes, new SHA1CryptoServiceProvider(), signature);
		}

		private static string GetLicenseIdFromCombinedKey(string combinedKey)
		{
			var combinedKeyBase64 = combinedKey.Substring(172, combinedKey.Length - 172);
			var combinedKeyParsed = Convert.FromBase64String(combinedKeyBase64);

			var compinedKeyAscii = new ASCIIEncoding().GetString(combinedKeyParsed);

			return compinedKeyAscii.ToLower();
		}

		private static string GetKeyFromCombinedKey(string combinedKey)
		{
			return combinedKey.Substring(0, 172);
		}

		private static string GetEmailIdFromLicenseId(string licenseId)
		{
			return licenseId.Substring(14, licenseId.Length - 14);
		}
	}
}
