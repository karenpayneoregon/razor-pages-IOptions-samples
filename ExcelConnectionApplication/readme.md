# About

This application that reads an excel file and displays the content in a DataGridView.

- appsettings.json contains an Excel file name used by [ExcelMapper](https://www.nuget.org/packages/ExcelMapper/5.2.590?_src=template) to read the file.
- appsettings.json contains a database connection string not used, here to show that we can do this same as with Excel.
- See Program.cs which sets up the configuration using dependency injection.
- Classes.Configuration has code to read settings from appsettings.json into singleton objects.
- Models.Configuration has the objects that hold the settings.

## Project type

Although this is done in Windows Forms project the code to work with settings in appsettings.json is the same for any .NET project type.

## Depenency Injection


Some developer may think this is overkill for a small application like this, but it is a good practice to use dependency injection. It makes the code more testable and easier to maintain.

:+1:
If all developer projects use what is presented the configuration code can be placed in a class project then create a local NuGet package to use in all projects that require connections.

## Notes

:heavy_check_mark: 
The reason for this project was after seeing a [question](https://stackoverflow.com/questions/79029134/the-microsoft-access-database-engine-could-not-find-the-object-in-c-sharp-on-the) on how to read an Excel file. The question was not answered, so I decided to create this project to show how it can be done.

:x: 
Did not reply to the question as I doubt they would have understood the answer. The question was not clear, and the person asking the question did not seem to have much experience with programming.
