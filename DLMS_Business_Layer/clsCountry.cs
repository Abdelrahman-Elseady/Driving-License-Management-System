using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLMS_Data_Layer;

namespace DLMS_Business_Layer
{
    public class clsCountry
    {
        public enum enMode { AddNew=0,Update = 1 }
        public enMode Mode;
        public int CountryID {  get; set; }
        public string CountryName { get; set; }
        public clsCountry()
        {
            CountryID = -1;
            CountryName= string.Empty;
            Mode = enMode.AddNew;
        }
        private clsCountry( int countryID, string countryName)
        {
            CountryID = countryID;
            CountryName = countryName;
            Mode = enMode.Update;
        }
        private bool _AddNewCountry()
        {
            this.CountryID = clsCountryData.AddNewCountry(this.CountryName);
            return this.CountryID != -1;
        }
        private bool _UpdateCountry()
        {
            return clsCountryData.UpdateCountry(this.CountryID, this.CountryName);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewCountry())
                    {
                        Mode = enMode.AddNew;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateCountry();
            }
            return false;
        }
        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }
        public static clsCountry FindCountry(int CountryID)
        {
            string CountryName= string.Empty;
            if(clsCountryData.GetCountryInfo(CountryID,ref CountryName))
                return new clsCountry(CountryID,CountryName);
            return null;
        }
        public static clsCountry FindCountry(string CountryName)
        {
            int CountryID = -1;
            if (clsCountryData.GetCountryInfo(CountryName, ref CountryID))
                return new clsCountry(CountryID, CountryName);
            return null;
        }
    }
}
