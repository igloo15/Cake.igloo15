public class ProjectData
{
    private Dictionary<string, string> _internalData = new Dictionary<string, string>();

    public string this[string index]
    {
        get
        {
            return _internalData[index];
        }

        set
        {
            _internalData[index] = value;
        }
    }

    public Dictionary<string, string> PrivateProperties { get; } = new Dictionary<string, string>();

    public Dictionary<string, object> GenericProperties { get; } = new Dictionary<string, object>();

    public Dictionary<string, object> Arguments { get; } = new Dictionary<string, object>();

    public ICakeContext Context { get; set; }

    public GitVersion Version { get; set; } = null;

    public T GetGenericProperty<T>(string key)
    {
        return (T)GenericProperties[key];
    }

    public T GetArgument<T>(string key)
    {
        return (T)Arguments[key];
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("\nPROJECT DATA INFO:\n");

        sb.AppendLine("\nPROPERTIES:\n");
        foreach(var kvp in _internalData)
        {
            sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value}");
        }

        sb.AppendLine("\nGENERIC PROPERTIES:\n");
        foreach(var kvp in GenericProperties)
        {
            sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value.ToString()}");
        }
        
        sb.AppendLine("\nARGUMENTS:\n");
        foreach(var kvp in Arguments)
        {
            sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value.ToString()}");
        }

        return sb.ToString();
    }
}