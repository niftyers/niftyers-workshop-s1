namespace ERP.BuildersAPI
{
    public class AppConfig : IAppConfig
    {
        public string Name { get; set; } = "";
        public string Token { get; set; } = "";
        public string TimeZone { get; set; } = "";
        public string Cookie { get; set; } = "";
        public string MongoDB { get; set; } = "";
        public string Database { get; set; } = "";
    }
}
