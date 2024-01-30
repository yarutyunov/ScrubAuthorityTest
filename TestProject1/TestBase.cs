using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Ppc;

namespace TestProject1
{
    public class TestBase
    {
        public string? ServicePassword { get; set; }

        public TestBase()
        {
            var config = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
            ServicePassword = config["ServicePassword"];
        }
    }
}
