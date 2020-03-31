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
            GetConfig();
        }

        internal static IConfiguration GetConfig()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
	}
}
