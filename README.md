# steps for building #

### 1. First we need to create a local database so we need to run command the following in the Package Manager Console ###
```
EntityFrameworkCore\Add-Migration Initial Create
```

### 2. after successful build of the Migrations, we now run the following in the Package Manager Console to create the actual db ###
```
Update-Database
```

### 3. Open the launchSettings.json file. Under the "iisExpress", then "applicationUrl", replace the value of "locahost" with your machine's IP address ###
### so that it can be accessed from anywhere within a local area network ###

### 4. Create an firewall inbound rule in your machine that allows set in Step 3 ###

### 5. Run the project in Visual Studio with Administrator rights ###

### 6. Access the API through [YOUR_MACHINE_LOCAL_IP_ADDRESS]:[PORT]/api/Users ###