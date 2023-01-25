﻿namespace Waitlist.Helpers
{
    public class AmazonSecretsManagerConfigurationProviderHelper : ConfigurationProvider
    {

        private readonly string _region;
        private readonly string _secretName;

        public AmazonSecretsManagerConfigurationProviderHelper(string region, string secretName)
        {
            _region = region;
            _secretName = secretName;
        }

        public override void Load()
        {
            var secret = GetSecret();

            Data = JsonSerializer.Deserialize<Dictionary<string, string>>(secret);
        }

        private string GetSecret()
        {
            var request = new GetSecretValueRequest
            {
                SecretId = _secretName,
                VersionStage = "AWSCURRENT" // VersionStage defaults to AWSCURRENT if unspecified.
            };

            using (var client =
            new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(_region)))
            {
                var response = client.GetSecretValueAsync(request).Result;

                string secretString;
                if (response.SecretString != null)
                {
                    secretString = response.SecretString;
                }
                else
                {
                    var memoryStream = response.SecretBinary;
                    var reader = new StreamReader(memoryStream);
                    secretString =
            System.Text.Encoding.UTF8
                .GetString(Convert.FromBase64String(reader.ReadToEnd()));
                }

                return secretString;
            }
        }

    }
}
