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
        static int register_expense_record(string file_name, string car_model, string expense_date, string expense_type, int expense)
        {
            string record;

            if (car_model == "None" && expense_date == "None" && expense == 1 && expense_type == "None")
            {
                Console.WriteLine( "What is model of the car?");
                car_model = Console.Readline();
                Console.WriteLine ("What is the expense date?");
                expense_date = Console.Readline();
                Console.WriteLine("What is the expense type?");
                expense_type = Console.Readline();
                cout << ("What is the expense cost?");
                cin >> expense;

                if (!int.TryParse(Console.ReadLine(), out expense))
                {
                    Console.WriteLine("Please use an integer");
                    return -1;
                }
            }

            record = $"{car_model}    {expense_date}   {expense_type}    {expense}";
            using(StreamWriter myFile = new StreamWriter(file_name, true))
            { 
            if (!File.Exists(file_name))
            {
                File.WriteLine(file_name, "CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE");
                File.AppendLine(file_name, record);
                return 0;
            }
            else
            {
                myFile.close();
                File.AppendLine(file_name, record);
            }

            return 0;
        }
        
