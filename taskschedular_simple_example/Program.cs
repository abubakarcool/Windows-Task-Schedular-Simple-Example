using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Win32.TaskScheduler;

namespace taskschedular_simple_example
{
    internal class Program
    {
        static void Main(string[] args)
        {


            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
                System.Diagnostics.Process.GetCurrentProcess().Kill();


            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;
                td.RegistrationInfo.Description = "Does something";

                // Create a trigger that will fire the task at this time every other day
                //td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

                //var trigger = new TimeTrigger();
                //trigger.Repetition.Interval = TimeSpan.FromMinutes(2);
                //td.Triggers.Add(trigger);


                var dttriggr = new DailyTrigger();
                dttriggr.StartBoundary = DateTime.Parse("12:01:00 AM");
                td.Triggers.Add(dttriggr);
                var dttriggr1 = new DailyTrigger();
                dttriggr1.StartBoundary = DateTime.Parse("03:02:00 AM");
                td.Triggers.Add(dttriggr1);
                var dttriggr2 = new DailyTrigger();
                dttriggr2.StartBoundary = DateTime.Parse("06:03:00 AM");
                td.Triggers.Add(dttriggr2);
                var dttriggr3 = new DailyTrigger();
                dttriggr3.StartBoundary = DateTime.Parse("09:04:00 AM");
                td.Triggers.Add(dttriggr3);
                var dttriggr4 = new DailyTrigger();
                dttriggr4.StartBoundary = DateTime.Parse("12:05:00 PM");
                td.Triggers.Add(dttriggr4);
                var dttriggr5 = new DailyTrigger();
                dttriggr5.StartBoundary = DateTime.Parse("03:06:00 PM");
                td.Triggers.Add(dttriggr5);
                var dttriggr6 = new DailyTrigger();
                dttriggr6.StartBoundary = DateTime.Parse("06:07:00 PM");
                td.Triggers.Add(dttriggr6);
                var dttriggr7 = new DailyTrigger();
                dttriggr7.StartBoundary = DateTime.Parse("09:08:00 PM");
                td.Triggers.Add(dttriggr7);



                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction("notepad.exe", "C:\\Users\\PC\\Documents\\callofduty_cfg_24May20.db", null));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"Test", td);

                // Remove the task we just created
                //ts.RootFolder.DeleteTask("Test");
                Console.WriteLine("done");
                Console.ReadLine();
            }
        }
    }
}
