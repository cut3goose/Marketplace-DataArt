# Online Shop #

Application clone of popular online stores.
DataArt IT Leaders project for educational purposes. 

### How do I get set up? ###
1. Clone repo via SSH/HTTPS
2. Apply migrations using Project Manager command line in order:
	- Update-Database -Context UserDbContext
	- Update-Database -Context ProductDbContext
	- Update-Database -Context OrderDbContext
	- Update-Database -Context CartDbContext

TODO: Apply migrations automatically on startup