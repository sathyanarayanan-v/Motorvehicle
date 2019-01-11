using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MotorVehicle
{
    public partial class Motor_frm : Form
    {
        
        public Motor_frm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox5.SelectedItem.ToString() == "State")
            {
                comboBox2.Items.Add("Andra Pradesh");
                comboBox2.Items.Add("Arunachal Pradesh");
                comboBox2.Items.Add("Assam");
                comboBox2.Items.Add("Bihar");
                comboBox2.Items.Add("Chhatisgarh");
                comboBox2.Items.Add("Goa");
                comboBox2.Items.Add("Gujarath");
                comboBox2.Items.Add("Haryana");
                comboBox2.Items.Add("Himachal Pradesh");
                comboBox2.Items.Add("Jammu and Kashmir");
                comboBox2.Items.Add("Jharkhand");
                comboBox2.Items.Add("Karnataka");
                comboBox2.Items.Add("Kerala");
                comboBox2.Items.Add("Madya Pradesh");
                comboBox2.Items.Add("Maharashtra");
                comboBox2.Items.Add("Manipur");
                comboBox2.Items.Add("Meghalaya");
                comboBox2.Items.Add("Mizoram");
                comboBox2.Items.Add("Nagaland");
                comboBox2.Items.Add("Orissa");
                comboBox2.Items.Add("Punjab");
                comboBox2.Items.Add("Rajasthan");
                comboBox2.Items.Add("Sikkim");
                comboBox2.Items.Add("Tamil Nadu");
                comboBox2.Items.Add("Trippura");
                comboBox2.Items.Add("Uttaranchal");
                comboBox2.Items.Add("Uttar Pradesh");
                comboBox2.Items.Add("West Bengal");
            }

            else if (comboBox5.SelectedItem.ToString() == "UT")
            {
                comboBox2.Items.Add("Andaman and Nicobar Islands");
                comboBox2.Items.Add("Chandigarh");
                comboBox2.Items.Add("Dadar and Nagar Haveli");
                comboBox2.Items.Add("Daman and Diu");
                comboBox2.Items.Add("Delhi");
                comboBox2.Items.Add("Lakshadeep");
                comboBox2.Items.Add("pondicherry");
            }
            



        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Code to fetch Aadhar Details From Database


            string sa = "Data Source=DELL,Catalog=STUDENT DB, Integrated Security=True";
            SqlConnection obj = new SqlConnection(sa);
            obj.Open();
            string cr = "select Aadhar_Number,Name,Father_Name,D_O_B,Address,License_Num,License_name,Reg_Num,S_W,Veh_cls,Cha_Num,Eng_Num,Mak_cls,Veh_clr,valfro,valto,PolNum,MobNum from Aadhar_det where Aadhar_Number='" + textBox7.Text + "'";                
            SqlCommand re1 = new SqlCommand(cr, obj);
            SqlDataReader obj1 = re1.ExecuteReader();
            if (obj1.HasRows == false)
            {
                MessageBox.Show("Aadhar Number invalid/Not found !", "Motor Vehicle System-Government Of India", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                while (obj1.Read())
                {
                    label1.Text              = obj1["Aadhar_Number"].ToString();
                    Name_tb.Text             = obj1["Name"].ToString();

                    NameOfInsured_tb.Text    = Name_tb.Text;
                    FatherName_tb.Text       = obj1["Father_Name"].ToString();
                    DOB_tb.Text              = obj1["D_O_B"].ToString();
                    Address_tb.Text          = obj1["Address"].ToString();
                    LicenseNum_tb.Text       = obj1["License_Num"].ToString();
                    LicenseName_tb.Text      = obj1["License_name"].ToString();
                    textBox2.Text            = obj1["Reg_Num"].ToString();

                    VehRegNo_tb.Text         = textBox2.Text;
                    textBox3.Text            = obj1["S_W"].ToString();
                    textBox4.Text            = obj1["Veh_cls"].ToString();
                    textBox5.Text            = obj1["Cha_Num"].ToString();

                    ChasisNum_tb.Text        = textBox5.Text;
                    textBox6.Text            = obj1["Eng_Num"].ToString();
                    textBox14.Text           = obj1["Mak_cls"].ToString();
                    textBox15.Text           = obj1["Veh_clr"].ToString();
                    textBox16.Text           = obj1["valfro"].ToString();
                    textBox17.Text           = obj1["valto"].ToString();
                    PolNum_tb.Text           = obj1["PolNum"].ToString();
                    MobNum_tb.Text           = obj1["MobNum"].ToString();
                } try
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Sathyanarayanan\Desktop\sathyaaadhar.jpg");
                    label1.Visible = true;
                }
                catch(Exception)
                {
                    MessageBox.Show("Error");
            }
            obj.Close();
        }}// To Fetch Aadhar Details

        private void uploadReport_btn_Click(object sender, EventArgs e)// Code to store Report into the Database
        {
            
            string sa = "Data Source=VS;Initial Catalog=Accident Details;Integrated Security=True";
            SqlConnection obj = new SqlConnection(sa);
            try
            {
                obj.Open();
                string ins = "insert into Accdet values('" + comboBox5.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + textBox12.Text + "','" + textBox11.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox13.Text + "','" + textBox8.Text + "','" + label1.Text + "','" + MailID_tb.Text + "','" + textBox1.Text + "')";
                SqlCommand re = new SqlCommand(ins, obj);
                re.ExecuteNonQuery();
                obj.Close();
                MessageBox.Show("Data Stored", "Motor Vehicle System-Government Of India", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Enter All Values","Motor Vehicle System-Government Of India",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        
        private void Upload1_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;
                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        Image img2;
                        byte[] temp;
                        img2 = pictureBox3.Image;
                        temp = converterDemo(img2);
                        objcon.Open();
                        string query = "insert into ImageUp (one)values('" + @temp + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox2.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Upload2_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        // Upload Photos to Databse for Insurance and Service Center Verification
        // Step 1. Image is uploaded to Picture Box
        // Step 2. Image is uploaded to Database
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}
        private void Upload2_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*|All files (*.*)|*.*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;

                Image img2;
                byte[] temp;
                img2=pictureBox3.Image;
                temp = converterDemo(img2);
                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (two)values('" + @temp + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();
                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox3.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            upload3_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void upload3_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;


                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (three)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox4.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            upload4_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void upload4_btn_Click(object sender, EventArgs e)
        {
        OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;
                

                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (four)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox5.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            upload5_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void upload5_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;


                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (five)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox6.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Upload6_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void Upload6_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;


                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (six)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox7.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Upload7_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void Upload7_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;


                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (seven)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox8.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Upload8_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void Upload8_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;


                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (eight)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox9.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Upload9_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void Upload9_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;


                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (nine)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox10.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Upload10_btn.Enabled = true;
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void Upload10_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "PNG files (*.png)|*.png|JPEG Files (*.jpeg*)|*.jpeg*|JPG Files(*.jpg*)|*.jpg*";
            string file_name = open.FileName;
            {
                DialogResult result1 = open.ShowDialog(); ;


                //Inserting Image into Database
                SqlConnection objcon = null;
                SqlCommand objcmd = null;
                using (objcon = new SqlConnection("Data Source=VS;Initial Catalog=Images;Integrated Security=True"))
                {
                    try
                    {
                        objcon.Open();
                        string query = "insert into ImageUp (ten)values('" + file_name + "')";
                        objcmd = new SqlCommand(query, objcon);
                        objcmd.ExecuteNonQuery();

                        if (result1 != (DialogResult.Cancel))
                        {
                            pictureBox11.Image = new Bitmap(open.FileName);
                            MessageBox.Show("Uploaded Successfully", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Uploaded Unsuccessfull", "Acknowledgement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    objcon.Close();
                }
            }
            //End of code for inserting image into database
        }

        private void RefID_btn_Click(object sender, EventArgs e)
        {
            Random a=new Random();
            textBox1.Text = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);
        }

        private void Motor_frm_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            Upload2_btn.Enabled = false;
            upload3_btn.Enabled = false;
            upload4_btn.Enabled = false;
            upload5_btn.Enabled = false;
            Upload6_btn.Enabled = false;
            Upload7_btn.Enabled = false;
            Upload8_btn.Enabled = false;
            Upload9_btn.Enabled = false;
            Upload10_btn.Enabled = false;
        }

        private void SavePrint_btn_Click(object sender, EventArgs e)
        {
            ReportGen a=new ReportGen();
            a.Show();
            
        }

        private void Motor_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_Page a = new Login_Page();
            a.Show();
        }

        private void Find_Rec_btn_Click(object sender, EventArgs e)
        {
            Search a = new Search();
            a.Show();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(myTxtbx.Text))
              //  myTxtbx.Text = "Enter your aadhar number";
        }

        
    }
}
