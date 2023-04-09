using System;

public class AlertService	
{
    private readonly AlertDAO storage = new AlertDAO();

    public Guid RaiseAlert()
    {
        return this.storage.AddAlert(DateTime.Now);
    }

    public DateTime GetAlertTime(Guid id)
    {
        return this.storage.GetAlert(id);
    }	
}
