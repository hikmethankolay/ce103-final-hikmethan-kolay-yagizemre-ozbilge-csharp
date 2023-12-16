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
static int register_expense_record(string file_name, string car_model, string expense_date, string expense_type, int expense){
  string record;

 if (car_model == "None" && expense_date == "None" && expense == 1 && expense_type == "None")
  {
  FileWrite( "What is model of the car?");
  car_model = FileRead();
  FileWrite ("What is the expense date?");
  expense_date = FileRead();
  FileWrite("What is the expense type?");
  expense_type = FileRead();
  cout << ("What is the expense cost?");
  cin >> expense;

 if (!int.TryParse(FileRead(), out expense))
 {
  FileWrite("Please use an integer");
  return -1;
   }
 }

record = $"{car_model}    {expense_date}   {expense_type}    {expense}";
using(StreamWriter myFile = new StreamWriter(file_name, true))
{ 
  if (!File.Exists(file_name))
  {
  FileWrite(file_name, "CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE");
  FileAppend(file_name, record);
  return 0;
  } else {
  myFile.close();
  FileAppend(file_name, record);
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
static int edit_expense_record(string file_name,int line_number_to_edit, string car_model, string expense_date, string expense_type, int expense){
 string record;

if (car_model == "None" && expense_date == "None" && expense == 1 && expense_type == "None") {
 FileWrite("Which line do you want to edit?")
 line_number_to_edit = int.Parse(FileRead());

if (!int.TryParse(File.Read(), out line_number_to_edit)) {
  FileWrite("Please use an integer");
 return -1;
 }

FileWrite("What is model of the car?");
car_model = Console.WriteLine();
 FileWrite("What is the expense date?");
 expense_date = Console.WriteLine();
FileWrite("What is the expense type?");
 expense_type = Console.WriteLine();

if (!int.TryParse(FileRead(), out expense)) {
 FileWrite("Please use an integer");
 return -1;
  }
}
record = $"{car_model}    {expense_date}   {expense_type}    {expense}";
using (StreamWriter myFile = new StreamWriter(file_name, true))
{
 if (FileEdit(file_name, line_number_to_edit, record) == 0)
{
                       
  return 0;
} else {
 return -1;
}

/**
* @brief This function edit records to expense_logging_records.bin.
*
*
* @return 0 on success.
* @return -1 on fail.
*/
static int delete_expense_record(string file_name, int line_number_to_delete) {

if (line_number_to_delete == 0)
{
 Console.WriteLine("Which line do you want to delete?")
 line_number_to_delete = int.Parse(FileDelete());
 if (FileLineDelete(,file_name,line_number_to_delete) == 0){
 Console.WriteLine("Please use an integer");
 return -1;
 }
}

 if (FileDelete(file_name, line_number_to_delete) == 0)
 {
  return 0;
 } else {
 return -1;
 }
}
           



