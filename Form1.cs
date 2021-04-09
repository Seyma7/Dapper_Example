using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dapper_Example
{
    public partial class Form1 : Form
    {
        EducationLayer getEducationLayer;
        Student getStudent;
        int _id;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            getStudent = new Student()
            {
                Id = _id,
                Name = txtBxName.Text,
                Surname = txtBxSurname.Text,
                Address = txtBxAddress.Text
            };
            if (_id==0)
            {
                getEducationLayer = new EducationLayer();
                getEducationLayer.Save(getStudent);
                MessageBox.Show("Kayıt başarılı");
            }
            else
            {
                getEducationLayer.Update(getStudent);
                MessageBox.Show("Güncelleme başarılı");
            }

            FillGrid();
        }

         void FillGrid()
        {
            getEducationLayer = new EducationLayer();
            var list=getEducationLayer.GetAll();
            dgwStudent.DataSource = list;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                getStudent = new Student()
                {
                    Id=_id
                };
                getEducationLayer = new EducationLayer();
                getEducationLayer.Delete(getStudent);
                MessageBox.Show("Successful Delete Transaction");
                FillGrid();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }


        private void dgwStudent_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgwStudent.CurrentRow.Index != -1)
                {
                    _id = Convert.ToInt32(dgwStudent.CurrentRow.Cells[0].Value.ToString());
                    
                    txtBxName.Text=dgwStudent.CurrentRow.Cells[1].Value.ToString();

                    txtBxSurname.Text = dgwStudent.CurrentRow.Cells[2].ToString();

                    txtBxAddress.Text= dgwStudent.CurrentRow.Cells[3].ToString();

                    btnDelete.Enabled = true;
                    btnSave.Text = "Update";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FillGrid();
            }
            catch (Exception ex)
            {

                throw new Exception("Check your SQL connection!"+ex.Message.ToString());
            }
        }
    }
}
