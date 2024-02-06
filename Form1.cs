using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonInformatiomProject
{
    public partial class frmPersonInformation : Form
    {
        public frmPersonInformation()
        {
            InitializeComponent();
        }

        private void frmPersonInformation_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            CleanAllControls();
            Application.Exit();
        }
        void CleanAllControls()
        {
            pic.Image = null;
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    C.Text = "";
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Trim() == "" || txtName.Text.Trim() == "" || txtAdrss.Text.Trim() == "")
                {
                    MessageBox.Show("Plesae Complete all Informations For Eccelent Result...", "Warning", MessageBoxButtons.OK);
                    txtID.Focus();
                    return;
                }

                StreamReader SR = new StreamReader("PersonData.txt");

                string line = SR.ReadToEnd();
                SR.Close();
                if (line.Contains(txtID.Text + ";"))
                {
                    MessageBox.Show("THis ID is already Exist Please Change it And Try Again!", "Warning", MessageBoxButtons.OK);
                    txtID.Focus();
                    txtID.SelectAll();
                }
                else
                {
                    try
                    {
                        StreamWriter SW = new StreamWriter("PersonData.txt", true);
                        if (!Directory.Exists("img"))
                            Directory.CreateDirectory("img");

                        if (pic.Image != null)
                            pic.Image.Save("img/" + txtID.Text + ".jpg");

                        else
                        {
                            MessageBox.Show("shoud put person Image to contunue", "information", MessageBoxButtons.OK);
                            return;
                        }
                        string strPersonData = txtID.Text + ";"
                                               + txtName.Text + ";"
                                               + txtAdrss.Text+ ";"+
                                               "D:\\cpp project\\DesktopC_sharpProject\\" +
                                               "PersonInformatiomProject\\bin\\Debug\\img";

                        //SW.WriteLine("");
                        SW.WriteLine(strPersonData);
                        SW.Close();
                        
                        foreach (Control C in this.Controls)
                        {
                            if (C is TextBox)
                            {
                                C.Text = "";
                            }
                        }
                        pic.Image = new PictureBox().Image;
                        MessageBox.Show("Person Information Add Successfully ", "Notes", MessageBoxButtons.OK);

                        txtID.Focus();
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }

            CleanAllControls();
        }
        void SecurateInfo(bool status)
        {
            btnSelectPhoto.Enabled = status;
            txtID.Enabled = status;
            txtName.Enabled = status;
            txtAdrss.Enabled = status;
            btnPrint.Enabled = !status;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("PersonData.txt");

            try
            {
                if (txtID.Text.Trim() != "")
                {
                    bool found = false;
                    string line ;
                    do
                    {
                        line= SR.ReadLine();

                        if(line!=null)
                        {
                            string[] arrpersonInfo = line.Split(';');
                            if (arrpersonInfo[0] == txtID.Text)
                            {
                                string Mypath = "img/" + txtID.Text + ".jpg";
                                txtID.Text = arrpersonInfo[0];
                                txtName.Text = arrpersonInfo[1];
                                txtAdrss.Text = arrpersonInfo[2];
                                if (File.Exists(Mypath)) ;
                                   pic.Image = Image.FromFile(Mypath);


                                SecurateInfo(false);
                                found = true;

                                break;

                            }
                        }

                    } while (line!= null);
                    if (!found) 
                    {
                        MessageBox.Show("Person Not Found", "Information", MessageBoxButtons.OK);
                        txtID.Focus();
                        txtID.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter ID For Good Result", "Warning", MessageBoxButtons.OK);
                    txtID.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            SR.Close();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            Form frahowAllInfo = new ShowAllPersons();
            frahowAllInfo.Icon =this.Icon;
            frahowAllInfo.ShowDialog();

            CleanAllControls();




            //Form frmShow = new Form();
            //TextBox txtbShow = new TextBox();
            //frmShow.StartPosition= FormStartPosition.CenterParent;
            //frmShow.Font = this.Font;
            //frmShow.Icon= this.Icon;
            //frmShow.Text = "Show All Person Information";

            //txtbShow.Dock = DockStyle.Fill;
            //txtbShow.Font= this.Font;
            //txtbShow.Multiline = true;
            //frmShow.Controls.Add(txtbShow);

            //try
            //{
            //    StreamReader SR = new StreamReader("PersonData.txt");
            //    string line;
            //    line = SR.ReadToEnd();
            //    SR.Close();

            //    txtbShow.Text = line;
            //}
            //catch(Exception ex) 
            //{
            //    MessageBox.Show(ex.Message);    
            //}



            //frmShow.ShowDialog();

        }
        void UpdateFile(string AllLines)
        {
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("You are Sure You Want to Delete This Person", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            
            if(DR==DialogResult.Yes)
            {
                StreamReader rs = new StreamReader("PersonData.txt");
                string line;
                string AllLines = "";

                do
                {
                    line = rs.ReadLine();
                    if (line != null)
                    {
                        if (!line.Contains(txtID.Text))
                        {
                            AllLines += line + "\n";
                        }
                    }

                } while (line != null);
                rs.Close();
                StreamWriter Sw = new StreamWriter("PersonData.txt", false);
                //AllLines = AllLines.Trim();

                Sw.Write(AllLines);
                Sw.Close();


                CleanAllControls();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory =  "D:\\cpp project\\DesktopC_sharpProject\\" +
                "PersonInformatiomProject\\bin\\Debug\\img"; //"D:\\DV LOTTERY24\\"
            ofd.Filter = "images |*.jpg;*.png";
            if(ofd.ShowDialog() == DialogResult.OK) 
            {
                pic.Image = Image.FromFile(ofd.FileName);            
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form frmpic= new Form();
            frmpic.StartPosition= this.StartPosition;
            frmpic.Font =this.Font;
            frmpic.AutoScroll= true;
            frmpic.Text = "Show All Person Whith Pictures";
            frmpic.Icon =this.Icon;
            frmpic.Size = new Size(500, 600);
            frmpic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            frmpic.MinimizeBox = false; 
            frmpic.MaximizeBox = false;

            StreamReader SR = new StreamReader("PersonData.txt");
            int MyTop = 0;
            string line;
            do
            {
                line = SR.ReadLine();

                if (line != null)
                {
                    TextBox txtb = new TextBox();
                    PictureBox picb = new PictureBox();
                    picb.SizeMode = PictureBoxSizeMode.StretchImage;
                    picb.Size = new Size(100, 100);
                    picb.Top = MyTop;
                    picb.Left = 300;
                    picb.BorderStyle=BorderStyle.FixedSingle;


                    txtb.Text = line;


                    txtb.Top = MyTop;
                    txtb.Multiline = true;
                    txtb.Width = 295;
                    txtb.Height = 100;
                    txtb.Font = this.Font;
                    string MyPath = "img/" + line.Split(';')[0] + ".jpg";
                    if(File.Exists(MyPath))
                        picb.Image=Image.FromFile(MyPath);

                    frmpic.Controls.Add(picb);
                    frmpic.Controls.Add(txtb);

                    MyTop += 105;
                }

            } while (line != null);
            SR.Close();


            frmpic.ShowDialog();
            CleanAllControls();
        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("ID:" + txtID.Text, this.Font, Brushes.Black, 0, 0);
            e.Graphics.DrawString("Name:" + txtName.Text, this.Font, Brushes.Black, 0, 20);
            e.Graphics.DrawString("Address:" + txtAdrss.Text, this.Font, Brushes.Black, 0, 40);
            e.Graphics.DrawImage(pic.Image, 200, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(/*printDialog1.*/ printPreviewDialog1.ShowDialog() == DialogResult.OK) 
            {
                printDocument1.Print();
                SecurateInfo(true);
                
                
            }
            else
            {
                MessageBox.Show("File Is D'ont Save", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                SecurateInfo(true);
            }
            CleanAllControls();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (printDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamReader SR = new StreamReader("PersonData.txt");
                string line;
                do
                {
                    line = SR.ReadLine();
                    if (line != null)
                    {
                        string[] personData = line.Split(';');

                        txtID.Text = personData[0];
                        txtName.Text = personData[1];   
                        txtAdrss.Text= personData[2];

                        string MyPath = "img/" + personData[0] + ".jpg";
                        if (File.Exists(MyPath))
                            pic.Image = Image.FromFile(MyPath);

                    }
                    printDocument2.Print();

                } while (line != null);
                SR.Close();
            }
            else
            {
                MessageBox.Show("File Is D'ont Save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            CleanAllControls();
        }
        int myTopImag = 0;
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("ID:" + txtID.Text, this.Font, Brushes.Black, 0, 0);
            e.Graphics.DrawString("Name:" + txtName.Text, this.Font, Brushes.Black, 0, 20);
            e.Graphics.DrawString("Address:" + txtAdrss.Text, this.Font, Brushes.Black, 0, 40);
            e.Graphics.DrawImage(pic.Image, 200, myTopImag);
            myTopImag += 105;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                CleanAllControls();
                SecurateInfo(true);
            }

        }

        private void txtID_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtID.Text)) 
            {
                e.Cancel=true;
                txtID.Focus();
                errorProvider1.SetError(txtID, "ID Shoud Have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtID, "");
            }

        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider1.SetError(txtName, "ID Shoud Have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, "");
            }
        }

        private void txtAdrss_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdrss.Text))
            {
                e.Cancel = true;
                txtAdrss.Focus();
                errorProvider1.SetError(txtAdrss, "ID Shoud Have a value");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAdrss, "");
            }
        }
    }
}
