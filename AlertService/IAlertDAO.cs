using System;

namespace AlertService.Logic;

public interface IAlertDAO
{
    Guid AddAlert(DateTime time);
    DateTime GetAlert(Guid id);
}