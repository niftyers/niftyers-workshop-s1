namespace ERP.BuildersAPI
{
    public interface IAppConfig
    {
        string Name { get; set; }
        string Token { get; set; }
        string TimeZone { get; set; }
        string Cookie { get; set; }
        string MongoDB { get; set; }
        string Database { get; set; }
    }
}