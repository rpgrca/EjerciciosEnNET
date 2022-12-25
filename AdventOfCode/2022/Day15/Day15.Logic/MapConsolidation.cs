namespace Day15.Logic;

internal class MapConsolidation
{
    public static bool Consolidate(List<Range> map, int newMinimum, int newMaximum)
    {
        foreach (var range in map)
        {
            if (newMinimum < range.Minimum)
            {
                if (newMaximum >= range.Minimum)
                {
                    range.UpdateMinimumTo(newMinimum);
                    if (newMaximum > range.Maximum)
                    {
                        range.UpdateMaximumTo(newMaximum);
                    }

                    return false;
                }
            }
            else
            {
                if (newMinimum <= range.Maximum)
                {
                    if (newMaximum > range.Maximum)
                    {
                        range.UpdateMaximumTo(newMaximum);
                    }

                    return false;
                }
                else
                {
                    if (range.Maximum == newMinimum || range.Maximum == newMinimum - 1) // (7)
                    {
                        range.UpdateMaximumTo(newMaximum);
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public static bool Consolidate(List<Range> map)
    {
        var counter = 0;
        while (map.Count > 1)
        {
            if (counter++ > 1)
            {
                return false;
            }

            for (var index = 0; index < map.Count - 1; index++)
            {
                for (var subIndex = index + 1; subIndex < map.Count; subIndex++)
                {
                    var range = map[index];
                    var newMinimum = map[subIndex].Minimum;
                    var newMaximum = map[subIndex].Maximum;

                    if (newMinimum < range.Minimum)
                    {
                        if (newMaximum >= range.Minimum) // (1)
                        {
                            if (newMaximum <= range.Maximum) // (2)
                            {
                                range.UpdateMinimumTo(newMinimum);
                                map.RemoveAt(subIndex);
                            }
                            /*
                            else
                            {
                                map.RemoveAt(index);
                            }*/
                        }
                    }
                    else
                    {
                        if (newMinimum <= range.Maximum)
                        {
                            if (newMaximum > range.Maximum)
                            {
                                range.UpdateMaximumTo(newMaximum);
                            }

                            map.RemoveAt(subIndex);
                        }
                        /*
                        else
                        {
                            if (range.Maximum == newMinimum || range.Maximum == newMinimum - 1)
                            {
                                range.UpdateMaximumTo(newMaximum);
                                map.RemoveAt(subIndex);
                            }
                        }*/
                    }
                }
            }
        }

        return true;
    }

}