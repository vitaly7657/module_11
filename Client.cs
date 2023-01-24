using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace module_11
{
    public class Client
    {
        int clientID;
        int departamentID;
        string surname;
        string name;
        string patronymic;
        string phoneNumber;
        string passport;

        public Client(int ClientID, string Surname, string Name, string Patronymic, string PhoneNumber, string Passport, int DepartamentID)
        {
            this.clientID = ClientID;
            this.surname = Surname;
            this.name = Name;
            this.patronymic = Patronymic;
            this.phoneNumber = PhoneNumber;
            this.passport = Passport;
            this.departamentID = DepartamentID;
        }
        public int ClientID
        {
            get { return clientID; }
        }
        public int DepartamentID
        {
            get { return departamentID; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }
        public override string ToString() //формат вывода клиента
        {
            return $"{this.ClientID} {this.Surname} {this.Name} {this.Patronymic} {this.PhoneNumber} {this.Passport}";
        }
    }
}
