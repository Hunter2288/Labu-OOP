using System;
using System.Collections.Generic;

namespace task_03
{
    // Delegate for job completion event
    public delegate void WorkDoneHandler(Job job);

    // Employee interface
    public interface IEmployee
    {
        string Name { get; }
        int WorkHoursPerWeek { get; }
    }

    public class StandardEmployee : IEmployee
    {
        public string Name { get; }
        public int WorkHoursPerWeek => 40;
        public StandardEmployee(string name) => Name = name;
    }

    public class PartTimeEmployee : IEmployee
    {
        public string Name { get; }
        public int WorkHoursPerWeek => 20;
        public PartTimeEmployee(string name) => Name = name;
    }

    public class Job
    {
        public string Name { get; }
        public int HoursRequired { get; private set; }
        public IEmployee Employee { get; }

        public event WorkDoneHandler JobDone;

        public Job(string name, int hoursRequired, IEmployee employee)
        {
            Name = name;
            HoursRequired = hoursRequired;
            Employee = employee;
        }

        public void Update()
        {
            HoursRequired -= Employee.WorkHoursPerWeek;
            if (HoursRequired <= 0)
            {
                Console.WriteLine($"Job {Name} completed!");
                JobDone?.Invoke(this);
            }
        }

        public void Status()
        {
            Console.WriteLine($"Job: {Name} Hours remaining: {Math.Max(HoursRequired, 0)}");
        }
    }

    public class JobCollection
    {
        private List<Job> jobs = new List<Job>();

        public void Add(Job job)
        {
            jobs.Add(job);
            job.JobDone += Remove;
        }

        private void Remove(Job job)
        {
            jobs.Remove(job);
            job.JobDone -= Remove;
        }

        public List<Job> GetJobs() => jobs;
    }

    internal class Program
    {
        static void Main()
        {
            var employees = new List<IEmployee>();
            var jobs = new JobCollection();

            string input;
            while ((input = Console.ReadLine()!) != "End")
            {
                string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "StandardEmployee":
                        employees.Add(new StandardEmployee(parts[1]));
                        break;

                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(parts[1]));
                        break;

                    case "Job":
                        string jobName = parts[1];
                        int hours = int.Parse(parts[2]);
                        string empName = parts[3];

                        IEmployee emp = employees.Find(e => e.Name == empName);
                        if (emp != null)
                        {
                            jobs.Add(new Job(jobName, hours, emp));
                        }
                        break;

                    case "Pass":
                        if (parts.Length > 1 && parts[1] == "Week")
                        {
                            foreach (var job in new List<Job>(jobs.GetJobs()))
                                job.Update();
                        }
                        break;

                    case "Status":
                        foreach (var job in jobs.GetJobs())
                            job.Status();
                        break;
                }
            }
        }
    }
}
