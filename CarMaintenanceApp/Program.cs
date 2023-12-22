/**
 * @file Program.cs
 *
 * @brief Main app source code
 */

/**
* @brief Necessary namespaces for main app.
*
*/
using CarMaintenanceLibrary;
/**
* @brief Necessary namespaces for main app.
*
*/
using System;
/**
* @brief Necessary namespaces for main app.
*
*/
using System.IO;

#pragma warning disable CS8604 // Possible null reference argument.
/**
* @brief Main apps Class
*
*/
class Program
{
    /**
    * @brief Main app fucntion
    *
    */
    static int Main()
    {
        int login_menu;
        int main_menu;
        int service_menu;
        int maintenance_reminder_menu;
        int expense_menu;
        int fuel_efficiency_menu;
        int reminder_count = 0;
        bool run = true;
        string? newUsername;
        string? newPassword;
        string? newRecoveryKey;
        string? choice;
        string? username;
        string? password;

        do
        {
            Console.WriteLine("----------Login----------");
            Console.WriteLine("1-)Login");
            Console.WriteLine("2-)Register");
            Console.WriteLine("3-)Change Password");
            Console.WriteLine("4-)Exit");
            Console.Write("Make a choice(1-4): ");

            login_menu = int.Parse(Console.ReadLine());
            CarMaintenance car = new CarMaintenance();
            switch (login_menu)
            {
                
                case 1:
                    Console.WriteLine("Please enter username:");
                    username = Console.ReadLine();
                    Console.WriteLine("Please enter password:");
                    password = Console.ReadLine();

                    if (car.UserLogin(username, password) == 0)
                    {
                        bool run_2 = true;

                        do
                        {
                            if (File.Exists("maintenance_reminder_records.bin") && reminder_count == 0)
                            {
                                Console.WriteLine("\n------------You Have Scheduled Maintenance-------------");
                                car.FileRead("maintenance_reminder_records.bin");
                                Console.WriteLine("-------------------------------------------------------");
                                reminder_count++;
                            }
                            


                            Console.WriteLine("\n----------Main Menu----------");
                            Console.WriteLine("1-)Service History Tracking");
                            Console.WriteLine("2-)Maintenance Reminders");
                            Console.WriteLine("3-)Expense Logging");
                            Console.WriteLine("4-)Fuel Efficiency Reports");
                            Console.WriteLine("5-)Back to login menu");
                            Console.Write("Make a choice(1-5): ");
                            main_menu = int.Parse(Console.ReadLine());


                            switch (main_menu)
                            {
                                case 1:
                                    string? vehicleModel;
                                    int serviceKm;
                                    string? serviceProvider;
                                    int serviceCost;
                                    int lineNumberToEdit;
                                    int lineNumberToDelete;


                                    Console.WriteLine("\n----------Service History Tracking----------");
                                    Console.WriteLine("1-)Show Service History Record");
                                    Console.WriteLine("2-)Register Service History Record");
                                    Console.WriteLine("3-)Edit Service History Record");
                                    Console.WriteLine("4-)Delete Service History Record");
                                    Console.WriteLine("5-)Previous Menu");
                                    Console.Write("Make a choice(1-5): ");
                                    service_menu = int.Parse(Console.ReadLine());

                                    if (service_menu == 1)
                                    {
                                        Console.WriteLine("-------------------------------------------------------");
                                        car.FileRead("service_history_records.bin");
                                        Console.WriteLine("-------------------------------------------------------");
                                        continue;
                                    }
                                    else if (service_menu == 2)
                                    {
                                        Console.Write("What is the model of vehicle? ");
                                        vehicleModel = Console.ReadLine();

                                        Console.Write("What is the service KM? ");
                                        if (!int.TryParse(Console.ReadLine(), out serviceKm))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }

                                        Console.Write("Who is the service provider? ");
                                        serviceProvider = Console.ReadLine();

                                        Console.Write("What is the service cost? ");
                                        if (!int.TryParse(Console.ReadLine(), out serviceCost))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }

                                        car.RegisterServiceHistoryRecord(vehicleModel,serviceKm,serviceProvider,serviceCost);
                                        continue;
                                    }
                                    else if (service_menu == 3)
                                    {

                                        Console.Write("Which line do you want to edit? ");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToEdit))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }

                                        Console.Write("What is the model of vehicle? ");
                                        vehicleModel = Console.ReadLine();

                                        Console.Write("What is the service KM? ");
                                        if (!int.TryParse(Console.ReadLine(), out serviceKm))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }

                                        Console.Write("Who is the service provider? ");
                                        serviceProvider = Console.ReadLine();

                                        Console.Write("What is the service cost? ");
                                        if (!int.TryParse(Console.ReadLine(), out serviceCost))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }

