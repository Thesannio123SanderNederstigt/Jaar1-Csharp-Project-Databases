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
                pnl_Activiteitenlijst.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();
                pnl_Omzetrapportage.Hide();

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
                pnl_Activiteitenlijst.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();
                pnl_Omzetrapportage.Hide();

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
                pnl_Activiteitenlijst.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();
                pnl_Omzetrapportage.Hide();

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
                pnl_Activiteitenlijst.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();
                pnl_Omzetrapportage.Hide();

                pnl_Rooms.Show();

                Room_Service roomService = new Room_Service();
                List<Room> roomList = roomService.GetRooms();

                ListRoomBox.Items.Clear();

                foreach(Room r in roomList)
                {
                    ListRoomBox.Items.Add(r.RoomToString());
                }


            }
            else if (panelName == "Activities")
            {
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();
                pnl_Omzetrapportage.Hide();

                pnl_Activiteitenlijst.Show();

                Activity_Service activityService = new Activity_Service();
                List<Activity> activityList = activityService.GetActivities();

                lv_Activiteitenlijst.Items.Clear();
                cmb_Activiteiten.Items.Clear();

                foreach (Activity a in activityList)
                {
                    ListViewItem li = new ListViewItem(a.Number.ToString());
                    li.SubItems.Add(a.Description.ToString());
                    li.SubItems.Add(a.StartTime.ToString());
                    li.SubItems.Add(a.NumberofStudents.ToString());
                    li.SubItems.Add(a.NumberofLecturers.ToString());
                    lv_Activiteitenlijst.Items.Add(li);

                    cmb_Activiteiten.Items.Add(a.ActiviteitcmbBoxToString());
                }

                cmb_Activiteiten.SelectedIndex = 0;

            }
            else if (panelName == "Drank")
            {
                //Hide all other panels (once again)
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_Activiteitenlijst.Hide();
                pnl_Kassa.Hide();
                pnl_Omzetrapportage.Hide();

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
                pnl_Activiteitenlijst.Hide();
                pnl_Drank.Hide();
                pnl_Omzetrapportage.Hide();

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


                Bestelling_Kassa_Service bestellingService = new Bestelling_Kassa_Service();
                List<Bestelling> orderList = bestellingService.GetOrders();

                //hier de listview van de bestellingen leegmaken om daarna weer te kunnen vullen
                lv_Bestelling.Items.Clear();

                foreach (Bestelling b in orderList)
                {
                    //drankService.StockCheck(d);

                    ListViewItem Order = new ListViewItem(b.Bestellingsnummer.ToString());
                    Order.SubItems.Add(b.Datum.ToString());

                    Drank Ordereddrank = drinksService.GetDrankById(b.Dranknummer);

                    Order.SubItems.Add(Ordereddrank.DrankName.ToString());

                    Student OrderedStudent = studentService.GetStudentById(b.Studentnummer);

                    Order.SubItems.Add(OrderedStudent.Studentname.ToString());

                    lv_Bestelling.Items.Add(Order);
                }

            }
            else if (panelName == "Omzetrapportage")
            {
                //Hide all the other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Lecturers.Hide();
                pnl_Rooms.Hide();
                pnl_Activiteitenlijst.Hide();
                pnl_Drank.Hide();
                pnl_Kassa.Hide();

                //show this panel
                pnl_Omzetrapportage.Show();

               

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

        private void ActivitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel("Activities");
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

        // methode met de code voor het klikken op de bestellingsknop in het bestellingsmenu
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

        //code van de methode voor het klikken op de bereken omzet knop van de Omzetrapportage
        private void OmzetBtn_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            lv_Omzet.Items.Clear();

            Bestelling_Kassa_Service bestellingService = new Bestelling_Kassa_Service();

            Drank_Service dService = new Drank_Service();

            Student_Service sService = new Student_Service();

            StartCalendar.MaxSelectionCount = 1;
            EindCalendar.MaxSelectionCount = 1;

            DateTime startDate = StartCalendar.SelectionRange.Start; //hier stond eerst StartCalendar.SelectionStart;

            DateTime endDate = EindCalendar.SelectionRange.Start;

            if (!bestellingService.ValidDateRangeCheck(startDate, endDate))
            {
                lblError.Text = "Er is een ongeldige tijdsperiode opgegeven!";
            }
            else if (bestellingService.ValidDateRangeCheck(startDate, endDate))
            {
                List<Bestelling> bestellingsList = bestellingService.GetRangedOrders(startDate, endDate);

                int aantaldranken = 0;

                int aantalstudenten = 0;

                decimal omzet = 0;

                foreach (Bestelling b in bestellingsList)
                {

                    Student student = sService.GetStudentById(b.Studentnummer);

                    if (student != null)
                    {
                        aantalstudenten++;
                    }

                    Drank drank = dService.GetDrankById(b.Dranknummer);

                    if (drank != null)
                    {
                        aantaldranken++;
                    }

                    decimal drankPrijs = drank.Price;

                    omzet += drankPrijs;
                }

                //decimal Omzettotaal = (aantaldranken * omzet);

                ListViewItem Omzet = new ListViewItem(aantaldranken.ToString());
                Omzet.SubItems.Add(omzet.ToString());
                Omzet.SubItems.Add(aantalstudenten.ToString());
                lv_Omzet.Items.Add(Omzet);

            }

            ShowPanel("Omzetrapportage");
        }

        //code van de methode voor het wijzigen van de geselecteerde activiteit in een te wijzigen of verwijderen activiteit van de activiteitenlijst
        private void Cmb_Activiteiten_SelectedIndexChanged(object sender, EventArgs e)
        {

            Activity_Service activityService = new Activity_Service();

            //het op nul zetten van de text in de wijzigen/verwijderen textboxen (gebruikt bij testen/debuggen)
            Txtactiviteitnr.Text = "";
            Txtactiviteitomschrijving.Text = "";
            Txtaantalstudenten.Text = "";
            Txtaantaldocenten.Text = "";

            EditOrDeleteCalendar.MaxSelectionCount = 1;

            //de twee regels hieronder om de gebruikte ActiviteitcmbBoxToString() string te gebruiken om vervolgens  het juiste activiteitnummer te kunnen gebruiken om in de database te kunnen zoeken en op te halen (geen combobox indexnummers meer nodig)
            string selectedActivity = cmb_Activiteiten.GetItemText(cmb_Activiteiten.SelectedItem);

            int activitynumber = int.Parse(selectedActivity);

            Activity activity = activityService.GetActivityById(activitynumber);

            Txtactiviteitnr.Text = activity.Number.ToString();
            Txtactiviteitomschrijving.Text = activity.Description.ToString();
            EditOrDeleteCalendar.SelectionStart = activity.StartTime;
            Txtaantalstudenten.Text = activity.NumberofStudents.ToString();
            Txtaantaldocenten.Text = activity.NumberofLecturers.ToString();

            Txtactiviteitnr.Enabled = false;

        }

        //Code voor de wijzigingsknop in en van de activiteiten in de activiteitenlijst
        private void Btnwijzigen_Click(object sender, EventArgs e)
        {
            Activity_Service activityService = new Activity_Service();

            int activityNumber = int.Parse(Txtactiviteitnr.Text);

            string NewDescription = Txtactiviteitomschrijving.Text;

            DateTime NewStartTime = EditOrDeleteCalendar.SelectionRange.Start;

            int NewNumberofStudents = int.Parse(Txtaantalstudenten.Text);

            int NewNumberofLecturers = int.Parse(Txtaantaldocenten.Text);

            if(NewDescription != "" && NewStartTime != null && NewNumberofStudents != 0 && NewNumberofLecturers != 0)
            {
                activityService.EditActivity(activityNumber, NewDescription, NewStartTime, NewNumberofStudents, NewNumberofLecturers);
            }
            else
            {
                lbl_ActivityErrorMessage.Text = "Niet alle velden zijn volledig of correct ingevuld!";
            }

            ShowPanel("Activities");
        }

        //Code voor de verwijderknop in en van de activiteiten in de activiteitenlijst
        private void Btnverwijderen_Click(object sender, EventArgs e)
        {
            string message = "Weet u zeker dat u deze activiteit wilt verwijderen?";
            string caption = "Activiteit verwijderen";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

            if(result == DialogResult.No)
            {
                ShowPanel("Activities");
            }
            else if (result == DialogResult.Yes)
            {
                Activity_Service activityService = new Activity_Service();

                int activityNumber = int.Parse(Txtactiviteitnr.Text);

                activityService.DeleteActivity(activityNumber);
            }

            ShowPanel("Activities");
        }

        //code voor de toevoegknop van een nieuwe activiteit in de activiteitenlijst
        private void Btntoevoegen_Click(object sender, EventArgs e)
        {
            Activity_Service activityService = new Activity_Service();

            AddCalendar.MaxSelectionCount = 1;

            string AddedDescription = Txtaddomschrijving.Text;

            DateTime AddedStartTime = AddCalendar.SelectionRange.Start;

            int AddedNumberofStudents = int.Parse(Txtaddstudentenaantal.Text);

            int AddedNumberofLecturers = int.Parse(Txtadddocentenaantal.Text);

            if (AddedDescription != "" && AddedStartTime != null && AddedNumberofStudents != 0 && AddedNumberofLecturers != 0)
            {
                activityService.AddNewActivity(AddedDescription, AddedStartTime, AddedNumberofStudents, AddedNumberofLecturers);
            }

            ShowPanel("Activities");

        }
    }
}
