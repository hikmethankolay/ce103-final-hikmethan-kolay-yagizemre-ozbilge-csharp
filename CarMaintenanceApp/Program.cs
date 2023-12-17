using CarMaintenanceLibrary;
using System;
using System.IO;

class Program
{
    static FileStream? File;

    static void Main()
    {
        bool run = true;

        do
        {
            int login_menu;
            int main_menu;
            int service_menu;
            int maintenance_reminder_menu;
            int expense_menu;
            int fuel_efficiency_menu;
            int reminder_count = 0;

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
                    if (car.UserLogin() == 0)
                    {
                        bool run_2 = true;

                        do
                        {
                            if (reminder_count == 0)
                            {
                                File = new FileStream("maintenance_reminder_records.bin", FileMode.Open, FileAccess.Read);
                                if (File != null)
                                {
                                    Console.WriteLine("\n------------You Have Scheduled Maintenance------------");
                                    car.FileRead("maintenance_reminder_records.bin");
                                    Console.WriteLine("-------------------------------------------------------");
                                    File.Close();
                                    reminder_count++;
                                }
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
                                        //RegisterServiceHistoryRecord();
                                        continue;
                                    }
                                    else if (service_menu == 3)
                                    {
                                        //EditServiceHistoryRecord();
                                        continue;
                                    }
                                    else if (service_menu == 4)
                                    {
                                        //DeleteServiceHistoryRecord();
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
                                        //RegisterMaintenanceReminderRecord();
                                        continue;
                                    }
                                    else if (maintenance_reminder_menu == 3)
                                    {
                                        //EditMaintenanceReminderRecord();
                                        continue;
                                    }
                                    else if (maintenance_reminder_menu == 4)
                                    {
                                        //DeleteMaintenanceReminderRecord();
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
                                        car.RegisterExpenseRecord();
                                        continue;
                                    }
                                    else if (expense_menu == 3)
                                    {
                                        car.EditExpenseRecord();
                                        continue;
                                    }
                                    else if (expense_menu == 4)
                                    {
                                        car.DeleteExpenseRecord();
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
                                        //RegisterFuelEfficiencyRecord();
                                        continue;
                                    }
                                    else if (fuel_efficiency_menu == 3)
                                    {
                                        //EditFuelEfficiencyRecord();
                                        continue;
                                    }
                                    else if (fuel_efficiency_menu == 4)
                                    {
                                        //DeleteFuelEfficiencyRecord();
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
                    car.UserRegister();
                    continue;

                case 3:
                    car.UserChangePassword();
                    continue;

                case 4:
                    run = false;
                    break;

                default:
                    continue;
            }
        } while (run);

        Console.ReadLine();
    }
}