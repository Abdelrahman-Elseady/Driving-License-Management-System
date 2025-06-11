using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLMS_Business_Layer;
namespace DLMS_Presentation_Layer
{
    public partial class frmPeople : Form
    {
        private static DataTable _dtAllPeople ;
        private static DataTable _dtPeople;
        public frmPeople()
        {
            InitializeComponent();
            _dtAllPeople = clsPerson.GetAllPersons();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "GenderCaption", "DateOfBirth", "CountryName", "Phone", "Email");
        }

        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPerson.GetAllPersons();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GenderCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            dgvPeople.DataSource = _dtPeople;
            lblRowsNum.Text = dgvPeople.Rows.Count.ToString();
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            dgvPeople.DataSource = _dtPeople;
            lblRowsNum.Text = dgvPeople.RowCount.ToString();
            if(dgvPeople.RowCount > 0 )
            {
                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[1].HeaderText = "National No";
                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[6].HeaderText = "Gender";
                dgvPeople.Columns[7].HeaderText = "Date Of Birth";
                dgvPeople.Columns[8].HeaderText = "Country";
                dgvPeople.Columns[9].HeaderText = "Phone";
                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns["Email"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterText.Visible = (cbFilter.Text != "None");
            if(txtFilterText.Visible)
            {
                txtFilterText.Text = "";
                txtFilterText.Focus();
            }
        }

        private void txtFilterText_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cbFilter.Text.Trim())
            {
                case "None":
                    FilterColumn = "None"; 
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;
                case "Country":
                    FilterColumn = "CountryName";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
            }
            if(FilterColumn == "None" || txtFilterText.Text.Trim() == "") 
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRowsNum.Text = dgvPeople.RowCount.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterText.Text.Trim());
            else
            {
                string FilterValue = txtFilterText.Text.Trim().Replace("'","''");
                _dtPeople.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterColumn, FilterValue);
            }

            lblRowsNum.Text = dgvPeople.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void ShowDetailsStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmPersonDetails frmPersonDetails = new frmPersonDetails(PersonId);
            frmPersonDetails.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            int ID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if(!clsPerson.DeletePerson(ID))
            {
                MessageBox.Show("Failed To delete this person","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            _RefreshPeoplList();

        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm=new frmAddUpdatePerson();
            frm.ShowDialog();
        }

        private void AddNewPersontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
        }

        private void EdittoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value.ToString());
            frmAddUpdatePerson frm=new frmAddUpdatePerson(ID);
            frm.ShowDialog();
        }
    }
}
