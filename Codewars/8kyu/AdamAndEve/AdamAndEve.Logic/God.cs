namespace AdamAndEve.Logic;

public class God
{
  public static Human[] Create() => new Human[] { new Man(), new Woman() };
}

public class Human
{
}

public class Man : Human
{
}

public class Woman : Human
{  
}