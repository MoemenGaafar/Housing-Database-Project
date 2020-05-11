﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    public class Controller
    {
        private DBManager dbMan; // A Reference of type DBManager 
                                 // (Initially NULL; NO DBManager Object is created yet)

        public Controller()
        {
            dbMan = new DBManager(); // Create the DBManager Object
        }

        //checks the username/password and returns the priviledges associated with this user
        //Returns 0 in case of error
        public DataTable CheckPassword_Citizen(int id, string password)
        {
            string StoredProcedureName = StoredProcedures.CheckPassword_Citizen;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalId", id);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable CheckPassword_Employee(int id, string password)
        {
            string StoredProcedureName = StoredProcedures.CheckPassword_Employee;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalId", id);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable CheckPassword_Company(int id, string password)
        {
            string StoredProcedureName = StoredProcedures.CheckPassword_Company;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@CID", id);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable CheckPassword_Bank(string name, string password)
        {
            string StoredProcedureName = StoredProcedures.CheckPassword_Bank;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable CheckPassword_Admin(string name, string password)
        {
            string StoredProcedureName = StoredProcedures.CheckPassword_Admin;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable GetTransactionFee(string name)
        {
            string StoredProcedureName = StoredProcedures.GetTransactionFee;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int ChangeTransactionFee(string name, int fee)
        {
            string StoredProcedureName = StoredProcedures.ChangeTransactionFee;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@Fee", fee);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ChangePassword_Citizen(int id, string password)
        {
            string StoredProcedureName = StoredProcedures.ChangePassword_Citizen;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalId", id);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int ChangePassword_Employee(int id, string password)
        {
            string StoredProcedureName = StoredProcedures.ChangePassword_Employee;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalId", id);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ChangePassword_Company(int id, string password)
        {
            string StoredProcedureName = StoredProcedures.ChangePassword_Company;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@CID", id);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ChangePassword_Bank(string name, string password)
        {
            string StoredProcedureName = StoredProcedures.ChangePassword_Bank;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int ChangePassword_Admin(string name, string password)
        {
            string StoredProcedureName = StoredProcedures.ChangePassword_Admin;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@Password", password);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int Add_CitTransaction(long TID, string BankName, int EmployeeID, int CitizenID, int ProjectID, int UnitID, int Amount)
        {
            string StoredProcedureName = StoredProcedures.Add_CitTransaction;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@TID", TID);
            Parameters.Add("@BankName", BankName);
            Parameters.Add("@EmployeeID", EmployeeID);
            Parameters.Add("@CitizenID", CitizenID);
            Parameters.Add("@ProjectID", ProjectID);
            Parameters.Add("@UnitID", UnitID);
            Parameters.Add("@Amount", Amount);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int Add_ComTransaction(long TID, string BankName, int EmployeeID, int CompanyID, int Amount)
        {
            string StoredProcedureName = StoredProcedures.Add_ComTransaction;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@TID", TID);
            Parameters.Add("@BankName", BankName);
            Parameters.Add("@EmployeeID", EmployeeID);
            Parameters.Add("@CompanyID", CompanyID);
            Parameters.Add("@Amount", Amount);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable GetAllProjectIDs()
        {
            string StoredProcedureName = StoredProcedures.GetAllProjectIDs;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable SelectAllCompanies()
        {
            string StoredProcedureName = StoredProcedures.SelectAllCompanies;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable SelectAllCompanyBankTransactions(string name)
        {
            string StoredProcedureName = StoredProcedures.SelectAllCompanyBankTransactions;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable SelectCompanyBankTransactions(string name, int CID)
        {
            string StoredProcedureName = StoredProcedures.SelectCompanyBankTransactions;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@CID", CID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable SelectAllCitizenBankTransactions(string name)
        {
            string StoredProcedureName = StoredProcedures.SelectAllCitizenBankTransactions;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public DataTable SelectCitizenBankTransactions(string name, int CID)
        {
            string StoredProcedureName = StoredProcedures.SelectCitizenBankTransactions;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@CID", CID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        /////////////////////////////////////// Sign Up Queries /////////////////////////////////////////////
        public int SignUpBank(string name, string password, int transfees)
        {
            string StoredProcedureName = StoredProcedures.Insert_Bank;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Name", name);
            Parameters.Add("@Password", password);
            Parameters.Add("@TranFees", transfees);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int SignUpCompany(string name, string password, int rating, int compproj, int currproj, int avgcost)
        {
            string StoredProcedureName = StoredProcedures.Insert_Company;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@Password", password);
            Parameters.Add("@Name", name);
            Parameters.Add("@NoCompleteProj", compproj);
            Parameters.Add("@NoCurrentProj", currproj);
            Parameters.Add("@Rating", rating);
            Parameters.Add("@AvgProjectCost", avgcost);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int SignUpCitizen(int id, string password, string firstname, string lastname, char sex, int salary,
            bool ownscurrent, string city, DateTime birthdate, int currentprice)
        {
            string StoredProcedureName = StoredProcedures.Insert_Citizen;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalId", id);
            Parameters.Add("@Password", password);
            Parameters.Add("@FirstName", firstname);
            Parameters.Add("@LastName", lastname);
            Parameters.Add("@BirthDate", birthdate);
            Parameters.Add("@Salary", salary);
            Parameters.Add("@Sex", sex);
            Parameters.Add("@CurentCity", city);
            Parameters.Add("@OwnsCurrent", ownscurrent);
            Parameters.Add("@CurrentAccommPrice", currentprice);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int SignUpEmployee(int id, string password, string firstname, string lastname, char sex, int compproj,
             int currproj, char type, DateTime birthdate)
        {
            string StoredProcedureName = StoredProcedures.Insert_Employee;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalId", id);
            Parameters.Add("@Password", password);
            Parameters.Add("@FirstName", firstname);
            Parameters.Add("@LastName", lastname);
            Parameters.Add("@StartDate", birthdate);
            Parameters.Add("@EType", type);
            Parameters.Add("@Sex", sex);
            Parameters.Add("@NoCompleteProj", compproj);
            Parameters.Add("@NoCurrentProj", currproj);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        /////////////////////////////////////// M Employee Functionalities  ///////////////////////////////////////////
        public DataTable GetAllProjectEmployees()
        {
            string StoredProcedureName = StoredProcedures.GetAllProjectEmployees;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable GetAllCompanies()
        {
            string StoredProcedureName = StoredProcedures.GetAllCompanies;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable GetAllEmployees()
        {
            string StoredProcedureName = StoredProcedures.GetAllEmployees;
            return dbMan.ExecuteReader(StoredProcedureName, null);
        }

        public DataTable SelectProjectByCompany(int cid)
        {
            string StoredProcedureName = StoredProcedures.SelectProjectByCompany;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@CID", cid);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);

        }

        public DataTable SelectProjectByEmployee(int eid, string type)
        {
            char Etype;
            switch (type)
            {
                case "Housing": Etype = 'H'; break;
                case "Projects": Etype = 'P'; break;
                default: Etype = 'M'; break;
            }
            string StoredProcedureName = StoredProcedures.SelectProjectByEmployee;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@EID", eid);
            Parameters.Add("@EType", Etype);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);

        }

        public int Insert_Project(string city, int price, int mgrEmpID, int projEmpID)
        {
            string StoredProcedureName = StoredProcedures.Insert_Project;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@City", city);
            Parameters.Add("@MEmployeeID", mgrEmpID);
            Parameters.Add("@PricePRoom", price);
            Parameters.Add("@PEmployeeID", projEmpID);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable SelectProjectByMEMPID(int ID, string statusFilter, string cityFilter)
        {
            char status;
            switch (statusFilter)
            {
                case "All Units Sold":
                    {
                        status = 'F';
                        break;
                    }
                case "Posted":
                    {
                        status = 'P';
                        break;
                    }
                case "Started":
                    {
                        status = 'S';
                        break;
                    }
                case "Launched":
                    {
                        status = 'L';
                        break;
                    }
                default:
                    {
                        status = 'A';
                        break;
                    }
            }
            string StoredProcedureName = StoredProcedures.SelectProjectByMEMPID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalID", ID);
            Parameters.Add("@PStatus", status);
            Parameters.Add("@City", cityFilter);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable SelectAppByMEMPID(int ID, string statusFilter, int projectFilter, string client)
        {
            char status;
            switch (statusFilter)
            {
                case "Waiting":
                    {
                        status = 'W';
                        break;
                    }
                case "Accepted":
                    {
                        status = 'A';
                        break;
                    }
                case "Rejected":
                    {
                        status = 'R';
                        break;
                    }
                case "Done":
                    {
                        status = 'D';
                        break;
                    }
                default:
                    {
                        status = 'L';
                        break;
                    }
            }
            string StoredProcedureName;
            if (client == "Company")
            {
                if (ID == -1) //Admin
                    StoredProcedureName = StoredProcedures.SelectAllComApps;
                else
                    StoredProcedureName = StoredProcedures.SelectComAppByMEMPID;
            }
            else
            {
                if (ID == -1) //Admin
                    StoredProcedureName = StoredProcedures.SelectAllCitApps;
                else
                    StoredProcedureName = StoredProcedures.SelectCitAppByMEMPID;
            }

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            if (ID != -1)
                Parameters.Add("@NationalID", ID);
            Parameters.Add("@AStatus", status);
            Parameters.Add("@ProjectID", projectFilter);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        //public DataTable SelectTransByMEMPID(int ID, string bankName, string clientName, string client)
        //{
        //    string StoredProcedureName;
        //    if (client == "Company")
        //    {
        //        if (ID == -1) //Admin
        //            StoredProcedureName = StoredProcedures.SelectAllCompanyBankTransactions;
        //        else
        //            StoredProcedureName = StoredProcedures.SelectComTransByMEMPID;
        //    }
        //    else
        //    {
        //        if (ID == -1)
        //            StoredProcedureName = StoredProcedures.SelectAllCitizenBankTransactions;
        //        else
        //            StoredProcedureName = StoredProcedures.SelectCitTransByMEMPID;
        //    }

        //    Dictionary<string, object> Parameters = new Dictionary<string, object>();
        //    if (ID != -1)
        //        Parameters.Add("@NationalID", ID);
        //    Parameters.Add("@BankName", bankName);
        //    Parameters.Add("@ClientName", clientName);
        //    return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        //}
        /////////////////////////////////////// P Employee Functionalities ///////////////////////////////////////////
        public DataTable SelectProjectByPEMPID(int ID, string statusFilter, string cityFilter)
        {
            char status;
            switch (statusFilter)
            {
                case "All Units Sold": 
                    {
                        status = 'F';
                        break;
                    }
                case "Posted":
                    {
                        status = 'P';
                        break;
                    }
                case "Started":
                    {
                        status = 'S';
                        break;
                    }
                case "Launched":
                    {
                        status = 'L';
                        break;
                    }
                default:
                    {
                        status = 'A';
                        break;
                    }
            }
            string StoredProcedureName = StoredProcedures.SelectProjectByPEMPID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalID", ID);
            Parameters.Add("@PStatus", status);
            Parameters.Add("@City", cityFilter);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable SelectAppByEMPID(int ID, string statusFilter, int projectFilter, string type)
        {
            char status;
            switch (statusFilter)
            {
                case "Waiting":
                    {
                        status = 'W';
                        break;
                    }
                case "Accepted":
                    {
                        status = 'A';
                        break;
                    }
                case "Rejected":
                    {
                        status = 'R';
                        break;
                    }
                case "Done":
                    {
                        status = 'D';
                        break;
                    }
                default:
                    {
                        status = 'L';
                        break;
                    }
            }
            string StoredProcedureName;

            if (type == "Projects")
                StoredProcedureName = StoredProcedures.SelectComAppByPEMPID;
            else 
                StoredProcedureName = StoredProcedures.SelectCitAppByHEMPID;

            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalID", ID);
            Parameters.Add("@AStatus", status);
            Parameters.Add("@ProjectID", projectFilter);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int ChangeComApplicationStatus(int projectID, string companyName, char newStatus)
        {
            string StoredProcedureName = StoredProcedures.ChangeComApplicationStatus;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ProjectID", projectID);
            Parameters.Add("@CompanyName", companyName);
            Parameters.Add("@NewStatus", newStatus);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable SelectAllBanks()
        {
            string StoredProcedureName = StoredProcedures.SelectAllBanks;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable SelectTransByEMPID(int ID, string bankName, string clientName, string type)
        {
            string StoredProcedureName;
            if (type == "Projects")
                StoredProcedureName = StoredProcedures.SelectTransByPEMPID;
            else 
                StoredProcedureName = StoredProcedures.SelectTransByHEMPID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalID", ID);
            Parameters.Add("@BankName", bankName);
            if (type == "Projects")
                Parameters.Add("@CompanyName", clientName);
            else
                Parameters.Add("@CitizenName", clientName);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }


        /////////////////////////////////////// H Employee Functionalities ///////////////////////////////////////////
        public DataTable SelectProjectByHEMPID(int ID, string statusFilter, string cityFilter)
        {
            char status;
            switch (statusFilter)
            {
                case "All Units Sold":
                    {
                        status = 'F';
                        break;
                    }
                case "Posted":
                    {
                        status = 'P';
                        break;
                    }
                case "Started":
                    {
                        status = 'S';
                        break;
                    }
                case "Launched":
                    {
                        status = 'L';
                        break;
                    }
                default:
                    {
                        status = 'A';
                        break;
                    }
            }
            string StoredProcedureName = StoredProcedures.SelectProjectByHEMPID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalID", ID);
            Parameters.Add("@PStatus", status);
            Parameters.Add("@City", cityFilter);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable SelectUnitByHEMPID(int ID, string statusFilter, int projectFilter)
        {
            bool? status;
            switch (statusFilter)
            {
                case "Sold":
                    {
                        status = true;
                        break;
                    }
                case "Not Sold":
                    {
                        status = false;
                        break;
                    }
                default:
                    {
                        status = null;
                        break;
                    }
            }
            string StoredProcedureName = StoredProcedures.SelectUnitByHEMPID;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@NationalID", ID);
            if (!(status is null))
                Parameters.Add("@UStatus", status);
            else
                Parameters.Add("@UStatus", DBNull.Value);
            Parameters.Add("@ProjectID", projectFilter);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int ChangeCitApplicationStatus(int projectID, int unitID, int citizenID, char newStatus)
        {
            string StoredProcedureName = StoredProcedures.ChangeCitApplicationStatus;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@ProjectID", projectID);
            Parameters.Add("@UnitID", unitID);
            Parameters.Add("@CitizenID", citizenID);
            Parameters.Add("@NewStatus", newStatus);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
    }
}
