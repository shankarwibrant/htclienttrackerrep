using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HealthCareObjects.Client;

namespace PatientServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFormFeatureServices" in both code and config file together.
    [ServiceContract]
    public interface IFormFeatureServices
    {

        [OperationContract]
        List<Feature> formfeatureser();
        [OperationContract]
        List<Feature> formfeaturemodser();
        [OperationContract]
        List<Feature> formfeatureformser(int moduleid);
        [OperationContract]
        List<Feature> cmbformser();
        [OperationContract]
        bool Createser(List<Feature> objtrans);
        [OperationContract]
        List<Feature> ListService(int PageNo, int RowsPerPage, string SearchText);
        [OperationContract]
        List<Feature> Listchildser(int Autoid);
        [OperationContract]
        bool Updateser(List<Feature> objtra, List<Feature> objformDeleteList);
        [OperationContract]
        Boolean DeleteSer(Int64 id);
        [OperationContract]
        string AutoIdSer();
        [OperationContract]
        Boolean DeleteDtlFeat(Feature objdelftr);
    }
}
