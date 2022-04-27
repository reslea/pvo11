using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using WebResponse;

IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
//TcpListener tcpListener = new TcpListener(iPAddress, 3000);

//tcpListener.Start();
//Console.WriteLine("listening...");

//Socket socket = tcpListener.AcceptSocket();

//byte[] buffer = new byte[1024];

//int receivedBytes = socket.Receive(buffer);

//Console.WriteLine(Encoding.UTF8.GetString(buffer));

HttpListener httpListener = new HttpListener();
httpListener.Prefixes.Add("http://127.0.0.1:4000/");
httpListener.Start();
Console.WriteLine("listening...");

var serviceCollection = new ServiceCollection();
AddControllers(serviceCollection);
serviceCollection.AddScoped<UserDbContext>();

var serviceProvider = serviceCollection.BuildServiceProvider();

while (true)
{
    HttpListenerContext context = httpListener.GetContext();

    var scope = serviceProvider.CreateScope();
    var scopedProvider = scope.ServiceProvider;
    Task.Run(() => ProcessRequest(context, scopedProvider));
}

static void ProcessRequest(HttpListenerContext context, IServiceProvider serviceProvider)
{
    // create scope
    HttpListenerRequest request = context.Request;
    Console.WriteLine($"request received to {request.RawUrl}");
    #region switch
    //switch (request.RawUrl)
    //{
    //    case "/Auth/Register":
    //        string responseString = fileText;
    //        byte[] buffer = Encoding.UTF8.GetBytes(responseString);

    //        context.Response.StatusCode = 200;
    //        context.Response.ContentLength64 = buffer.Length;
    //        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
    //        context.Response.OutputStream.Close();
    //        break;
    //    default:
    //        context.Response.StatusCode = 400;
    //        context.Response.OutputStream.Close();
    //        break;
    //}
    #endregion
    var splittedUrl = request.RawUrl.Split("/");
    if (splittedUrl.Length < 3)
    {
        context.Response.StatusCode = 400;
        context.Response.OutputStream.Close();
        return;
    }

    var controllerName = splittedUrl[1];
    var methodName = splittedUrl[2];
    Type? controllerType = typeof(Program).Assembly
        .GetTypes()
        .FirstOrDefault(t => t.Name == $"{controllerName}Controller");

    MethodInfo? method = controllerType?.GetMethod(methodName);
    if (controllerType is null || method is null)
    {
        context.Response.StatusCode = 404;
        context.Response.OutputStream.Close();
        return;
    }

    if (method.ReturnType != typeof(string))
    {
        context.Response.StatusCode = 500;
        context.Response.OutputStream.Close();
        return;
    }

    object? controller = serviceProvider.GetService(controllerType);

    try
    {
        string resultString = (string)method.Invoke(controller, null)!;

        byte[] buffer = Encoding.UTF8.GetBytes(resultString);

        context.Response.StatusCode = 200;
        context.Response.ContentLength64 = buffer.Length;
        context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        context.Response.OutputStream.Close();
    }
    catch (Exception)
    {
        context.Response.StatusCode = 500;
        context.Response.OutputStream.Close();
        return;
    }
}

static void AddControllers(ServiceCollection serviceCollection)
{
    var controllerTypes = typeof(Program).Assembly
            .GetTypes()
            .Where(t => t.IsClass && t.IsAssignableTo(typeof(IController)));

    foreach (var controllerType in controllerTypes)
    {
        serviceCollection.AddScoped(controllerType);
    }
}

public interface IController { }

public class AuthController : IController
{
    private readonly UserDbContext context;

    public AuthController(UserDbContext context)
    {
        this.context = context;
    }

    public string Register()
    {
        return File.ReadAllText("register.html");
    }

    public string GetUser()
    {
        return context.Users.First().Name;
    }
}

public class HomeController : IController
{
    public string Index()
    {
        return File.ReadAllText("index.html");
    }
    public string Index2()
    {
        throw new NotImplementedException();
    }
}