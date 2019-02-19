
public T ArgumentOrEnvironmentVariable<T>(string name, T defaultValue, string prefix = null)
{
    var environmentVariableName = prefix != null ? $"{prefix}{name}" : name;

    var envValue = EnvironmentVariable(environmentVariableName);
    T newDefaultValue = defaultValue;
    if(!string.IsNullOrEmpty(envValue))
    {
        var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        newDefaultValue =  (T)converter.ConvertFromInvariantString(envValue);
    }
    
    var value = Argument<T>(name, newDefaultValue);

    GlobalProjectData.Arguments[name] = value;

    return value;
}