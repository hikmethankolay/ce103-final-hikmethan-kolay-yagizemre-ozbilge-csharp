/**
 * @file CarMaintenance.cs
 *
 * @brief Provides functions for file operations
 */

/**
* @brief Namespace CarMaintenanceLibrary for Functions.
*
*/
namespace CarMaintenanceLibrary {
    /**
    * 
    *@brief Imports Text Class from System Namespace for file operations.
    *
    */
    using System.Text;

    /**
    * Class CarMaintenance for Functions
    *
    */
    public class CarMaintenance
    {    /**
         * Open a FileStream object named myFile.
         *
         */
        private FileStream? myFile; // FileStream object for file operations

        /**
         * Opens a binary file, deletes all of its content, and writes given text to it.
         *
         * @param file_name The name of the file to write.
         * @param text The text to write.
         * @return 0 on success.
         */
        public int FileWrite(string FileName, string text)
        {
            text = "0-)" + text + "\n";

            using (myFile = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                myFile.Write(bytes, 0, bytes.Length);
            }

            return 0;
        }

        /**
        * @brief Opens a binary file, Reads all of its content, seperate line with "\n" and write them to console, also returns a string for unit tests.
        *
        *
        * @param file_name The name of the file to read from.
        * @return The contents of the file as a string.
        */
        public string FileRead(string FileName)
        {
            {
                string line = "";
                try
                {
                    using (myFile = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(myFile, Encoding.Default))
                        {
                            while (!streamReader.EndOfStream)
                            {
                                char character = (char)streamReader.Read();
                                if (character == '\r')
                                {
                                    continue;
                                }

                                line += character;
                            }
                        }
                    }

                    Console.WriteLine(line);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("File operation failed. There is no record.");
                    Console.WriteLine(ex.Message);
                    return "-1";
                }

                return line;
            }
        }
        /**
        * @brief Appends given text to a binary file with a automatic calculated line number. Calcultes new lines line number by finding last lines line number.
        *
        *
        * @param file_name The name of the file to append to.
        * @param text The text to append to the file.
        * @return 0 on success.
        */
        public int FileAppend(string FileName, string text)
        {
            try
            {
                string lastLine = "";
                string currentLine = "";
                char character;

                using (myFile = new FileStream(FileName, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(myFile, Encoding.Default))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            character = (char)streamReader.Read();
                            if (character == '\n')
                            {
                                currentLine += character;
                                lastLine = currentLine;
                                currentLine = "";
                                continue;
                            }

                            currentLine += character;
                        }
                    }
                }

                int pos = lastLine.IndexOf("-)"); // Finds the location of "-)" in the last line
                int lineNumber = int.Parse(lastLine.Substring(0, pos)) + 1; // Finds the number for the appended line
                text = lineNumber + "-)" + text + "\n";

                using (myFile = new FileStream(FileName, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(myFile, Encoding.Default))
                    {
                        streamWriter.Write(text);
                    }
                }

