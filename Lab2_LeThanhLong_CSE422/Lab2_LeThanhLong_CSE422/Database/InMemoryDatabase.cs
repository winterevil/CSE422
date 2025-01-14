public static class InMemoryDatabase
{
    public static List<DeviceCategory> DeviceCategories { get; set; } = new List<DeviceCategory>
    {
        new DeviceCategory { CategoryId = 1, CategoryName = "Computer" },
        new DeviceCategory { CategoryId = 2, CategoryName = "Printer" },
        new DeviceCategory { CategoryId = 3, CategoryName = "Phone" }
    };

    public static List<Device> Devices { get; set; } = new List<Device>
    {
        new Device { 
            DeviceId = 1, 
            DeviceName = "Laptop Acer", 
            DeviceCode = "ACER",
            CategoryId = 1,
            UserId = 1,
            DeviceStatus = "In use",
            DeviceDateOfEntry = DateTime.Now.AddDays(-30) },
        new Device { 
            DeviceId = 2, 
            DeviceName = "Printer Brother",
            DeviceCode = "BROTHER", 
            CategoryId = 2,
            UserId = 2,
            DeviceStatus = "Broken",
            DeviceDateOfEntry = DateTime.Now.AddDays(-30) },
        new Device { 
            DeviceId = 3, 
            DeviceName = "Phone OPPO", 
            DeviceCode = "OPPO",
            CategoryId = 3,
            UserId = 1,
            DeviceStatus = "Under maintanance",
            DeviceDateOfEntry = DateTime.Now.AddDays(-30) }
    };

    public static List<User> Users { get; set; } = new List<User>
    {
        new User { 
            UserId = 1, 
            UserName = "Thanh Long",
            UserEmail = "W8ZaE@example.com",
            UserPhone = "0123456789",},
        new User { 
            UserId = 2, 
            UserName = "Long Le",
            UserEmail = "Ht8lY@example.com",
            UserPhone = "0123456788",}
    };

    private static int _nextDeviceCategoryId = 4;
    private static int _nextDeviceId = 4;
    private static int _nextUserId = 3;

    public static int GetNextId(String modelName)
    {
        return modelName switch
        {
            "DeviceCategory" => _nextDeviceCategoryId++,
            "Device" => _nextDeviceId++,
            "User" => _nextUserId++,
            _ => throw new KeyNotFoundException("Invalid model name")
        };
    }
}