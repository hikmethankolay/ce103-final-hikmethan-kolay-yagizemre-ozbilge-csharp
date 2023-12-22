/**
 * @file CarMaintenance.cs
 *
 * @brief Provides functions for file operations
 */

/**
* 
*@brief Imports Text Class from System Namespace for file operations.
*
*/
using System.Text;

/**
* @brief Namespace CarMaintenanceLibrary for Functions.
*
*/
namespace CarMaintenanceLibrary {


    /**
    * @brief Class CarMaintenance for Functions
    *
    */
    public class CarMaintenance
    {
        /**
         * Open a FileStream object named myFile.
         *
         */
        private FileStream? myFile; // FileStream object for file operations

        /**
         * Opens a binary file, deletes all of its content, and writes given text to it.
         *
         * @param FileName The name of the file to write.
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
        * @param FileName The name of the file to read from.
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
        * @param FileName The name of the file to append to.
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
        * @param fileName The name of the file to edit.
        * @param lineNumberToEdit The line number to edit.
        * @param newLine The new text to replace the existing line.
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
        * @param fileName The name of the file to delete the line from.
        * @param LineNumberToDelete The line number to delete.
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
        public int UserRegister(string? newUsername, string? newPassword, string? newRecoveryKey, string userFile = "user.bin")
        {
            string loginInfo;
            loginInfo = $"{newUsername}/{newPassword}/{newRecoveryKey}";

            using (myFile = new FileStream(userFile, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter streamWriter = new StreamWriter(myFile))
                {
                    streamWriter.Write(loginInfo);
                }
            }

            File.Delete("service_history_records.bin");
            File.Delete("maintenance_reminder_records.bin");
            File.Delete("expense_records.bin");
            File.Delete("fuel_efficiency_records.bin");

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
        public int UserLogin(string? username, string? password, string? userFile = "user.bin")
        {
            string usernameRead = "";
            string passwordRead = "";
            int count = 0;

            if (!File.Exists(userFile))
            {
                Console.WriteLine("There is no user info. Please register first.");
                return -1;
            }

            using (myFile = new FileStream(userFile, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(myFile))
                {
                    while (!streamReader.EndOfStream){ // Reading until the end of the file
                        char i = (char)streamReader.Read();
                        if (i == '/')
                        {
                            count++;
                            continue;
                        }

                        if (count == 0)
                        {
                            usernameRead += i;
                        }
                        else if (count == 1)
                        {
                            passwordRead += i;
                        }
                        else if (count == 2)
                        {
                            break;
                        }
                    }
                }
            }

            if (username == usernameRead && password == passwordRead)
            {
                Console.WriteLine("Login Succesfull");
                return 0;
            }
            else
            {
                Console.WriteLine("Wrong username or password");
                return -1;
            }
        }


        /**
         * @brief This function changes password of user.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int UserChangePassword(string? recoveryKey, string? newPassword, string? userFile = "user.bin")
        {
            string usernameRead = "";
            string recoveryKeyRead = "";
            string newLoginInfo;
            int count = 0;

            if (!File.Exists(userFile))
            {
                Console.WriteLine("There is no user info. Please register first.");
                return -1;
            }

            using (myFile = new FileStream(userFile, FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader streamReader = new StreamReader(myFile))
                {
                    while (!streamReader.EndOfStream){ // Reading until the end of the file 
                        char i = (char)streamReader.Read();
                        if (i == '/')
                        {
                            count++;
                            continue;
                        }

                        if (count == 0)
                        {
                            usernameRead += i;
                        }
                        else if (count == 1)
                        {
                            // Skipping password field
                            continue;
                        }
                        else if (count == 2)
                        {
                            recoveryKeyRead += i;
                        }
                    }
                }
            }

            if (recoveryKeyRead == recoveryKey)
            {
                Console.WriteLine("Recovery Key Approved");

                newLoginInfo = $"{usernameRead}/{newPassword}/{recoveryKeyRead}";

                using (FileStream fileStream = new FileStream(userFile, FileMode.Open, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write(newLoginInfo);
                    }
                }

                Console.WriteLine("Password changed successfully");
                return 0;
            }
            else
            {
                Console.WriteLine("Wrong Recovery Key");
                return -1;
            }
        }

        /**
        * @brief This function register records to service_history_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int RegisterServiceHistoryRecord(string? vehicleModel,int serviceKm,string? serviceProvider,int serviceCost,string fileName = "service_history_records.bin")
        {
            string record;

            record = $"{vehicleModel}   {serviceKm}   {serviceProvider}   {serviceCost}";
            if (File.Exists(fileName))
            {
                FileAppend(fileName, record);
                return 0;
            }
            else
            {
                FileWrite(fileName, "VEHICLE MODEL | SERVICE KM | SERVICE PROVIDER | SERVICE COST");
                FileAppend(fileName, record);
                return 0;
            }
        }

        /**
         * @brief This function edit the records in service_history_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int EditServiceHistoryRecord(int lineNumberToEdit,string? vehicleModel,int serviceKm,string? serviceProvider,int serviceCost,string fileName = "service_history_records.bin")
        {
            string record;

            record = $"{vehicleModel}   {serviceKm}   {serviceProvider}   {serviceCost}";

            if (FileEdit(fileName, lineNumberToEdit, record) == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        /**
         * @brief This function delete the records in service_history_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int DeleteServiceHistoryRecord(int lineNumberToDelete,string fileName = "service_history_records.bin")
        {
            if (FileLineDelete(fileName, lineNumberToDelete) == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        /**
        * @brief This function register records to expense_logging_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int RegisterExpenseRecord(string? carModel, string? expenseDate, string? expenseType, int expense,string fileName = "expense_logging_records.bin") {
            string record;

            record = $"{carModel}   {expenseDate}   {expenseType}   {expense}";

            if (File.Exists(fileName))
            {
                FileAppend(fileName, record);
                return 0;
            }
            else
            {
                FileWrite(fileName, "CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE");
                FileAppend(fileName, record);
                return 0;
            }
        }
        /**
        * @brief This function edit records to expense_logging_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
         */
        public int EditExpenseRecord(int lineNumbertoEdit,string? carModel, string? expenseDate, string? expenseType, int expense, string fileName = "expense_logging_records.bin")
        {
            string record;

            record = $"{carModel}   {expenseDate}   {expenseType}   {expense}";

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
        public int DeleteExpenseRecord(int lineNumbertoDelete,string fileName = "expense_logging_records.bin")
        {

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
        public int RegisterMaintenanceReminderRecord(string? vehicleModel, int serviceKm, string? ServiceType, string fileName = "maintenance_reminder_records.bin")
        {
            string record;

            record = $"{vehicleModel}   {serviceKm}   {ServiceType}";

            if (File.Exists(fileName))
            {
                FileAppend(fileName, record);
                return 0;
            }
            else
            {
                FileWrite(fileName, "VEHICLE MODEL | SERVICE KM | PLANNED SERVICE TYPE");
                FileAppend(fileName, record);
                return 0;
            }
        }

        /**
         * @brief This function edit the records in maintenance_reminder_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int EditMaintenanceReminderRecord(int lineNumbertoEdit, string? vehicleModel, int serviceKm, string? ServiceType, string fileName = "maintenance_reminder_records.bin")
        {
            string record;

            record = $"{vehicleModel}   {serviceKm}   {ServiceType}";
            
            if (FileEdit(fileName, lineNumbertoEdit, record) == 0)
            {
                return 0;
            } else {
                return -1;

            }
        }

        /**
         * @brief This function delete the records in maintenance_reminder_records.bin.
         *
         *
         * @return 0 on success.
         * @return -1 on fail.
         */
        public int DeleteMaintenanceReminderRecord(int lineNumbertoDelete, string fileName = "maintenance_reminder_records.bin")
        {

            if (FileLineDelete(fileName, lineNumbertoDelete) == 0)
            {
                return 0;
            } else {
                return -1;

            }
        }
        /**
        * @brief This function register records to fuel_efficiency_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int RegisterFuelEfficiencyRecord(string? carModel , float fuelConsumed, float roadTraveled, string fileName = "fuel_efficiency_records.bin")
        {
            string record;

            float efficiency = (fuelConsumed / roadTraveled) * 100;
            record = $"{carModel}   {efficiency}";
            if (File.Exists(fileName))
            {
                FileAppend(fileName, record);
                return 0;
            }
            else
            {
                FileWrite(fileName, "CAR MODEL | FUEL CONSUMED(L/100KM)");
                FileAppend(fileName, record);
                return 0;
            }
        }

        /**
        * @brief This function edit the records in fuel_efficiency_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int EditFuelEfficiencyRecord(int lineNumberToEdit, string? carModel, float fuelConsumed, float roadTraveled, string fileName = "fuel_efficiency_records.bin")
        {
            string record;

            float efficiency = (fuelConsumed / roadTraveled) * 100;
            record = $"{carModel}   {efficiency}";

            if(FileEdit(fileName, lineNumberToEdit, record) == 0)
            {
               return 0;

            } 
            else 
            {
                return -1;
            }
        }

        /**
        * @brief This function delete the records in fuel_efficiency_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int DeleteFuelEfficiencyRecord(int lineNumberToDelete,string fileName = "fuel_efficiency_records.bin")
        {
          if (FileLineDelete(fileName, lineNumberToDelete) == 0)
          {
              return 0;
          } 
          else 
          {
             return -1;
          }
        }
    }
}

