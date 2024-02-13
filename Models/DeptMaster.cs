using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmsFullStackApplication.Models
{
    public class DeptMaster
    {
        [Key]
       public int EmpCode {  get; set; }
        public string ? EmpName {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ? Email { get; set; }
        public int DeptCode {  get; set; }

    }
}