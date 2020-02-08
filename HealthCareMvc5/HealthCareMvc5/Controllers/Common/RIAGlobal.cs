using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Xml;

namespace HealthCareMvc5.Controllers.Common
{
    public class RIAGlobal
    {
        public static double NoOfDaysBefore = 30;
        public static double NoOfDaysAfter = 30;

        static BasicHttpBinding binding = null;

        public static BasicHttpBinding GetBinding()
        {
            binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2147483647;
            binding.MaxBufferSize = 2147483647;
            binding.Security.Mode = BasicHttpSecurityMode.None;
            XmlDictionaryReaderQuotas readerQuotas = new XmlDictionaryReaderQuotas();
            readerQuotas.MaxStringContentLength = 2147483647;
            readerQuotas.MaxArrayLength = 2147483647;
            readerQuotas.MaxBytesPerRead = 2147483647;
            readerQuotas.MaxDepth = 2147483647;
            readerQuotas.MaxNameTableCharCount = 2147483647;
            binding.ReaderQuotas = readerQuotas;
            return binding;
        }

        internal static string GetServicePath(object servicepath, string v)
        {
            throw new NotImplementedException();
        }

        public static string GetServicePath(string ServicePath, string ServiceName)
        {
            return (ServicePath + ServiceName);
        }




        public enum RequestType
        {
            NewUserRequest = 1
        }

    }
}