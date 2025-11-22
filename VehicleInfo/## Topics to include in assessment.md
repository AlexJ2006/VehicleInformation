## Topics to include in assessment

**ITEMS DISPLAYED LIKE THIS ARE COMPLETE**

1) Collections (Lists including add, remove, clear, sort and contains.)

**ADD TO LIST** -- STORE LIST
**REMOVE FROM LIST** -- STORE LIST
**CLEAR LIST** -- STORE LIST
**SORT LIST, alphabetical?** --STORE LIST
**CONTAINS** -- STORE LIST

**HASH SET** --USER ID's
**N/A as using the hashset means that the entire item has to be unique, not just the userID**

HASH SET for the USER ID's as it can't contain duplicates. It also presents the items in no particular order.

Dictionary (KEYS AND VALUES)

2) using System.Linq;

**List.Take(n)** -STORE LIST, asking the user how many items they wish to view.

Could use an IEnumerable list to create a "save" for the recently viewed cars by the user. Making the list clear once the user has used it. somehow????

you can also use IEnumerable to create a short "lazy" list to loop over.

You can also use IEnumerable to select number using the select function.

You can also use OrderBy();

COULD CREATE A SORT BY FUNCTION TO PROVIDE THE USER WITH MORE SPECIFIC RESULTS.

COULD ALSO ASK THE USER HOW MANY ITEMS THEY WANT TO DISPLAY.

3) **N/A** --assessment information 

4) **Command line arguments** --staff and admin commands to access alternative menus

5) Robustness

For example, if your program expects a certain number of command line arguments, you should be able to handle situations where the user doesn't provide this or enters them incorrectly.

When converting between types for example, string to integer. You should use a try, catch statement for when the user inputs an incorrect value such as a string rather than an integer. Follow this with "return;"

This ensures that the program won't simply crash as you have handles the erorr/exception.

Alternative to returning the user, you can simply inform them that you are going to continue with a minimum value that your system is happy with.

You should hover over the section of the code that could throw an exception. For example, the ReadAllText or Convert.ToInt32 section. You should then handle the exceptions that could potentially be thrown by the system.

To make things such as error messages a bit "nicer" or stand out more to the user, you can use colours. Using 
**Console.ForegroundColor = Console.Red, yellow and green**
**Console.ResetColor;**
**Using different colours for different messages of varying severity**
**GREEN when the user has successfully logged in etc**
**Kept consistent throughought the code using functions**

**MORE TRY/CATCH EXPECTION HANDLING FOR JSON AND THROUGHOUT THE PROGRAM**

6) Encapsulation and Constructors

OOP, Object Oriented Programming. 

Encapsulation is when we make variables in a class innaccessible.

All data in a class should be private. 

You can then use getter and setter functions to obtain the information from the class that is private.

7) Inheritance and Polymorphism

Continuation of OOP.

8) Serialisation and Binary Files. 

**JSON Serialization and DeSerialization** --Various vehicle JSON files have been created (one each for cars, motorbikes and vans). These are edited by both the staff members and the customers. The customers rent vehicles which removes them from the JSON file. The staff members add vehicles to the JSON file so that they can be seen/rented by the customer.

**Binary files** --Not included yet, need to understand the benefits of these over using JSON

Usually recommends using a binary file instead of JSON due to the size of the file and security. Security is very important. I can change this. HOPEFULLY EASILY????

Will definitely need to check the lecture again.



Can implement OOP (inheritance) with the vehicle classes, re-watch the lecture and adapt it to my needs.
JungHun worried about time - Bring work in each week to ask him questions.