# Challenge 0: Environment setup

**Duration**: 20 minutes

In this challenge, you set up your environment for use in the remaining challenge. You must follow all steps provided.

> **Important**: Many Azure resources require globally unique names. Throughout these steps, `XXXXX` appears as part of resource names. You should replace this with your Microsoft alias, initials, or another value to ensure uniquely named resources.

## Challenge 0 tasks to complete

1. Create an Azure resource group in your subscription.
   - Use `mca-challenge-XXXXX` as the name of the new resource group, where `XXXXX` is a unique suffix, such as your initials or a random number used to ensure a unique resource group name.
2. Run ARM template to provision lab resources.
    - Select **Deploy to Azure** below to launch a custom deployment using an ARM template.
    - On the custom deployment screen in the Azure portal, enter the following:
      - **Subscription**: Select the subscription you are using for this challenge.
      - **Resource group**: Select the resource group you created above from the dropdown list.
      - **Signed In User Object Id**: Enter the Azure AD `ObjectId` for your user account. You can retrieve this value by opening a **Cloud Shell** in the Azure portal and executing the following command: `az ad signed-in-user show --query id -o tsv`.
      - **Username**: Accept the default value, **demouser**.
      - **Password**: Accept the default value, **Password.1!!**.

    <a href ="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fsolliancenet%2Fchallenge-modern-cloud-apps%2Fmaster%2Flab-files%2Farm-template%2Fazure-deploy.json" target="_blank" title="Deploy to Azure"><img src="./media/deploy-button.png"/></a>

    > **Note**: The ARM template will append a hyphen followed by a 13-digit string at the end of resource names. This suffix ensures globally unique names for resources. We will ignore that string when referring to resources throughout the challenges. The resources created by the ARM template include:
    >
    > - [App Service Plan](https://docs.microsoft.com/azure/app-service/overview-hosting-plans)
    > - [Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview)
    > - [Azure App Configuration](https://docs.microsoft.com/azure/azure-app-configuration/overview)
    > - [Azure App Service](https://docs.microsoft.com/azure/app-service/overview) (Web App)
    > - [Azure Key Vault](https://docs.microsoft.com/azure/key-vault/general/overview)
    > - [Azure Logic App](https://docs.microsoft.com/azure/logic-apps/logic-apps-overview)
    > - [Azure SQL Database](https://docs.microsoft.com/azure/azure-sql/database/sql-database-paas-overview)
    > - [Azure Storage account](https://docs.microsoft.com/azure/storage/common/storage-account-overview)
    > - [Network interface](https://docs.microsoft.com/azure/virtual-network/virtual-network-network-interface) for VM
    > - [Network security group](https://docs.microsoft.com/azure/virtual-network/network-security-groups-overview) for VM
    > - [Public IP address](https://docs.microsoft.com/azure/virtual-network/public-ip-addresses) for VM
    > - [Service Bus namespace](https://docs.microsoft.com/azure/service-bus-messaging/service-bus-messaging-overview)
    > - [Virtual network](https://docs.microsoft.com/azure/virtual-network/virtual-networks-overview) with `default` subnet
    > - [Virtual machine using the Visual Studio 2019 (Latest) Community Edition image](https://docs.microsoft.com/azure/virtual-machines/windows/using-visual-studio-vm), which uses a custom script extension to:
    >     - Disable **IE Enhanced Security Configuration**
    >     - Download the starter solution from Serverless architecture MCW GitHub repo
    >     - Download and install Azure Data Studio
    >     - Download and install Microsoft Edge browser
