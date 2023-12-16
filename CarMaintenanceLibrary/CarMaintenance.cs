namespace CarMaintenanceLibrary {
    /// \brief A class for performing basic arithmetic operations.
    public class CarMaintenance {


























































































































































































































































































































































        
        /**
        * @brief This function register records to expense_logging_records.bin.
        *
        *
        * @return 0 on success.
        * @return -1 on fail.
        */
        public int RegisterExpsenseRecord(string fileName, string carModel, string expenseDate, string expenseType, int expense) {
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
        public int EditExpsenseRecord(string filename, int lineNumbertoEdit, string carModel, string expenseDate, string expenseType, int expense)
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

            if (FileEdit(filename, lineNumbertoEdit, record) == 0) {
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
        public int DeleteExpenseRecord(string fileName, int lineNumbertoDelete)
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
    }
}



