using System;
using System.Collections.Generic;

/////////////////////////////////////////////////////
///CreatedBy Newton     Date:30/01/2010
///Sl.No    ModifiedBy      Date        Changes Made
///1.       Newton          30/01/2010  Code Updation Comments Added          
///2.                                                   
//////////////////////////////////////////////////////

namespace HospitalManagement
{
    interface DBOperation<T>
    {
        string Create(T t);
        Boolean Update(T t);
        List<T> List();
        T ListByID(string str);
        Boolean Delete(T t);
    }
}



