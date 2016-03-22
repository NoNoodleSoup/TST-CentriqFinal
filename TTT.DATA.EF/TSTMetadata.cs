using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT.DATA.EF
{
    /// <summary>
    /// All Metadata classes associated with Entity Data Models are contained in this TSTMetadata class.
    /// </summary>

    #region Departments

    public class TSTDepartmentMetadata
    {
        [Display(Name = "Department")]
        public int DeptID { get; set; }

        [Required(ErrorMessage = "\"Department\" is required")]
        [StringLength(25, ErrorMessage = "\"Department\" must be 25 characters or less")]
        [Display(Name = "Department")]
        public string DeptName { get; set; }

        [StringLength(150, ErrorMessage = "\"Description\" must be 150 characters or less")]
        [UIHint("MultilineText")]
        [Display(Name = "Description")]
        public string DeptDescription { get; set; }

        [Display(Name = "Currently Active?")]
        public bool IsActive { get; set; }
    }
    [MetadataType(typeof(TSTDepartmentMetadata))]
    public partial class TSTDepartment { }

    #endregion

    #region Employees

    public class TSTEmployeeMetadata
    {
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Display(Name = "Employee Image")]
        [StringLength(100, ErrorMessage = "\"Employee Image\" filename must be 100 characters or less")]
        public string EmpImage { get; set; }

        [Required(ErrorMessage = "\"First Name\" is required")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "\"First Name\" must be 50 characters or less")]
        public string FName { get; set; }

        [Required(ErrorMessage = "\"Last Name\" is required")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "\"Last Name\" must be 50 characters or less")]
        public string LName { get; set; }

        [Required(ErrorMessage = "\"Job Title\" is required")]
        [Display(Name = "Job Title")]
        [StringLength(50, ErrorMessage = "\"Job Title\" must be 50 characters or less")]
        public string JobTitle { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = false)]
        public System.DateTime DateOfBirth { get; set; }

        [Display(Name = "Street Address")]
        [StringLength(100, ErrorMessage = "\"Street Address\" must be 100 characters or less")]
        public string StreetAddress { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(25, ErrorMessage = "\"Address Line 2\" must be 25 characters or less")]
        public string Address2 { get; set; }

        [StringLength(50, ErrorMessage = "\"City\" must be 50 characters or less")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "\"State\" must be 2 characters or less")]
        public string State { get; set; }

        [StringLength(5, ErrorMessage = "\"Zip Code\" must be 5 characters or less")]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "\"Email Address\" is required")]
        [RegularExpression(@"^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$",
            ErrorMessage = "\"Email Address\" must be in correct format")]
        [StringLength(150, ErrorMessage = "\"Email Address\" must be 150 characters or less")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "\"Cell Phone #\" is required")]
        [Display(Name = "Cell Phone #")]
        public string CellPhone { get; set; }

        [Display(Name = "Date of Hire")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = false)]
        public System.DateTime DateOfHire { get; set; }

        [Display(Name = "Date of Separation")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = false)]
        public Nullable<System.DateTime> DateOfSeparation { get; set; }

        [Display(Name = "Employee Notes")]
        public string EmpNotes { get; set; }
    }
    [MetadataType(typeof(TSTEmployeeMetadata))]
    partial class TSTEmployee { }

    #endregion

    #region EmpStatuses

    public class TSTEmpStatusMetadata
    {
        [Display(Name = "Employee Status")]
        public int EmpStatusID { get; set; }

        [Required(ErrorMessage = "\"Status\" is required")]
        [StringLength(50, ErrorMessage = "\"Status\" must be 50 characters or less")]
        [Display(Name = "Status")]
        public string EmpStatusName { get; set; }

        [StringLength(150, ErrorMessage = "\"Description\" must be 150 characters or less")]
        [UIHint("MultilineText")]
        [Display(Name = "Description")]
        public string EmpStatusDescription { get; set; }
    }
    [MetadataType(typeof(TSTEmpStatusMetadata))]
    partial class TSTEmpStatus { }

    #endregion

    #region Mail

    public class TSTMailMetadata
    {
        [Required(ErrorMessage = "\"Subject\" required")]
        [Display(Name = "Subject")]
        [StringLength(100, ErrorMessage = "Must be 100 characters or less")]
        public string MailSubject { get; set; }

        [Required(ErrorMessage = "\"Message\" is required")]
        [Display(Name = "Messsage")]
        public string MailMessage { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date Mailed")]
        public System.DateTime DateSent { get; set; }

        [Display(Name = "Delete?")]
        public bool IsActive { get; set; }
    }

    #endregion

    #region Priority

    public class TSTPriorityMetadata
    {
        [Display(Name = "Priority")]
        public int PriorityID { get; set; }

        [Display(Name = "Priority")]
        [StringLength(25, ErrorMessage = "\"Priority\" must be 25 characters or less")]
        [Required(ErrorMessage = "\"Priority\" is required")]
        public string PriorityName { get; set; }

        [Display(Name = "Description")]
        [StringLength(25, ErrorMessage = "\"Description\" must be 150 characters or less")]
        public string PriorityDescription { get; set; }
    }

    #endregion

    #region TechNote

    public class TSTTechNoteMetadata
    {
        [StringLength(500, ErrorMessage = "\"Tech\" Note must be 500 characters or less")]
        [Required(ErrorMessage = "\"Content\" is required")]
        public string NoteContent { get; set; }

        [Display(Name = "Date Submitted")]
        public System.DateTime TechNoteDate { get; set; }
    }

    #endregion

    #region Ticket

    public class TSTTicketMetadata
    {
        [Display(Name = "Ticket")]
        public int TicketID { get; set; }

        [Display(Name = "Subject")]
        [StringLength(100, ErrorMessage = "\"Subject\" must be 100 characters or less")]
        [Required(ErrorMessage = "\"Subject\" is required")]
        public string TicketSubject { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "\"Description\" is required")]
        public string TicketDescription { get; set; }

        [Display(Name = "Attached Image")]
        [StringLength(100, ErrorMessage = "\"Attached Image\" must be 100 characters or less")]
        public string TicketImage { get; set; }

        [Display(Name = "Date Submitted")]
        public System.DateTime DateSubmitted { get; set; }
    }

    #endregion

    #region TicketStatus

    public class TSTTicketStatusMetadata
    {
        [Display(Name = "Ticket Status")]
        public int TicketStatusID { get; set; }

        [Display(Name = "Ticket Status")]
        [StringLength(25, ErrorMessage = "\"Ticket Status\" must be 25 characters or less")]
        [Required(ErrorMessage = "\"Ticket Status\" is required")]
        public string TicketStatusName { get; set; }

        [StringLength(150, ErrorMessage = "\"Description\" must be 150 characters or less")]
        public string TicketStatusDescription { get; set; }
    }

    #endregion

}
