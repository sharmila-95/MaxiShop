using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.ApplicationConstants
{
    public class ApplicationConstant
    {
    }

    public class CommonMessage
    {
        public const string CreateOperationSuccess = "Record Created successfully";
        public const string UpdateOperationSuccess = "Record updated successfully";
        public const string deleteOperationSuccess = "Record deleted successfully";

        public const string CreateOperationFailed = "Create operation failed!";
        public const string UpdateOperationFailed = "Update operation failed!";
        public const string DeleteOperationFailed = "Delete operation failed!";

        public const string RecordNotFound = "Record not found";
        public const string SystemErr = "System error! something went wrong!";

    }
}
