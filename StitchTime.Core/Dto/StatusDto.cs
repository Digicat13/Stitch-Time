﻿namespace StitchTime.Core.Dto
{
    public class StatusDto : IDto<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
