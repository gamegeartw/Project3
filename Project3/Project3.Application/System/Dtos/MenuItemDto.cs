namespace Project3.Application.Dtos
{
    /// <summary>
    /// 側邊選單Dto
    /// </summary>
    [Serializable]
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public long? ParentId { get; set; }

        public IEnumerable<MenuItemDto> SubMenuItems { get; set; }

        public long Index { get; set; }

        public bool CanMoveUp => ParentId.HasValue || Index != 1;

        public string[] AllowUsers { get; set; }

        public string[] AllowRoles { get; set; }


    }

    public class InputMenuItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public long? ParentId { get; set; }
        public string Url { get; set; }
        public long[] Roles { get; set; }
    }
}