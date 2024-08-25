namespace ProEventos.API.DTOs.Mappings
{
    public class ProdutoDTOMappingProfile
    {
        public ProdutoDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTOUpdateRequest>().ReverseMap();
            CreateMap<Produto, ProdutoDTOUpdateResponse>().ReverseMap();
        }
    }
}
