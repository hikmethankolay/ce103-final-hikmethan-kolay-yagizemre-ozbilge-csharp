
using Xunit.Sdk;

namespace CarMaintenanceLibrary.Tests
{
    public class CarMaintenanceTests
    {
        private string? testString;
        private const int fail = -1;
        private const int success = 0;

        [Fact]
        public void TestFileRead()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)TEXT STRING0\n1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING3\n4-)TEXT STRING4\n";
            Assert.Equal(testString, car.FileRead("test1.bin"));
        }

        [Fact]
        public void TestFileAppend()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)TEXT STRING0\n1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING3\n4-)TEXT STRING4\n5-)TEXT STRING5\n";
            string appendString = "TEXT STRING5";
            car.FileAppend("test2.bin", appendString);
            Assert.Equal(testString, car.FileRead("test2.bin"));
        }

        [Fact]
        public void TestFileEdit()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)TEXT STRING0\n1-)TEXT STRING1\n2-)TEXT STRING2\n3-)TEXT STRING EDIT\n4-)TEXT STRING4\n";
            string editString = "TEXT STRING EDIT";
            car.FileEdit("test3.bin", 3, editString);
            Assert.Equal(testString, car.FileRead("test3.bin"));
        }

        [Fact]
        public void TestFileDelete()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)TEXT STRING0\n1-)TEXT STRING2\n2-)TEXT STRING3\n3-)TEXT STRING4\n";
            car.FileLineDelete("test4.bin", 1);
            Assert.Equal(testString, car.FileRead("test4.bin"));
        }

        [Fact]
        public void TestFileWrite()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)TEXT STRING WRITE\n";
            string writeString = "TEXT STRING WRITE";
            car.FileWrite("test5.bin", writeString);
            Assert.Equal(testString, car.FileRead("test5.bin"));
        }

        [Fact]
        public void TestFileReadFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal("-1", car.FileRead("test1f.bin"));
        }

        [Fact]
        public void TestFileAppendFail()
        {
            CarMaintenance car = new CarMaintenance();
            string appendString = "TEXT STRING5";
            Assert.Equal(fail, car.FileAppend("test2f.bin", appendString));
        }

        [Fact]
        public void TestFileEditFail()
        {
            CarMaintenance car = new CarMaintenance();
            string editString = "TEXT STRING EDIT";
            Assert.Equal(fail, car.FileEdit("test3f.bin", 3, editString));
        }

        [Fact]
        public void TestFileEditFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            string editString = "TEXT STRING EDIT";
            Assert.Equal(fail, car.FileEdit("test3.bin", 100, editString));
        }

        [Fact]
        public void TestFileDeleteFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.FileLineDelete("test4f.bin", 2));
        }

        [Fact]
        public void TestFileDeleteFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.FileLineDelete("test4.bin", 100));
        }

        [Fact]
        public void TestUserRegister()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "username/password/recoverykey";
            car.UserRegister("username", "password", "recoverykey", "usertest.bin");
            Assert.Equal(testString, car.FileRead("usertest.bin"));
        }

        [Fact]
        public void TestUserLogin()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(success, car.UserLogin("username", "password", "usertest_2.bin"));
        }

        [Fact]
        public void TestUserLoginFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.UserLogin("usernameaa", "passwordaa", "usertest_2.bin"));
        }

        [Fact]
        public void TestUserLoginFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.UserLogin("username", "password", "usertestfail.bin"));
        }

        [Fact]
        public void TestUserChangePassword()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(success, car.UserChangePassword("recoverykey", "newpassword", "usertest_3.bin"));
        }

        [Fact]
        public void TestUserChangePasswordFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.UserChangePassword("recoverykey", "newpassword", "usertestfail.bin"));
        }

        [Fact]
        public void TestUserChangePasswordFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.UserChangePassword("recoverykeyaaa", "newpassword", "usertest_3.bin"));
        }

        [Fact]
        public void TestRegisterExpense()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE\n1-)Audi   10/10/2023   Brake   15000\n";
            car.RegisterExpenseRecord("Audi", "10/10/2023", "Brake", 15000, "expense_logging_records_test.bin");
            Assert.Equal(testString, car.FileRead("expense_logging_records_test.bin"));
        }

        [Fact]
        public void TestRegisterExpense_2()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE\n1-)Audi   10/10/2023   Brake   15000\n2-)Ferrari   11/11/2023   Oil   19000\n";
            car.RegisterExpenseRecord("Ferrari", "11/11/2023", "Oil", 19000, "expense_logging_records_test_2.bin");
            Assert.Equal(testString, car.FileRead("expense_logging_records_test_2.bin"));
        }

        [Fact]
        public void TestEditExpense()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE\n1-)Mercedes   11/11/2023   Oil   17000\n";
            car.EditExpenseRecord(1, "Mercedes", "11/11/2023", "Oil", 17000, "expense_logging_records_test_3.bin");
            Assert.Equal(testString, car.FileRead("expense_logging_records_test_3.bin"));
        }

        [Fact]
        public void TestEditExpenseFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditExpenseRecord(1, "Audi", "10/10/2023", "Brake", 15000, "expense_logging_records_testaaa.bin"));
        }

        [Fact]
        public void TestEditExpenseFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditExpenseRecord(8, "Audi", "10/10/2023", "Brake", 15000, "expense_logging_records_test.bin"));
        }

        [Fact]
        public void TestDeleteExpense()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | EXPENSE DATE | EXPENSE TYPE | EXPENSE\n";
            car.DeleteExpenseRecord(1, "expense_logging_records_test_4.bin");
            Assert.Equal(testString, car.FileRead("expense_logging_records_test_4.bin"));
        }

        [Fact]
        public void TestDeleteExpenseFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteExpenseRecord(1,"expense_logging_records_testaaa.bin"));
        }

        [Fact]
        public void TestDeleteExpenseFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteExpenseRecord(7, "expense_logging_records_test.bin"));
        }

        [Fact]
        public void TestRegisterService()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | SERVICE PROVIDER | SERVICE COST\n1-)Audi   10500   Service   1500\n";
            car.RegisterServiceHistoryRecord("Audi", 10500, "Service", 1500, "service_history_test.bin");
            Assert.Equal(testString, car.FileRead("service_history_test.bin"));
        }

        [Fact]
        public void TestRegisterService_2()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | SERVICE PROVIDER | SERVICE COST\n1-)Audi   10500   Service   1500\n2-)Ferrari   12500   Service   1900\n";
            car.RegisterServiceHistoryRecord("Ferrari", 12500, "Service", 1900, "service_history_test_2.bin");
            Assert.Equal(testString, car.FileRead("service_history_test_2.bin"));
        }

        [Fact]
        public void TestEditService()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | SERVICE PROVIDER | SERVICE COST\n1-)Mercedes   12500   Service   1700\n";
            car.EditServiceHistoryRecord(1, "Mercedes", 12500, "Service", 1700, "service_history_test_3.bin");
            Assert.Equal(testString, car.FileRead("service_history_test_3.bin"));
        }

        [Fact]
        public void TestEditServiceFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditServiceHistoryRecord(1, "Mercedes", 12500, "Service", 1700, "service_history_testfail.bin"));
        }

        [Fact]
        public void TestEditServiceFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditServiceHistoryRecord(7, "Mercedes", 12500, "Service", 1700, "service_history_test.bin"));
        }

        [Fact]
        public void TestDeleteService()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | SERVICE PROVIDER | SERVICE COST\n";
            car.DeleteServiceHistoryRecord(1, "service_history_test_4.bin");
            Assert.Equal(testString, car.FileRead("service_history_test_4.bin"));
        }

        [Fact]
        public void TestDeleteServiceFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteServiceHistoryRecord(1, "service_history_testfail.bin"));
        }

        [Fact]
        public void TestDeleteServiceFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteServiceHistoryRecord(9,"service_history_test.bin"));
        }
        [Fact]
        public void TestRegisterFuel()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | FUEL CONSUMED(L/100KM)\n1-)BWM   5\n";
            car.RegisterFuelEfficiencyRecord("BWM", 50, 1000, "fuel_efficiency_records_test.bin");
            Assert.Equal(testString, car.FileRead("fuel_efficiency_records_test.bin"));

        }
        [Fact]
        public void TestRegisterFuel_2()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | FUEL CONSUMED(L/100KM)\n1-)BWM   5\n2-)Ferrari   8\n";
            car.RegisterFuelEfficiencyRecord("Ferrari", 80, 1000, "fuel_efficiency_records_test_2.bin");
            Assert.Equal(testString, car.FileRead("fuel_efficiency_records_test_2.bin"));
        }
        [Fact]
        public void TestEditFuel()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | FUEL CONSUMED(L/100KM)\n1-)Audi   6\n";
            car.EditFuelEfficiencyRecord(1, "Audi", 60, 1000, "fuel_efficiency_records_test_3.bin");
            Assert.Equal(testString, car.FileRead("fuel_efficiency_records_test_3.bin"));

        }
        [Fact]
        public void TestEditFuelFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditFuelEfficiencyRecord(1,"Mercedes",2.0f,2.0f, "fuel_efficiency_records_testaaa.bin"));

        }
        [Fact]
        public void TestEditFuelFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditFuelEfficiencyRecord(6,"Mercedes",2.0f,2.0f, "fuel_efficiency_records_test.bin"));

        }
        [Fact]
        public void TestDeleteFuel()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)CAR MODEL | FUEL CONSUMED(L/100KM)\n";
            car.DeleteFuelEfficiencyRecord(1, "fuel_efficiency_records_test_4.bin");
            Assert.Equal(testString, car.FileRead("fuel_efficiency_records_test_4.bin"));

        }
        [Fact]
        public void TestDeleteFuelFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteFuelEfficiencyRecord(1, "fuel_efficiency_records_testaaa.bin"));

        }
        [Fact]
        public void TestDeleteFuelFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteFuelEfficiencyRecord(5, "fuel_efficiency_records_test.bin"));

        }
        [Fact]
        public void TestRegisterReminder()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | PLANNED SERVICE TYPE\n1-)Audi   1000   Brake\n";
            car.RegisterMaintenanceReminderRecord("Audi",1000,"Brake", "reminder_logging_records_test.bin");
            Assert.Equal(testString, car.FileRead("reminder_logging_records_test.bin"));

        }
        [Fact]
        public void TestRegisterReminder_2()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | PLANNED SERVICE TYPE\n1-)Audi   1000   Brake\n2-)Ferrari   2000   Brake\n";
            car.RegisterMaintenanceReminderRecord("Ferrari",2000,"Brake", "reminder_logging_records_test_2.bin");
            Assert.Equal(testString, car.FileRead("reminder_logging_records_test_2.bin"));
        }

        [Fact]
        public void TestEditReminder()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | PLANNED SERVICE TYPE\n1-)Mercedes   1100   Oil\n";
            car.EditMaintenanceReminderRecord(1,"Mercedes", 1100, "Oil", "reminder_logging_records_test_3.bin");
            Assert.Equal(testString, car.FileRead("reminder_logging_records_test_3.bin"));
            
        }
        [Fact]
        public void TestEditReminderFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditMaintenanceReminderRecord(1,"Mercedes", 1100, "Oil", "reminder_logging_records_testaaa.bin"));

        }
        [Fact]
        public void TestEditReminderFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.EditMaintenanceReminderRecord(6,"Mercedes", 1100, "Oil", "reminder_logging_records_test.bin"));

        }
        [Fact]
        public void TestDeleteReminder()
        {
            CarMaintenance car = new CarMaintenance();
            testString = "0-)VEHICLE MODEL | SERVICE KM | PLANNED SERVICE TYPE\n";
            car.DeleteMaintenanceReminderRecord(1, "reminder_logging_records_test_4.bin");
            Assert.Equal(testString, car.FileRead("reminder_logging_records_test_4.bin"));

        }
        [Fact]
        public void TestDeleteReminderFail()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteMaintenanceReminderRecord(1, "reminder_logging_records_testaaaa.bin"));

        }
        [Fact]
        public void TestDeleteReminderFail_2()
        {
            CarMaintenance car = new CarMaintenance();
            Assert.Equal(fail, car.DeleteMaintenanceReminderRecord(6, "reminder_logging_records_test.bin"));

        }
    }
}
