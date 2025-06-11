using DLMS_Business_Layer;
using DLMS_Presentation_Layer.Properties;
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

namespace DLMS_Presentation_Layer
{
    public partial class PersonCardUsrCtrl : UserControl
    {
        public PersonCardUsrCtrl()
        {
            InitializeComponent();
        }
        private clsPerson _Person;
        private int _Id = -1;
        public int ID { get { return this._Id; } }
        public clsPerson SelectedPerson {  get { return this._Person; } }

        private void _ResetValues()
        {
            this._Id = -1;
            this._Person = null;
            lblAddress.Text = "[????]";
            lblCountry.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblEmail.Text = "[????]";
            lblGender.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPersonID.Text = "[????]";
            lblPhone.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
        }
        private void _LoadPersonImage()
        {
            if(_Person.Gender)
                pbPersonImage.Image = Resources.Female_512;
            else
                pbPersonImage.Image = Resources.Male_512;

            if (_Person.Image_Path !=null && _Person.Image_Path != "") 
            {
                if (File.Exists(_Person.Image_Path))
                    pbPersonImage.ImageLocation = _Person.Image_Path;
                else
                    MessageBox.Show("There is no image With this path", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void _FillPersonInfo()
        {
            lblPhone.Text = _Person.Phone;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName;
            lblAddress.Text = _Person.Address;
            if (_Person.Gender)
                lblGender.Text = "Female";
            else
                lblGender.Text = "Male";
            lblEmail.Text = _Person.Email;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString().ToString();
            lblCountry.Text = _Person.Country.CountryName;
            _LoadPersonImage();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.FindPerson(PersonID);
            if (_Person == null)
            {

                _ResetValues();
                MessageBox.Show("There is no Person with ID: " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.FindPerson(NationalNo);
            if (_Person == null)
            {

                _ResetValues();
                MessageBox.Show("There is no Person with NationalNo: " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
