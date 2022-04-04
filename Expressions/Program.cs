using Expressions;
using System.Linq.Expressions;
using System.Reflection;

Expression<Func<BudgetInfo, int>> expression = b => b.Id;

var memberExpression = expression.Body as MemberExpression;
//Console.WriteLine($"ORDER BY {memberExpression.Member.Name}");


Expression<Func<int, int, int>> addExpression = (a, b) => a + b;
var lambdaExpression = addExpression as LambdaExpression;

Func<int, int, int> AddFunc = addExpression.Compile();
//Console.WriteLine(AddFunc(1, 1));

var constExpression1 = Expression.Constant(1);
var constExpression2 = Expression.Constant(10);
var sumExpression = Expression.Add(constExpression1, constExpression2);
var sumLambda = Expression.Lambda<Func<int>>(sumExpression).Compile();

//Console.WriteLine(sumLambda.Invoke());

var value = 1 + 10;

var posts = new List<Post>();

posts
    .MyJoin(p => p.Blog, (p, b) => p.BlogId == b.BlogId)
    .Where(p => p.Title.StartsWith("Срочно!"))
    .OrderBy(p => p.PostId);

public static class ListExtentions
{
    public static List<TItem> MyJoin<TItem, TJoined>(
        this List<TItem> list,
        Expression<Func<TItem, TJoined>> joinMember,
        Expression<Func<TItem, TJoined, bool>> onExpression
        )
        where TJoined : class, new()
    {
        var memberExpression = joinMember.Body as MemberExpression;

        if (memberExpression?.Member.MemberType != MemberTypes.Property)
        {
            throw new ArgumentException("Wrong member type");
        }

        var binaryExpression = onExpression.Body as BinaryExpression;

        string sqlOperator = binaryExpression.NodeType switch
        {
            ExpressionType.Equal => "=",
            ExpressionType.NotEqual => "!=",
            ExpressionType.GreaterThan => ">",
            ExpressionType.GreaterThanOrEqual => ">=",
            ExpressionType.LessThan => "<",
            ExpressionType.LessThanOrEqual => "<=",
            _ => throw new ArgumentException("Wrong comparison operator type")
        };

        var leftProperty = (binaryExpression.Left as MemberExpression).Member;

        var leftName = leftProperty.Name;
        var leftType = leftProperty.ReflectedType.Name;


        var rigthProperty = (binaryExpression.Right as MemberExpression).Member;

        var rightName = rigthProperty.Name;
        var rightType = rigthProperty.ReflectedType.Name;

        Console.WriteLine($"JOIN {memberExpression.Member.Name} ON {leftType}.{leftName} {sqlOperator} {rightType}.{rightName}");

        return list;
    }
}