                return 0;
            }
            catch (IOException ex)
            {
                Console.WriteLine("File operation failed.");
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        /**
        * @brief This function Opens a binary file, finds the line that user wants to edit and replace it wih new text.
        *
        *
        * @param file_name The name of the file to edit.
        * @param line_number_to_edit The line number to edit.
        * @param new_line The new text to replace the existing line.
        * @return 0 on success.
        */
        public int FileEdit(string fileName, int lineNumberToEdit, string newLine)
        {
            string[] lines = new string[100]; // An array to store lines
            string line = "";
            char character;
            int lineCount = 0; // A variable for an if statement to check if the line that the user wants to edit exists
            try
            {

                using (myFile = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(myFile, Encoding.Default))
                    {

                        while (!streamReader.EndOfStream)
                        {
                            character = (char)streamReader.Read();
                            if (character == '\n')
                            {
                                line += character;
                                lines[lineCount++] = line;
                                line = "";
                                continue;
                            }

                            line = line + character;
                        }
                    }
                }

                if (lineNumberToEdit > 0 && lineNumberToEdit <= lineCount)
                {
                    lines[lineNumberToEdit] = lineNumberToEdit + "-)" + newLine + "\n"; // Changes a member of the Lines array to a new line with its line number
                }
                else
                {
                    Console.WriteLine("You can only edit existing lines.");
                    return -1;
                }

                using (StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.Default))
                {
                    foreach (string updatedLine in lines)
                    {
                        if (string.IsNullOrEmpty(updatedLine))
                        {
                            break; // Stops if there is nothing on the next line since arrays have fixed slots inside them from the start
                        }

                        streamWriter.Write(updatedLine);
                    }
                }

                Console.WriteLine("\nData successfully edited\n\n");
                return 0;
            }
            catch (IOException ex)
            {
                Console.WriteLine("File operation failed.");
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        /**
        * @brief This function Opens a binary file, deletes the line user wanted and make adjustments on line number acordingly.
        *
        *
        * @param file_name The name of the file to delete the line from.
        * @param line_number_to_delete The line number to delete.
        * @return 0 on success.
        */
        public int FileLineDelete(string fileName, int LineNumberToDelete)
        {
            string[] lines = new string[100]; // An array to store lines
            string line = "";
            char character;
            int lineCount = 0; // A variable for an if statement to check if the line that the user wants to edit exists
            try
            {

                using (myFile = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader streamReader = new StreamReader(myFile, Encoding.Default))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            character = (char)streamReader.Read();
                            if (character == '\n')
                            {
                                line += character;
                                lines[lineCount++] = line;
                                line = "";
                                continue;
                            }

                            line = line + character;
                        }
                    }
                }

                if (LineNumberToDelete > 0 && LineNumberToDelete < lineCount)
                {
                    for (int i = LineNumberToDelete; i < lineCount - 1; ++i)
                    {
                        lines[i] = lines[i + 1];
                    }

                    lines[lineCount - 1] = "";
                }
                else
                {
                    Console.WriteLine("You can only erase existing lines");
                    return -1;
                }

                using (StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.Default))
                {
                    foreach (string updatedLine in lines)
                    {
                        if (string.IsNullOrEmpty(updatedLine))
                        {
                            break;
                        }

                        int pos = updatedLine.IndexOf("-)");
                        int lineNumber = int.Parse(updatedLine.Substring(0, pos));

                        if (lineNumber > LineNumberToDelete)
                        {
                            string updatedLineWithNewNumber = (lineNumber - 1) + updatedLine.Substring(pos);
                            streamWriter.Write(updatedLineWithNewNumber);
                        }
                        else
                        {
                            streamWriter.Write(updatedLine);
                        }
                    }
                }

                Console.WriteLine("\nData successfully deleted\n\n");
                return 0;
            }
            catch (IOException ex)
            {
                Console.WriteLine("File operation failed");
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        /**
        * @brief This function is for user register
        *
        * Function creates a user.bin file and writes inputted username and password in it.
        *
        * @return 0 on success.
        * @return -1 on faill.
        */
        public int user_register(string new_username = "None", string new_password = "None", string new_recovery_key = "None", string user_file = "user.bin", string choice = "None")
        {
            return 0;
        }

        /**
         * @brief This function is for user login
         *
         * Function read user.bin file and checks if username and password matchs with inputted username and password
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int user_login(string username = "None", string password = "None", string user_file = "user.bin")
        {
            return 0;
        }

        /**
         * @brief This function changes password of user.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int user_change_password(string recovery_key = "None", string new_password = "None", string user_file = "user.bin")
        {
            return 0;
        }
        /**
        * @brief This function register records to service_history_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int register_service_history_record(string file_name = "service_history_records.bin", string vehicle_model = "None", int service_km = 1, string service_provider = "None", int service_cost = 1)
        {
            return 0;
        }

        /**
         * @brief This function edit the records in service_history_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int edit_service_history_record(string file_name = "service_history_records.bin", int line_number_to_edit = 0, string vehicle_model = "None", int service_km = 1, string service_provider = "None",int service_cost = 1)
        {
            return 0;
        }

        /**
         * @brief This function delete the records in service_history_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int delete_service_history_record(string file_name = "service_history_records.bin", int line_number_to_delete = 0)
        {
            return 0;
        }
        /**
        * @brief This function register records to expense_logging_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int RegisterExpenseRecord(string fileName = "expense_logging_records.bin", string carModel = "None", string expenseDate = "None", string expenseType = "None", int expense = 1) {
            string record;

            if (carModel == "None" && expenseDate == "None" && expense == 1 && expenseType == "None")
            {
                Console.WriteLine("What is the model of the car?");
                carModel = Console.ReadLine();
                Console.WriteLine("What is the expense date?");
                expenseDate = Console.ReadLine();
                Console.WriteLine("What is the expenseType");
                expenseType = Console.ReadLine();

                if (!int.TryParse(Console.ReadLine(), out expense))
                {
                    Console.WriteLine("Please use an integer");
                    return -1;
                }
            }

            record = $"{carModel} {expenseDate} {expenseType} {expense} ";
            if (FileWrite(fileName, record) == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        /**
        * @brief This function edit records to expense_logging_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
         */
        public int EditExpenseRecord(string fileName = "expense_logging_records.bin", int lineNumbertoEdit = 0, string carModel = "None", string expenseDate = "None", string expenseType = "None", int expense = 1)
        {
            string record;

            if (carModel == "None" && expenseDate == "None" && lineNumbertoEdit == 0 && expense == 1 && expenseType == "None") {
                Console.WriteLine("Which do you want to edit");
                lineNumbertoEdit = int.Parse(Console.ReadLine());

                if (!int.TryParse(Console.ReadLine(), out lineNumbertoEdit)) {
                    Console.WriteLine("Please use an integer");
                    return -1;
                }
                Console.WriteLine("What is the model of the car?");
                carModel = Console.ReadLine();
                Console.WriteLine("What is the expense date?");
                expenseDate = Console.ReadLine();
                Console.WriteLine("What is the expenseType");
                expenseType = Console.ReadLine();

                if (!int.TryParse(Console.ReadLine(), out expense)) {
                    Console.WriteLine("Please use an integer");
                    return -1;
                }
            }

            record = $"{carModel} {expenseDate} {expenseType} {expense} ";

            if (FileEdit(fileName, lineNumbertoEdit, record) == 0) {
                return 0;
            } else {
                return -1;
            }
        }
        /**
        * @brief This function delete records to expense_logging_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int DeleteExpenseRecord(string fileName = "expense_logging_records.bin", int lineNumbertoDelete = 0)
        {
            if (lineNumbertoDelete == 0)
            {
                Console.WriteLine("Which do you want to delete?");
                lineNumbertoDelete = int.Parse(Console.ReadLine());

                if (int.TryParse(Console.ReadLine(), out lineNumbertoDelete))
                {
                    Console.WriteLine("Please use an integer");
                    return -1;
                }
            }

            if (FileLineDelete(fileName, lineNumbertoDelete) == 0)
            {
                return 0;
            } else {
                return -1;

            }
        }
        /**
        * @brief This function register records to maintenance_reminder_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int register_maintenance_reminder_record(string file_name = "maintenance_reminder_records.bin", string vehicle_model = "None", int service_km = 1, string service_type = "None")
        {
            return 0;
        }

        /**
         * @brief This function edit the records in maintenance_reminder_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int edit_maintenance_reminder_record(string file_name = "maintenance_reminder_records.bin", int line_number_to_edit = 0, string vehicle_model = "None", int service_km = 1,string service_type = "None")
        {
            return 0;
        }

        /**
         * @brief This function delete the records in maintenance_reminder_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int delete_maintenance_reminder_record(string file_name = "maintenance_reminder_records.bin", int line_number_to_delete = 0)
        {
            return 0;
        }
        /**
        * @brief This function register records to fuel_efficiency_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
*/
        public int register_fuel_efficiency_record(string file_name = "fuel_efficiency_records.bin", string car_model = "None", float fuel_consumed = 1.0f, float road_traveled = 1.0f)
        {
            return 0;
        }

        /**
        * @brief This function edit the records in fuel_efficiency_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
*/
        public int edit_fuel_efficiency_record(string file_name = "fuel_efficiency_records.bin", int line_number_to_edit = 0, string car_model = "None", float fuel_consumed = 1.0f, float road_traveled = 1.0f)
        {
            return 0;
        }

        /**
        * @brief This function delete the records in fuel_efficiency_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
*/
        public int delete_fuel_efficiency_record(string file_name = "fuel_efficiency_records.bin", int line_number_to_delete = 0)
        {
            return 0;
        }
    }
}
