﻿public class Calendar: BaseEntity
{
    public long Timestamp { get; set; }

    public int Week { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int Date { get; set; }
    public int Day { get; set; }
    public int Quarter { get; set; }
}