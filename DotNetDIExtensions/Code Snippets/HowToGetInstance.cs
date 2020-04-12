var employeeType = employee.Type;
var employeeTaxLogic = _serviceProvider.ResolveByName<itaxcalculator>(employeeType);

var tax = employeeTaxLogic.CalculateTax(employee);