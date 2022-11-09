namespace RobLandPG.Models
{
    public class FileModel
    {
        public int id { get; set; }
        public int clientid { get; set; }
        public string docname { get; set; }
        public string description { get; set; }
        public string contenttype { get; set; }
        public byte[] document { get; set; }
        public string username { get; set; }
 
    }
    public class UploadFileModel
    {
        public int id { get; set; }
        public IFormFile files { get; set; }
        public string Name { get; set; }
        

    }
}
