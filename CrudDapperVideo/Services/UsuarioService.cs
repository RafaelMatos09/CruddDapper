using AutoMapper;
using CrudDapperVideo.Dto;
using CrudDapperVideo.Models;
using Dapper;
using System.Data.SqlClient;

namespace CrudDapperVideo.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UsuarioService(IConfiguration configuration, IMapper mapper) 
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        [Obsolete]
        public async Task<ResponseModel<List<UsuarioDtoListar>>> BuscarUsuarios()
        {
            ResponseModel<List<UsuarioDtoListar>> response = new ResponseModel<List<UsuarioDtoListar>>();
            
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");

                if (usuariosBanco.Count() == 0)
                {
                    response.Mensagem = "Nenhum usuário localizado!";
                    response.Status = false;
                    return response;
                }

                //Transformacao Mapper
                var usuarioMapeado = _mapper.Map<List<UsuarioDtoListar>>(usuariosBanco);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuário localizados com sucesso!";
                
            }
            return response;
        }
    }
}
