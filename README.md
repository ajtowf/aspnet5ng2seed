# Video tutorial

Setting up seed project: https://youtu.be/Zkesm9CUP_o

Consume data from aspnet5 mvc6 controller: https://youtu.be/Rq63N61C3G4

Upgrade angular2 alpha 47 to 52: https://youtu.be/cbozcSC0L4A

## Future
 - Use EntityFramework7
 - Use Aspnet Identity
 - Implement cookie based authentication

# Build

 1. Make sure you have ASP.NET 5 RC1 installed.
 2. Open and build the project.

# Troubleshoot

Sometimes VS failes to restore the npm deps, restore them from the cmd in that case.

 1. Open a cmd prompt
 2. Navigate to src\aspnet5ng2seed\
 3. run "npm install"
 4. run "dnx ef database update"
 5. Make sure the "node_modules" folder contains all the libs.

# Upgrade dnvm and use 1.0.0-rc1-final

 1. dnvm update-self
 2. dnvm upgrade
 3. dnvm use 1.0.0-rc1-final -r clr -arch x86 -p
