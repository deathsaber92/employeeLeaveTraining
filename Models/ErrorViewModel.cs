using System;

namespace EmployeeLeaveTraining.Models
{
    /// <summary>
    /// View model for error
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
