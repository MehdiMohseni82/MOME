public class EmployeeProcess
{
    private readonly IServiceProvider _serviceProvider;

    public EmployeeProcess(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}