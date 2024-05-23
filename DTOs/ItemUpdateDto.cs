namespace backendP.DTOs
{
    public class ItemUpdateDto
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }
    }
}
