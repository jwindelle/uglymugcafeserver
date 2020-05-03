# steps for building #

## 1. run command in Package Manager Console: ##
```
EntityFrameworkCore\Add-Migration Initial Create
```

## 2. after successful build of first script, run this as well in the Package Manager Console: ##
```
Update-Database
```

## 3. run the server ##

## 4. access the API through localhost:[PORT]/api/Users ##