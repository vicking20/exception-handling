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

            string? userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput))
            {
                try
                {
                    int number = int.Parse(userInput!);
                    Console.WriteLine($"You entered: {number}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid numeric value.");
                }
                catch (Exception err)
                {
                    Console.WriteLine($"An error occurred: {err.Message}");
                }
            }

        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
            // Display appropriate error messages for different exceptions.
            string? userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput))
            {
                try
                {
                    int number = int.Parse(userInput);
                    Console.WriteLine($"You entered: {number}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a valid numeric value.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The entered number is too large or too small for an integer.");
                }
                catch (Exception err)
                {
                    Console.WriteLine($"An error occurred: {err.Message}");
                }
            }
            else
            {
                Console.WriteLine("Error: Input cannot be null or empty.");
            }
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Add a finally block to the program.
            // Use the finally block to display a message whether an exception was caught or not.
            string? userInput = Console.ReadLine();

            try
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    int number = int.Parse(userInput);
                    Console.WriteLine($"You entered: {number}");
                }
                else
                {
                    Console.WriteLine("Error: Input cannot be null or empty.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid numeric value.");
            }

            catch (Exception err)
            {
                Console.WriteLine($"An error occurred: {err.Message}");
            }
            finally
            {
                Console.WriteLine("An exception was caught");
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
            string? userInput = Console.ReadLine();

            try
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    int number = int.Parse(userInput);

                    if (number < 0)
                    {
                        throw new NegativeNumberException("Error: Negative numbers are not allowed.");
                    }

                    Console.WriteLine($"You entered: {number}");
                }
                else
                {
                    Console.WriteLine("Error: Input cannot be null or empty.");
                }
            }
            catch (NegativeNumberException err)
            {
                Console.WriteLine(err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine($"An error occurred: {err.Message}");
            }
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // In this function, call CheckNumber inside a try block and handle the exception.
            string? userInput = Console.ReadLine();

            try
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    int number = int.Parse(userInput);
                    CheckNumber(number);
                    Console.WriteLine($"You entered: {number}");
                }
                else
                {
                    Console.WriteLine("Error: Input cannot be null or empty.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid numeric value.");
            }
            catch (ArgumentOutOfRangeException err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
            catch (Exception err)
            {
                Console.WriteLine($"An error occurred: {err.Message}");
            }
        }

        // CheckNumber Function
        static void CheckNumber(int number)
        {
            if (number > 100)
            {
                throw new ArgumentOutOfRangeException("Number should not be greater than 100.");
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
            string? userInput = Console.ReadLine();

            try
            {
                if (!string.IsNullOrEmpty(userInput))
                {
                    int number = int.Parse(userInput);
                    CheckNumberWithLogging(number);
                    Console.WriteLine($"You entered: {number}");
                }
                else
                {
                    Console.WriteLine("Error: Input cannot be null or empty.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid numeric value.");
            }

            catch (ArgumentOutOfRangeException err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
            catch (Exception err)
            {
                Console.WriteLine($"An error occurred: {err.Message}");
            }
        }

        // ChceckNumberWithLogging Function
        static void CheckNumberWithLogging(int number)
        {
            try
            {
                if (number > 100)
                {
                    Console.WriteLine($"Logging: Number {number} is greater than 100.");
                    throw new ArgumentOutOfRangeException("Number should not be greater than 100.");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Exception caught in CheckNumberWithLogging: {err.Message}");
                throw;
            }
        }
    }
}