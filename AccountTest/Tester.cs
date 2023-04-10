using System;
using NUnit.Framework;

[TestFixture]
public class Tester
{	
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        var account = new Account(-20);
        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }

    [Test]
    public void DepositMustNotAcceptNegativeNumbers()
    {
        var account = new Account(0);
        account.Deposit(30);

        account.Deposit(-15);
        Assert.AreEqual(30, account.Balance);
    }

    [Test]
    public void WithdrawMustNotAcceptNegativeNumbers()
    {
        var account = new Account(0);
        account.Deposit(30);

        account.Withdraw(-7);
        Assert.AreEqual(30, account.Balance);
    }

    [Test]
    public void DepositMustIncrementCorrectAmount()
    {
        var account = new Account(0);
        account.Deposit(30);
        Assert.AreEqual(30, account.Balance);
    }

    [Test]
    public void WithdrawMustDiscountCorrectAmount()
    {
        var account = new Account(0);
        account.Deposit(30);
        account.Withdraw(7);
        Assert.AreEqual(23, account.Balance);
    }

    [Test]
    public void NeitherDepositNorWithdrawMustAcceptNegativeNumbers()
    {
        var account = new Account(0);
        Assert.AreEqual(false, account.Deposit(-30));
        Assert.AreEqual(false, account.Withdraw(-15));
    }

    [Test]
    public void BothDepositAndWithdrawMustWorkWithPositiveNumbers()
    {
        var account = new Account(0);
        Assert.AreEqual(true, account.Deposit(30));
        Assert.AreEqual(true, account.Withdraw(13));
    }

    [Test]
    public void CannotWithdrawAboveOverdraft()
    {
        var account = new Account(30);
        Assert.AreEqual(false, account.Withdraw(35));
    }
}