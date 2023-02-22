namespace BindBox.Models
{
    /// <summary>
    /// 盲盒目录
    /// </summary>
    public class BoxFolder
    {
        public int BoxFolderId { get; set; }
        public string BoxFolderName { get; set; }
        public bool IsDelete { get; set; }
        public List<BoxCommodity> BoxCommodities { get; set; }
    }
}
