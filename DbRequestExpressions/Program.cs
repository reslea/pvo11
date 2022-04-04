using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

using var context = new BlogDbContext();

context.Database.EnsureCreated();

var data = context.Posts
    .OrderBy(p => p.PostId)
    .Where(p => p.Title == "test1")
    .Select(p => p.Title);

var expression = data.AsQueryable().Expression as MethodCallExpression;

var queryItems = new List<QueryItem>();
ShowQueryExpression(queryItems, expression);

Console.WriteLine();

Console.WriteLine(GenerateSql(queryItems));

Console.WriteLine();


string GenerateSql(List<QueryItem> queryItems)
{
    var selectQueryItem = queryItems.SingleOrDefault(q => q.MethodName == "Select" /* or nameof(Enumerable.Select) */);

    var query = selectQueryItem == null
        ? "SELECT * "
        : GetSelectString(selectQueryItem.Expression);

    query += $"FROM {GetTableType(selectQueryItem.Expression)}\n";

    var whereQueryItems = queryItems.Where(q => q.MethodName == "Where");

    query += GetWhereString(whereQueryItems);

    return query;
}

string GetWhereString(IEnumerable<QueryItem> whereQueryItems)
{
    if(!whereQueryItems.Any())
    {
        return string.Empty;
    }

    var whereExression = whereQueryItems.First().Expression;

    var unaryExpression = whereExression as UnaryExpression;
    var lambdaExpression = unaryExpression?.Operand as LambdaExpression;

    var binaryExpression = lambdaExpression?.Body as BinaryExpression;

    string sqlOperator = binaryExpression?.NodeType switch
    {
        ExpressionType.Equal => "=",
        ExpressionType.NotEqual => "!=",
        ExpressionType.GreaterThan => ">",
        ExpressionType.GreaterThanOrEqual => ">=",
        ExpressionType.LessThan => "<",
        ExpressionType.LessThanOrEqual => "<=",
        _ => throw new ArgumentException("Wrong comparison operator type")
    };

    var constantExpression = binaryExpression.Left as ConstantExpression
        ?? binaryExpression.Right as ConstantExpression
        ?? throw new ArgumentException("constant wasnt found");

    var memberExpression = binaryExpression.Left as MemberExpression
        ?? binaryExpression.Right as MemberExpression
        ?? throw new ArgumentException("property wasnt found");

    return $"WHERE {memberExpression.Member.Name} {sqlOperator} {constantExpression.Value}";
}

Type GetTableType(Expression selectExression)
{
    var unaryExpression = selectExression as UnaryExpression;
    var lambdaExpression = unaryExpression.Operand as LambdaExpression;

    var propertyExpression = lambdaExpression.Body as MemberExpression;

    return propertyExpression.Member.ReflectedType;
}

string GetSelectString(Expression expression)
{
    var unaryExpression = expression as UnaryExpression;
    var lambdaExpression = unaryExpression.Operand as LambdaExpression;

    var propertyExpression = lambdaExpression.Body as MemberExpression;

    var selectProp = propertyExpression.Member.Name;

    return $"SELECT {selectProp} ";
}

void ShowQueryExpression(List<QueryItem> queryItems, Expression expression)
{
    var methodCallExpression = expression as MethodCallExpression;
    if (methodCallExpression == null) throw new ArgumentException("Not method call!");

    var methodName = methodCallExpression.Method.Name;
    var innerExpression = methodCallExpression.Arguments[0];
    var lambda = methodCallExpression.Arguments[1];

    Console.WriteLine($"{methodName}: {lambda}");

    queryItems.Add(new QueryItem { MethodName = methodName, Expression = lambda });

    if (innerExpression.GetType() != typeof(QueryRootExpression))
    {
        ShowQueryExpression(queryItems, innerExpression);
    }
}

//Enumerable.Select(
//    Enumerable.OrderBy(
//        Enumerable.Where(context.Posts, p => p.Title == "test"), p => p.PostId), p => p.Title);

class QueryItem
{
    public string MethodName { get; set; }
    public Expression Expression { get; set; }
}

class BlogDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BlogDb;Trusted_Connection=True";
        optionsBuilder.UseSqlServer(connectionString);

        base.OnConfiguring(optionsBuilder);
    }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public int Rating { get; set; }
    public List<Post> Posts { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}