using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

namespace Number_conversion_project_final
{
    internal class Program
    {
        //This code is initially executed when the program is run by the user and so opens the main menu through the subroutine
        static void Main(string[] args)
        {
            MainMenu();
        }
        //Finds the user's selected task, whilst rejecting any invalid or incorrect inputs
        static void MainMenuInputValidator()
        {
            //Gets the user's input and stores it in a string so that it will not give an error if a unexpected character such as 
            // a number or a symbol is input
            string userInput = Console.ReadLine();

            //Removes any leading or trailing whitespace
            userInput = userInput.Trim();

            //Checks that the string is not null as this could cause an error in the switch case statement further down
            if (userInput == null)
            {
                //If the user's input is null, then the subroutine calls itself and the user must try again
                Console.WriteLine("Input is not valid. Try again.");
                MainMenuInputValidator();
            }
            else
            {
                //Checks that the string is not empty (different to null)  as this could cause an error in the switch case
                // statement further down
                if (userInput == "")
                {
                    //If the user's input is empty, then the subroutine calls itself and the user must try again
                    Console.WriteLine("Input is not valid. Try again.");
                    MainMenuInputValidator();
                }
            }

            //Switch case statement is used to check for any valid inputs, allowing the user to enter their choice in multiple formats
            //If the user's input is found as a case, then a confirmation message is shown and the corresponding subroutine is called
            switch (userInput)
            {
                //All valid task A formats
                case "a":
                case "A":
                case "task a":
                case "Task A":
                    Console.WriteLine("Task A selected");
                    Console.WriteLine();
                    TaskA();
                    break;

                //All valid task B formats
                case "b":
                case "B":
                case "task b":
                case "Task B":
                    Console.WriteLine("Task B selected");
                    Console.WriteLine();
                    TaskB();
                    break;

                //All valid task C formats
                case "c":
                case "C":
                case "task c":
                case "Task C":
                    Console.WriteLine("Task C selected");
                    Console.WriteLine();
                    TaskC();
                    break;

                //All valid task D formats
                case "d":
                case "D":
                case "task d":
                case "Task D":
                    Console.WriteLine("Task D selected");
                    Console.WriteLine();
                    TaskD();
                    break;

                //All valid task E formats
                case "e":
                case "E":
                case "task e":
                case "Task E":
                    Console.WriteLine("Task E selected");
                    Console.WriteLine();
                    TaskE();
                    break;

                //All valid task F formats
                case "f":
                case "F":
                case "task f":
                case "Task F":
                    Console.WriteLine("Task F selected");
                    Console.WriteLine();
                    TaskF();
                    break;

                //All valid task G and H (as h is part of task g) formats
                case "g":
                case "G":
                case "h":
                case "H":
                case "task g and h":
                case "Task G and H":
                    Console.WriteLine("Task G selected");
                    Console.WriteLine();
                    TaskG();
                    break;

                //If the user's input is valid then it will have been compared true to the above case statements
                //Therefore, if it reaches the default case then it must be an invalid input and so the subroutine must be called again
                default:
                    Console.WriteLine("Input is not valid. Try again.110");
                    MainMenuInputValidator();
                    break;

            }
        }
        //Used to validate any 8 digit binary inputs (used in multiple tasks)
        static string BinaryInputValidator()
        {
            //Gets the user's input and stores it in a string so that it will not give an error if a unexpected character such as 
            // a number or a symbol is input
            string userInput = Console.ReadLine();

            //Removes any leading or trailing whitespace
            userInput = userInput.Trim();

            //Defines a boolean used to check for digits later on in the if statements
            bool isBinary = true;

            //Checks that the string is not null 
            if (userInput == null)
            {
                //If the user's input is null, then the subroutine calls itself and the user must try again
                Console.WriteLine("Input is not valid (cannot be a null value). Try again.");
                return BinaryInputValidator();
            }
            else
            {
                //Checks that the string is not empty (different to null) 
                if (userInput == "")
                {
                    //If the user's input is empty, then the subroutine calls itself and the user must try again
                    Console.WriteLine("Input is not valid (cannot be an empty value). Try again.");
                    return BinaryInputValidator();
                }
                else
                {
                    //Checks that the user's input is 8 digits long
                    if (userInput.Length != 8)
                    {
                        //If the user's input is not 8 characters then it is an invalid entry, then the subroutine
                        //calls itself and the user must try again
                        Console.WriteLine("Input is not valid (must be 8 digits). Try again.");
                        return BinaryInputValidator();
                    }
                    else
                    {
                        //Loops through each digit of the string, from index 0 to 7 incrementing by 1 each time
                        for (int i = 0; i < userInput.Length; i++)
                        {
                            //Checks to see if the digit being checked is not either a 1 or 0
                            //Converts to string to check a string against a string, instead of a character against a string which causes errors
                            //&& is used to reperesent AND
                            if (Convert.ToString(userInput[i]) != "0" && Convert.ToString(userInput[i]) != "1")
                            {
                                isBinary = false;
                            }
                        }

                        //If there is only 0s and 1s the value of isBinary will remain true and the validated result is returned
                        if (isBinary)
                        {
                            return userInput;
                        }
                        else
                        {
                            //User input contains forbidden characters and so is invalid
                            Console.WriteLine("Input is not valid (must be a 0 or a 1)");
                            return BinaryInputValidator();
                        }

                    }
                }

            }
        }
        //Used to validate any 0 -255 denary input (used in multiple task)
        //Returns a double as they are easier to work with than integers
        static double DenaryInputValidator()
        {
            //Gets the user's input and stores it in a string so that it will not give an error if a unexpected character such as 
            // a number or a symbol is input
            string userInput = Console.ReadLine();

            //Removes any leading or trailing whitespace
            userInput = userInput.Trim();

            //Checks that the string is not null 
            if (userInput == null)
            {
                //If the user's input is null, then the subroutine calls itself and the user must try again
                Console.WriteLine("Input is not valid (cannot be a null value). Try again.");
                return DenaryInputValidator();
            }
            else
            {
                //Checks that the string is not empty (different to null) 
                if (userInput == "")
                {
                    //If the user's input is empty, then the subroutine calls itself and the user must try again
                    Console.WriteLine("Input is not valid (cannot be an empty value). Try again.");
                    return DenaryInputValidator();
                }
                else
                {
                    //Checks that the user's input contains only numbers
                    //TryParse allows digits and whitespace only
                    //It returns a true or false value depending on whether the string can be converted to an integer
                    if (int.TryParse(userInput, out int userInputTestInt) != true)
                    {
                        //If the input contains characters that arent digits then it is invalid and calls itself
                        Console.WriteLine("Input is not valid (must contain only digits 0-9)");
                        return DenaryInputValidator();
                    }

                    //Converts the user's string input to an integer (will not cause an error as only digits left)
                    //If a zero is at the start then it will be removed
                    double userInputInt = Convert.ToDouble(userInput);

                    //Checks that the user value is between 0 and 255
                    if (userInputInt < 0 || userInputInt > 255)
                    {
                        //Users input not is within the valid range and so the subroutine repeats
                        Console.WriteLine("Input is not valid (must be between 0 - 255)");
                        return DenaryInputValidator();
                    }
                    else
                    {
                        //Users input is within the valid range and returns the double to the required task
                        return userInputInt;
                    }
                }
            }
        }
        //Used to validate any 2 digit hexadecimal input (used in multiple tasks)
        static string HexInputValidator()
        {
            //Gets the users input
            string userInput = Console.ReadLine();

            //Removes any leading or trailing whitespace
            userInput = userInput.Trim();

            //Used later in a for loop
            bool isHex = true;

            //Checks to see if the users input is null
            if (userInput == null)
            {
                //If the users input is null then the function calls itself
                Console.WriteLine("Input is not valid (string cannot be null)");
                return HexInputValidator();
            }
            else
            {
                //Checks to see if the users input is an empty string
                if (userInput == "")
                {
                    //If the users input is empty then the function calls itself
                    Console.WriteLine("Input is not valid (string cannot be empty)");
                    return HexInputValidator();
                }
                else
                {
                    //Checks to see if the users input is the correct length of 2
                    if (userInput.Length != 2)
                    {
                        //If the users input is not 2 characters long then the function calls itself
                        Console.WriteLine("Input is not valid (must be 2 characters)");
                        return HexInputValidator();

                    }
                    else
                    {
                        //Loops through all the characters of the users input
                        for (int i = 0; i < userInput.Length; i++)
                        {
                            //Converts the string of the users input to a character to prevent an error with the contains function
                            char c = userInput[i];

                            //Checks if the character is not a digit or a valid hexadecimal letter
                            if ("1234567890ABCDEFabcdef".Contains(c) != true)
                            {
                                //Exits the loop if an invalid character is found and sets isHex to zero
                                isHex = false;
                                break;
                            }
                        }
                        //If the users input is valid it is returned to the correct task
                        if (isHex)
                        {
                            return userInput;
                        }
                        else
                        {
                            //The users input is invalid and the function calls itself
                            Console.WriteLine("Input is not valid (only use hexadecimal characters)");
                            return HexInputValidator();
                        }
                    }
                }
            }
        }
        //Used to convert a denary value between 0 - 15 to a a hexadecimal value
        static string DecToHex(double denValue)
        {
            //Creates a array of strings 6 elements long with the alphabetical hexadecimal values
            string[] hexValues = new string[6] { "A", "B", "C", "D", "E", "F" };

            switch (denValue)
            {
                case < 10:
                    //If the denary value is less than 10 then it does not have to be converted to an alphabetical value
                    //The string version of the double is returned instead
                    return Convert.ToString(denValue);

                case 10:
                    //Otherwise return the alphabetical value corresponding to the denary value
                    return hexValues[0];

                case 11:
                    return hexValues[1];

                case 12:
                    return hexValues[2];

                case 13:
                    return hexValues[3];

                case 14:
                    return hexValues[4];

                default:
                    return hexValues[5];

            }
        }
        //Used to convert a 2 char hex value to a denary num
        static double HexToDec(string hex)
        {
            //Initialises a answer variable
            double answer = 0;

            //Loops through both characters of the hexadecimal string
            for (int characterIndex = 0; characterIndex < hex.Length; characterIndex++)
            {
                //Checks each of the characters seperately
                //Converts the character to a string to remove errors
                //If it is the first digit then the denary value is multiplied by 16
                switch (Convert.ToString(hex[characterIndex]))
                {
                    //Does not need to be changed if it is a zero
                    case "0":
                        continue;
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        //Converts the character to a string then to a double and then multiplys by 16 if it is the first digit
                        if (characterIndex == 0)
                        {
                            answer += Convert.ToDouble(Convert.ToString(hex[characterIndex])) * 16;
                        }
                        else
                        {
                            answer += Convert.ToDouble(Convert.ToString(hex[characterIndex]));
                        }
                        break;
                    case "a":
                    case "A":
                        //A is worth 10 at the second digit or 160 at the first digit
                        if (characterIndex == 0)
                        {
                            answer += 10 * 16;
                        }
                        else
                        {
                            answer += 10;
                        }
                        break;
                    case "b":
                    case "B":
                        //B is worth 11 at the second digit or 176 at the first digit
                        if (characterIndex == 0)
                        {
                            answer += 11 * 16;
                        }
                        else
                        {
                            answer += 11;
                        }
                        break;
                    case "c":
                    case "C":
                        //C is worth 12 at the second digit or 192 at the first digit
                        if (characterIndex == 0)
                        {
                            answer += 12 * 16;
                        }
                        else
                        {
                            answer += 12;
                        }
                        break;
                    case "d":
                    case "D":
                        //D is worth 13 at the second digit or 208 at the first digit
                        if (characterIndex == 0)
                        {
                            answer += 13 * 16;
                        }
                        else
                        {
                            answer += 13;
                        }
                        break;
                    case "e":
                    case "E":
                        //E is worth 14 at the second digit or 224 at the second digit
                        if (characterIndex == 0)
                        {
                            answer += 14 * 16;
                        }
                        else
                        {
                            answer += 14;
                        }
                        break;
                    case "f":
                    case "F":
                        //F is worth 15 at the second digit or 240 at the second digit
                        if (characterIndex == 0)
                        {
                            answer += 15 * 16;
                        }
                        else
                        {
                            answer += 15;
                        }
                        break;
                    default:
                        continue;
                }
            }

            //Returns the denary value to the task it is required in
            return answer;
        }
        //Used to display the main menu to the user
        static void MainMenu()
        {
            //Uses write line statements to display the different tasks to the user
            Console.WriteLine();
            Console.WriteLine("------------MAIN MENU------------");
            Console.WriteLine("Select your task below: ");
            Console.WriteLine("Task A: Convert binary to denary");
            Console.WriteLine("Task B: Convert denary to binary");
            Console.WriteLine("Task C: Convert binary to hexadecimal");
            Console.WriteLine("Task D: Convert hexadecimal to binary");
            Console.WriteLine("Task E: Convert denary to hexadecimal");
            Console.WriteLine("Task F: Convert hexadecimal to denary");
            Console.WriteLine("Task G: Adding two binary numbers");

            //Calls the input validator subroutine which will get the users input and therefore also the task
            MainMenuInputValidator();
        }
        //Peforms task A for the user
        static void TaskA()
        {
            //Gets the 8-bit binary input for the function and validates it with the validator function
            Console.WriteLine("Enter your 8 digit binary number (The leftmost bit is the largest bit): ");
            string taskABin = BinaryInputValidator();

            double taskAresult = 0;

            //Creates a for loop in order to loop through each digit of the binary input
            for (int digit = 0; digit < taskABin.Length; digit++)
            {
                //Converts to a string to prevent comparing a string to a character which causes an error
                //Only checks for a 1 as any 0s in the data have a value of 0 in denary and so can be ignored
                if (Convert.ToString(taskABin[digit]) == "1")
                {
                    //Binary digits have a value of 2 to the power of their position in denary
                    //As binary digits have a value of largest on the left -> smallest on the right, the value must be subracted from the
                    //length to get the correct exponent
                    //The -1 is added as the indexes of the strings start at 0 whereas the indexes for the denary values start at 1
                    taskAresult += Math.Pow(2, taskABin.Length - 1 - digit);
                }
            }

            //String.format is used to display multiple variables easily in the same string
            //Outputs the result of task A
            Console.WriteLine(string.Format("{0} as a denary number is {1}", taskABin, taskAresult));

            //Takes the user back to the main menu in order to select another task
            MainMenu();
        }
        //Performs task B for the user
        static void TaskB()
        {
            //Gets the input of the user from the user and validates it
            Console.WriteLine("Enter your denary value (must be between 0 - 255): ");
            double taskBDec = DenaryInputValidator();

            //Creates a temporary value to store the user's input whilst the main value is changed
            double tempTaskBDec = taskBDec;

            //Creates an array of strings 8 long but empty and also a final answer variable
            string[] taskBArrayResult = new string[8];
            string taskBResult = "";

            //Loops through each binary digit
            for (int digit = 0; digit < 8; digit++)
            {
                //Each place value in a binary string is equal to 2^digit position
                //The 7 minus digit makes the first digit have a value of 1 not 2 and the final value have a value of 128 
                if (taskBDec - Math.Pow(2, 7 - digit) >= 0)
                {
                    //Makes the corresponding index in the array the correct binary value
                    taskBArrayResult[digit] = "1";

                    //Removes the binary value from the denary number
                    taskBDec = taskBDec - Math.Pow(2, 7 - digit);
                }
                else
                {
                    //Makes the corresponding index in the array a "0" to show that the value does not exist in the denary value
                    taskBArrayResult[digit] = "0";
                }
            }
            //Loops through each index in the array of strings
            for (int digit = 0; digit < taskBArrayResult.Length; digit++)
            {
                //Concatonates an array of strings to a single string
                taskBResult += taskBArrayResult[digit];
            }
            //String.format is used to display multiple variables easily in the same string
            //Outputs the result of task B
            Console.WriteLine(string.Format("{0} as a binary number is {1}", tempTaskBDec, taskBResult));
            MainMenu();
        }
        //Performs task C for the user
        static void TaskC()
        {
            //Gets the 8-bit binary input for the function and validates it with the validator function
            Console.WriteLine("Enter your 8 digit binary number (The leftmost bit is the largest bit): ");
            string taskCBin = BinaryInputValidator();

            //Splits the binary input in half and stores it seperately
            string taskCHalf1 = taskCBin.Substring(0, 4);
            string taskCHalf2 = taskCBin.Substring(4);

            //Used to store the denary values of the first and last half of the input
            double taskCHalf1Result = 0;
            double taskCHalf2Result = 0;

            string taskCFinalResult = "";

            //First half loop
            for (int digit = 0; digit < taskCHalf1.Length; digit++)
            {
                //If there is a one then the value of the binary digit is added to the denary digit
                if (Convert.ToString(taskCHalf1[digit]) == "1")
                {
                    taskCHalf1Result += Math.Pow(2, taskCHalf1.Length - 1 - digit);
                }
            }

            //Second half
            for (int digit = 0; digit < taskCHalf2.Length; digit++)
            {
                //If there is a one then the value of the binary digit is added to the denary digit
                if (Convert.ToString(taskCHalf2[digit]) == "1")
                {
                    taskCHalf2Result += Math.Pow(2, taskCHalf2.Length - 1 - digit);
                }
            }

            //Calls the DecToHex function (used in both task C and E)
            //Concatonates the two hexadecimal values together
            taskCFinalResult = DecToHex(taskCHalf1Result) + DecToHex(taskCHalf2Result);

            //Displays the result and takes the user back to the main menu
            Console.WriteLine(string.Format("{0} as a hexadecimal number is {1}", taskCBin, taskCFinalResult));
            MainMenu();
        }
        //Performs task D for the user
        static void TaskD()
        {
            //Gets the input of the user and converts it to a decimal using the Hex To Dec function
            Console.WriteLine("Enter your 2 digit hexadecimal value: ");
            string taskDHexInput = HexInputValidator();

            double taskDDec = HexToDec(taskDHexInput);

            //COPIED FROM TASK B
            //Creates a temporary value to store the user's input whilst the main value is changed
            double tempTaskDDec = taskDDec;

            //Creates an array of strings 8 long but empty and also a final answer variable
            string[] taskDArrayResult = new string[8];
            string taskDResult = "";

            //Loops through each binary digit
            for (int digit = 0; digit < 8; digit++)
            {
                //Each place value in a binary string is equal to 2^digit position
                //The 7 minus digit makes the first digit have a value of 1 not 2 and the final value have a value of 128 
                if (taskDDec - Math.Pow(2, 7 - digit) >= 0)
                {
                    //Makes the corresponding index in the array the correct binary value
                    taskDArrayResult[digit] = "1";

                    //Removes the binary value from the denary number
                    taskDDec = taskDDec - Math.Pow(2, 7 - digit);
                }
                else
                {
                    //Makes the corresponding index in the array a "0" to show that the value does not exist in the denary value
                    taskDArrayResult[digit] = "0";
                }
            }
            
            //Loops through each index in the array of strings
            for (int digit = 0; digit < taskDArrayResult.Length; digit++)
            {
                //Concatonates an array of strings to a single string
                taskDResult += taskDArrayResult[digit];
            }

            //String.format is used to display multiple variables easily in the same string
            //Outputs the result of task D
            Console.WriteLine(string.Format("{0} as a binary number is {1}", taskDHexInput, taskDResult));
            MainMenu();
        }
        //Performs task E for the user
        static void TaskE()
        {
            //Gets the users denary input as a double 
            Console.WriteLine("Enter your denary value (0 - 255): ");
            double taskEDecInput = DenaryInputValidator();
            double taskEDecDigit1 = taskEDecInput % 16;
            double taskEDecDigit2 = (taskEDecInput - taskEDecDigit1) / 16;
            string taskEAnswer = Convert.ToString(DecToHex(taskEDecDigit2)) + Convert.ToString(DecToHex(taskEDecDigit1));

            //String.format is used to display multiple variables easily in the same string
            //Outputs the result of task E
            Console.WriteLine(string.Format("{0} as a hexadecimal number is {1}", taskEDecInput, taskEAnswer));
            MainMenu();
        }
        //Performs task F for the user
        static void TaskF()
        {
            //Gets the input of the user and converts it to a decimal using the Hex To Dec function
            Console.WriteLine("Enter your 2 digit hexadecimal value: ");
            string taskFHexInput = HexInputValidator();

            double taskFDec = HexToDec(taskFHexInput);

            //String.format is used to display multiple variables easily in the same string
            //Outputs the result of task E
            Console.WriteLine(string.Format("{0} as a denary number is {1}", taskFHexInput, taskFDec));
            MainMenu();
        }
        //Performs task G
        static void TaskG()
        {
            //Gets the users input for the two binary numbers to be added
            Console.WriteLine("Enter the first binary value: ");
            string binaryInput1 = BinaryInputValidator();
            Console.WriteLine("Enter the second binary value: ");
            string binaryInput2 = BinaryInputValidator();

            //Creates two variables to hold the result of the addition, one a string and the other an array
            string[] answer = new string[9] { "0", "0", "0", "0", "0", "0", "0", "0", "0" };
            string stringAnswer = "";

            //Used to check if the calculation needs to carry on to the next digit
            bool carry = false;

            //Loops through both binary numbers from right to left
            for (int digit = 7; digit >= 0; digit--)
            {
                //2 ZEROS NO CARRY
                //0 + 0 + 0
                if (Convert.ToString(binaryInput1[digit]) == "0" && Convert.ToString(binaryInput2[digit]) == "0" && carry == false)
                {
                    //Sets the result to zero and doesn't carry
                    answer[digit + 1] = "0";
                    carry = false;
                }
                //2 ZEROS AND CARRY
                //0 + 0 + 1
                if (Convert.ToString(binaryInput1[digit]) == "0" && Convert.ToString(binaryInput2[digit]) == "0" && carry == true)
                {
                    //Sets the result to one and doesn't carry
                    answer[digit + 1] = "1";
                    carry = false;
                }
                //1 ZERO NO CARRY
                //1 + 0 + 0
                //0 + 1 + 0
                if (((binaryInput1[digit] == '0' && binaryInput2[digit] == '1') ||
                     (binaryInput1[digit] == '1' && binaryInput2[digit] == '0')) && carry == false)
                {
                    //Sets the result to one and doesn't carry
                    answer[digit + 1] = "1";
                    carry = false;
                }
                //1 ZERO AND CARRY
                //1 + 0 + 1
                //0 + 1 + 1
                if (((binaryInput1[digit] == '0' && binaryInput2[digit] == '1') ||
                     (binaryInput1[digit] == '1' && binaryInput2[digit] == '0')) && carry == true)
                {
                    //Sets the result to zero and carrys
                    answer[digit + 1] = "0";
                    carry = true;
                }
                //0 ZEROS AND NO CARRY
                //1 + 1 + 0
                if (Convert.ToString(binaryInput1[digit]) == "1" && Convert.ToString(binaryInput2[digit]) == "1" && carry == false)
                {
                    //Sets the result to zero and carrys
                    answer[digit + 1] = "0";
                    carry = true;
                }
                //0 ZEROS AND CARRY
                //1 + 1 + 1
                if (Convert.ToString(binaryInput1[digit]) == "1" && Convert.ToString(binaryInput2[digit]) == "1" && carry == true)
                {
                    //Sets the result to one and carrys
                    answer[digit + 1] = "1";
                    carry = true;
                }
            }

            //If carry is true then there has been an overflow and so the 9th digit is correctly set
            if (carry)
            {
                answer[0] = "1";
            }

            //If there is an overflow
            if (answer[0] == "1")
            {
                Console.WriteLine("There was an overflow");

                //Change the array of strings to a string
                for (int digit = 0; digit < answer.Length; digit++)
                {
                    //Display the overflow
                    if (digit == 0)
                    {
                        stringAnswer += "(1) ";
                    }
                    else
                    {
                        stringAnswer += Convert.ToString(answer[digit]);
                    }
                }

                //Display the answer of the calculation
                Console.WriteLine(string.Format("{0} + {1} is equal to {2}", binaryInput1, binaryInput2, stringAnswer));
            }
            else
            {
                //No overflow
                Console.WriteLine("There was no overflow");
                for (int digit = 0; digit < answer.Length; digit++)
                {
                    
                    stringAnswer += Convert.ToString(answer[digit]);
                    
                }

                //Display the answer of the calculation
                Console.WriteLine(string.Format("{0} + {1} is equal to {2}", binaryInput1, binaryInput2, stringAnswer));
            }

            //Go back to the main menu
            MainMenu();
        }
    }
}