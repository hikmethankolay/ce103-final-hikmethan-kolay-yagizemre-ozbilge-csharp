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
  


