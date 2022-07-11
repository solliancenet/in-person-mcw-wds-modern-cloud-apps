# Challenge 8: Identity and Security (Optional)

**Duration**: 75 Minutes

The Contoso call center admin application will only be accessible by users of the Contoso Active Directory environment. You have been asked to create a new Azure AD Tenant and secure the application so only users from the tenant can log on.

- [Challenge 8: Identity and Security (Optional)](#challenge-8-identity-and-security-optional)
  - [Task 1: Enable Azure AD Premium Trial](#task-1-enable-azure-ad-premium-trial)
  - [Task 2: Create a new Contoso user](#task-2-create-a-new-contoso-user)
  - [Task 3: Configure access control for the call center administration Web Application](#task-3-configure-access-control-for-the-call-center-administration-web-application)
  - [Task 4: Apply custom branding for the Azure Active Directory logon page](#task-4-apply-custom-branding-for-the-azure-active-directory-logon-page)
  - [Task 5: Verify the branding has been successfully applied to the Azure Active Directory logon page](#task-5-verify-the-branding-has-been-successfully-applied-to-the-azure-active-directory-logon-page)

## Task 1: Enable Azure AD Premium Trial

>**Note**: This task is **optional**, and it is valid only if you are a global administrator on the Azure AD tenant associated with your subscription.

1. Navigate to the home page of the [Azure portal](http://portal.azure.com/) and select **Azure Active Directory**. under Azure Services.

    > **Note**: If you do not see Azure Active Directory, select More Services, and then select it there.

    ![The Azure Active Directory menu option.](media/azure-home-active-directory.png "Azure Portal")

2. On the **Azure Active Directory** blade, locate and select the **Company branding** option in the left-hand navigation menu.

    ![In the Azure Active Directory blade, Company branding is selected.](media/image124.png "Azure Active Directory blade")

3. In the right pane, select the **Get Free Premium Trial** button.

    ![On the left side of the Azure Active Directory blade, Company branding is selected. On the right side, the Get a free Premium trial link is selected.](media/azure-active-directory-free-premium-trial.png "Azure Active Directory blade")

    If you already have a Premium Azure Active Directory, skip to Task 2.

4. On the **Activate** blade, expand **Free trial** under **Azure AD Premium P2**, then select **Activate**.

    ![The Free trial link is selected on the Activate blade in the Azure AD Premium P2 box, and the Activate button is highlighted.](media/azure-active-directory-free-trial-activate.png "Activate blade")

5. Close the **Azure Active Directory** blades.

## Task 2: Create a new Contoso user

> **Note**: This task is **optional**, and it is valid only if you are a global administrator on the Azure AD tenant associated with your subscription.

1. On the **Azure Active Directory** blade, select **Custom domain names**.

    ![Custom Domain Names menu option screenshot.](media/image128.png "Custom Domain names")

2. Copy the **Domain Name** for your Azure AD Tenant. It will be in the format: *[your tenant].onmicrosoft.com*.
    This will be used for creating the new user's Username.

    ![Under Name, the Domain Name is selected.](media/image129.png "Domain name")

3. On the **Azure Active Directory** blade, select **Users**.

    ![Under Manage, All users is selected.](media/image130.png "Azure Active Directory blade")

4. On the **User** blade, enter the following:

    **Identity**:

    - **User name**: Enter a username and select the domain name for your Azure AD Tenant. For example: *tbaker@[your tenant].onmicrosoft.com*.
    - **Name**: Enter the name of the user.
    - **Password**: Select **Auto-generate** and then check **Show password**. Copy this value into a text editor for later user.

    ![On the User blade, the two previously defined fields (Name and User name) are circled.](media/azure-active-directory-new-user.png "User blade")

5. Select **Create**.

## Task 3: Configure access control for the call center administration Web Application

> **Note**: This task is **optional**, and it is valid only if you have the right to create applications in your Azure AD Tenant.

1. Return to the **hands-on-lab-SUFFIX** resource group and select the **Call Center Administration web app** App Service resource.

   ![The list of resources in the hands-on-lab-SUFFIX resource group are displayed, and call center admin web app resource is highlighted.](./media/resource-group-resources-app-service-admin.png "Call center admin web app in resource group list")

2. On the **App Service** blade, select the **Authentication** from the left-hand navigation menu and then select **Add Identity Provider**.

    ![On the App Service blade, Authentication is selected in the left-hand menu and the Add identity provider button is highlighted.](media/app-service-authentication.png "App Service blade")

3. On the **Add an identity provider** dialog, enter the following:

    - **Identity provider**: Select **Microsoft**.
    - **App registration type**: Choose **Create new app registration**.
    - **Name**: Accept the default value entered into this box.
    - **Supported account types**: Choose **Current tenant - Single tenant**.
    - **Authentication**: Choose **Require authentication**.
    - **Unauthenticated requests**: Choose **HTTP 302 Found redirect: recommended for web sites**.
    - **Token store**: Check this box.

    ![The values specified above are entered into the basics tab of the add an identity provider dialog.](media/add-identity-provider-basics.png "Add an identity provider")

4. Select **Add**.

5. Launch a new **In-Private or Incognito mode** browser window and navigate to the **Call Center Administration** website. You can find the URL in the Essentials area of the web app's blade in the Azure portal.

6. The browser will redirect to the non-branded Access Control logon URL. You can log on with your Microsoft account or the **Contoso test user** you created earlier.

    ![Microsoft login prompt.](media/image144.png "Microsoft login prompt")

7. On the **Permissions requested** page, select **Accept**.

    ![The permissions requested page is displayed](media/permissions-requested.png "Permissions requested")

8. After you log on and **accept the consent**, your browser will be redirected to the Contoso Sports League Admin webpage.

    ![The Contoso Sports League Admin webpage displays with one Completed Order.](media/contoso-sports-admin-auth.png "Contoso Sports League Admin webpage")

## Task 4: Apply custom branding for the Azure Active Directory logon page

> **Note**: this task is **optional**, and it is valid only if you are a global administrator on the Azure AD tenant associated with your subscription, and you completed the Enabling Azure AD Premium challenge.

1. Navigate to the home page of the [Azure portal](http://portal.azure.com/) and select **Azure Active Directory**. under Azure Services.

    > **Note**: If you do not see Azure Active Directory, select More Services, and then select it there.

    ![The Azure Active Directory menu option.](media/azure-home-active-directory.png "Azure Portal")

2. On the **Azure Active Directory** blade, locate and select the **Company branding** option in the left-hand navigation menu.

    ![In the Azure Active Directory blade, Company branding is selected.](media/image124.png "Azure Active Directory blade")

3. Select the **Configure...** information box.

    ![The Configure company branding link is selected.](media/image149.png "Configure company branding link")

4. On the **Configure company branding** blade, select the `default_signin_illustration.jpg` image file from `C:\MCW` for the **Sign-in page image**.

    ![The Configure company branding blade displays the default sign in picture of the Contoso sports league text, and a person on a bicycle. Below that, the Select a file field and browse icon is selected.](media/image150.png "Configure company branding blade")

5. Select the `logo-60-280.png` image file from the supplementary files for the **Banner image**.

    ![The Contoso sports league banner text displays.](media/image151.png "Contoso sports league banner")

6. Select **Save**.

    ![The Save button is circled on the Configure company branding blade.](media/image152.png "Configure company branding blade")

## Task 5: Verify the branding has been successfully applied to the Azure Active Directory logon page

1. Close any previously authenticated browser sessions to the call center administration website, reopen using InPrivate or Incognito mode, and navigate to the **call center administration** website.

2. The browser will redirect to the branded access control logon URL.

    ![The Call center administration Sign in webpage displays in an InPrivate / Incognito browser.](media/image153.png "Call center administration website")

3. After you log on, your browser will be redirected to the Contoso Sports League Admin webpage.

    ![The Contoso Sports League Admin webpage displays with one Completed Order.](media/contoso-sports-admin-auth.png "Contoso Sports League Admin webpage")

    >**Note**: If you run the app using localhost, ensure connection strings within all the appsettings.json files in the solution have the placeholders removed with actual values. Search on appsettings.json in the Visual Studio Solution Explorer to come up with the list.
