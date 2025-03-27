using System;

public class Job
{
    public string _jobTitle;
    public string _company;
    public string _jobStart;
    public string _jobEnd;

    public void DisplayJobDetails()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_jobStart}-{_jobEnd}");
    }
}