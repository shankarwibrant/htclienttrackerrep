using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagement;
using HealthCareObjects.UserRights;

/////////////////////////////////////////////////////
///CreatedBy Newton     Date:30/01/2010
///Sl.No    ModifiedBy      Date        Changes Made
///1.       Newton          30/01/2010  Code Updation Comments Added          
///2.                                                   
//////////////////////////////////////////////////////

namespace PatientLibrary.Common
{


    public class EntityRight
    {
        //Checked out by Ajmal Khan

        
        
        //public enum EntityType { List = "List", Create = "Create", Update = "Update", Delete = "Delete" };

        public enum EntityType { List, Create, Update, Delete };
        public static Boolean GetRights(string entityName, EntityType eType, List<EntityAccessRight> objEARights)
        {
            foreach (EntityAccessRight item in objEARights)
            {
                if (item.EntityName.CompareTo(entityName) == 0)
                {
                    switch (eType)
                    {
                        case EntityType.List:
                            return (item.EntityRead);
                        case EntityType.Create:
                            return (item.EntityCreate);
                        case EntityType.Update :
                            return (item.EntityUpdate);
                        case EntityType.Delete:
                            return (item.EntityDelete);
                    }
                }
            }

            return false;
        }
    }
}
