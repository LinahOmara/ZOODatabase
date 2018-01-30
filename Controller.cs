using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace ZOO_Application
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }
//---------------------------------------------------------------------------
//--------------------------------Visitors-----------------------------------
//---------------------------------------------------------------------------


        public DataTable returnAnimals()
        {
            string query = "SELECT General_Kind ,Specific_Kind ,Visiting_Time_From ,Visiting_Time_To FROM Animal Group by General_Kind ,Specific_Kind ,Visiting_Time_From ,Visiting_Time_To  ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable returnTickets()
        {
            string query = "SELECT ForWhat , Price FROM Tickets";
            return dbMan.ExecuteReader(query);
        }
        public DataTable returnShows()
        {
            string query = "SELECT Title , Show_Day  , Duration ,Start_Time , Specific_Kind , General_Kind FROM Animal , Shows , ShowsDays SD , Animal_Acting_Shows ACS WHERE Title = ACS.Show_Title and Title = SD.Show_Title and A_ID = Animal_ID GROUP BY Title , Show_Day  , Duration ,Start_Time , Specific_Kind , General_Kind";
            return dbMan.ExecuteReader(query);
        }
        public DataTable returnRestandCafee()
        {
            string query = "SELECT Name,Service_Type, NearBy FROM RestaurantAndCafes";
            return dbMan.ExecuteReader(query);
        }
        public DataTable returnLostandFound()
        {
            string query = "SELECT Seq_Num,Name,DateFoundOrLost ,TheDescription ,Place FROM LostAndFound WHERE FoundOrLost = 'Found'";
            return dbMan.ExecuteReader(query);
        }


        public void VisitorFeedback(string dt, string fb) 
        {
            string query = " INSERT INTO  FeedBack ( FeedBack_Date , FeedBack_Text   ) VALUES (' " + dt + " ' , ' " + fb + " ' ) ";          
            dbMan.ExecuteNonQuery(query);
    
        }

//---------------------------------------------------------------------------
//--------------------------------Admin--------------------------------------
//---------------------------------------------------------------------------

        //---------------------Animals ----------------------------
        public DataTable ShowAnimals() 
        {
            string query = " SELECT   Animal_Name , DOBirth , Animal_ID , General_Kind , Specific_Kind , Visiting_Time_From , Visiting_Time_To , T_ID , Food_Type , Food_Time , AmountPerDay From Animal A , Food F   WHERE  A.Animal_ID  = F.A_ID";
           return dbMan.ExecuteReader(query);
        }


    //----------return columns name of animal to be set to the combo box---------
       public DataTable animalcol() 
        {
           string q = "SELECT name FROM sys.columns WHERE (   object_id = object_id('Food')or  object_id = object_id('Animal')) and name <> 'A_ID'  ";
            
           return dbMan.ExecuteReader(q);
        }
        //show animals in dataGrid view after the required selection 
        public DataTable selectedanimalcol(string columntxt, string selItem)
        {string q;
            // selitem may be int or  string , depending on the selected columne , so we have to check it 
        if (columntxt == "Animal_Name" || columntxt == "Specific_Kind" || columntxt == "General_Kind" || columntxt == "Food_Type")
            {
                  q = " SELECT  *  From Animal A , Food F   WHERE  A.Animal_ID  = F.A_ID and " + columntxt + " =  '" + selItem + "'  ";
            }
            else    q = " SELECT  *  From Animal A , Food F   WHERE  A.Animal_ID  = F.A_ID and " + columntxt + " =  " + selItem ;
          
                 return  dbMan.ExecuteReader(q);

        }
        //data of  selected columne , to be shown in the combobox
        public DataTable SearchAnimal(string columntxt)
        {
            string q = " SELECT DISTINCT " + columntxt + " FROM Animal, Food    ";
          return  dbMan.ExecuteReader(q);

        }
        public DataTable getT_ID()
        {
            string q = "SELECT DISTINCT T_ID From Animal ";
            return dbMan.ExecuteReader(q);
        }
        public void  InsertAnimal(string name , string DOB , int AID , string gKind , string sKind , int vFrom , int vTo , int TID , string fType , int fTime , int fAmount  )
         {
            //insert to animal 
            string q = "INSERT INTO Animal VALUES ( '"+name +"' , '"+DOB+"' , "+AID+" , ' "+gKind+"' , ' " + sKind + " ' , "+ vFrom +" , "+vTo+" , " + TID + " )";
            dbMan.ExecuteNonQuery(q);
          
            // insert to food
            string qf = "INSERT INTO Food VALUES  ( " + AID + " , '" + fType + "' , ' " + fTime + " ' , " + fAmount + " )";
            dbMan.ExecuteNonQuery(qf);
        }
        // check if animal id exist in animal table 
        public DataTable AIDExist(int ID )
        {
            string q = "SELECT Animal_ID FROM Animal WHERE Animal_ID = "+ID ;
            return dbMan.ExecuteReader(q);
        }
        // check if animal id exist in MedicalCare table 
        public DataTable AIDExistMC(int ID)
        {
            string q = "SELECT A_ID FROM MedicalCare WHERE A_ID = " + ID;
            return dbMan.ExecuteReader(q);
        }
        public void InsertAniShow(int id , string show)
        {
            string q = "INSERT INTO Animal_Acting_Shows VALUES ( "+id+ " , '"+show+"' )";
            dbMan.ExecuteNonQuery(q);
        }
        public void  deleteAnimal(int ID)
        {
            string q = "DELETE FROM Animal Where Animal_ID = "+ID;
        }
        //----------------------LOst and Found ----------------------------
        public DataTable ShowLostandFound()
        {
            string query = "SELECT * FROM LostAndFound ";
            return dbMan.ExecuteReader(query);
        }
        public DataTable ShowLostorFound(string x)
        {
            string query = "SELECT Seq_Num,Name,DateFoundOrLost ,TheDescription ,Place FROM LostAndFound WHERE FoundOrLost = '"+x+"'";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getSeqNo()
        {
            string q = "SELECT Seq_Num From LostandFound";
            return dbMan.ExecuteReader(q);
        }
        public void ConvertToFound(int seq)
        {
            string q = "UPDATE LostandFound set FoundOrLost = 'Found' Where Seq_Num = "+seq;
            dbMan.ExecuteNonQuery(q);
        }
        public void DeleteLostFOund(int seq)
        {
            string q = "DELETE LostandFound Where Seq_Num = "+seq;
            dbMan.ExecuteNonQuery(q);
        }
        //---------------------Medical Care----------------------------------

        public DataTable ShowMedCare()
        {
            string q = "SELECT * FROM  Examination E, MedicalCare M WHERE M.A_ID=E.A_ID ";
            return  dbMan.ExecuteReader(q);
        }
        public DataTable ShowSickAnimals()
        {
            string q = "SELECT * FROM  Examination E, MedicalCare M WHERE M.A_ID=E.A_ID and M.Healthy = 0 ";
            return dbMan.ExecuteReader(q);
        }
        public DataTable ShowMedCarebyID(string ID )
        {
            //To Do check if id is available 
            string q = "SELECT * FROM  Examination E, MedicalCare M WHERE M.A_ID=E.A_ID  and M.A_ID = ' " + ID + " ' ; ";
            return dbMan.ExecuteReader(q);
        }
        //-------------------------MEdicines-------------------------
        public DataTable ShowMEdicines() 
        {
            string q = "SELECT * FROM Medicine";
            return dbMan.ExecuteReader(q);
        }
        public DataTable ShowMEdicinesNeedToBuy()
        {
            string q = "SELECT * FROM Medicine WHERE Medicine_Quantity < 5";
            return dbMan.ExecuteReader(q);
        }
        //-------------------------Employees--------------------------

        public DataTable ShowEmployees()
        {
            string q = "SELECT * FROM Employee E  ";
            return dbMan.ExecuteReader(q);
        }
        public DataTable ShowEmployeesByJob(string job)
        {
            if (job == "Doctor")
            {
                string q = "SELECT  Doctor_ID, Employee_Name , Password, Job , Salary , Shift FROM Employee E , Doctor D   Where E.Employee_ID = D.Doctor_ID  ";
                return dbMan.ExecuteReader(q);
            }
            else
            {
                if (job == "Keeper")
                {
                    string q = "SELECT Keeper_ID, Employee_Name , Password, Job , Salary ,A_ID, Shift FROM Employee E  , Keeper K , Keeping Q Where Keeper_ID = K_ID and K_ID = Employee_ID  ";
                    return dbMan.ExecuteReader(q);
                }
                else
                {
                    string q = "SELECT * FROM Employee E Where  Job = '" + job+"'";
                    return dbMan.ExecuteReader(q);
                }
            }
        }
        public DataTable EIDExist(int ID)
        {
            string q = "SELECT Employee_ID FROM Employee WHERE Employee_ID = " + ID;
            return dbMan.ExecuteReader(q);
        }
        public void  updateSalry(int id , int salary)
        {
            string q = "UPDATE Employee SET Salary =  "+salary +" WHERE Employee_ID = "+id  ;
           dbMan.ExecuteNonQuery(q);
        }
        public DataTable EmplJob()
        {
            string q = "SELECT  DISTINCT Job FROM Employee ";
            return dbMan.ExecuteReader(q);
        }
        //---------------------------researchers------------------------
        public DataTable ShowResearchers()
        {
            string q = "SELECT * FROM Researcher , Researches WHERE Researcher_ID = RES_ID  ";
            return dbMan.ExecuteReader(q);
        }
        public void InsertResearcher(string name , string college , string startDate , string endDate )
        {
            string q = " INSERT INTO Researcher (Researcher_Name , College , Start_Date , End_Date) VALUES ( ' " + name + " ' , ' " + college + " ' , ' " + startDate + " ' , ' " + endDate + " ' ) ; ";
          
            dbMan.ExecuteNonQuery(q);
          
        }

        public void InserResearch(int  AID , int RID , string title , string  type , string result )
        {
            string q = "INSERT INTO Researches VALUES ( "+ AID +" , "+RID+", ' "+title+" ' , ' "+type+" ' , ' "+result+" ' ) ; ";
            dbMan.ExecuteNonQuery(q);
        }
        //---------------------------Feedback------------------------
        public DataTable ShowFeedback()
        { 
        string q ="SELECT * FROM FeedBack";
        return dbMan.ExecuteReader(q);
        }
       
        //---------------------------Shows------------------------
        public DataTable ShowShows()
        {
            string q = "SELECT * FROM Shows S, Shows_Trainers T , ShowsDays D WHERE S.Title = T.Show_Title and S.Title = D.Show_Title  ";
            return dbMan.ExecuteReader(q);
        }
        public DataTable ShowsTitle()
        {
            string q = "SELECT DISTINCT Title FROM Shows";
            return dbMan.ExecuteReader(q);
        }
        public DataTable ShowsbyTitle(string title)
        {
            string q = "SELECT * FROM Shows S, Shows_Trainers T , ShowsDays D WHERE S.Title = T.Show_Title and S.Title = D.Show_Title and S.Title = '"+title+ " ' ;";
            return dbMan.ExecuteReader(q);
        }
        //---------------------------Rest&Cafe--------------------

        public DataTable ShowRestCafee()
        {
            string q = "SELECT * FROM RestaurantAndCafes";
            return dbMan.ExecuteReader(q);
        }

        public DataTable RentedRest()
        {
            string q = "SELECT * FROM RestaurantAndCafes WHERE RentedOrNot = 1 ";
            return dbMan.ExecuteReader(q);
        }
        public DataTable NotRentedRest()
        {
            string q = "SELECT * FROM RestaurantAndCafes WHERE RentedOrNot = 0 ";
            return dbMan.ExecuteReader(q);
        }
        //---------------------------Bye Bye =) ------------------
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
    }
}
