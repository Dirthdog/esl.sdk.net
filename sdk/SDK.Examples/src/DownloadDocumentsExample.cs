using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class DownloadDocumentsExample
	{
		public static string apiToken = "YOUR TOKEN HERE";
		public static string baseUrl = "ENVIRONMENT URL HERE";

		public static void Main (string[] args)
		{
			// Create new esl client with api token and base url
			EslClient client = new EslClient (apiToken, baseUrl);
			PackageId packageId = new PackageId ("GLK2xasqLvFe2wc4qwO5iTKyjx42");

			byte[] documentContent = client.DownloadDocument (packageId, "testing");
			File.WriteAllBytes (Directory.GetCurrentDirectory() + "/downloaded.pdf", documentContent);

			byte[] evidenceContent = client.DownloadEvidenceSummary (packageId);
			File.WriteAllBytes (Directory.GetCurrentDirectory() + "/evidence-summary.pdf", evidenceContent);

			byte[] zipContent = client.DownloadZippedDocuments (packageId);
			File.WriteAllBytes (Directory.GetCurrentDirectory() + "/package-documents.zip", zipContent);
		}
	}
}