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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DLMS_Presentation_Layer
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public DataBackEventHandler DataBack;

        public enum enMode { AddNew=0, Update=1}
        public enMode Mode;
        public int PersonID = -1; 
        private clsPerson _Person;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Mode=enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            this.PersonID = PersonID;
            Mode = enMode.Update;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked && pbPersonImage.ImageLocation == null)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(rbFemale.Checked && pbPersonImage.ImageLocation==null )
            {
                pbPersonImage.Image = Resources.Female_512;
            }
        }
        private void _FillCountriesInComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();
            foreach (DataRow dr in dt.Rows)
            {
                cbCountry.Items.Add(dr["CountryName"].ToString());
            }
        }
        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();
            if (Mode == enMode.AddNew)
            {
                lblAddUpdateTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblAddUpdateTitle.Text = "Update Person"; 
            }
            if (rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;


            lblRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            cbCountry.SelectedItem = "Egypt";
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.Value = dtDateOfBirth.MaxDate;

            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            txtPhone.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            rbMale.Checked = true;

        }
        private void _LoadData()
        {
            _Person = clsPerson.FindPerson(PersonID);
            if(_Person==null)
            {
                MessageBox.Show("There is no person with id: " + PersonID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtAddress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text= _Person.NationalNo;
            txtPhone.Text = _Person.Phone;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            rbMale.Checked = !(_Person.Gender);
            rbFemale.Checked = _Person.Gender;
            cbCountry.SelectedItem= _Person.Country.CountryName;
            dtDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Image_Path != "")
                pbPersonImage.ImageLocation = _Person.Image_Path;
            lblRemoveImage.Visible = (pbPersonImage.ImageLocation != "");
            lblPersonID.Text = _Person.PersonID.ToString();

        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (Mode == enMode.Update)
                _LoadData();
        }
  
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)(sender);
            if (string.IsNullOrEmpty(temp.Text.Trim()))
                errorProvider1.SetError(temp, "This Field is Required");
            else
                errorProvider1.SetError(temp, null);
        }

        private void NationalNoValidating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
                errorProvider1.SetError(txtNationalNo, "This Field is Required");
            else if (clsPerson.IsPersonExist(txtNationalNo.Text.Trim()) && _Person.NationalNo!=txtNationalNo.Text.Trim())
                errorProvider1.SetError(txtNationalNo, "This National No already exist");
            else
                errorProvider1.SetError(txtNationalNo, null);
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                errorProvider1.SetError(txtEmail, null);
            else
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtEmail.Text.Trim(), pattern))
                {
                    errorProvider1.SetError(txtEmail, "Invalid email format.");
                }
                else
                    errorProvider1.SetError(txtEmail, null);
            }
               

        }

        private void lblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            lblRemoveImage.Visible = false;
            if (rbFemale.Checked)
                pbPersonImage.Image = Resources.Female_512;
            else
                pbPersonImage.Image = Resources.Male_512;
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image File|*.png;*.jpeg;*.jpg;*.bmp;*.gif";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string Path = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = Path;
                lblRemoveImage.Visible = true;
            }
        }

        private bool _HandlePersonImageWhenSaving()
        {
            if(pbPersonImage.ImageLocation != _Person.Image_Path )
            {
                if(_Person.Image_Path!= null && _Person.Image_Path!=string.Empty)
                {
                    try
                    {
                        File.Delete(_Person.Image_Path);
                    }
                    catch
                    {
                        return false;
                    }
                }
                if(pbPersonImage.ImageLocation!= null && pbPersonImage.ImageLocation != string.Empty)
                {
                    try
                    {
                        Guid guid = Guid.NewGuid();
                        string extension = Path.GetExtension(pbPersonImage.ImageLocation);
                        string destination = "D:\\vs\\DLMS\\Person Images\\" + guid + extension;
                        File.Copy(pbPersonImage.ImageLocation, destination);
                        _Person.Image_Path = destination;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    _Person.Image_Path = null;
                }

            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("some Fields Are not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImageWhenSaving())
                return;


            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtDateOfBirth.Value;
            _Person.Gender = !rbMale.Checked;

            int NationalityCountryID = clsCountry.FindCountry(cbCountry.Text).CountryID;
            _Person.NationalCountryID = NationalityCountryID;


            if (_Person.Save())
            {
                lblPersonID.Text = _Person.PersonID.ToString();
                //change form mode to update.
                Mode = enMode.Update;
                lblAddUpdateTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
    }
}
