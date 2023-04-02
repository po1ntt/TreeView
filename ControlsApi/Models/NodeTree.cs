namespace ControlsApi.Models
{
    public class NodeTree
    {
        public string TitleNode { get; set; }
        public int LevelNode { get; set; }
        public string ImageUrl { get; set; }
        public bool HasChilds { get; set; }
        public string ApiUrl { get; set; }
       public bool IsVisible { get; set; }
    }
}
