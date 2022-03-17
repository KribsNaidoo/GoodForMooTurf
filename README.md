# Good-For-Moo Turf

A web application for a pre-grown lawn blocks supplier

## Getting Started

Update connection string in appsettings.json to function on your local machine

```bash
"ConnectionStrings": {
    "TurfConn": "Server=[server];Database=[database];User ID=[user];Password=[password]"
  }
```
Run below through "Package Manager Console"
```
Update-Database
```
Verify the database and tables have been created with relevant data and you're good to go!

## Note
If experiencing issues with number/currency fields regarding decimal points then you will have to adjust "Decimal Symbol" under "Additional Settings..." through Region settings.

Unfortunately I wasn't able to find a solution aside from fixing all currency inputs which wasn't feasible

## Technology & Third Party

- Net Core 3.1
- MVC
- C#
- EF Core(Code First)
- Bootstrap & Bootswatch
- NToastNotify


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
