// <copyright file="LocalSecretConfiguration.cs" company="Benjamin Howarth &amp; contributors">
// Copyright (c) Benjamin Howarth &amp; contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Refit.Clients.Twitter.Tests
{
	[SetUpFixture]
	public class LocalSecretConfiguration
	{
		[OneTimeSetUp]
		public void LoadSecrets()
        {
            var currentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
            if (File.Exists(Path.Combine(currentDirectory, "appsettings.json")))
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                Environment.SetEnvironmentVariable(Constants.ConsumerKey, config[Constants.ConsumerKey], EnvironmentVariableTarget.Process);
                Environment.SetEnvironmentVariable(Constants.ConsumerSecret, config[Constants.ConsumerSecret], EnvironmentVariableTarget.Process);
                Environment.SetEnvironmentVariable(Constants.AccessToken, config[Constants.AccessToken], EnvironmentVariableTarget.Process);
                Environment.SetEnvironmentVariable(Constants.AccessTokenSecret, config[Constants.AccessTokenSecret], EnvironmentVariableTarget.Process);
            }
            else
            {
                // BH: Do nothing, access tokens set by Azure Key Vault at build time
            }
        }
    }
}
