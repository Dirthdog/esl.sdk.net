using System;
using System.IO;
using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;

namespace SDK.Examples
{
	public class CreatePackageFromStream
	{
		public static string apiToken = "Q2xubnp5Y2dIQ3lROnNlY3JldA==";
		public static string baseUrl = "http://localhost:8080";

		public static void Main (string[] args)
		{
			// Create new esl client with api token and base url
			EslClient client = new EslClient (apiToken, baseUrl);
			FileInfo file = new FileInfo (Directory.GetCurrentDirectory() + "/src/document.pdf");
			Stream fileStream = File.OpenRead (file.FullName);

			DocumentPackage package = PackageBuilder.NewPackageNamed ("C# Package " + DateTime.Now)
					.DescribedAs ("This is a new package")
					.WithSigner(SignerBuilder.NewSignerWithEmail("etienne_hardy@silanis.com")
					            .WithFirstName("John")
					            .WithLastName("Smith"))
					.WithDocument(DocumentBuilder.NewDocumentNamed("My Document")
					              .FromStream(fileStream, DocumentType.PDF))
					.Build ();

			PackageId id = client.CreatePackage (package);

			Console.WriteLine ("Package {0} was created", id.Id);
		}
	}
}