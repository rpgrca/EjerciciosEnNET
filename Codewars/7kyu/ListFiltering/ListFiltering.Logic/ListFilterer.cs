namespace ListFiltering.Logic;

using System.Collections;
using System.Collections.Generic;

public class ListFilterer
{
    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems) =>
        listOfItems.Where(p => p is int).Select(p => (int)p);
}