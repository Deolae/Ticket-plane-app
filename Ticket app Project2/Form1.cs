using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Ticket_app_Project2
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public Form1()
        {
            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //Hide other panels and keep them main menu
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            groupBox2.Hide();
        }
        //Variable for ticket IDs
        static int ticketCount = 0;


        //The "Close" button, closes the app
        private void round_Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        //Changes the look of the "Close" button based on mouse entry and leave
        private void round_Button2_MouseEnter(object sender, EventArgs e)
        {
            round_Button2.BackgroundImage = Properties.Resources.image__4_;
        }

        private void round_Button2_MouseLeave(object sender, EventArgs e)
        {
            round_Button2.BackgroundImage = Properties.Resources.Close2_removebg;

        }

        //The "Home" button, goes to the main menu
        private void round_Button1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }

        //Changes the look of the "Home" button based on mouse entry and leave
        private void round_Button1_MouseEnter(object sender, EventArgs e)
        {
            round_Button1.BackgroundImage = Properties.Resources.image__5_;
        }

        private void round_Button1_MouseLeave(object sender, EventArgs e)
        {
            round_Button1.BackgroundImage = Properties.Resources.Home;
        }
        

        //"Find my Trip" button, hides all panels and shows the trips menu
        private void round_Button3_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
        }

        //Changes the look of the "Find my Trip" button based on mouse entry and leave
        private void round_Button3_MouseEnter(object sender, EventArgs e)
        {
            round_Button3.BackgroundImage = Properties.Resources.gradient_BP_2;
            round_Button3.ForeColor = Color.WhiteSmoke;
        }

        private void round_Button3_MouseLeave(object sender, EventArgs e)
        {
            round_Button3.BackgroundImage = Properties.Resources.gradient_BP;
            round_Button3.ForeColor = Color.Black;
        }


        //The "Return to previous page" button from the trips menu to the main menu
        private void round_Button4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        //Changes the look of the "Return to previous page" button based on mouse entry and leave
        private void round_Button4_MouseEnter(object sender, EventArgs e)
        {
            round_Button4.BackgroundImage = Properties.Resources.backarrowP;
        }

        private void round_Button4_MouseLeave(object sender, EventArgs e)
        {
            round_Button4.BackgroundImage = Properties.Resources.backarrow;
        }


        //Changes the look of the "Current Reservation" button based on mouse entry and leave
        private void round_Button8_MouseEnter(object sender, EventArgs e)
        {
            round_Button8.BackgroundImage = Properties.Resources.ResTicketP;

        }

        private void round_Button8_MouseLeave(object sender, EventArgs e)
        {
            round_Button8.BackgroundImage = Properties.Resources.ResTicket_removebg_preview;
        }

        //The "Current Reservation" button, opens the current ticket page
        private void round_Button8_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }


        //The "Turkey" button
        private void round_Button6_Click(object sender, EventArgs e)
        {
            //Clears combo box and radio button previous selection, and resets the No. Passengers number to 1
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            numericUpDown1.Value = 1;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Changes the combobox items to Turkey cities
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Turkey, Antalya");
            comboBox2.Items.Add("Turkey, Istanbul");
            comboBox2.Items.Add("Turkey, Trabzon");

            //Changes the panel background image to turkey 
            panel3.BackgroundImage = Properties.Resources.turkBP2;

            //hides the other panels and shows the turkey panel, also hides the plane reservations groupbox
            groupBox2.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            panel5.Hide();
        }


        //The "Return to previous page" button from the reservation menu to trips
        private void round_Button9_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel2.Show();
        }

        //Changes the look of the "Return to previous page" button based on mouse entry and leave
        private void round_Button9_MouseEnter(object sender, EventArgs e)
        {
            round_Button9.BackgroundImage = Properties.Resources.backarrowP;
        }

        private void round_Button9_MouseLeave(object sender, EventArgs e)
        {
            round_Button9.BackgroundImage = Properties.Resources.backarrow;
        }


        //The "Show Flights" button
        private void round_Button5_Click_2(object sender, EventArgs e)
        {
            //Changes the flight times based on the chosen cities from the combo boxes
            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0)
            {
                radioButton4.Text = "10:35AM                              12:45PM";
                
                radioButton6.Text = "9:00AM                              10:10AM";

                radioButton5.Text = "7:20AM                             8:30AM";
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
            {
                radioButton4.Text = "1:20PM                              2:35PM";

                radioButton6.Text = "12:00PM                              1:15PM";

                radioButton5.Text = "8:45AM                             10:00AM";
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 2)
            {
                radioButton4.Text = "3:00PM                              4:30PM";

                radioButton6.Text = "1:25PM                              2:55PM";

                radioButton5.Text = "11:10AM                             12:40PM";
            }
            //--------------------------------------------------

            if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0)
            {
                radioButton4.Text = "10:35AM                              12:45PM";

                radioButton6.Text = "9:00AM                              10:10AM";

                radioButton5.Text = "7:20AM                             8:30AM";
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 1)
            {
                radioButton4.Text = "1:20PM                              2:35PM";

                radioButton6.Text = "12:00PM                              1:15PM";

                radioButton5.Text = "8:45AM                             10:00AM";
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 2)
            {
                radioButton4.Text = "3:00PM                              4:30PM";

                radioButton6.Text = "1:25PM                              2:55PM";

                radioButton5.Text = "11:10AM                             12:40PM";
            }


            //--------------------------------------------------

            if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 0)
            {
                radioButton4.Text = "10:35AM                              12:45PM";

                radioButton6.Text = "9:00AM                              10:10AM";

                radioButton5.Text = "7:20AM                             8:30AM";
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1)
            {
                radioButton4.Text = "1:20PM                              2:35PM";

                radioButton6.Text = "12:00PM                              1:15PM";

                radioButton5.Text = "8:45AM                             10:00AM";
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 2)
            {
                radioButton4.Text = "3:00PM                              4:30PM";

                radioButton6.Text = "1:25PM                              2:55PM";

                radioButton5.Text = "11:10AM                             12:40PM";
            }

            //Shows the names of the cities under each flight
            label8.Text = comboBox1.SelectedItem.ToString();
            label10.Text = comboBox1.SelectedItem.ToString();
            label11.Text = comboBox1.SelectedItem.ToString();

            label9.Text = comboBox2.SelectedItem.ToString();
            label12.Text = comboBox2.SelectedItem.ToString();
            label13.Text = comboBox2.SelectedItem.ToString();

            //Shows the groupbox of flights
            groupBox2.Show();
        }


        //Changes the look of the "Show Flights" button based on mouse entry and leave
        private void round_Button5_MouseEnter_1(object sender, EventArgs e)
        {
            round_Button5.BackgroundImage = Properties.Resources.Gradient_Back_2;

        }

        private void round_Button5_MouseLeave_1(object sender, EventArgs e)
        {
            round_Button5.BackgroundImage = Properties.Resources.Gradient_back2;
        }


        //Hides the flights groupbox whenever a new city is chosen
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Hide();
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox2.Hide();
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
        }


        //Changes the look of the "Next" button based on mouse entry and leave
        private void round_Button10_MouseEnter(object sender, EventArgs e)
        {
            round_Button10.BackgroundImage = Properties.Resources.gradient_BP_2;
            round_Button10.ForeColor = Color.WhiteSmoke;
        }

        private void round_Button10_MouseLeave(object sender, EventArgs e)
        {
            round_Button10.BackgroundImage = Properties.Resources.gradient_back;
            round_Button10.ForeColor = Color.Black;
        }

        //The "Next" button
        private void round_Button10_Click(object sender, EventArgs e)
        {
            //If the country is Turkey, the background image in the "Contact Information" panel will be Turkey, else it will be Russia background
            string[] toCity = label9.Text.Split(',');
            if (toCity[0] == "Turkey")
            {
                panel5.BackgroundImage = Properties.Resources.turkBP2;
            }
            else
            {
                panel5.BackgroundImage = Properties.Resources.RussiaBP;
            }

            //Hides other panels and shows the "Contact Information" panel
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Show();

            //Clear the input in the "Contact Information" page if there is any
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }


        //The "Russia" button
        private void round_Button7_Click(object sender, EventArgs e)
        {
            //Clears combo box and radio button previous selection, and resets the No. Passengers number to 1
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            numericUpDown1.Value = 1;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //Changes the combobox items to Russia cities
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Russia, Moscow");
            comboBox2.Items.Add("Russia, Kazan");
            comboBox2.Items.Add("Russia, Saint Petersburg");

            //Changes the panel background image to Russia
            panel3.BackgroundImage = Properties.Resources.RussiaBP;

            //hides the other panels and shows the Russia panel, also hides the plane reservations groupbox
            groupBox2.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            panel5.Hide();
        }

        //The "Return to previous page" button from the Contact Information menu to the Reservation Menu 
        private void round_Button11_Click(object sender, EventArgs e)
        {
            panel5.Hide();
            panel3.Show();
        }

        //Changes the look of the "Return to previous page" button based on mouse entry and leave
        private void round_Button11_MouseEnter(object sender, EventArgs e)
        {
            round_Button11.BackgroundImage = Properties.Resources.backarrowP;

        }

        private void round_Button11_MouseLeave(object sender, EventArgs e)
        {
            round_Button11.BackgroundImage = Properties.Resources.backarrow;

        }


        //The Submit button, confirm the reservation information in the ticket
        private void round_Button12_Click(object sender, EventArgs e)
        {
            //increment ticket count by 1
            ticketCount++;
            //Gets the flight information based on the checked radiobutton 
            if (radioButton4.Checked)
            {
                label21.Text = radioButton4.Text;
                label20.Text = label8.Text;
                label19.Text = label9.Text;
            }
            else if (radioButton5.Checked)
            {
                label21.Text = radioButton5.Text;
                label20.Text = label10.Text;
                label19.Text = label12.Text;
            }
            else if (radioButton6.Checked)
            {
                label21.Text = radioButton6.Text;
                label20.Text = label11.Text;
                label19.Text = label13.Text;
            }

            //Gets the number of passengers
            label4.Text = "No. Passengers: "+numericUpDown1.Value.ToString();

            //Gets the Contact Information
            label22.Text = "Full name: "+textBox4.Text + " " + textBox1.Text;
            label23.Text = "Email: "+textBox2.Text;
            label24.Text = "Phone number: " + textBox3.Text;
            label25.Text = "Ticket ID: " + ticketCount;

            panel2.Hide();
            panel3.Hide();
            panel5.Hide();
            panel4.Show();
            round_Button13.Enabled = true;
        }

        //Changes the look of the "Submit" button based on mouse entry and leave
        private void round_Button12_MouseEnter(object sender, EventArgs e)
        {
            round_Button10.BackgroundImage = Properties.Resources.gradient_BP_2;
            round_Button10.ForeColor = Color.WhiteSmoke;
        }

        private void round_Button12_MouseLeave(object sender, EventArgs e)
        {
            round_Button10.BackgroundImage = Properties.Resources.gradient_back;
            round_Button10.ForeColor = Color.Black;
        }


        //The "Print Reservation" button
        private void round_Button13_Click(object sender, EventArgs e)
        {
            //Prints the current made reservation info in a text file in the debug folder of the solution
            StreamWriter myfile = new StreamWriter("Ticket Reservation.txt");
            myfile.WriteLine("Ticket ID: " + ticketCount);
            myfile.WriteLine("\n");
            myfile.WriteLine("Flight info");
            myfile.WriteLine(":::::::::::::::::::::::::::::::::::");
            string[] time = label21.Text.Split(' ');
            myfile.WriteLine("Plane take off time: " + time[0]);
            myfile.WriteLine("From: " + label20.Text);
            myfile.WriteLine("To: " + label19.Text);
            myfile.WriteLine(label4.Text);
            myfile.WriteLine("\n");
            myfile.WriteLine("Personal info");
            myfile.WriteLine(":::::::::::::::::::::::::::::::::::");
            myfile.WriteLine(label22.Text);
            myfile.WriteLine(label23.Text);
            myfile.WriteLine(label24.Text);
            myfile.Close();
        }

        //Changes the look of the "Print Reservation" button based on mouse entry and leave
        private void round_Button13_MouseEnter(object sender, EventArgs e)
        {
            round_Button10.BackgroundImage = Properties.Resources.gradient_BP_2;
            round_Button10.ForeColor = Color.WhiteSmoke;
        }

        private void round_Button13_MouseLeave(object sender, EventArgs e)
        {
            round_Button10.BackgroundImage = Properties.Resources.gradient_back;
            round_Button10.ForeColor = Color.Black;
        }


        //in the "Contact Information" page, Moves from one textbox to the next one once the user clicks "Enter"
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                round_Button12.Focus();
            }
        }
    }
}
