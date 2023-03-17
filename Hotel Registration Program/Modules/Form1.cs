using Hotel_Registration_Program.Entities;
using Hotel_Registration_Program.Repositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Hotel_Registration_Program
{
    public partial class Form1 : Form
    {
        CustomersRepository customersRepository = new CustomersRepository();
        RoomsRepository roomsRepository = new RoomsRepository();
        ReservationsRepository reservationsRepository = new ReservationsRepository();
        AddEditCustomerRepository addEditCustomerRepository = new AddEditCustomerRepository();
        AddEditReservationRepository addEditReservationRepository = new AddEditReservationRepository();
        
        string gender;
        public Form1()
        {
            InitializeComponent();
            foreach (DataRow row in roomsRepository.SelectEmpty().Rows)
            {
                cmbx_addcstroomnumber.Items.Add(row.ItemArray[1].ToString());
                cmbx_addcstroomcategory.Items.Add(row.ItemArray[2].ToString());
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            datagrid_cst.DataSource = customersRepository.SelectAllCustomersData();
            datagrid_rms.DataSource = roomsRepository.SelectAllRoomsData();
            datagrid_reserv.DataSource = reservationsRepository.SelectAllReservationsData();

            datagrid_cst.Columns[0].Width = 40;
            datagrid_cst.Columns[8].Width = 150;
            datagrid_cst.Columns[9].Width = 150;
            datagrid_cst.Columns[11].Width = 150;
            datagrid_rms.Columns[2].Width = 145;
            datagrid_reserv.Columns[0].Width = 40;
            datagrid_reserv.Columns[1].Width = 150;
            datagrid_reserv.Columns[3].Width = 150;
            datagrid_reserv.Columns[4].Width = 150;
            datagrid_reserv.Columns[5].Width = 150;
            datagrid_reserv.Columns[6].Width = 150;
            datagrid_reserv.Columns[7].Width = 150;
           
        }

        private void cst_ms_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void addcst_ms_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            label22.Text = "New Customer";
            label22.Location = new Point(400, label22.Location.Y);

            txt_addcstname.Text = "";
            txt_addcstsurname.Text = "";
            radiobtn_male.Checked = false; radiobtn_female.Checked = false;
            txt_addcstpin.Text = "";
            txt_addcstphonenumber.Text = "";
            txt_addcstemail.Text = "";
            richTextBox_addcstaddress.Text = "";
            cmbx_addcstroomcategory.Text = "";
            cmbx_addcstroomnumber.Text = "";
            dateTimePicker_addcstarrival.Text = "";
            dateTimePicker_addcstdeparture.Text = "";

        }

        private void rooms_ms_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void checkout_ms_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            txt_cstmrid.Text = "";
            txt_chckname.Text = "";
            txt_chckoutcategory.Text = "";
            txt_chckoutnumber.Text = "";
            dateTimePicker_checkin.Text = "";
            dateTimePicker_addcstarrival.Text = "";
            txt_nmbrofdays.Text = "";
            txt_chckprice.Text = "";
            txt_discount.Text = "";
        }

        private void reserv_ms_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void cst_add_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            label22.Text = "New Customer";
            label22.Location = new Point(400, label22.Location.Y);

            txt_addcstname.Text = "";
            txt_addcstsurname.Text = "";
            radiobtn_male.Checked = false; radiobtn_female.Checked =  false;
            txt_addcstpin.Text = "";
            txt_addcstphonenumber.Text = "";
            txt_addcstemail.Text = "";
            richTextBox_addcstaddress.Text = "";
            cmbx_addcstroomcategory.Text = "";
            cmbx_addcstroomnumber.Text = "";
            dateTimePicker_addcstarrival.Text = "";
            dateTimePicker_addcstdeparture.Text = "";

        }

        private void cst_edit_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            label22.Text = "Change customer information";
            label22.Location = new Point(300, label22.Location.Y);

            if (datagrid_cst.CurrentRow.Index >= 0)
            {
                txt_addcstname.Text = datagrid_cst.CurrentRow.Cells[1].Value.ToString();
                txt_addcstsurname.Text = datagrid_cst.CurrentRow.Cells[2].Value.ToString();
                if (datagrid_cst.CurrentRow.Cells[3].Value.ToString() == "Male") radiobtn_male.Checked = Enabled;
                else radiobtn_female.Checked = Enabled;
                txt_addcstpin.Text = datagrid_cst.CurrentRow.Cells[4].Value.ToString();
                txt_addcstphonenumber.Text = datagrid_cst.CurrentRow.Cells[5].Value.ToString();
                txt_addcstemail.Text = datagrid_cst.CurrentRow.Cells[6].Value.ToString();
                richTextBox_addcstaddress.Text = datagrid_cst.CurrentRow.Cells[7].Value.ToString();
                cmbx_addcstroomcategory.Text = datagrid_cst.CurrentRow.Cells[8].Value.ToString();
                cmbx_addcstroomnumber.Text = datagrid_cst.CurrentRow.Cells[9].Value.ToString();
                dateTimePicker_addcstarrival.Text = datagrid_cst.CurrentRow.Cells[10].Value.ToString();
                dateTimePicker_addcstdeparture.Text = datagrid_cst.CurrentRow.Cells[11].Value.ToString();
            }
        }

        private void cst_del_Click(object sender, EventArgs e)
        {
            if (datagrid_cst.CurrentRow.Index >= 0)
            {
                customersRepository.DeleteCustomer(Convert.ToInt32(datagrid_cst.CurrentRow.Cells[0].Value));
                MessageBox.Show("Customer has been deleted!", "Successfully");
            }
        }

        private void rsrv_delete_Click(object sender, EventArgs e)
        {
            if (datagrid_reserv.CurrentRow.Index >= 0)
            {
                reservationsRepository.DeleteReservation(Convert.ToInt32(datagrid_reserv.CurrentRow.Cells[0].Value));
                MessageBox.Show("Reservation has been deleted!", "Successfully");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (radiobtn_male.Checked) gender = "Male";
            else if (radiobtn_female.Checked) gender = "Female";
            Customers customers = new Customers
            {
                Name = txt_addcstname.Text,
                Surname = txt_addcstsurname.Text,
                Gender = gender,
                Pin = txt_addcstpin.Text,
                Phone = txt_addcstphonenumber.Text,
                Email = txt_addcstemail.Text,
                Address = richTextBox_addcstaddress.Text,
                Room_category = cmbx_addcstroomcategory.Text,
                Room_number = Convert.ToInt32(cmbx_addcstroomnumber.Text),
                Arrival_date = Convert.ToDateTime(dateTimePicker_addcstarrival.Text),
                Departure_date = Convert.ToDateTime(dateTimePicker_addcstdeparture.Text)
            };
            Rooms rooms = new Rooms
            {
               
                Number = Convert.ToInt32(cmbx_addcstroomnumber.Text),
               
                
            };
            if (label22.Text == "New Customer")
            {
                if (addEditCustomerRepository.AddCustomer(customers) > 0)
                {
                    addEditCustomerRepository.UpdateEmpty(rooms);
                    MessageBox.Show("Customer has been added!", "Successfully");
                }
            }
            else if (label22.Text == "Change customer information")
            {
                customers.Id = Convert.ToInt32(datagrid_cst.CurrentRow.Cells[0].Value);
                if (addEditCustomerRepository.UpdateCustomer(customers) > 0)
                    MessageBox.Show("Customer informations has been changed!", "Successfully");
            }
            tabControl1.SelectedTab = tabPage1;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cstmrid.Text == "")
                    MessageBox.Show("Customer ID textbox is empty!", "Alert");
                else
                {
                    foreach (DataRow row in reservationsRepository.FindCustomer(Convert.ToInt32(txt_cstmrid.Text)).Rows)
                    {
                        if (string.IsNullOrEmpty(row.ItemArray[1].ToString()))
                        {
                            MessageBox.Show("Customer not found!", "Alert");
                        }
                        else
                        {
                            txt_cstmrid.Text = row.ItemArray[0].ToString();
                            string fullname = row.ItemArray[1].ToString() + " " + row.ItemArray[2].ToString();
                            txt_chckname.Text = fullname;
                            txt_chckoutcategory.Text = row.ItemArray[3].ToString();
                            txt_chckoutnumber.Text = row.ItemArray[4].ToString();
                            dateTimePicker_checkin.Text = row.ItemArray[5].ToString();
                            dateTimePicker_checkout.Text = row.ItemArray[6].ToString();

                            string[] str1 = dateTimePicker_checkin.Text.Split(' ', '\t');
                            string[] str2 = dateTimePicker_checkout.Text.Split(' ', '\t');
                            int checkin = Convert.ToInt32(str1[0]);
                            int checkout = Convert.ToInt32(str2[0]);
                            txt_nmbrofdays.Text = (checkout - checkin).ToString();

                            txt_chckprice.Text = CalculatePrice(txt_chckoutcategory.Text, Convert.ToInt32(txt_nmbrofdays.Text)).ToString();
                            txt_bill.Text = txt_chckprice.Text;
                            MessageBox.Show("Customer found!", "Successfully");
                        }
                    }
                }
            }catch(Exception b){}
        }

        private void dateTimePicker_checkin_ValueChanged(object sender, EventArgs e)
        {
            DynamicFillDateCheckout();
        }

        private void dateTimePicker_checkout_ValueChanged(object sender, EventArgs e)
        {
            DynamicFillDateCheckout();
        }

        private void txt_nmbrofdays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_chckprice.Text = CalculatePrice(txt_chckoutcategory.Text, Convert.ToInt32(txt_nmbrofdays.Text)).ToString();
                CalculateBill();
            }catch(Exception b) { }
            
        }

        private void DynamicFillDateCheckout()
        {
            string[] str1 = dateTimePicker_checkin.Text.Split(' ', '\t');
            string[] str2 = dateTimePicker_checkout.Text.Split(' ', '\t');
            int checkin = Convert.ToInt32(str1[0]);
            int checkout = Convert.ToInt32(str2[0]);
            if (checkout - checkin > 0)
            {
                txt_nmbrofdays.Text = (checkout - checkin).ToString();
            }
            else
            {
                if (checkout - checkin == 0)
                    txt_nmbrofdays.Text = "1";
                else
                {
                    MessageBox.Show("Checkout date cannot be earlier than the check in date!", "Alert");
                    dateTimePicker_checkout.Text = dateTimePicker_checkin.Text;
                }
            }
        }

        private double CalculatePrice(string ctg, int day)
        {
            double price = 0;
            switch (ctg)
            {
                case "Single":
                    price = 50 * day;
                    break;
                case "Double":
                    price = 75 * day;
                    break;
                case "Triple":
                    price = 100 * day;
                    break;
                case "Quad":
                    price = 150 * day;
                    break;
                case "Queen":
                    price = 200 * day;
                    break;
                default: break;
            }
            return price;
        }

        private void CalculateBill()
        {
            try
            {
                float discount = float.Parse(txt_discount.Text);
                float price = float.Parse(txt_chckprice.Text);
                float bill = 0;
                bill = price - (price * (discount / 100));
                txt_bill.Text = bill.ToString();
            }catch (Exception b) { }
        }

        private void checkBox_discount_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_discount.Checked)
            {
                txt_discount.Enabled = false;
                txt_bill.Text = txt_chckprice.Text;
                if (txt_discount.Text == "")
                    txt_discount.Text = "0";
            }
            else
            {
                txt_discount.Enabled = true;
                CalculateBill();
                if (txt_discount.Text == "0")
                    txt_discount.Text = "";
            }
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            CalculateBill();
        }

        private void btn_checkout_Click(object sender, EventArgs e)
        {
            try
            {
                Reservations reservations = new Reservations
                {
                    Customer_id = Convert.ToInt32(txt_cstmrid.Text),
                    Fullname = txt_chckname.Text,
                    Room_category = txt_chckoutcategory.Text,
                    Room_number = Convert.ToInt32(txt_chckoutnumber.Text),
                    Checkin_date = Convert.ToDateTime(dateTimePicker_checkin.Text),
                    Checkout_date = Convert.ToDateTime(dateTimePicker_checkout.Text),
                    Number_days = Convert.ToInt32(txt_nmbrofdays.Text),
                    Price = Convert.ToDouble(txt_chckprice.Text),
                    Discount = Convert.ToInt32(txt_discount.Text),
                    Bill = Convert.ToDouble(txt_bill.Text)
                };
                if (addEditReservationRepository.AddReservation(reservations) > 0)
                    MessageBox.Show("Reservation has been added!", "Successfully");
                tabControl1.SelectedTab = tabPage5;
            }
            catch(Exception ex) { }
            
        }
    }
}
