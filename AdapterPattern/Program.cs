namespace AdapterPattern;

public class Employee
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Department { get; set; }

    public override string ToString() => $"Id {Id} FirstName {FirstName} LastName {LastName} Department {Department}";

}

public class RecordServer
{
    private List<Employee>? _employees;

    public RecordServer()
    {
        InitializeEmployees();
    }

    public List<Employee> GetEmployees() => _employees;

    private void InitializeEmployees()
    {
        _employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "Michael" , LastName = "Lawson", Department = "Management"},
            new Employee { Id = 2, FirstName = "Aris" , LastName = "Brown", Department = "Developer"},
            new Employee { Id = 3, FirstName = "Tobias" , LastName = "Funke", Department = "IT"},
            new Employee { Id = 4, FirstName = "Byron" , LastName = "Cullen", Department = "IT"},
            new Employee { Id = 5, FirstName = "George" , LastName = "Edwards", Department = "Developer"}
        };
    }
}

public interface IEmployeeService
{
    Employee GetEmployee(int employeeId);
}

public class EmployeeService : IEmployeeService
{
    RecordServer recordServer;

    public EmployeeService()
    {
        recordServer = new RecordServer();
    }

    public Employee GetEmployee(int employeeId)
    {
        var allEmployees = recordServer.GetEmployees();
        return allEmployees.FirstOrDefault(e => e.Id == employeeId);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IEmployeeService service = new EmployeeService();

        var employee = service.GetEmployee(1);
        Print(employee);

        employee = service.GetEmployee(4);
        Print(employee);

        employee = service.GetEmployee(20);
        Print(employee);

        employee = service.GetEmployee(2);
        Print(employee);


        static void Print(Employee employee)
        {
            if (employee != null)
                Console.WriteLine(employee);
            else
                Console.WriteLine("Employee not found");
        }
    }
}