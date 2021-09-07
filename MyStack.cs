using System.Threading.Tasks;
using Pulumi;
using Pulumi.AzureNative.Resources;
using Pulumi.AzureNative.Storage;
using Pulumi.AzureNative.Storage.Inputs;

class MyStack : Stack
{
    public MyStack()
    {
        // Create an Azure Resource Group
        var resourceGroup = new ResourceGroup("PulumiTestRG");

        var b2cTenant = new Pulumi.AzureNative.AzureActiveDirectory.B2CTenant("PulumiTest", new Pulumi.AzureNative.AzureActiveDirectory.B2CTenantArgs
        {
            Location = "Europe",
            ResourceGroupName = resourceGroup.Name,
            Properties = new Pulumi.AzureNative.AzureActiveDirectory.Inputs.CreateTenantRequestBodyPropertiesArgs
            {
                CountryCode = "europe",
                DisplayName = "pk-PulumiTest"
            },
            ResourceName = "pkpulumitest",
            Sku = new Pulumi.AzureNative.AzureActiveDirectory.Inputs.B2CResourceSKUArgs
            {
                Name = Pulumi.AzureNative.AzureActiveDirectory.B2CResourceSKUName.PremiumP1,
                Tier = Pulumi.AzureNative.AzureActiveDirectory.B2CResourceSKUTier.A0
            }
        });
    }


}
