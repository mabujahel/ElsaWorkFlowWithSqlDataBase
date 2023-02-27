using Elsa;
using Elsa.Activities.Primitives;
using Elsa.Builders;
using Namotion.Reflection;
using ElsaWorkFlowWithSqlDataBase.Activities;

namespace ElsaWorkFlowWithSqlDataBase.WorkFlow
{
    public class MyWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder builder)
        {
            builder
                .StartWith<ReviewDocument>()
                .Then<CreateOrder>();
        }
    }
}
