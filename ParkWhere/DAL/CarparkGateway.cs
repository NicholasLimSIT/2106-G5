using System.Collections.Generic;
using System.Linq;
using ParkWhere.Models;

namespace ParkWhere.DAL
{
    public class CarparkGateway : DataGateway<Carpark>
    {

        IEnumerable<Carpark> Carparks;

       
        public List<string[]> GetAllCarparks()
        {
            
            List<string[]> CarparkList;

            Carparks = SelectAll();
            CarparkList = new List<string[]>();

            foreach (var item in Carparks)
            {
                string[] listString = new string[7];
                listString[0] = item.id.ToString();
                listString[1] = item.carparkNo;
                listString[2] = item.address;
                listString[3] = item.carparkType;
                listString[4] = item.typeOfparking;
                listString[5] = item.x_coord.ToString();
                listString[6] = item.y_coord.ToString();
                CarparkList.Add(listString);
            }
            return CarparkList;
        }

        public List<string[]> searchCarpark(string address)
        {
            if (address== null)
            {
                
                
                List<string[]> CarparkList;

                Carparks = data.SqlQuery("SELECT * From dbo.Carparks ").ToList();
                CarparkList = new List<string[]>();

                foreach (var item in Carparks)
                {
                    string[] listString = new string[7];
                    listString[0] = item.id.ToString();
                    listString[1] = item.carparkNo;
                    listString[2] = item.address;
                    listString[3] = item.carparkType;
                    listString[4] = item.typeOfparking;
                    listString[5] = item.x_coord.ToString();
                    listString[6] = item.y_coord.ToString();
                    CarparkList.Add(listString);
                }
                return CarparkList;
            }
            else
            {
                List<string[]> CarparkList;
                string str = address.Substring(0, 5);
                Carparks = data.SqlQuery("SELECT * From dbo.Carparks WHERE address LIKE '%" + str + "%'").ToList();
                CarparkList = new List<string[]>();

                foreach (var item in Carparks)
                {
                    string[] listString = new string[7];
                    listString[0] = item.id.ToString();
                    listString[1] = item.carparkNo;
                    listString[2] = item.address;
                    listString[3] = item.carparkType;
                    listString[4] = item.typeOfparking;
                    listString[5] = item.x_coord.ToString();
                    listString[6] = item.y_coord.ToString();
                    CarparkList.Add(listString);
                }
                return CarparkList;
            }
        }
        public List<string[]> FilterAddressByType(string address,string parkingTyperesult, string carparkTyperesult)
        {
            
                string resultAddress = address.Substring(0, 5);
                
            List<string[]> CarparkList;
            string str = address.Substring(0, 5);
            Carparks = data.SqlQuery("SELECT * From dbo.Carparks WHERE address LIKE '%" + resultAddress + "%' AND typeOfparking = '" + parkingTyperesult + "' AND carparkType = '" + carparkTyperesult + "'").ToList();
            CarparkList = new List<string[]>();

            foreach (var item in Carparks)
            {
                string[] listString = new string[7];
                listString[0] = item.id.ToString();
                listString[1] = item.carparkNo;
                listString[2] = item.address;
                listString[3] = item.carparkType;
                listString[4] = item.typeOfparking;
                listString[5] = item.x_coord.ToString();
                listString[6] = item.y_coord.ToString();
                CarparkList.Add(listString);
            }
            return CarparkList;

        }
        public List<string[]> FilterByType(string parkingTyperesult, string carparkTyperesult)
        {

            
         

            

            List<string[]> CarparkList;
           
            Carparks = data.SqlQuery("SELECT * From dbo.Carparks WHERE typeOfparking = '" + parkingTyperesult + "' AND carparkType = '" + carparkTyperesult + "'").ToList();
            CarparkList = new List<string[]>();

            foreach (var item in Carparks)
            {
                string[] listString = new string[7];
                listString[0] = item.id.ToString();
                listString[1] = item.carparkNo;
                listString[2] = item.address;
                listString[3] = item.carparkType;
                listString[4] = item.typeOfparking;
                listString[5] = item.x_coord.ToString();
                listString[6] = item.y_coord.ToString();
                CarparkList.Add(listString);
            }
            return CarparkList;
        }
    }
}