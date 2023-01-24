using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;



namespace module_11
{
    public partial class MainWindow : Window
    {
        Repository clientsData; //объявление клиентской базы репозитория

        public void FillClientsLV() //метод заполнения lv_clients
        {
            string[] clientListID = (cb_department.SelectedItem.ToString()).Split(' '); //разделение строки данных выбанного в cb_department департамента на части через разделитель пробел
            int depID = Convert.ToInt32(clientListID[clientListID.Length - 1]); //извлечение номера департамента из последнего значения массива
            lv_clients.ItemsSource = clientsData.ClientsDB.FindAll(a => a.DepartamentID == depID); //заполнение lv_clients на основе DepartamentID
        }

        public MainWindow()
        {
            InitializeComponent();

            clientsData = Repository.CreateRepository(); //создание репозитория

            //ниже исходные состояния кнопок и форм ввода
            tb_surname.IsEnabled = false;
            tb_name.IsEnabled = false;
            tb_patronimic.IsEnabled = false;
            tb_phone.IsEnabled = false;
            tb_passport.IsEnabled = false;

            btn_add_client.IsEnabled = false;
            btn_add_dep.IsEnabled = false;
            btn_sort.IsEnabled = false;
            btn_del_client.IsEnabled = false;
            btn_change.IsEnabled = false;

            rb_sort_surname.IsChecked = true;
        }

        private void btn_check_pass_Click(object sender, RoutedEventArgs e) //кнопка авторизации
        {
            if (tb_login.Text == "consultant" && tb_password.Text == "consultant") //проверка ввода данных консультанта
            {
                tb_surname.IsEnabled = false;
                tb_name.IsEnabled = false;
                tb_patronimic.IsEnabled = false;
                tb_phone.IsEnabled = true;
                tb_passport.IsEnabled = false;
                btn_add_client.IsEnabled = false;
                btn_add_dep.IsEnabled = false;
                btn_change.IsEnabled = true;
                btn_sort.IsEnabled = true;

                cb_department.ItemsSource = clientsData.DepartmentDB; //заполнение cb_department из базы департаментов
                cb_department.SelectedIndex = 0; //выбор департамента по умолчанию
            }

            else if (tb_login.Text == "manager" && tb_password.Text == "manager") //проверка ввода данных менеджера
            {
                tb_surname.IsEnabled = true;
                tb_name.IsEnabled = true;
                tb_patronimic.IsEnabled = true;
                tb_phone.IsEnabled = true;
                tb_passport.IsEnabled = true;
                btn_add_client.IsEnabled = true;
                btn_add_dep.IsEnabled = true;
                btn_sort.IsEnabled = true;
                btn_del_client.IsEnabled = true;
                btn_change.IsEnabled = true;

                cb_department.ItemsSource = clientsData.DepartmentDB; //заполнение cb_department из базы департаментов
                cb_department.SelectedIndex = 0; //выбор департамента по умолчанию
            }
            else
            {
                MessageBox.Show("Логин или пароль неверный!"); //вывод окна уведомления о неверных данных
            }
        }


        private void btn_add_dep_Click(object sender, RoutedEventArgs e) //кнопка добавления департамента
        {
            if (tb_dep_add.Text == "") //проверка заполнения поля департамента
            {
                MessageBox.Show("Заполните поле департамента!"); // вывод окна уведомления о неверных данных
            }
            else
            {
                int maxDB = clientsData.DepartmentDB.Max(point => point.DepartmentID); //поиск в базе DepartmentDB максимального DepartmentID
                clientsData.DepAdd(tb_dep_add.Text, maxDB + 1); //добавление нового департамента

                cb_department.Items.Refresh(); //обновление списка cb_department
            }
        }

        private void btn_add_client_Click(object sender, RoutedEventArgs e) //кнопка добавления клиента
        {
            if ((tb_surname_add.Text == "") || (tb_name_add.Text == "") || (tb_patronimic_add.Text == "") || (tb_phone_add.Text == "") || (tb_passport_add.Text == "")) //проверка заполнения всех полей
            {
                MessageBox.Show("Заполните все поля клиента!"); // вывод окна уведомления о незаполненных данных
            }
            else
            {
                int maxCL = clientsData.ClientsDB.Max(a => a.ClientID); //поиск в базе ClientsDB максимального значения ClientID

                string[] clientListID = (cb_department.SelectedItem.ToString()).Split(' '); //разделение строки данных выбанного в cb_department департамента на части через разделитель пробел
                int depID = Convert.ToInt32(clientListID[clientListID.Length - 1]); //извлечение номера департамента из последнего значения массива
                clientsData.ClientAdd(maxCL + 1, tb_surname_add.Text, tb_name_add.Text, tb_patronimic_add.Text, tb_phone_add.Text, tb_passport_add.Text, depID); //добавление новго клиента
                lv_clients.ItemsSource = clientsData.ClientsDB.FindAll(a => a.DepartamentID == depID); //повторное заполнение lv_clients
            }
        }

        private void DepartmentChange(object sender, SelectionChangedEventArgs e) //метод заполнения данных lv_clients и cb_department
        {
            FillClientsLV(); //заполнение lv_clients
        }

        private void btn_sort_Click(object sender, RoutedEventArgs e) //кнопка сортировки
        {
            string[] clientListID = (cb_department.SelectedItem.ToString()).Split(' '); //разделение строки данных выбанного в cb_department департамента на части через разделитель пробел
            int depID = Convert.ToInt32(clientListID[clientListID.Length - 1]); //извлечение номера департамента из последнего значения массива
            List<Client> sortList = clientsData.ClientsDB.FindAll(a => a.DepartamentID == depID); //заполнение lv_clients на основе DepartamentID
            if (rb_sort_surname.IsChecked == true) //проверка выбранного radio button
            {
                lv_clients.ItemsSource = sortList.OrderBy(t => t.Surname); //сортировка по фамилии
            }
            if (rb_sort_name.IsChecked == true) //проверка выбранного radio button
            {
                lv_clients.ItemsSource = sortList.OrderBy(t => t.Name); //сортировка по имени
            }
            if (rb_sort_patronimic.IsChecked == true) //проверка выбранного radio button
            {
                lv_clients.ItemsSource = sortList.OrderBy(t => t.Patronymic); //сортировка по отчеству
            }
        }

        private void btn_del_client_Click(object sender, RoutedEventArgs e) //кнопка удаления выбранного  клиента из базы
        {
            string[] clientTemp = lv_clients.SelectedItem.ToString().Split(' '); //разделение строки данных выбранного в lv_clients клиента через разделитель пробел
            int currentClientID = Convert.ToInt32(clientTemp[0]); //извленение ID клиента через первый аргумент

            var deleteClient = clientsData.ClientsDB.FirstOrDefault(p => p.ClientID == currentClientID); //поиск в ClientsDB клиента с данным ID
            if (deleteClient != null) //проверка на наличие клиента в базе
            {
                clientsData.ClientsDB.Remove(deleteClient); //удаление клиента
            }

            FillClientsLV(); //повторное заполнение lv_clients
        }

        private void btn_info_Click(object sender, RoutedEventArgs e) //кнопка справки по пользователям и паролям
        {
            MessageBox.Show("для пользователя manager пароль manager \nдля пользователя consultant пароль consultant");
        }
    }
}
