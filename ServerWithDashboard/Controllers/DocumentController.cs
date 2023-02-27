//using Elsa.Services;
//using Elsa.Services.Workflows;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks; 

//namespace ElsaWorkFlowWithSqlDataBase.Controllers
//{
//    public class DocumentController : Controller
//    {
//        private readonly IWorkflowRunner _workflowStarter;


//        public DocumentController(IWorkflowRunner workflowEngine)
//        {
//            _workflowStarter = workflowEngine;
//        }

//        public IActionResult Index()
//        {
//            _workflowStarter.
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> StartApprovalProcess(Document document, string approvalToken)
//        {
//            var success = await _workflowEngine.StartApprovalProcessAsync(document, approvalToken);

//            if (success)
//            {
//                return RedirectToAction(nameof(WaitForApproval), new { id = document.Id });
//            }

//            return BadRequest();
//        }

//        public IActionResult WaitForApproval(int id)
//        {
//            var document = new Document { Id = id };

//            return View(document);
//        }

//        [HttpPost]
//        public async Task<IActionResult> WaitForApproval(Document document, string approvalToken)
//        {
//            var success = await _workflowEngine.WaitForApprovalAsync(document, approvalToken);

//            if (success)
//            {
//                return RedirectToAction(nameof(CheckApprovalStatus), new { id = document.Id });
//            }

//            return BadRequest();
//        }

//        public async Task<IActionResult> CheckApprovalStatus(int id)
//        {
//            var document = new Document { Id = id };

//            var isApproved = await _workflowEngine.CheckApprovalStatusAsync(document);

//            if (isApproved)
//            {
//                return View("Approved", document);
//            }
//            else
//            {
//                return View("NotApproved", document);
//            }
//        }
//    }
//}
