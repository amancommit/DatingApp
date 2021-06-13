using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
     [Authorize]
    public class UsersController : BaseApiController
    {
        // private readonly DataContext _context;
        // public UsersController(DataContext context)
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
          //  _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }


         [HttpGet]
        
        //public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
           // return await _context.Users.ToListAsync();
           var users = await _userRepository.GetMembersAsync();

            return Ok(users);
        }


        // [HttpGet("{id}")]
       
        // public async Task<ActionResult<AppUser>> GetUser(int id)
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            //return await _context.Users.FindAsync(id);
            return await _userRepository.GetMemberAsync(username);
        }
    }
}