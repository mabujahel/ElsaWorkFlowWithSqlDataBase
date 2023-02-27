using Elsa;
using Elsa.Activities.Http.Models;
using Elsa.ActivityResults;
using Elsa.Services;
using Elsa.Services.Models;
using ElsaWorkFlowWithSqlDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elsa.Attributes;

namespace ElsaWorkFlowWithSqlDataBase.Activities
{
    [Elsa.Attributes.Activity(Category = "Users", Description = "Activate a User" , Outcomes = new[] { "Approve", "Not Approve" })]
    public class ReviewDocument : Activity 
    {
        private ElsaDbContext _context;

        public ReviewDocument(ElsaDbContext  context)
        {
            _context = context;
        }
        protected override IActivityExecutionResult OnExecute(ActivityExecutionContext context)
        {
             
            var DocumentId = Convert.ToInt32( ((HttpRequestModel)(context.Input))?.QueryString["DocumentId"]??"0");
            //add new record -- new approvel 
            var doucument = _context.DocumentApprovals.FirstOrDefault(e => e.Id == DocumentId);



            if (!doucument.IsAprrove) 
                return Outcome("Not Approve");

            //check doucment status 
            //-approve manger 
            return Outcome("Approve");


        }


    }   
    
    
     
}

/*
 
private async Task WaitForApprovalAsync(int processId)
{
    // Wait until the approval process is no longer "Pending".
    ApprovalProcess process;
    do
    {
        process = await _dbContext.ApprovalProcesses.FindAsync(processId);
        await Task.Delay(TimeSpan.FromSeconds(5)); // Poll every 5 seconds
    } while (process.Status == ApprovalStatus.Pending);

    // Check if the document was approved or rejected.
    if (process.Status == ApprovalStatus.Approved)
    {
        // Document was approved. Mark it as approved in the database.
        var document = await _dbContext.Documents.FindAsync(process.DocumentId);
        document.ApprovalStatus = ApprovalStatus.Approved;
    }
    else
    {
        // Document was rejected. Mark it as rejected in the database.
        var document = await _dbContext.Documents.FindAsync(process.DocumentId);
        document.ApprovalStatus = ApprovalStatus.Rejected;
    }

    await _dbContext.SaveChangesAsync();
}
 */
