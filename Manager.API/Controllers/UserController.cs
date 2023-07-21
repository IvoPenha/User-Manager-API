using AutoMapper;
using Manager.API.Utilities;
using Manager.API.ViewModels;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Manager.API.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    private readonly IUserService _userService;

    private readonly IMapper _mapper;

    [HttpPost]
    [Route("/api/v1/users/create")]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
    {
        try
        {
            var userDto = _mapper.Map<UserDTO>(userViewModel);

            var userCreated = await _userService.Create(userDto);

            return Ok(new ResultViewModel
            {
                Message = "Usuario Criado Com sucesso",
                Data = userCreated,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpPut]
    [Route("/api/v1/users/update")]
    public async Task<IActionResult> Update([FromBody] UpdateViewModel userViewModel)
    {
        try
        {
            var userDto = _mapper.Map<UserDTO>(userViewModel);
            var userUpdated = await _userService.Update(userDto);
            return Ok(new ResultViewModel
            {
                Message = "Usuario atualizado com sucesso",
                Data = userUpdated,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/users/{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            var userUpdated = await _userService.Get(id);
            return Ok(new ResultViewModel
            {
                Message = "Usuario atualizado com sucesso",
                Data = userUpdated,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }

    [HttpGet]
    [Route("/api/v1/users/")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var usersList = await _userService.Get();
            return Ok(new ResultViewModel
            {
                Message = "Sucesso",
                Data = usersList,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
    
    [HttpDelete]
    [Route("/api/v1/users/{id}")]
    public async Task<IActionResult> Remove([FromRoute] long id)
    {
        try
        {
            await _userService.Remove(id);
            return Ok(new ResultViewModel
            {
                Message = "Usuario atualizado com sucesso",
                Data = null,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
    
        
    [HttpGet]
    [Route("/api/v1/users/get-by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        try
        {
            var searchedUser = await _userService.GetByEmail(email);
            return Ok(new ResultViewModel
            {
                Message = "Usuario encontrado com sucesso com sucesso",
                Data = searchedUser,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
        
    [HttpGet]
    [Route("/api/v1/users/search-by-email")]
    public async Task<IActionResult> SearchByEmail([FromQuery] string email)
    {
        try
        {
            var searchedUsers = await _userService.SearchByEmail(email);
            return Ok(new ResultViewModel
            {
                Message = "Usuario encontrado com sucesso com sucesso",
                Data = searchedUsers,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }
        
    [HttpGet]
    [Route("/api/v1/users/search-by-name")]
    public async Task<IActionResult> SearchByName([FromQuery] string name)
    {
        try
        {
            var searchedUsers = await _userService.SearchByName(name);
            return Ok(new ResultViewModel
            {
                Message = "Usuario encontrado com sucesso com sucesso",
                Data = searchedUsers,
                Success = true
            });
        }
        catch (DomainException e)
        {
            return BadRequest(Responses.DomainErrorMessage(e.Message, e.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, Responses.ApplicationErrorMessage());
        }
    }




}