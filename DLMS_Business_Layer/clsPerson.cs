using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DLMS_Data_Layer;

namespace DLMS_Business_Layer
{
    public class clsPerson
    {
        internal enum enMode { AddNew = 0, Update = 1 }

        internal enMode Mode;
        public string NationalNo { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + SecondName; } }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalCountryID { get; set; }
        public string Image_Path { get; set; }
        public clsCountry Country;


        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
            this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.Country = null;
            this.DateOfBirth = DateTime.Now;
            this.NationalCountryID = -1;
            this.Image_Path = string.Empty;
            this.Mode = enMode.AddNew;
        }
        public static DataTable GetAllPersons()
        {
            return clsPersonData.GetAllPeople();
        }
        private clsPerson(string nationalNo, int personID, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, bool gender, string address, string phone, string email, int nationalCountryID, string image_Path)
        {
            Mode = enMode.Update;
            NationalNo = nationalNo;
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalCountryID = nationalCountryID;
            Image_Path = image_Path;
            Country = clsCountry.FindCountry(NationalCountryID);
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Email, this.Phone, this.NationalCountryID, this.Image_Path);
            return PersonID != -1;
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gender, this.Address, this.Email, this.Phone, this.NationalCountryID, this.Image_Path);
        }
        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            this.Mode = enMode.Update;
                            return true;
                        }
                    }
                    break;
                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }
        public static clsPerson FindPerson(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Email = "", Phone = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            bool Gender = false;
            int NationalityCountryID = -1;
            if (clsPersonData.GetPersonByID(ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Email, ref Phone, ref NationalityCountryID, ref ImagePath))
                return new clsPerson(NationalNo, ID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            return null;
        }
        public static clsPerson FindPerson(string NationalNo)
        {
            string  FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Email = "", Phone = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.MinValue;
            bool Gender = false;
            int PersonID=-1, NationalityCountryID = -1;
            if(clsPersonData.GetPersonByNationalNo(NationalNo,ref PersonID,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref DateOfBirth,ref Gender,ref Address,ref Email,ref Phone,ref NationalityCountryID,ref ImagePath))
                return new clsPerson(NationalNo, PersonID, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            return null;
        }
        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
    }

}
