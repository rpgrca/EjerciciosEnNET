using System;

namespace AlertService.Logic;

public class AlertService	
{
    private readonly IAlertDAO storage = new AlertDAO();

    public AlertService(IAlertDAO storage)
    {
        this.storage = storage;
    }

    public Guid RaiseAlert()
    {
        return this.storage.AddAlert(DateTime.Now);
    }

    public DateTime GetAlertTime(Guid id)
    {
        return this.storage.GetAlert(id);
    }	
}
