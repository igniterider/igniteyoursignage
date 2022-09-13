using System;
using IgniteYourSigns.Models;

namespace IgniteYourSigns.Services
{
	public class SignService
	{
        HttpClient httpClient;

        public SignService()
		{
            this.httpClient = new HttpClient();

        }

        List<PremadeSigns> premadesigns;
        public async Task<List<PremadeSigns>> GetPremadeSigns()
        {
            if (premadesigns?.Count > 0)
                return premadesigns;

            using var stream = await FileSystem.OpenAppPackageFileAsync("premadesigns.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            premadesigns = JsonSerializer.Deserialize <List<PremadeSigns>>(contents);
            return premadesigns;

        }

    }
}

