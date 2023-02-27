using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicServiceClientNamespace;

namespace ClinicDesctopHomework11
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Настройка сбытим клик на кнопку
        private void buttonLoadClients_Click(object sender, EventArgs e)
        {
            ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5105/",
                new System.Net.Http.HttpClient());

            // Настраиваем совместную работу ClientService и
            // ClientDesctop правой кнопкой на Solution вызываем
            // меню и выбираем Multiple startup projects
            ICollection<Client> clients = clinicServiceClient.ClientGetAllAsync().Result;

            listViewClients.Items.Clear();

            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();

                ListViewItem.ListViewSubItem surNameItem = new ListViewItem.ListViewSubItem();
                surNameItem.Text = client.SurName;

                item.SubItems.Add(surNameItem);

                ListViewItem.ListViewSubItem nameItem = new ListViewItem.ListViewSubItem();
                nameItem.Text = client.FirstName;

                item.SubItems.Add(nameItem);

                ListViewItem.ListViewSubItem patronymicItem = new ListViewItem.ListViewSubItem();
                patronymicItem.Text = client.Patronymic;

                item.SubItems.Add(patronymicItem);

                listViewClients.Items.Add(item);
                // На этом мы полностью добавили нашего клиента
            }

        }
    }
}
