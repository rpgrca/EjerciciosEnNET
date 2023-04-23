using System;
using AlertService.Logic;

namespace AlertService.UnitTests;

public class AlertServiceMust
{
    public class AlertDaoSpy : IAlertDAO
    {
        public bool AddAlertCalled { get; private set; }
        public bool GetAlertCalled { get; private set; }

        public Guid AddAlert(DateTime time)
        {
            AddAlertCalled = true;
            return Guid.NewGuid();
        }

        public DateTime GetAlert(Guid id)
        {
            GetAlertCalled = true;
            return new DateTime(2022, 12, 13);
        }
    }

    [Fact]
    public void UseAlertDaoGivenInConstructor_WhenCallingRaiseAlert()
    {
        var spy = new AlertDaoSpy();
        var sut = new Logic.AlertService(spy);
        sut.RaiseAlert();
        Assert.True(spy.AddAlertCalled);
    }

    [Fact]
    public void UseAlertDaoGivenInConstructor_WhenCallingGetAlertTime()
    {
        var anyGuid = Guid.NewGuid();
        var spy = new AlertDaoSpy();
        var sut = new Logic.AlertService(spy);
        sut.GetAlertTime(anyGuid);
        Assert.True(spy.GetAlertCalled);
    }
}