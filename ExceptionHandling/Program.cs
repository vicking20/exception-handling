namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Convert the input to an integer using int.Parse().
            // Use a try-catch block to handle FormatException if the user enters a non-numeric value.
            // Display an error message in case of an exception.
            // Output the input if correct
            try
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number}");
                    }
            catch (FormatException)
            { 
                Console.WriteLine("Error, please enter a valid number.")
                    }
        }


        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
            // Display appropriate error messages for different exceptions.
 
                try
                {
                    
                    int number = int.Parse(Console.ReadLine());

                    Console.WriteLine($"You entered: {number}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The entered number is too large or too small for an integer.");
                }
            }


        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
        // TODO:
        // Implement BasicExceptionHandling code with following modification
        // Add a finally block to the program.
        // Use the finally block to display a message whether an exception was caught or not.
        static void FinalyBlockUsage()
        {
            try
            {
                Console.Write("Enter a number: ");
                int number = int.Parse(Console.ReadLine());

                Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: The entered number is too large or too small for an integer.");
            }
            finally
            {
                Console.WriteLine("Exception caught.");
            }
            else
            { Console.WriteLine("No exception thrown"); 
            }
        }


    }

    // Class for custom exception type
    class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Modify your number input program to throw NegativeNumberException if the user enters a negative number.
            // Handle this exception in a separate catch block and display an appropriate message.
        try
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new NegativeNumberException("Error: Negative numbers are not allowed.");
            }
            Console.WriteLine($"You entered: {number}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid numeric value.");
        
        catch (NegativeNumberException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Exception caught.");
        }
    }

}

static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
    // TODO:
    // Implement BasicExceptionHandling code with following modification
    // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
    // In this function, call CheckNumber inside a try block and handle the exception.
    try
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        CheckNumber(number);
        Console.WriteLine($"You entered: {number}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Please enter a valid numeric value.");
    }

    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }

        // NOTE: You can implement the CheckNumber here
        static void CheckNumber(int number)
{
    if (number > 100)
    {
        throw new ArgumentOutOfRangeException("Error: Number cannot be greater than 100.");
    }
}

static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
    // TODO:
    // Implement BasicExceptionHandling code with following modification
    // Write a function CheckNumberWithLogging that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
    // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
    // In this function, catch the exception in the main program and display the logged message.
        try
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            CheckNumberWithLogging(number);
            Console.WriteLine($"You entered: {number}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter a valid numeric value.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

}
// NOTE: You can implement the CheckNumberWithLogging here
static void CheckNumberWithLogging(int number)
{
    try
    {
        if (number > 100)
        {
            Console.WriteLine($"Logging: Number {number} is greater than 100.");
            throw new ArgumentOutOfRangeException("Number cannot be greater than 100.");
        }
    }
    catch (Exception ex)
    {
        throw new ArgumentOutOfRangeException("Error in CheckNumberWithLogging", ex);
    }
}
}