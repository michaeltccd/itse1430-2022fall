# Computer Builder (ITSE 1430)

## Version 1.0

You work for the Zell PC manufacturer. In this lab you will build a console program to order a PC from the company.

[Skills Needed](#skills-needed)\
[Story 1](#story-1)\
[Story 2](#story-2)\
[Story 3](#story-3)\
[Story 4](#story-4)\
[Story 5](#story-5)\
[Story 6](#story-6)\
[Story 7](#story-7)\
[Story 8](#story-8)\
[General Guidelines](#general-guidelines)\
[Requirements](#requirements)

## Skills Needed

- C#
  - Control Flow Statements
  - Expressions
  - Functions
  - Types
  - Variables and Scope
- Console Input/Output

*NOTE: For the first lab more detailed instructions will be given in some cases compared to later labs.*

## Story 1 - Set Up Project

Create a new Console project to hold your code.

### Description

1. Open Visual Studio.
1. Create a new project by using the `Create a new project` option in the `Start Window`.
   1. Under the languages filter select `C#`. Then search for the template `Console App`.
   1. Select `Console App`. Ensure that the language is shown as `C#` and it includes the tags `C#`, `Linux` and `Windows`. Click `Next`.
   1. Configure project
      1. For the project name use `{Name}.PcBuilder.ConsoleHost`.
      1. Set the solution nanme to `Lab1`.
      1. Ensure the project location is set to the `Labs` folder of your Github repo that you have previously cloned.
      1. Click `Next`.
   1. Set additional information.
      1. Ensure the target framework is set to `.NET 6.0`.
      1. Uncheck the `Do not use top-level statements` option if it is checked.
      1. Click `Create` to create the project.
   1. Click the project in `Solution Explorer` to open it.
      1. Find the line `<nullable>?</nullable>` and set the value to `disable`.
1. Commit the solution to Github and ensure it shows up online in the browser under the `Labs` folder.

### Acceptance Criteria

- Solution opens properly in Visual Studio and loads all projects.
- Project is properly named in repository.
- Code compiles cleanly.

## Story 2 - Display Program Information

Display program information when the program runs.

### Description

Display the following information to the user when the program starts.

- Name
- Class (`ITSE 1430`)
- Date

NOTE: This only needs to be displayed when the program starts. If it makes it easier you can display it as part of the main menu added later but this is not required.

### Acceptance Criteria

- Program information is shown when application starts.

## Story 3 - Set Up Main Menu

Implement a menu for the program.

### Description

Display a simple menu system for the user to select options from. The menu can be shown below the program information.

The menu system can use either numbers or letters. If using letters then it should be case insensitive.

The menu should show the following options.

- Quit

NOTE: The `Quit` option should always be last in the menu.

If the user selects an invalid option then display an error and show the menu again.

If the user selects the `Quit` option then display a confirmation message. If the user confirms they want to quit then exit the program otherwise return to the main menu.

Above the menu always show the current cart total (it defaults to $0). Ensure it is properly formatted as money.

Unless otherwise stated, display the main menu after the user selects an option and the program executes the request.

NOTE: Collecting user input is going to be needed in several places so use functions to make it easier to reuse functionality such as getting user input, validating menu ranges and converting string values to other values (e.g. numerics).

### Acceptance Criteria

- Menu is shown.
- If incorrect option is selected then display an error.
- If user selects `Quit` then they are shown a confirmation message.
- If user confirms quit then program terminates.
- If user does not confirm then returns to main menu.
- Cart price is shown above menu and is properly formatted.

## Story 4 - Start New Order

Implement support for starting a new order.

### Description

Allow the user to start a new order. Add the option to the main menu.

When selected walk the user through the process of ordering a new computer.
The steps in ordering a new computer are as follows:

- Reset the cart price to 0.
- Prompt the user for the processor to use

For now a computer will consist of the components mentioned below. For each component:

- Display the available options including the price.
- If the user selects a valid option then move to the next component otherwise display a message and have them try again.
- As the user selects components update the order price so they know how much it will be.

After the user has selected a value for all the components display the order information to the user, a message that the order has been added and return to the main menu.

The main menu should show the price of the order.

*Note: You will need price in several places so create a function for it. Calculate the price on demand rather than trying to keep a running total.*

#### Processor

The processor should be selected first. The cost includes the OEM components such as case, power supply, etc.

| Processor | Price |
| - | - |
| AMD Ryzen 9 5900X | $1410 |
| AMD Ryzen 7 5700X | $1270 |
| AMD Ryzen 5 5600X | $1200 |
| Intel i9-12900K | $1590 |
| Intel i7-12700K | $1400 |
| Intel i5-12600K | $1280 |

#### Memory

The memory should be selected next.

| Memory | Price |
| - | - |
| 8 GB | $30 |
| 16 GB | $40 |
| 32 GB | $90 |
| 64 GB | $410 |
| 128 GB | $600 |

### Acceptance Criteria

- User is prompted for each component.
- Input is properly validated.
- Order price is properly calculated.
- User returns to main menu and price is properly shown.

## Story 5 - View Order

Display the order information.

### Description

Add a menu option to view the order.

When selected show each of the components that were selected along with their price.
Show the total order price.

```shell
Processor: i7-11700K  $1320
Memory:    32 GB      $200
--------------------------
Total:                $520
```

*Note: The output is an example. Provided the information is shown, formatted and reasonably pretty then it is sufficient.*

If there is no order yet then show a message stating there is no order. The price should be $0.

Update the new order commmand to show the order information as part of the message about the order being added.

Return to the main menu.

### Acceptance Criteria

- Option shown in main menu.
- If no order then a message is shown.
- Order is displayed including item, price and total price.
- New order option shows order information.
- User is returned to main menu.

## Story 6 - Clear Order

Allow user to clear the order.

### Description

Add a menu option to clear the order.

If selected then prompt the user for confirmation. If the user confirms then clear the order information and reset the price to 0.
IF the user does not confirm then do nothing.

Return to the main menu.

*Note: To clear an error the easiest approach is to simply "reset" the first component back to its default value.*

### Acceptance Criteria

- Option show in main menu.
- User is prmopted to confirm request.
- If confirmed then order information is removed.
- If not confirmed then nothing happens.
- User is returned to main menu.

## Story 7 - Modify Order

Allow user to modify an existing order.

### Description

Add a menu option to modify the order.

If there is not an order yet then display an error and do nothing.

Display a list of components to modify (e.g. processor, memory, etc). Display the currently selected item for each component.
Display an option to return to the main menu.

If the user selects the component then prompt them for the new value just like they were prompted in the new order process.
Provide an additional option to change nothing.

If the user makes a change then ensure the updated value is used in the order and that the price is correctly updated.
If no changes were made then do nothing.

After a user modifies a component return to the modify menu so they can change another component.
Continue this process until the user decides to return to the main menu.

### Acceptance Criteria

- User can modify an order, if they have one.
- User can select any of the components and change it.
- Price and order information is properly updated with changes.
- User can change multiple components.

## Story 8 - Add More Components

Allow the user to select more components.

### Description

Expand the components that can be ordered.

- Add the components to the New Order command.
- Add the components to the View Order display.
- Add the components to the Modify Order command.
- Add the components to the price calculation.

#### Primary Storage

Allow the user to select their primary storage.

| Storage | Price |
| - | - |
| SSD 256 GB | $90 |
| SSD 512 GB | $100 |
| SSD 1 TB | $125 |
| SSD 2 TB | $230 |

#### Secondary Storage

Allow the user to select their secondary storage.

| Storage | Price |
| - | - |
| None | $0 |
| HDD 1 TB | $40 |
| HDD 2 TB | $50 |
| HDD 4 TB | $70 |
| SSD 512 GB | $100 |
| SSD 1 TB | $125 |
| SSD 2 TB | $230 |

#### Graphics Card

Allow the user to select their graphics card.

| Graphics Card | Price |
| - | - |
| None | $0 |
| GeForce RTX 3070 | $580 |
| GeForce RTX 2070 | $400 |
| Radeon RX 6600 | $300 |
| Radeon RX 5600 | $325 |

#### Operating System

Allow the user to select the operating system.

| Operating System | Price |
| - | - |
| Windows 11 Home | $140 |
| Windows 11 Pro | $160 |
| Windows 10 Home | $150 |
| Windows 10 Pro | $170 |
| Linux (Fedora) | $20 |
| Linux (Red Hat) | $60 |

### Acceptance Criteria

- Additional components are added to new, view, modify order and price.

## General Guidelines

### General

- It is strongly recommended that you complete the stories in order. Some stories rely on the work done in previous stories.
- Commit your changes to Github frequently to ensure you don't lose any work. You do not need to wait for a story to be completed.
- After you implement a story ensure it meets all the acceptance criteria. In some cases a later story may change the behavior of an earlier story.

### Naming Conventions

- USE descriptive nouns for variable and parameter identifiers (e.g. `payRate`, `name`, `index`).
- USE descriptive verbs for function identifiers (e.g. `getName`, `showProgress`).
- DO NOT use single letters or abbreviations in identifiers (e.g. `x`, `descriptValue`).
- DO ensure spelling for identifiers.
- DO use camel casing for variables, parameters and fields.
- DO use Pascal casing for types and public members.

### Coding Style

- DO put a file header at the top of each file you create. The file header should contain the class, date and your name.
- DO use consistent indentation. In general each block indents one time (3 or 4 spaces). Curly braces should be aligned.

  ```csharp
  //NO
  while (someCondition) 
     { 
    Foo();
      };
   
  //YES
  while (someCondition)
  {
     Foo();
  };
  ```

- DO use a single blank line between blocks of code (e.g. functions, control flow statements, etc).

  ```csharp
  //NO
  void DoWork ()
  {
  }
  void DoMoreWork()
  {
  }
  
  //YES
  void DoWork ()
  {
  }
  
  void DoWork ()
  {
  }
  ```

- DO consider declaring variables just before or as part of their first usage instead of up front.

  ```csharp
  //NO
  int hours;
  double payRate, totalPay;
  ...
  totalPay = payRate * hours;
  
  //YES
  double totalPay = payRate * hours;
  ```

- DO put comments above code that is not clear.
- DO NOT put comments in code that repeats what the code does.

  ```csharp
  //NO
  //Loop through stuff
  for (...)
  //YES
  for (...)
  ```

## Requirements

- DO ensure code compiles cleanly without warnings or errors (unless otherwise specified).
- DO ensure all acceptance criteria are met.
- DO Ensure each file has a file header indicating the course, your name and date.
- DO ensure you are using the provided `.gitignore` file in your repository.
- DO ensure the entire solution directory is uploaded to Github (except those files excluded by `.gitignore`).
- DO submit your lab in Canvas by providing the link to the Github repository.
