using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaWorkFlowWithSqlDataBase.Activities
{

    public class CreateOrder : Activity
    {
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
            Console.WriteLine("Hello World!");

            return Done();
        }
    }
}
