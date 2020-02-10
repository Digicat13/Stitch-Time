using System;
using System.Collections.Generic;
using System.Text;

namespace StitchTime.Core.Dto
{
    public class UserViewDto : IDto<int>
    {
        public int Id { get; set; }

        public int PositionId { get; set; }

    }
}
