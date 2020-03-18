using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            ShowPanel("Dashboard");
        }

        private void ShowPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();

                // show students
                pnl_Students.Show();

                

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Studentname, s.Studentnumber);
                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Lecturers")
            {
                //hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();

                pnl_Lecturers.Show();

                Teacher_Service teachService = new Teacher_Service();
                List<Teacher> teacherList = teachService.GetTeachers();

                listViewLecturers.Clear();

                foreach (Teacher t in teacherList)
                {
                    ListViewItem li = new ListViewItem(t.Teachername, t.Teachernumber);
                    listViewLecturers.Items.Add(li);
                }
            }
            else if (panelName == "Rooms")
            {
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();

                pnl_Rooms.Show();

                Room_Service roomService = new Room_Service();
                List<Room> roomList = roomService.GetRooms();

                ListRoomBox.Items.Clear();

                foreach(Room r in roomList)
                {
                    ListRoomBox.Items.Add(r.RoomToString());
                }


            }
            else if (panelName == "Drank")
            {
                //Hide all other panels (once again)
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_Kassa.Hide();

                //show the Drinks panel
                pnl_Drank.Show();

                Drank_Service drankService = new Drank_Service();
                List<Drank> drankList = drankService.GetDrinks();

                lv_Drank.Items.Clear();

                foreach(Drank d in drankList)
                {
                    //drankService.StockCheck(d);

                    ListViewItem li = new ListViewItem(d.DrankName.ToString());
                    li.SubItems.Add(d.StockAmount.ToString());
                    li.SubItems.Add(d.Price.ToString());
                    li.SubItems.Add(drankService.StockCheck(d));
                    lv_Drank.Items.Add(li);
                }

            }
            else if (panelName == "Kassa")
            {
                //Hide all the other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_Drank.Hide();

                //show the Kassa panel
                pnl_Kassa.Show();

                cmb_Students.Items.Clear();

                Student_Service studentService = new Student_Service();
                List<Student> studentList = studentService.GetStudents();

                foreach(Student s in studentList)
                {
                    cmb_Students.Items.Add(s.Studentname);
                }

                //eerste student selecteren als standaard.
                cmb_Students.SelectedIndex = 0;



                cmb_Drinks.Items.Clear();

                Drank_Service drinksService = new Drank_Service();
                List<Drank> drankList = drinksService.GetAllDrinks();

                foreach(Drank d in drankList)
                {
                    cmb_Drinks.Items.Add(d.DrankName);
                }

                //eerste drank selecteren als standaard.
                cmb_Drinks.SelectedIndex = 0;

            }
            else if (panelName == "Omzetrapportage")
            {

            }
        }

        private void DashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //dit is voor het klikken op de 'application' knop
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //deze is voor het klikken op Exit binnen de application knop
            Application.Exit();
        }

        private void DashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //deze is voor het gaan naar het het dashboard (klikken op de 'Dashboard' knop binnen de 'Application' knop z'n dropdown menu)
            ShowPanel("Dashboard");
        }

        private void Img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void StudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("Students");
        }

        private void LecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("Lecturers");
        }

        private void RoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("Rooms");
        }

        private void DrankvoorraadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("Drank");
        }

        private void KassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("Kassa");
        }

        private void OmzetrapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("Omzetrapportage");
        }

        private void OrderBtn_Click(object sender, EventArgs e)
        {
            Student_Service sService = new Student_Service();

            Student student = sService.GetStudentById(cmb_Students.SelectedIndex + 1);

            int studentNummer = student.Studentnumber;


            Drank_Service dService = new Drank_Service();

            Drank drank = dService.GetDrankById(cmb_Drinks.SelectedIndex + 1); //hier een + 1 vanwege het verschil in C# index tellen wat bij 0 begint, en de database entries die bij 1 beginnen...

            int drankNummer = drank.DrankNumber;

            studenttestlabel.Text = studentNummer.ToString(); //debugging test label voor studentnamen

            dranktestlabel.Text = drankNummer.ToString(); //debugging test label voor dranken

            
            //hier straks code voor het aanmaken van een Bestelling_Kassa_Service en DAO en het dus doen van een bestelling (totaalbedrag = de prijs van een drank in deze bestelling tabel)
            Bestelling_Kassa_Service bestellingService = new Bestelling_Kassa_Service();


            DateTime datum = DateTime.Now;

            decimal Total = drank.Price;

            bestellingService.PlaceOrder(datum, Total, drankNummer, studentNummer);

            //dranktestlabel.Text = newOrderNumber.ToString();

            //haal de lijst opnieuw op na het toevoegen van een bestelling
            List<Bestelling> orderList = bestellingService.GetOrders();

            //hier de listview van de bestellingen leegmaken om daarna weer te kunnen vullen
            lv_Bestelling.Items.Clear();

            foreach (Bestelling b in orderList)
            {
                //drankService.StockCheck(d);

                ListViewItem Order = new ListViewItem(b.Bestellingsnummer.ToString());
                Order.SubItems.Add(b.Datum.ToString());

                Drank Ordereddrank = dService.GetDrankById(b.Dranknummer);

                Order.SubItems.Add(Ordereddrank.DrankName.ToString());

                Student OrderedStudent = sService.GetStudentById(b.Studentnummer);

                Order.SubItems.Add(OrderedStudent.Studentname.ToString());

                lv_Bestelling.Items.Add(Order);
            }

            Bestelling Kassaorder = orderList.Last();

            Voorraad_Service vService = new Voorraad_Service();

            Voorraad Kassavoorraad = vService.GetVoorraadByDrankId(Kassaorder.Dranknummer);
            int stockNumber = Kassavoorraad.VoorraadNumber;

            bestellingService.RegisterOrder(Kassaorder.Bestellingsnummer, stockNumber);

            //attempt 1 to reset the screen
            ShowPanel("Kassa");

            
        }
    }
}
