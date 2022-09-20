# Character Creator (ITSE 1430)
## Version 2.0

In this lab you will create a Console application to create a character for a [Role Playing Game](https://en.wikipedia.org/wiki/Role-playing_game) (RPG). 

## Skills Needed

- C#
   - Classes
   - Class Members: property, method, field, constructor
   - Inheritance

## Story 1 - Set Up Project

Create a new Console project to hold your code.

### Description

1. Open Visual Studio.
1. Create a new project in a new solution.
    1. Select the `Console App (.NET Core)` project template.    
    1. Set the project name to `<name>.CharacterCreator.ConsoleHost`.
	1. Set the solution name to `Lab2`.
    1. Ensure the location is under your `Labs` folder in your local Git repository.
    1. Create the project.
1. Fix project settings.
   1. TBD
1. Add the appropriate file header.

Like in the previous lab display basic program information on startup.

1. Display the program information at startup including class name, lab and your name.

### Acceptance Criteria

- Solution opens properly in Visual Studio and loads all projects.
- Project is properly named in repository.
- Code compiles cleanly.
- Program information displayed at startup

## Story 2 - Create the Main Menu

Implement a simple menu system for the program.

### Description

Display the main menu of the program at startup and after each menu command selected by the user is finished.

- The menu system may use either letters or digits.
- If using letters then case should not matter.
- If the user enters an invalid option then display an error and prompt again.

### Acceptance Criteria

- Main menu is displayed at program startup.
- Selecting an invalid option displays an error.

## Story 3 - Support Exiting the Program

Add a menu option to quit the program.

### Description

If the user selects the quit command then display a confirmation message to quit.
If the user confirms then exit the program.
If the user does not confirm then return to the main menu.

### Acceptance Criteria

- Option is shown in menu.
- Selecting the quit option displays a confirmation.
- Confirming to quit terminates the program otherwise it does not.

## Story 4 - Create the Character Types

Create types to represent a character in the game.

### Description 

The character types are not tied to a UI so create a separate class library project for the business layer.

Create the new business layer project.

1. Create a new `Class Library (.NET Core)` project in the existing solution. DO NOT select `Class Library (.NET Standard)`.
1. Set the project name to `<name>.CharacterCreator`.
1. After creation set the framework to .NET 6.
1. TBD

This project will be the business layer for the application. It will house any logic that is not tied to a UI. The UI project will rely on this.

1. In the UI project right click and select `Add Reference` to bring up the `References` dialog.
1. Go to the `Projects` category.
1. Check the box next to the business layer project.
1. Click `OK`.

*Note: Do not add any UI elements to this project.*

Rename the auto-generated class to `Character` or delete it and create a new class file. The type will contain the data needed to "define" a character. 

The following data define what a character is.

- Name: (Required) The name of the character.
- Profession: (Required) The profession of the character. The available professions are: `Fighter`, `Hunter`, `Priest`, `Rogue` and `Wizard`. 
- Race: (Required) The race of the character. The available races are: `Dwarf`, `Elf`, `Gnome`, `Half Elf` and `Human`.
- Biography: The optional, biographic details of the character.

Each character has a set of numeric attributes that define the character. The attributes are: `Strength`, `Intelligence`, `Agility`, `Constitution` and `Charisma`. 
For each attribute:

- An integral value is required.
- The value must be between 1 and 100.

Ensure that the class is properly documented and follows the general guidelines outlined in class.

### Acceptance Criteria

- Code compiles.
- Types are defined in appropriate project.
- Doctags are used to properly document types.

## Story 5 - Support Adding a New Character 

Allow the user to create a new character. 

### Description

*Note: For this lab there will be only one character.*

Add support for creating a new character in the menu.
When the option is selected prompt the user for the character information.
After entering a character return the user to the main menu.

Prompt the user for each piece of data that defines a character (e.g. name, profession, etc).
For each data.

- Store all the data in the `Character` class created earlier.
- If it is required then enforce the entry.
- If the value is limited (e.g. profession) then ensure the user enters only the valid options.
- For the attributes prompt for each input with validation.
- For any invalid inputs display an error and keep prompting until the user enters the information properly.

After all the information is entered save the character object for later.
There is only support for one character at this time.

### Acceptance Criteria

- When selected from the menu the user is prompted for the data.
- User input is validated.
- Required fields are entered.
- Numeric field ranges are enforced.

## Story 6 - Support Viewing Character

Allow the user to view a character.

### Description

Add the option to view the character to the menu.
If no character has been entered yet display a friendly message about adding the character.
If a character is available then display the character information in a print-friendly way.

Return to the main menu when done.

### Acceptance Criteria

- Menu option is available.
- If no character is entered then a friendly message is shown.
- If a characdter is available then the character information is shown.

## Story 7 - Support Editing a Character

Allow the user to edit an existing character.

### Description

Add the option to edit an existing character to the menu.
If no character is defined et then add a new character instead.
If a character is defined then allow the user the option to edit the existing information.

For each data field:

- Display the existing value.
- Allow the user the option to change the value or leave it alone.
- Any changes must follow the same rules as adding a new character.

After any edits have been completed display the new character information.
Return to the main menu.

### Acceptance Criteria

- Menu option is available.
- If no character is available then add a new character.
- For each data field show the existing value and allow the user to change it if desired.
- Ensure data is validated.
- Display the updated character information when done.

## Story 8 - Support Deleting a Character

Allow the user to delete an existing character.

### Description

Add the option to delete a character.
If no character is available then display an error message.
If a character is available then display a confirmation message.
If the user confirms then remove the character otherwise do nothing.

Return to the main menu.

### Acceptance Criteria

- Menu option is available.
- If no character is available then an error is shown.
- Confirmation message is shown

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in MyTCC by providing the link to the Github repository.
