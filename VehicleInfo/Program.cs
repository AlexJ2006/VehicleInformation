using System.ComponentModel;
using System.Reflection;
using VehicleInfo;

//Showing the user the version as per the "Version" tag within the VehicleInfo.csproj file.
var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown";

//Loading the car data for use within the file.
VehicleManagement.LoadCars();
//Loading the motorbike data
VehicleManagement.LoadMotorbikes();
//Loading the van data
VehicleManagement.LoadVans();

//======================================================== MAIN PROGRAM BEGINS ==========================================================================
//Showing the user the current version of the program.
Utilities.getAndShowVersion();

//Welcoming the user to the program.
Utilities.welcomeUser();


bool keepRunning = true;

while (keepRunning)
{
    UserType.staffArgsMenu(args);

    Utilities.insertBreak();
    Console.WriteLine("SELECT L now to LOG OUT");
    Utilities.insertBreak();
    Console.Write("ENTER YOUR CHOICE: ");
    string userSelection = Console.ReadLine()!.Trim().ToUpper();

    switch (userSelection)
    {
        case "C":
            Utilities.newUserWelcomeMessage();
            break;
        case "S":
            LogInFunction.LogIn();
            break;
        case "G":
            VehicleManagement.guestMenu();
            break;
        case "E":
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("PROGRAM TERMINATING");
            Console.ResetColor();
            keepRunning = false; // exits loop gracefully
            break;
        case "L":
        Utilities.insertBreak();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("YOU WILL NOW BE LOGGED OUT.");
            Console.ResetColor();
            Environment.Exit(0);
            break;
        default:
            Utilities.invalidInput();
            break;
    }
}

//Presenting the user with the option to sign in as a member of staff (using command line arguments).

// ============================================================================== MAIN PROGRAM ENDS ===================================================
//Potential Developments

//We have the potential to add in a new dataset containing supercars/luxury vehicles for rental.
//This will give us the opportunity to use a new type potentially other than dictionary if applciable.
//Should check the date and only take the car out of the system on the correct date.

//In the assessment application

//You need to take arguments
//And also handle them properly

//The --3 argument will show the version of the program.
//This is a very common command line argument

//Do we need to use command line arguments multiple times or only once to show we know how to use them?

//You need to include the things that we have learnt within the assessment so that we can get higher marks.

//Make sure that as many exceptions as possible are covered.
//Could use the try functions for this, try...while...
//Exceptions can be seen my hovering over the top of functions.

//For premium cars, I could use a databse which would allow me to use the try, catch, finally statements.
//The above statements are included within the week 6 work for robustness.
//The file needs to be within the bin file (at the same level as the exe document).
//I could have a list of the filenames (in a normal list).
//And then the user can select a file to open.

//Need to continue working on the user create account function.
//Need to continue implementing the User log in function.

//Make sure to catch exceptions throughout the code.
//Even if it makes the code look messy

//Could have it so the admin user can view all of the staff details by printing them from the file. 
//This could work by using the week 6 content and using try, catch and exception handling.

//Could potentially aslo put the guest section into a function.

//Could use IEnumerable for the storelist.

//Look at putting the functions into classes and moving them to other files and then calling them into the program.cs which will just be used for calling the functions.

//Should the name of the functions be in camelCase too?