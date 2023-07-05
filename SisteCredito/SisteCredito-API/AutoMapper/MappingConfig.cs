using AutoMapper;
using SisteCredito_Core.Dtos.AreasDto;
using SisteCredito_Core.Dtos.EmpleadosDto;
using SisteCredito_Core.Dtos.LideresDto;
using SisteCredito_Core.Dtos.ReporteHoraExtraDto;
using SisteCredito_Core.Dtos.UsuariosDto;
using SisteCredito_Core.Models;

namespace SisteCredito_API.AutoMapper;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Areas, AreasResponseDto>().ReverseMap();
        CreateMap<Areas, AreasRequestDto>().ReverseMap();
        CreateMap<Areas, AreasUpdateDto>().ReverseMap();

        CreateMap<Lideres, LideresRequestDto>().ReverseMap();
        CreateMap<Lideres, LideresUpdateDto>().ReverseMap();
        CreateMap<Lideres, LideresResponseDto>().ReverseMap();

        CreateMap<Empleados, EmpleadosResponseDto>().ReverseMap();
        CreateMap<Empleados, EmpleadosRequestDto>().ReverseMap();
        CreateMap<Empleados, EmpleadosUpdateDto>().ReverseMap();

        CreateMap<Usuarios, UsuarioLoginDto>().ReverseMap();
        CreateMap<Usuarios, UsuarioRegisterDto>().ReverseMap();
        CreateMap<Usuarios, UsuarioRegisterDto>().ReverseMap();

        CreateMap<ReporteHorasExtra, ReporteHorasExtraRequestDto>().ReverseMap();
        CreateMap<ReporteHorasExtra, ReporteHorasExtraResponseDto>().ReverseMap();
        CreateMap<ReporteHorasExtra, ReporteHorasExtraUpdateDto>().ReverseMap();
    }
}