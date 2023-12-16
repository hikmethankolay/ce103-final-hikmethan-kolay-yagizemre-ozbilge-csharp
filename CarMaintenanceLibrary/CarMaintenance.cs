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
 static int RegisterExpsenseRecord(string filename, string carModel, string expenseDate, string expenseType, int expense) {
 string record;

 if (carModel == "None" && expenseDate == "None" && expense == 1 && expenseType == "None")
 {
 Console.WriteLine("What is the model of the car?");
 carModel = Console.ReadLine();
 Console.WriteLine("What is the expense date?");
 expenseDate = Console.ReadLine();
 Console.WriteLine("What is the expenseType");
 expenseType = Console.ReadLine();

 if (!int.TryParse(Console.Readline(), out expense)
 {
 Console.WriteLine("Please use an integer");
  return -1;
 }
}

 record = $"{carModel} {expenseDate} {expenseType} {expense} ";

 using (StreamWriter myFile = new StreamWriter(fileName, true))
 {
  FileWrite(filename, "CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE");
  }


  myFile.WriteLine(record);

  }
        return 0;
}

 /**
 * @brief This function edit records to expense_logging_records.bin.
 *
 *
 * @return 0 on success.
 * @return -1 on fail.
 */
 static int EditExpsenseRecord(string filename,int linenumbertoEdit, string carModel, string expenseDate, string expenseType, int expense)
  {
  string record;

            if (carModel == "None" && expenseDate == "None" && linenumbertoEdit == 0 && expense == 1 && expenseType == "None") {
            Console.WriteLine("Which do you want to edit");
            linenumbertoEdit = int.Parse(Console.ReadLine());

            if (!int.TryParse(Console.ReadLine(), out linenumbertoEdit)) {
                Console.WriteLine("Please use an integer");
                return -1;
            }
            Console.WriteLine("What is the model of the car?");
            carModel = Console.ReadLine();
            Console.WriteLine("What is the expense date?");
            expenseDate = Console.ReadLine();
           Console.WriteLine("What is the expenseType");
           expenseType = Console.ReadLine();

            if (!int.TryParse(Console.Readline(), out expense) {
                Console.WriteLine("Please use an integer");
                return -1;
            }
      }

      record = $"{carModel} {expenseDate} {expenseType} {expense} ";

        if (FileEdit(filename, linenumbertoEdit, record) == 0) {
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
  static int DeleteExpenseRecord(string fileName, int linenumbertoDelete)
  {
        if(linenumbertoDelete == 0)
        {
            Console.WriteLine("Which do you want to delete?");
            linenumbertoDelete = int.Parse(Console.ReadLine());

            if(int.TryParse(Console.ReadLine(), out linenumbertoDelete))
            {
               Console.WriteLine("Please use an integer");
                return -1;
            }
        }

        if(FileLineDelete(fileName, linenumbertoDelete) == 0) 
        {
            return 0;
        } else {
            return -1;

        }
  }



