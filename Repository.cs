using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module_11
{
    public class Repository
    {
        public List<Client> ClientsDB { get; set; } //база клиентов
        public List<Department> DepartmentDB { get; set; } //база департаментов

        private Repository()
        {
            ClientsDB = new List<Client>(); //создание новой базы клиентов
            DepartmentDB = new List<Department>(); //создание новой базы департаментов

            DepartmentDB.Add(new Department("Клиенты", 1));
            ClientsDB.Add(new Client(1, "Степанов", "Дмитрий", "Васильевич", "89548654475", "2019224451", 1));
            ClientsDB.Add(new Client(2, "Васильев", "Степан", "Дмитриевич", "89315745587", "2021542156", 1));
            ClientsDB.Add(new Client(3, "Иванов", "Василий", "Стапанович", "89648552154", "2011224585", 1));

            DepartmentDB.Add(new Department("Контрагенты", 2));
            ClientsDB.Add(new Client(4, "Потапов", "Александ", "Сергеевич", "89167581453", "2013524541", 2));
            ClientsDB.Add(new Client(5, "Фролов", "Артём", "Фёдорович", "89505475685541", "2012568545", 2));
        }

        public static Repository CreateRepository() //создание репозитория с базами
        {
            return new Repository();
        }

        public void DepAdd(string depname, int depnum) //метод добавления нового департамента в базу
        {
            DepartmentDB.Add(new Department(depname, depnum));
        }

        public void ClientAdd(int clientid, string surname, string name, string patronimic, string phone, string passport, int depid) //метод добавления нового клиента в базу
        {
            ClientsDB.Add(new Client(clientid, surname, name, patronimic, phone, passport, depid));
        }

    }
}
