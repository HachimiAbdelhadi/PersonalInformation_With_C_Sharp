using System;
using System.Collections;
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
    public partial class ControlInformation : Form
    {
        public ControlInformation()
        {
            InitializeComponent();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void ControlInformation_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("PersonData.txt");
            string line;
            while((line = sr.ReadLine()) !=null)
            {
                string[] info= line.Split(';');
                dgvPersonsInfo.Rows.Add(info[0], info[1], info[2],
                    Image.FromFile("D:\\cpp project\\DesktopC_sharpProject\\" +
                    "PersonInformatiomProject\\bin\\Debug\\img\\"+ info[0]+".jpg"));

            }

            sr.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvPersonsInfo.Rows.Add();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("PersonData.txt", false);
            if(dgvPersonsInfo.Rows.Count>0)
            {
                string line;
                int i = 0;
                foreach (DataGridViewRow dgv in dgvPersonsInfo.Rows)
                {
                     i = dgv.Index;
                    line  = dgv.Cells[0].Value.ToString()+ ";";
                    line += dgv.Cells[1].Value.ToString() + ";";
                    line += dgv.Cells[2].Value.ToString() + ";";
                    line += "D:\\cpp project\\DesktopC_sharpProject\\" +
                    "PersonInformatiomProject\\bin\\Debug\\img\\" 
                    + dgv.Cells[0].Value.ToString() + ".jpg";

                    if (!Directory.Exists("img"))
                        Directory.CreateDirectory("img");


                     

                    

                    sw.WriteLine(line);
                }
            }

            sw.Close();

        }

        private void addImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\cpp project\\DesktopC_sharpProject\\" +
                "PersonInformatiomProject\\bin\\Debug\\img"; //"D:\\DV LOTTERY24\\"
            ofd.Filter = "images |*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dgvPersonsInfo.SelectAll();
                dgvPersonsInfo.SelectedRows[0].Cells[3].Value = Image.FromFile(ofd.FileName);
            }
        }
    }
}
