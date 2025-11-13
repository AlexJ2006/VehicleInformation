## Topics to include in assessment

1) Collections (Lists including add, remove, clear, sort and contains.)

HASH SET for the USER ID's as it can't contain duplicates. It also presents the items in no particular order.

Dictionary (KEYS AND VALUES)

2) using System.Linq;

List.Take(n)

for example with cars, you can display the first(n) number of variables in a list.

you can also use IEnumerable to create a short "lazy" list to loop over.

You can also use IEnumerable to select number using the select function.

You can also use OrderBy();

3) assessment information 

4) Command line arguments. 

5) Robustness 

For example, if your program expects a certain number of command line arguments, you should be able to handle situations where the user doesn't provide this or enters them incorrectly.

When converting between types for example, string to integer. You should use a try, catch statement for when the user inputs an incorrect value such as a string rather than an integer. Follow this with "return;"

This ensures that the program won't simply crash as you have handles the erorr/exception.

Alternative to returning the user, you can simply inform them that you are going to continue with a minimum value that your system is happy with.

You should hover over the section of the code that could throw an exception. For example, the ReadAllText or Convert.ToInt32 section. You should then handle the exceptions that could potentially be thrown by the system.

To make things such as error messages a bit "nicer" or stand out more to the user, you can use colours. Using 

Console.ForegroundColor = ConsoleColor.Red;

for example

and then resetting the colour by saying.

Console.ResetColor; 

You could potentially use different colour for different things. For example, you could use yellow, red and green. 

I could potentially use green for the situtations in which the user input has been accepted and a message validating their acceptance has been displayed. For example, "LOGGING YOU IN..." OR 
"CONTINUING AS A GUEST..." etc. 

The main thing with this is to try and keep it professional and consistent throughout the code.

6) Encapsulation and Constructors

OOP, Object Oriented Programming. 

Encapsulation is when we make variables in a class innaccessible.

All data in a class should be private. 

You can then use getter and setter functions to obtain the information from the class that is private.


7) Inheritance and Polymorphism

Continuation of OOP.

8) Serialisation and Binary Files. 





