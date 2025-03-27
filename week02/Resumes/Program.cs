using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World! This is the Resumes Project.");
        // class instances
        Job job1 = new Job();
        Job job2 = new Job();

        // populate attributes
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._jobStart = "2019";
        job1._jobEnd = "2022";
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._jobStart = "2022";
        job2._jobEnd = "2023";

        job1.DisplayJobDetails();
        job2.DisplayJobDetails();

        // instantiate the Resume class
        Resume myResume = new Resume();
        Console.WriteLine("");
        
        // populate attributes
        myResume._name = "Katlego Kgwetiane";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        
        myResume.DisplayResume();
    }
}