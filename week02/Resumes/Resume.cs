﻿using System;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (var job in _jobs)
        {
            Console.WriteLine($"{job._jobTitle} ({job._company}) {job._jobEnd}-{job._jobEnd}");
        }
    }
}