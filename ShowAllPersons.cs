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
using System.Xml.Linq;

namespace PersonInformatiomProject
{
    public partial class ShowAllPersons : Form
    {
        public ShowAllPersons()
        {
            InitializeComponent();
        }
        int index;
        private void ShowAllPersons_Shown(object sender, EventArgs e)
        {

            if (lsvPersonsInformation.Items.Count>0)
            {
                foreach (ListViewItem li in lsvPersonsInformation.Items)
                {
                    li.Remove();

                }
            }
                StreamReader SR = new StreamReader("PersonData.txt");
                string line;
                do
                {
                    line = SR.ReadLine();

                    if (line != null)
                    {
                        string[] arrpersonInfo = line.Split(';');
                       // arrpersonInfo.Append("img/" + arrpersonInfo[0] + ".jpg");
                        ListViewItem list = new ListViewItem(arrpersonInfo);
                        
                       lsvPersonsInformation.Items.Add(list);
                       combSearch.Items.Add(arrpersonInfo[1]);
                         

                    }

                } while (line != null);
                SR.Close();

            
        }

        
       

        private void button1_Click(object sender, EventArgs e)
        {
            bool FindIt = false;
            foreach(ListViewItem li in lsvPersonsInformation.Items)
            {
                if(li.SubItems[1].Text == combSearch.Text)
                {
                    li.Selected = true;
                    FindIt = true;
                }
                else
                {
                    li.Remove();
                }

            }

            if(FindIt)
            {
                MessageBox.Show("Person is Exist ", "Information", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Person is not Exist ", "Information", MessageBoxButtons.OK);
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem li in lsvPersonsInformation.Items)
            {
                 li.Remove();

            }
            combSearch.Items.Clear();
            StreamReader SR = new StreamReader("PersonData.txt");
            string line;
            do
            {
                line = SR.ReadLine();

                if (line != null)
                {
                    string[] arrpersonInfo = line.Split(';');
                    //arrpersonInfo[3] = "img/" + arrpersonInfo[0] + ".jpg";
                    ListViewItem list = new ListViewItem(arrpersonInfo);
                    lsvPersonsInformation.Items.Add(list);
                    combSearch.Items.Add(arrpersonInfo[1]);

                }

            } while (line != null);
            SR.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text =="Save")
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to Save", "Save", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    StreamWriter SW = new StreamWriter("PersonData.txt", false);

                    foreach (ListViewItem li in lsvPersonsInformation.Items)
                    {
                        SW.WriteLine(li.SubItems[0].Text + ";" + li.SubItems[1].Text + ";" + li.SubItems[2].Text);
                    }



                    SW.Close();
                }
            }
            else if(btnSave.Text == "Update")
            {
                if (lsvPersonsInformation.SelectedIndices.Count > 0)
                {
                    
                    lsvPersonsInformation.Items[index].SubItems[1].Text = txtName.Text ;
                    lsvPersonsInformation.Items[index].SubItems[2].Text = txtAddress.Text;
                }

                btnSave.Text = "Save";
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("You are Sure You Want to Delete This Person", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (DR == DialogResult.Yes)
            {

                while(lsvPersonsInformation.SelectedIndices.Count > 0)
                    lsvPersonsInformation.Items.RemoveAt(lsvPersonsInformation.SelectedIndices[0]);

            }
        }
        
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lsvPersonsInformation.SelectedIndices.Count > 0)
            {
                index = lsvPersonsInformation.SelectedIndices[0];
                txtName.Text = lsvPersonsInformation.Items[index].SubItems[1].Text;
                txtAddress.Text = lsvPersonsInformation.Items[index].SubItems[2].Text;

                txtName.Focus();
                txtName.SelectAll();
                btnSave.Text = "Update";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm = new ControlInformation();

            frm.ShowDialog();
        }
    }
}
