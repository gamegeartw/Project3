using Project3.Core;

namespace Project3.Application.Dtos
{
    public class Mapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<SysMenu, MenuItemDto>()
                .Map(desc => desc.SubMenuItems, src => src.Children)
                .Fork(config =>
                {
                    config.Default.MaxDepth(3);
                    config.Default.PreserveReference(true);
                });
        }
    }
}