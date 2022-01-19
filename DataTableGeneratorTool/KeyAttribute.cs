public class KeyAttribute : Attribute { }

public class ForeignKeyAttribute : Attribute
{
    public string RelatedPropSelector { get; }

    public ForeignKeyAttribute(string relatedPropSelector)
    {
        RelatedPropSelector = relatedPropSelector;
    }
}