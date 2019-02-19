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

    public Dictionary<string, string> PrivateProperties { get; set; } = new Dictionary<string, string>();

    public ICakeContext Context { get; set; }

    public ProjectData(ICakeContext context)
    {
        Context = context;
    }
}