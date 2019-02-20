using System.Collections.Generic;

public class ProjectData
{
    private Dictionary<string, object> _internalData = new Dictionary<string, object>();
    private Dictionary<string, object> _privateData = new Dictionary<string, object>();
    private Dictionary<string, object> _arguments = new Dictionary<string, object>();

    public object this[string index]
    {
        get
        {
            if(_internalData.ContainsKey(index))
            {
                return _internalData[index];
            }

            if(_privateData.ContainsKey(index))
            {
                return _privateData[index];
            }

            if(_arguments.ContainsKey(index))
            {
                return _arguments[index];
            }

            throw new Exception($"Could not find Key {index}");
        }

        set
        {
            _internalData[index] = value;
        }
    }

    public ICakeContext Context { get; }

    public GitVersion Version { get; set; } = null;

    public ProjectData(ICakeContext context, Dictionary<string, object> arguments = null)
    {
        Context = context;
        _arguments = arguments ?? new Dictionary<string, object>();
    }

    public T GetProperty<T>(string key)
    {
        return (T)this[key];
    }

    public T GetArgument<T>(string key)
    {
        return (T)_arguments[key];
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
        
        sb.AppendLine("\nARGUMENTS:\n");
        foreach(var kvp in _arguments)
        {
            sb.AppendLine($"{kvp.Key.PadRight(40)}{kvp.Value.ToString()}");
        }

        return sb.ToString();
    }
}