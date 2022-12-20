using MediatR;
using TechCareerShoppingList.Back.Application.CQRS.Queries;
using TechCareerShoppingList.Back.Application.Dto;
using TechCareerShoppingList.Back.Application.Enums;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Data.Entities;
using TechCareerShoppingList.Back.Tools;

namespace TechCareerShoppingList.Back.Application.CQRS.Handlers
{
    public class CheckUserQueryRequestHandler : IRequestHandler<CheckUserQueryRequest, UserDto>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        //private readonly QeryControl _control;

        public CheckUserQueryRequestHandler(IRepository<User> userRepository, IRepository<Role> roleRepository/*, QeryControl control*/)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            //_control = control;
        }

        public async Task<UserDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {

            var dto = new UserDto();

            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                //_control.QueryControl(eQueryControl.nullValue);
                dto.IsExist = false;
                return dto;
            }
            else
            {
                var user = await _userRepository.GetByFilterAsync(x => x.Email.Equals(request.Email) && x.Password.Equals(request.Password));
                if (user == null)
                {
                    dto.IsExist = false;
                }
                else
                {
                    dto.Email = request.Email;
                    dto.Id = user.Id;
                    dto.IsExist = true;
                    var role = await _roleRepository.GetByFilterAsync(x => x.Id == user.Id);
                    dto.Role = role.Definition;
                }
                return dto;
            }
        }
    }
}
