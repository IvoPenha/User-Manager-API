using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services;

public class UserService : IUserService
{
    
    private readonly IMapper _mapper;

    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);
        if (userExists != null)
            throw new DomainException("Já existe um usuário cadastrado com esse email");
        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var createdUser = await _userRepository.Create(user);

        return _mapper.Map<UserDTO>(createdUser);
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var userExists = await _userRepository.Get(userDto.Id);
        if (userExists == null)
            throw new DomainException("Nenhum usuario com o Id mencionado");
        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var updatedUser = await _userRepository.Update(user);

        return _mapper.Map<UserDTO>(updatedUser);
        
    }

    public async Task Remove(long id)
    {
        await _userRepository.Remove(id);
        return;
    }

    public async Task<UserDTO> Get(long id)
    {
        var user = await _userRepository.Get(id);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> Get()
    {
        var allusers = await _userRepository.Get();
        return _mapper.Map<List<UserDTO>>(allusers);
    }

    public async Task<List<UserDTO>> SearchByName(string nome)
    {
        var searchedUsers = await _userRepository.SearchByNome(nome);
        return _mapper.Map<List<UserDTO>>(searchedUsers);
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
        var searchedUsers = await _userRepository.SearchByEmail(email);
        return _mapper.Map<List<UserDTO>>(searchedUsers);
    }

    public async Task<UserDTO> GetByEmail(string email){
        var user = await _userRepository.GetByEmail(email);
        return _mapper.Map<UserDTO>(user);
    }

}