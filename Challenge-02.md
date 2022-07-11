# Challenge 2: Deploy e-commerce website

**Duration**: 15 minutes

In this challenge, you deploy the Contoso web app and provide the necessary configuration to display the e-commerce website.

- [Challenge 2: Deploy e-commerce website](#challenge-2-deploy-e-commerce-website)
  - [Task 1: Configure SQL Database firewall](#task-1-configure-sql-database-firewall)
  - [Task 2: Connect to the Lab VM](#task-2-connect-to-the-lab-vm)
  - [Task 3: Open the Contoso Sports League starter solution in Visual Studio](#task-3-open-the-contoso-sports-league-starter-solution-in-visual-studio)
  - [Task 4: Configure the e-commerce Web App in Visual Studio](#task-4-configure-the-e-commerce-web-app-in-visual-studio)
  - [Task 5: Publish the web app to Azure](#task-5-publish-the-web-app-to-azure)

## Task 1: Configure SQL Database firewall

In this task, you set up access to the Azure SQL Database from your local machine.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** from the Azure services list.

   ![Resource groups is highlighted in the Azure services list.](media/azure-services-resource-groups.png "Azure services")

2. Select the **hands-on-lab-SUFFIX** resource group from the list.

   ![The "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

3. In the list of resources within your resource group, select the **contososports** SQL Server resource.

   ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and contososports SQL Server resource is highlighted.](./media/resource-group-resources-sql-server.png "ContosoSports SQL Server in resource group list")

4. On the **Overview** blade for the **SQL Server** resource, select the **Show firewall settings** in the Essentials area.

    ![On the SQL Server Overview screen with the Show firewall settings link highlighted.](media/sql-server-overview-show-firewall-settings.png "SQL Server Overview")

5. On the **Firewalls and virtual networks** blade, select **Add client IP** from the toolbar.

    ![The Add client IP button is highlighted on the firewalls and virtual networks toolbar.](media/sql-server-firewall-toolbar-add-client-ip.png "Add client IP")

6. A new rule will be generated that contains your client IP address for the **Start IP** and **End IP**. This allows you to connect to the database from your machine.

    ![Screenshot of the Rule name, Start IP. and End IP fields on the Firewall Settings blade.](media/sql-server-client-ip-rule.png "Firewall rule")

7. Select **Save** on the toolbar.

    ![Screenshot of the Firewall settings Save button.](media/sql-server-firewall-toolbar-save.png "Firewall settings Save button")

8. Select **OK** on the **Success** dialog when it appears.

    ![The success dialog for updating the server firewall rules is displayed and the OK button is highlighted.](media/sql-server-firewall-save-success.png "Success")

## Task 2: Connect to the Lab VM

In this task, you create an RDP connection to your Lab virtual machine (VM).

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** from the Azure services list.

   ![Resource groups is highlighted in the Azure services list.](media/azure-services-resource-groups.png "Azure services")

2. Select the **hands-on-lab-SUFFIX** resource group from the list.

   ![The "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

3. In the list of resources within your resource group, select the **LabVM Virtual machine** resource.

   ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and LabVM is highlighted.](./media/resource-group-resources-labvm.png "LabVM in resource group list")

4. On your LabVM blade, select **Connect** and **RDP** from the top menu.

   ![The LabVM blade is displayed, with the Connect button highlighted in the top menu.](./media/connect-vm-rdp.png "Connect to Lab VM")

5. On the Connect to virtual machine blade, select **Download RDP File**, then open the downloaded RDP file.

   ![The Connect to virtual machine blade is displayed, and the Download RDP File button is highlighted.](./media/connect-to-virtual-machine.png "Connect to virtual machine")

6. Select **Connect** on the Remote Desktop Connection dialog.

   ![In the Remote Desktop Connection Dialog Box, the Connect button is highlighted.](./media/remote-desktop-connection.png "Remote Desktop Connection dialog")

7. Enter the following credentials when prompted and select **OK**:

   - **User name**: demouser
   - **Password**: Password.1!!

   ![The credentials specified above are entered into the Enter your credentials dialog.](media/rdc-credentials.png "Enter your credentials")

8. Select **Yes** to connect if prompted that the remote computer's identity cannot be verified.

   ![In the Remote Desktop Connection dialog box, a warning states that the remote computer's identity cannot be verified and asks if you want to continue anyway. At the bottom, the Yes button is highlighted.](./media/remote-desktop-connection-identity-verification-labvm.png "Remote Desktop Connection dialog")

## Task 3: Open the Contoso Sports League starter solution in Visual Studio

1. On the LabVM, open File Explorer and navigate to the `C:\MCW\MCW-Modern-cloud-apps-main\Hands-on lab\lab-files\src\Contoso Sports League` folder.

2. From the **Contoso Sports League** folder, open the Visual Studio solution by double-clicking on the `Contoso.Apps.SportsLeague.sln` file.

3. If prompted about how to open the file, select **Visual Studio 2019**, and then select **OK**.

   ![Visual Studio 2019 is highlighted in the How do you want to open this file? dialog.](media/solution-file-open-with.png "Visual Studio 2019")

4. Sign in to Visual Studio using your Azure account credentials.

   ![The Sign in button is highlighted on the Visual Studio Welcome screen.](media/visual-studio-sign-in.png "Visual Studio 2019")

5. If prompted with a security warning, uncheck **Ask me for every project in this solution**, and then select **OK**.

6. Using the Visual Studio Solution Explorer, expand each of the folders and notice the solution contains the following projects:

    | Project | Description |
    |:----------|:-------------|
    | Contoso.Apps.SportsLeague.Web |   Contoso Sports League e-commerce application |
    | Contoso.Apps.SportsLeague.Admin |   Contoso Sports League call center admin application |
    | Contoso.Apps.Common  |   Shared tier |
    | Contoso.Apps.SportsLeague.Data  |   Shared tier |
    | Contoso.Apps.FunctionApp  |   Function app tier |
    | Contoso.Apps.SportsLeague.Offers |  API for returning list of available products |
    | Contoso.Apps.PaymentGateway   |     API for payment processing |

   ![The projects contained within the solution are displayed in the Visual Studio Solution Explorer.](media/visual-studio-solution.png "Contoso.Apps.SportsLeague solution files")

## Task 4: Configure the e-commerce Web App in Visual Studio

1. Navigate to the `Contoso.Apps.SportsLeague.Web` project located in the **Web** folder using the **Solution Explorer** of Visual Studio.

    ![The Web project is highlighted in Visual Studio Solution Explorer.](media/visual-studio-web-app.png "Solution Explorer")

2. Right-click the `Contoso.Apps.SportsLeague.Web` project and select **Manage NuGet Packages** from the context menu.

3. Select the **Browse** tab and search for **Microsoft.Azure.AppConfiguration.AspNetCore**.

4. Select **Microsoft.Azure.AppConfiguration.AspNetCore** from the search results, and in the next pane, select **Install** to install the latest stable version.

    ![The NuGet Package Manager windows is displayed with the Browse tab selected, Microsoft.Azure.AppConfiguration.AspNetCore entered into the search box and selected from the search results. In the next pane, the Install button is selected.](media/nuget_installappconfigpackage_web.png "NuGet Package Manager")

5. Repeat step 4-6, this time installing the latest **Azure.Identity**.

6. Now you are ready to configure this application to use the App Configuration in Azure. Expand the **Contoso.Apps.SportsLeague.Web** project and open the `Program.cs` file.

7. Uncomment the following **using** statements at the top of the file:

    ```csharp
    using Microsoft.Extensions.Configuration;
    using Azure.Identity;
    ```

8. In the **CreateHostBuilder** method, uncomment the following code. This tells the application to utilize the AppConfig connection string that you've already setup on the **contosoapp** application service to point to the centralized App Configuration resource.

    ```csharp
    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
    {
        var settings = config.Build();

        config.AddAzureAppConfiguration(options =>
        {
            options.Connect(settings["ConnectionStrings:AppConfig"])
                    .ConfigureKeyVault(kv =>
                    {
                        kv.SetCredential(new DefaultAzureCredential());
                    });
        });
    })
    .UseStartup<Startup>();
    ```

9. Save `Program.cs` by selecting Save on the Visual Studio toolbar.

## Task 5: Publish the web app to Azure

1. Right-click the **Contoso.Apps.SportsLeague.Web** project in the Visual Studio Solution Explorer and select **Publish**.

    ![In Solution Explorer, under Solution \'Contoso.Apps.SportsLeague\' (7 projects), Web is expanded, and under Web, Contoso.Apps.SportsLeague.Web is selected.](media/2019-04-19-14-03-04.png "Solution Explorer")

2. On the Publish dialog, select **Azure** as the **Target**, then select **Next**.

    ![On the Publish dialog, Azure is specified as the target and the next button is highlighted.](media/publish-target.png "Publish Target")

3. For **Specific target**, select **Azure App Service (Windows)**, then select **Next**.

    ![On the Publish dialog, Azure App Service (Windows) is specified as the specific target and the next button is highlighted.](media/publish-specific-target-app-service-windows.png "Publish Specific Target")

4. On the **App Service** tab of the Publish dialog, select the appropriate subscription, then expand the **hands-on-lab-SUFFIX** resource group, select the **contosoapp** Web App from the list, and then select **Finish**.

    ![On the Publish dialog App Service tab, the contosoapp Web App is highlighted and the finish button is highlighted.](media/publish-app-service-contoso-app.png "App Service Publish")

5. Back in Visual Studio, select **Publish** to publish the Web application.

    ![Publish profile is displayed with the Publish button highlighted.](media/visual-studio-publish-web.png "Publish profile")

6. In the Visual Studio **Output** view, you will see a status that indicates the Web App was published successfully.

    ![Screenshot of the Visual Studio Output view, with the Publish Succeeded message circled.](media/image50.png "Visual Studio Output view")

    >**Note**: Your URL will differ from the one shown in the Output screenshot because it must be globally unique.

7. A new browser should automatically open the deployed web application. Validate the website by choosing the **Store** link on the menu. You should see product items. If products are returned, then the connection to the database was successful.

    ![Screenshot of the Store link.](media/contoso-web-site-store-products.png "Store link")

    >**Troubleshooting**: If the web site fails to start up or show products, go back and double check all your connection string entries and passwords web application settings. If you get a message indicating the Service is unavailable. Give it a moment and refresh your browser.
