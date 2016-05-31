## Notice

### How to run migrate in Bgts.Gps.EntityFramework?

* Please set Bgts.Gps.WebApp to start project, it is important.
* Please select your default project to Bcs.Vahs.EntityFramework in your package console.
* Please run this command in your package console : Update-Database -Verbose 
  You needn't give a connection string as shown below:

 > Update-Database -ConnectionString "Server=CARL\MSSQL2012; Database=BcsVhas; Trusted_Connection=Yes;" -ConnectionProviderName "System.Data.SqlClient" -Verbose -ProjectName "Bgts.Gps.EntityFramework"

* If you come accross some strange things, please compile Bgts.Gps.WebApp