                                        car.EditServiceHistoryRecord(lineNumberToEdit,vehicleModel,serviceKm,serviceProvider,serviceCost);
                                        continue;
                                    }
                                    else if (service_menu == 4)
                                    {
                                        Console.Write("Which line do you want to delete? ");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToDelete))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }

                                        car.DeleteServiceHistoryRecord(lineNumberToDelete);
                                        continue;
                                    }
                                    else if (service_menu == 5)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                case 2:
                                    string? ServiceType;

                                    Console.WriteLine("\n----------Maintenance Reminder Records----------");
                                    Console.WriteLine("1-)Show Maintenance Reminder Records");
                                    Console.WriteLine("2-)Register Maintenance Reminder Records");
                                    Console.WriteLine("3-)Edit Maintenance Reminder Records");
                                    Console.WriteLine("4-)Delete Maintenance Reminder Records");
                                    Console.WriteLine("5-)Previous Menu");
                                    Console.Write("Make a choice(1-5): ");
                                    maintenance_reminder_menu = int.Parse(Console.ReadLine());

                                    if (maintenance_reminder_menu == 1)
                                    {
                                        Console.WriteLine("-------------------------------------------------------");
                                        car.FileRead("maintenance_reminder_records.bin");
                                        Console.WriteLine("-------------------------------------------------------");
                                        continue;
                                    }
                                    else if (maintenance_reminder_menu == 2)
                                    {
                                        Console.Write("What is the model of vehicle? ");
                                        vehicleModel = Console.ReadLine();

                                        Console.Write("What is the service KM? ");
                                        if (!int.TryParse(Console.ReadLine(), out serviceKm))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }

                                        Console.Write("Who is the planned service type? ");
                                        ServiceType = Console.ReadLine();

                                        car.RegisterMaintenanceReminderRecord(vehicleModel, serviceKm, ServiceType);
                                        continue;
                                    }
                                    else if (maintenance_reminder_menu == 3)
                                    {
                                        Console.WriteLine("Which do you want to edit");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToEdit))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }

                                        Console.Write("What is the model of vehicle? ");
                                        vehicleModel = Console.ReadLine();

                                        Console.Write("What is the service KM? ");
                                        if (!int.TryParse(Console.ReadLine(), out serviceKm))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }

                                        Console.Write("Who is the planned service type? ");
                                        ServiceType = Console.ReadLine();
                                        car.EditMaintenanceReminderRecord(lineNumberToEdit, vehicleModel, serviceKm, ServiceType);
                                        continue;
                                    }
                                    else if (maintenance_reminder_menu == 4)
                                    {
                                        Console.Write("Which line do you want to delete? ");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToDelete))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }
                                        car.DeleteMaintenanceReminderRecord(lineNumberToDelete);
                                        continue;
                                    }
                                    else if (maintenance_reminder_menu == 5)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                case 3:
                                    
                                    string? carModel;
                                    string? expenseType;
                                    string? expenseDate;
                                    int expense;
                                    

                                    Console.WriteLine("\n----------Expense Tracking Records----------");
                                    Console.WriteLine("1-)Show Expense Tracking Records");
                                    Console.WriteLine("2-)Register Expense Tracking Records");
                                    Console.WriteLine("3-)Edit Expense Tracking Records");
                                    Console.WriteLine("4-)Delete Expense Tracking Records");
                                    Console.WriteLine("5-)Previous Menu");
                                    Console.Write("Make a choice(1-5): ");
                                    expense_menu = int.Parse(Console.ReadLine());

                                    if (expense_menu == 1)
                                    {
                                        Console.WriteLine("-------------------------------------------------------");
                                        car.FileRead("expense_logging_records.bin");
                                        Console.WriteLine("-------------------------------------------------------");
                                        continue;
                                    }
                                    else if (expense_menu == 2)
                                    {
                                        Console.WriteLine("What is the model of the car?");
                                        carModel = Console.ReadLine();
                                        Console.WriteLine("What is the expense date?");
                                        expenseDate = Console.ReadLine();
                                        Console.WriteLine("What is the expense type?");
                                        expenseType = Console.ReadLine();
                                        Console.WriteLine("How much is the expense?");
                                        if (!int.TryParse(Console.ReadLine(), out expense))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }

                                        car.RegisterExpenseRecord(carModel, expenseDate, expenseType, expense);
                                        continue;
                                    }
                                    else if (expense_menu == 3)
                                    {
                                        Console.WriteLine("Which do you want to edit");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToEdit))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }
                                        Console.WriteLine("What is the model of the car?");
                                        carModel = Console.ReadLine();
                                        Console.WriteLine("What is the expense date?");
                                        expenseDate = Console.ReadLine();
                                        Console.WriteLine("What is the expenseType");
                                        expenseType = Console.ReadLine();
                                        Console.WriteLine("How much is the expense?");
                                        if (!int.TryParse(Console.ReadLine(), out expense))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }

                                        car.EditExpenseRecord(lineNumberToEdit, carModel, expenseDate, expenseType, expense);
                                        continue;
                                    }
                                    else if (expense_menu == 4)
                                    {
                                        Console.Write("Which line do you want to delete? ");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToDelete))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }

                                        car.DeleteExpenseRecord(lineNumberToDelete);
                                        continue;
                                    }
                                    else if (expense_menu == 5)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                case 4:
                                    float fuelConsumed;
                                    float roadTraveled;

                                    Console.WriteLine("\n----------Fuel Efficiency Records----------");
                                    Console.WriteLine("1-)Show Fuel Efficiency Records");
                                    Console.WriteLine("2-)Register Fuel Efficiency Records");
                                    Console.WriteLine("3-)Edit Fuel Efficiency Records");
                                    Console.WriteLine("4-)Delete Fuel Efficiency Records");
                                    Console.WriteLine("5-)Previous Menu");
                                    Console.Write("Make a choice(1-5): ");
                                    fuel_efficiency_menu = int.Parse(Console.ReadLine());

                                    if (fuel_efficiency_menu == 1)
                                    {
                                        Console.WriteLine("-------------------------------------------------------");
                                        car.FileRead("fuel_efficiency_records.bin");
                                        Console.WriteLine("-------------------------------------------------------");
                                        continue;
                                    }
                                    else if (fuel_efficiency_menu == 2)
                                    {
                                        Console.WriteLine("What is the model of the car?");
                                        carModel = Console.ReadLine();

                                        if (!float.TryParse(Console.ReadLine(), out fuelConsumed))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }

                                        if (!float.TryParse(Console.ReadLine(), out roadTraveled))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }
                                        car.RegisterFuelEfficiencyRecord(carModel, fuelConsumed, roadTraveled);
                                        continue;
                                    }
                                    else if (fuel_efficiency_menu == 3)
                                    {
                                        Console.WriteLine("Which do you want to edit?");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToEdit))
                                        {
                                            Console.WriteLine("Please use an integer");
                                            continue;
                                        }

                                        Console.WriteLine("What is the model of the car?");
                                        carModel = Console.ReadLine();
                                        Console.WriteLine("What is the fuel consumed");

                                        if (!float.TryParse(Console.ReadLine(), out fuelConsumed))
                                        {
                                            Console.WriteLine("Please use a float");
                                            continue;
                                        }

                                        Console.WriteLine("What is the road traveled");
                                        if (!float.TryParse(Console.ReadLine(), out roadTraveled))
                                        {
                                            Console.WriteLine("Please use a float");
                                           continue;
                                        }
                                        car.EditFuelEfficiencyRecord(lineNumberToEdit, carModel, fuelConsumed, roadTraveled);
                                        continue;
                                    }
                                    else if (fuel_efficiency_menu == 4)
                                    {
                                        Console.Write("Which line do you want to delete? ");
                                        if (!int.TryParse(Console.ReadLine(), out lineNumberToDelete))
                                        {
                                            Console.WriteLine("Please use an integer.");
                                            continue;
                                        }
                                        car.DeleteFuelEfficiencyRecord(lineNumberToDelete);
                                        continue;
                                    }
                                    else if (fuel_efficiency_menu == 5)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                case 5:
                                    run_2 = false;
                                    break;

                                default:
                                    break;
                            }
                        } while (run_2);
                    }
                    else
                    {
                        continue;
                    }

                    break;

                case 2:

                    Console.Write("Do you understand that if you create a new account all the records that have been saved so far will be deleted?[Y/N]: ");
                    choice = Console.ReadLine();
                    if (choice == "Y")
                    {
                        Console.WriteLine("Please enter a new username: ");
                        newUsername = Console.ReadLine();
                        Console.WriteLine("Please enter a new password: ");
                        newPassword = Console.ReadLine();
                        Console.WriteLine("\nWARNING!!!\nYou will use this to change password if needed, if you lost this you can't access logs without them being completely deleted\nWARNING!!!\n");
                        Console.WriteLine("Please enter a new recovery key: ");
                        newRecoveryKey = Console.ReadLine();
                        car.UserRegister(newUsername, newPassword, newRecoveryKey);
                    }

                    continue;
                case 3:
                    string? recoveryKey;
                    string? ChangedPassword;

                    Console.Write("Please enter your recovery key: ");
                    recoveryKey = Console.ReadLine();

                    Console.Write("Please enter a new password: ");
                    ChangedPassword = Console.ReadLine();

                    car.UserChangePassword(recoveryKey, ChangedPassword);
                    continue;

                case 4:
                    run = false;
                    break;

                default:
                    continue;
            }
        } while (run);

        return 0;
    }
}