# Challenge 1: Create Key Vault secrets and add to App Configuration

**Duration**: 15 minutes

In this challenge, you retrieve various keys and connection string from resources in the **hands-on-lab-SUFFIX** resource group and use them to create secrets in Key Vault. You will first copy connection string and keys into a text editor, such as Notepad.exe, for easier reference when creating secrets in Key Vault. You finish the challenge by adding references to the Key Vault into the App Configuration resource.

- [Challenge 1: Create Key Vault secrets and add to App Configuration](#challenge-1-create-key-vault-secrets-and-add-to-app-configuration)
  - [Task 1: Retrieve database connection string](#task-1-retrieve-database-connection-string)
  - [Task 2: Retrieve Storage Account access key](#task-2-retrieve-storage-account-access-key)
  - [Task 3: Retrieve Service Bus Queue connection string](#task-3-retrieve-service-bus-queue-connection-string)
  - [Task 4: Create secrets in Azure Key Vault](#task-4-create-secrets-in-azure-key-vault)
  - [Task 5: Centralize secrets for multiple projects using an App Configuration store](#task-5-centralize-secrets-for-multiple-projects-using-an-app-configuration-store)

## Task 1: Retrieve database connection string

In this task, you retrieve the connection string for the ContosoSports DB SQL Database, set the password, and save it to a text editor, such as Notepad.exe.

1. In the [Azure portal](https://portal.azure.com), select **Resource groups** from the Azure services list.

   ![Resource groups is highlighted in the Azure services list.](media/azure-services-resource-groups.png "Azure services")

2. Select the **hands-on-lab-SUFFIX** resource group from the list.

   ![The "hands-on-lab-SUFFIX" resource group is highlighted.](./media/resource-groups.png "Resource groups list")

3. In the list of resources within your resource group, select the **ContosoSportsDB** SQL database resource.

   ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and ContosoSportsDB is highlighted.](./media/resource-group-resources-sql-db.png "ContosoSportsDB in resource group list")

4. On the **SQL Database** blade, select the **Show database connection strings** link within the Essentials area.

    ![On the SQL Database blade, in the left pane, Overview is selected. In the right pane, under Essentials, the Connection strings (Show database connection strings) link is circled.](media/sql-db-connection-strings-link.png "SQL Database blade")

5. On the **Connection strings** blade, select the **Copy to clipboard** icon in the bottom right-hand corner of the `ADO.NET` connection string box.

    ![In the Database connection strings blade, the ADO.NET connection string is circled.](media/sql-db-connection-string-ado-net.png "Database connection strings blade")

6. Paste the copied connection string into a text editor, such as **Notepad.exe** and then replace the `{your_password}` token with `Password.1!!`.

7. In the tasks below, you will be copying additional values into the text editor, so you can have easy access to these values for creating secrets in Key Vault later in this hand-on lab. Leave the text editor open.

## Task 2: Retrieve Storage Account access key

In this task, you retrieve the access key for your Azure Storage account and save it to a text editor, such as Notepad.exe.

1. Return to the **hands-on-lab-SUFFIX** resource group and select the **contoso** Storage account resource from the list.

    ![The storage account resource is highlighted in the hands-on-lab-SUFFIX resource group.](media/resource-group-resources-storage-account.png "Storage account resource")

2. On the **Storage account** blade, select the **Access keys** in the left-hand navigation menu, and on the **Access keys** blade, from the top toolbar, select the **Show keys** button (text will change to **Hide keys**) and then copy the **key1** **Connection string** value by selecting the **Copy to clipboard** icon.

    ![The Access keys blade is displayed, with Access keys highlighted in the left-hand menu and the copy to clipboard icon highlighted next to the key1 Connection string value.](media/storage-account-access-keys.png "Storage account access keys")

3. Paste the copied value into your open text editor for later reference, as you did with the database connection string above.

## Task 3: Retrieve Service Bus Queue connection string

In this task, you retrieve the primary connection string for the `receiptgenerator` Service Bus queue and save it to a text editor, such as Notepad.exe.

1. Return to the **hands-on-lab-SUFFIX** resource group and select the **Service Bus Namespace** resource from the list.

    ![The Service Bus Namespace resource is highlighted in the hands-on-lab-SUFFIX resource group.](media/resource-group-resources-service-bus-namespace.png "Service Bus Namespace resource")

2. On the Service Bus Namespace blade, select **Queues** from the left-hand navigation menu, under the Entities header, and then select the `receiptgenerator` queue.

    ![On the Queues blade, the Queues item is highlighted in the left-hand menu and the receiptgenerator queue is highlighted.](media/service-bus-queues-receipt-generator.png "Queues")

3. On the `receiptgenerator` Service Bus Queue blade, select **Shared access policies** in the left-hand navigation menu and then select the **Publisher** policy.

    ![On the Shared access policies blade, Shared access policies in highlighted in the left-hand navigation menu and the Publisher policy is highlighted in the list of policies.](media/service-bus-queues-shared-access-policies.png "Shared access policies")

    >**Note**: The _Publisher_ and _Listener_ shared access policies for the Azure Service Bus Queue were deployed as part of the ARM Template that was used to setup the lab environment. Notice the **Publisher** policy only has permissions to _Send_ messages to the queue.
    >
    > By default, no policies are created. Additionally, it is best practice to use least privilege security to create separate shared access policies for publishers sending messages and listeners receiving messages from the queue.

4. On the **SAS Policy: Publisher** dialog, copy the **Primary Connection String** by selecting the **Copy to clipboard** icon.

    ![The copy to clipboard icon is highlighted next to the primary connection string on the SAS Policy: Publisher dialog.](media/service-bus-queues-sas-policy-publisher.png "SAS Policy: Publisher")

5. Paste the copied value into your open text editor for later reference, as you did with the database connection string above.

## Task 4: Create secrets in Azure Key Vault

In this task, you create secrets in Key Vault for each of the connection strings and keys you retrieved in the tasks above.

1. Return to the **hands-on-lab-SUFFIX** resource group and select the **Key vault** resource from the list.

    ![The Key Vault resource is highlighted in the hands-on-lab-SUFFIX resource group.](media/resource-group-resources-key-vault.png "Key Vault resource")

2. Select **Secrets** from the left-hand navigation menu and then select **Generate/Import**.

    ![The Secrets item in highlighted in the left-hand menu and Generate/Import is highlighted on the Secrets blade.](media/key-vault-secrets.png "Key Vault Secrets")

3. You will create three secrets in Key Vault, using the values you copied into your text editor. The secrets will be named according to the table below:

    | Name | Value |
    |------|-------|
    | AzureQueueConnectionString | Use the primary connection string you recorded for the Service Bus `receiptgenerator` queue |
    | ContosoSportsLeague | Use the database connection string |
    | contososportsstorage | Use the storage account connection string you recorded for the storage account |

4. On the **Create a secret** blade, enter the following:

    - **Name**: Enter `AzureQueueConnectionString`.
    - **Value**: Paste the Service Bus queue primary connection string value into this box.

    > The remaining settings will retain their default values.

    ![The Create a secret form is displayed with the Name and Value fields highlighted.](media/key-vault-create-a-secret.png "Create a secret")

5. Select **Create**.

6. Select **Generate/Import** again and repeat steps 4 and 5 for the remaining two secrets specified in the table above, replacing the name and value settings with appropriate values.

7. You should end up with three secrets in Key Vault.

    ![The list of newly created secrets in Key Vault is displayed.](media/key-vault-secrets-list.png "Key Vault secrets")

## Task 5: Centralize secrets for multiple projects using an App Configuration store

The Contoso Sports solution contains multiple projects, each of which access the same Azure resources. In this task, you centralize the configuration of the solution applications via the deployed Azure **App Configuration** resource.

1. Return to the **hands-on-lab-SUFFIX** resource group and select the **App Configuration** resource from the list.

    ![The App Configuration resource is highlighted in the hands-on-lab-SUFFIX resource group.](media/resource-group-resources-app-configuration.png "App Configuration resource")

2. Select **Configuration explorer** from the left-hand navigation menu and then select **Create** and **Key Vault reference**.

    ![Configuration explorer is highlighted in the left-hand menu and Create --> Key Vault reference is highlighted on the Configuration explorer blade.](media/app-configuration-explorer.png "Configuration explorer")

3. You will add a Key Vault reference for each of the three secrets you created in the previous task. The configuration values will be named according to the table below:

    | Key | Secret |
    |-----|--------|
    | ConnectionStrings:ReceiptQueue | Select **AzureQueueConnectionString** |
    | ConnectionStrings:ReceiptStorage | Select **contososportsstorage** |
    | ConnectionStrings:SportsDB | Select **ContosoSportsLeague** |

4. On the **Create** dialog, enter the following:

    - **Key**: Enter `ConnectionStrings:ReceiptQueue`.
    - **Subscription**: Select the subscription you are using for this hands-on lab.
    - **Resource group**: Select the **hands-on-lab-SUFFIX** resource group.
    - **Key Vault**: Choose the **key-vault-UNIQUE-ID** Key Vault resource.
    - **Secret**: Select the secret named `AzureQueueConnectionString`.

    ![The Create new Key vault reference form is displayed populated with the ConnectionStrings:ReceiptQueue values.](media/app-configuration-create-key-vault-reference.png "The create new key vault reference form")

5. Select **Apply** on the Create dialog.

6. Select **Create --> Key Vault reference** again and repeat steps 4 and 5 for the remaining two keys specified in the table above, populating the **Key** and **Secret** fields with appropriate values.

7. From the left menu, select **Access keys** within the Settings section, copy the **Primary key Connection string** value using the clipboard icon. Save this value for a future task.

    ![The App Configuration Access keys screen is shown with Access keys selected from the left menu and the clipboard icon highlighted next to the Primary key connection string value.](media/app_config_copy_connection_string.png "App Configuration Access keys")
