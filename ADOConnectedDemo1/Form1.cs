using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ADOConnectedDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\user\source\repos\ADOConnectedDemo1\ADOConnectedDemo1\DatabaseEmp.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            String str = "insert into employee (emp_id,emp_Name,emp_Desg,emp_City,emp_Age) values (@id,@nm,@desg,@city,@age)";
            SqlCommand cmd = new SqlCommand(str, con);


            cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@nm", txtName.Text);
            cmd.Parameters.AddWithValue("@desg", txtDesg.Text);
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(txtAge.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Inserted Sucessfully!!");

            con.Close();



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\user\source\repos\ADOConnectedDemo1\ADOConnectedDemo1\DatabaseEmp.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            String str = "update employee set emp_City = @city where emp_Id = @id";
            SqlCommand cmd = new SqlCommand(str, con);

            cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@city", txtCity.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully!!");

            txtName.Text = "";
            txtDesg.Text = "";
            txtAge.Text = "";

            con.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\user\source\repos\ADOConnectedDemo1\ADOConnectedDemo1\DatabaseEmp.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            String str = "delete from employee where emp_id=@id ";
            SqlCommand cmd = new SqlCommand(str, con);

            cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully");
            con.Close();

        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\user\source\repos\ADOConnectedDemo1\ADOConnectedDemo1\DatabaseEmp.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            String str = "select *from employee";
            SqlCommand cmd = new SqlCommand(str, con);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                String nm = rdr.GetString(1);
                String desg = rdr.GetString(2);
                String city = rdr.GetString(3);
                int age = rdr.GetInt32(4);

                listBox1.Items.Add("ID= " + id+"  ||  "+  " Name= " + nm+"  ||  " + " Desg= " + desg+"  ||  " + " City = " +city+"  ||  " + " Age = " +age );
            }
                con.Close();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDesg.Text = "";
            txtCity.Text = "";
            txtAge.Text = "";
            listBox1.Items.Clear();

        }
    }
}
