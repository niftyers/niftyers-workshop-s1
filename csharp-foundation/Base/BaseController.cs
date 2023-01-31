using System;

namespace Lambert.MVC {
    public class BaseController {
        public string Name { get; set; } = "";
        public void Init() {
            Console.WriteLine("API Base");
        }
    }
}