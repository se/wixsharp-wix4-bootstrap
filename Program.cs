using System;
using WixSharp;
using WixSharp.Bootstrapper;

namespace WixSharpSetupBootstrapperCustomBAWiX4
{
    internal class Program
    {
        static void Main()
        {
            string productMsi = BuildMsi();

            var bootstrapper =
                new Bundle("MyProduct",
                    new MsiPackage(productMsi)
                    {
                        Id = "MyProductPackageId",
                        DisplayInternalUI = true
                    });

            bootstrapper.Version = new Version("1.0.0.0");
            bootstrapper.UpgradeCode = new Guid("aeaffa48-66a6-4ee6-97a2-87746024e4f4");

            bootstrapper.Application = new ManagedBootstrapperApplication("%this%");

            bootstrapper.Build("MyProduct.exe");
        }

        static string BuildMsi()
        {
            var project = new Project("MyProduct",
                              new Dir(@"%ProgramFiles%\My Company\My Product",
                                  new File("Program.cs")));

            project.GUID = new Guid("bfd0f215-8e51-41ee-87d4-ce70f42968f8");

            return project.BuildMsi();
        }
    }
}