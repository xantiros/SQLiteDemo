using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteDemo
{
    public partial class Form1 : Form
    {
        List<PersonModel> people = new List<PersonModel>();

        public Form1()
        {
            InitializeComponent();

            LoadPeopleList();
        }

        private void LoadPeopleList()
        {
            people = SqliteDataAccess.LoadPeople();

            //people.Add(new PersonModel { FirstName = "Tim", LastName = "Kowal" });
            //people.Add(new PersonModel { FirstName = "John", LastName = "Doe" });
            //people.Add(new PersonModel { FirstName = "Mary", LastName = "Smith" });

            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            listPeopleListBox.DataSource = null;
            listPeopleListBox.DataSource = people;
            listPeopleListBox.DisplayMember = "FullName";

        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            PersonModel p = new PersonModel();
            p.FirstName = tbFirstName.Text;
            p.LastName = tbLastName.Text;

            //people.Add(p);
            //WireUpPeopleList();

            SqliteDataAccess.SavePerson(p);

            tbFirstName.Text = "";
            tbLastName.Text = "";
        }
    }
}
