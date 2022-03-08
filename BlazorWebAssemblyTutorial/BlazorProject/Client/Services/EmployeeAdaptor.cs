using BlazorProject.Shared;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace BlazorProject.Client.Services
{
    public class EmployeeAdaptor : DataAdaptor
    {
        private readonly IEmployeeService employeeService;

        public EmployeeAdaptor(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            EmployeeDataResult result = 
                await employeeService.GetEmployees(dataManagerRequest.Skip, dataManagerRequest.Take);

            DataResult dataResult = new DataResult()
            {
                Result = result.Employees,
                Count = result.Count
            };

            return dataResult;
        }
    }
}
