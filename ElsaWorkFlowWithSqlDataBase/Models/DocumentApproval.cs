using System.ComponentModel.DataAnnotations;

namespace ElsaWorkFlowWithSqlDataBase.Models
{
    public class DocumentApproval 
    {
        [Key]
        public int Id{ get; set; }

        public string Name{ get; set; }
        public bool IsAprrove{ get; set; }
    }
}
