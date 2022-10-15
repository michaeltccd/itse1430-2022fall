# Contact Manager (ITSE 1430)

## Version 2.0

In this lab you will create a Windows Forms application to manage a list of contacts.

## Skills Needed

- C#
  - Abstract Classes  
  - Generic Types
  - Interfaces
  - Lists
- Windows Forms
  - Child Forms
  - Layouts
  - List Controls
  - Validation

## Story 1 - Set Up Main Window

Set up the main window.

### Description

Create a new Windows Forms (`Windows Forms App`) project to hold your code. The project should be named such that it is clear it is the UI portion of the solution (e.g. `{name}.ContactManager.UI`).

- Ensure the project template is `Windows Forms App`.
- Ensure the target framework iw `net6.0`.
- Open the project file by double clicking it in Solution Explorer. Change `<nullable>enable</nullable>` to `<nullable>disable</nullable>`.

Ensure the main form is reasonably sized, is appropriately named and has the appropriate title. Include your name in the title of the main window.

Add a main menu to the form. The main menu should have the following functionality as in past labs.

- `File \ Exit` that exits the program.
- `Help \ About` that displays an about box with your basic information. The hotkey is `F1`

### Acceptance Criteria

- The application compiles cleanly without warnings or errors.
- The application runs.
- Form title is descriptive.
- The exit functionality works.
- The help functionality works.
- Event handlers have reasonable names

## Story 2 - Define the Contact Type

Define the `Contact` type to represent a contact.

### Description

Create a new `Class Library` project to manage contacts. This project represents the business layer of the application and should be named accordingly. Add a reference to the class library to the main UI project.

*NOTE: Do not reference Windows Forms or `Console` in the business project. It must remain UI agnostic.*

Create a `Contact` type to represent a contact in the system. It should contain the data needed to represent a contact.

- `FirstName`:: [Optional] The first name of the contact.
- `LastName` :: [Required] The last name of the contact.
- `Email` :: [Required] The email address of the contact.
- `Notes` :: [Optional] An optional set of notes.
- `IsFavorite` :: A flag indicating if the contact is a favorite.

The type should validate that the data is valid.

### Validating an Email Address

To help with validating email addresses use the following code. It is wrapped in a function but you can use it however you need.

```csharp
bool IsValidEmail ( string source )
{
   return MailAddress.TryCreate(source, out var address); 
}
```

### Acceptance Criteria

- The application compiles cleanly without warnings or errors.
- The application runs.
- The new type(s) are properly documented.

## Story 3 - Define the Contact Database

Define the database type to store contacts.

### Description

Create an interface `IContactDatabase` to store contacts. This interface needs to have methods similar to the following.

`Add` method to add a new contact to the database. The method should validate the contact is not null, is valid and a contact with the same name does not already exist.
Set an appropriate identifier on the contact so the caller can get back to the added contact later.

`Get` method to get a specific contact. If no contact exists then return nothing.

`GetAll` method to get all the contacts in the database. Use `IEnumerable<Contact>` for the return type.

`Remove` method to remove a contact from the database. It should accept the unique ID of the contact. If the contact does not exist then do nothing.

`Update` method to update an existing contact's information. The method should accept the ID of the contact to update and the new contact information.
The method should validate the contact exists, the new contact is valid and the contact name is unique. Return an error if anything is incorrect.

*Note: Ensure you handle the case of updating a contact and not changing their name. This should not fail.*

Create an implementation of the `IContactDatabase` interface that uses `List<Contact>` to store the contacts. Feel free to add any data needed by the implementation to the `Contact` type.

*NOTE: Only interfaces should start with `I`.*

### Acceptance Criteria

- The new type(s) are properly documented.
- The database class properly enforces the rules.

## Story 4 - Add Support for Adding a Contact

Add support for adding contacts in the UI.

### Description

In the main form add a new menu to support working with contacts. Add an option to add a new contact. Add an appropriate hotkey (e.g. `Insert`). When clicked display a form to collect the contact information.

- The form should be appropriately titled and sized.
- The form should allow for entering the contact information.
- Error provider should be used to validate user input before they attempt to save.
- Email addresses should be in the valid format but do not have to be valid.
- The form should allow for saving or cancelling the request.
- If the user clicks save the form should ensure the contact is valid before closing. Display an errors as appropriate.
- If the user clicks the cancel option then no validation is done and the form closes.
- The form should resize appropriately.

*Note: Allow the user to navigate away from invalid controls. Just do not allow saving of invalid data.*

*Note: Ensure the notes control allows multiple lines.*

### Acceptance Criteria

- Adding a contact is available in menu.
- Menu hotkey works.
- Clicking menu displays appropriate form. Form layout is clean and usable.
- Form can be cancelled without validation.
- Attempting to save with data missing reports the correct errors.
- Clicking save with valid data works.
- Form properly resizes.

## Story 5 - Display the Contacts in the Main Window

The main form will need to track the contacts that have been added. Each time a contact is added the main window should update to show the new contact.

### Description

The main form should have a field for the `IContactDatabase` interface being used. Whenever the main form manipulates a contact it should update the database as needed.

The main form should display a list of contacts in the main window that includes their last name, first name and email address. The display should take up the entire main window.

Contacts should be sorted by last name and then first name.

### Acceptance Criteria

- Adding a new contact adds them to the list being displayed.
- Contacts are sorted by last name and then first name.

## Story 6 - Add Support for Editing Contacts

Add support for editing an existing contact.

### Description

Update the add contact form to support editing a contact as well. When the form is loaded and a contact is provided then show the initial contact information. If the user clicks save then update the existing contact otherwise ignore the changes.

Add a new menu item to the contacts menu to allow editing. Get the currently selected contact, if any, and display the form for editing. If there is no selected contact then do nothing.

Update the contact list to allow double clicking a contact. If a contact is double clicked then treat it like the menu and display the edit form.

### Acceptance Criteria

- Using the menu to edit a selected contact shows the form appropriate populated.
- Clicking save in the form updates the contact information.
- Clicking cancel in the form does not update the contact information.
- Double clicking a contact in the contact list edits the contact.
- Trying to edit a contact when none is selected does nothing.
- Editing a contact updates the contact list appropriately.

## Story 7 - Add Support for Removing Contacts

Add support for deleting a contact.

### Description

Add a menu item to allow deleting a contact. When clicked display a confirmation message with the contact's name. If the user confirms then remove the contact. Otherwise do nothing.

Allow the user to press the `DEL` key to delete a contact as well.

### Acceptance Criteria

- Clicking delete menu item on selected contact displays a confirmation.
- Confirming the delete prompt removes the contact from the list and UI.
- Declining the delete prmopt leaves the user.
- Using `DEL` key triggers deletion prompt.

## Story 8 - Seed Some Contacts

Add some default contacts into the database when the program starts.

### Description

To save some time, when the program runs ensure there are a couple of contacts already in the database.

*Note: Do not use real people or email addresses.*

Ensure the main window shows the initial list of contacts. These contacts can be edited or removed normally.

### Acceptance Criteria

- Main window shows pre-defined contacts when the application starts.

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in Canvas by providing the link to the Github repository.
