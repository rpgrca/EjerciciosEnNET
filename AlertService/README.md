## Alert Service

Refactor the AlertService and AlertDAO classes:

- Create a new interface, named _IAlertDAO_, that contains the same methods as _AlertDAO_.
- _AlertDAO_ should implement the _IAlertDAO_ interface.
- _AlertService_ should have a public constructor that accepts _IAlertDAO_.
- The _RaiseAlert_ and _GetAlertTime_ methods should use the object passed through the constructor.

[Try it yourself!](https://www.testdome.com/questions/c-sharp/alert-service/96005)