using Microsoft.AspNetCore.Mvc;
public class DeviceController : Controller
{
    public IActionResult Device()
    {
        var devices = InMemoryDatabase.Devices;
        return View(devices);
    }

    public IActionResult AddEdit(int? id)
    {
        var device = id.HasValue
            ? InMemoryDatabase.Devices.FirstOrDefault(d => d.DeviceId == id.Value)
            : new Device();
        ViewBag.Categories = InMemoryDatabase.DeviceCategories;
        ViewBag.Users = InMemoryDatabase.Users;
        return View(device);
    }

    [HttpPost]
    public IActionResult AddEdit(Device device)
    {
        if (ModelState.IsValid)
        {
            if (device.DeviceId == 0)
            {
                device.DeviceId = InMemoryDatabase.GetNextId("Device");
                InMemoryDatabase.Devices.Add(device);
            }
            else
            {
                var existingDevice = InMemoryDatabase.Devices.FirstOrDefault(d => d.DeviceId == device.DeviceId);
                if (existingDevice != null)
                {
                    existingDevice.DeviceName = device.DeviceName;
                    existingDevice.DeviceCode = device.DeviceCode;
                    existingDevice.CategoryId = device.CategoryId;
                    existingDevice.UserId = device.UserId;
                    existingDevice.DeviceStatus = device.DeviceStatus;
                    existingDevice.DeviceDateOfEntry = device.DeviceDateOfEntry;
                }
            }

            return RedirectToAction("Device", "Device");
        }

        ViewBag.Categories = InMemoryDatabase.DeviceCategories;
        ViewBag.Users = InMemoryDatabase.Users;
        return View(device);
    }

    public IActionResult Delete(int id)
    {
        var device = InMemoryDatabase.Devices.FirstOrDefault(d => d.DeviceId == id);
        if (device != null)
        {
            InMemoryDatabase.Devices.Remove(device);
        }

        return RedirectToAction("Device", "Device");
    }
}